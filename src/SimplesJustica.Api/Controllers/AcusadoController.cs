using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SimplesJustica.Data.Context;
using SimplesJustica.Data.UnitOfWork;
using SimplesJustica.Domain.Entities;
using SimplesJustica.Domain.Interfaces.UnitOfWork;

namespace SimplesJustica.Api.Controllers
{
    public class AcusadoController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public AcusadoController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await unitOfWork.Acusados.Listar());
        }

        [ResponseType(typeof(Acusado))]
        public async Task<IHttpActionResult> GetAcusado(Guid id)
        {
            Acusado acusado = await unitOfWork.Acusados.Obter(id);
            if (acusado == null)
            {
                return NotFound();
            }

            return Ok(acusado);
        }

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAcusado(Guid id, Acusado acusado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != acusado.Id)
            {
                return BadRequest();
            }

            unitOfWork.Acusados.Atualizar(acusado);

            try
            {
                await unitOfWork.CommitAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcusadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(Acusado))]
        public async Task<IHttpActionResult> PostAcusado(Acusado acusado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unitOfWork.Acusados.Adicionar(acusado);

            try
            {
                await unitOfWork.CommitAsync();
            }
            catch (DbUpdateException)
            {
                if (AcusadoExists(acusado.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = acusado.Id }, acusado);
        }

        [ResponseType(typeof(Acusado))]
        public async Task<IHttpActionResult> DeleteAcusado(Guid id)
        {
            Acusado acusado = await unitOfWork.Acusados.Obter(id);
            if (acusado == null)
            {
                return NotFound();
            }

            unitOfWork.Acusados.Deletar(acusado);
            await unitOfWork.CommitAsync();

            return Ok(acusado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AcusadoExists(Guid id)
        {
            return unitOfWork.Acusados.Encontrar(e => e.Id == id).Any();
        }
    }
}