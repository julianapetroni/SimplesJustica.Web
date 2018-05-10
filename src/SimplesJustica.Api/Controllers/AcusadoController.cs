using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SimplesJustica.Application.Interfaces;
using SimplesJustica.Application.Models;

namespace SimplesJustica.Api.Controllers
{
    public class AcusadoController : ApiController
    {
        private readonly IAcusadoAppService app;

        public AcusadoController(IAcusadoAppService app)
        {
            this.app = app;
        }

        public async Task<IHttpActionResult> Get()
        {
            return Ok(await app.List());
        }

        [ResponseType(typeof(AcusadoModel))]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            AcusadoModel acusado = await app.Get(id);
            if (acusado == null)
            {
                return NotFound();
            }

            return Ok(acusado);
        }

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Put(Guid id, AcusadoModel acusado)
        {
            if (!ModelState.IsValid)
            {
                //TODO criar um ActionFilter pra isso
                return BadRequest(ModelState);
            }

            if (id != acusado.Id)
            {
                return BadRequest();
            }

            await app.Update(acusado);
            if (!app.Response.Successful)
            {
                return StatusCode((HttpStatusCode)(int)(app.Response.StatusCode));
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(AcusadoModel))]
        public async Task<IHttpActionResult> Post(AcusadoModel acusado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await app.Add(acusado);

            if (!app.Response.Successful)
            {
                return StatusCode((HttpStatusCode)(int)(app.Response.StatusCode));
            }

            return CreatedAtRoute("DefaultApi", new { id = acusado.Id }, acusado);
        }

        [ResponseType(typeof(AcusadoModel))]
        public async Task<IHttpActionResult> DeleteAcusado(Guid id)
        {
            AcusadoModel acusado = await app.Get(id);
            if (acusado == null)
            {
                return NotFound();
            }

            app.Delete(acusado);

            return Ok(acusado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                app.Dispose();
            }
            base.Dispose(disposing);
        }
        
    }
}