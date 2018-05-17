using System;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SimplesJustica.Application.Interfaces;
using SimplesJustica.Application.Models;

namespace SimplesJustica.Web.Controllers
{
    [Authorize]
    public class ReclamacaoController : Controller
    {
        private readonly IReclamacaoAppService app;
        private readonly IReuAppService reuApp;

        public ReclamacaoController(IReclamacaoAppService app, IReuAppService reu)
        {
            this.reuApp = reu;
            this.app = app;
        }

        public ActionResult Index()
        {
            var model = app.List(User.Identity.GetUserGuid());
            return View(model);
        }

        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReclamacaoModel reclamacaoModel = await app.Get(id.Value);
            if (reclamacaoModel == null)
            {
                return HttpNotFound();
            }
            return View(reclamacaoModel);
        }

        [AllowAnonymous]
        public async Task<ActionResult> Create()
        {
            var listaReus = await reuApp.List();
            var model = new RegistrarReclamacaoViewModel
            {
                Reus = listaReus
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegistrarReclamacaoViewModel reclamacaoModel)
        {
            if (ModelState.IsValid)
            {
                await app.Add(reclamacaoModel, User.Identity.GetUserGuid());
                return RedirectToAction("Index");
            }

            return View(reclamacaoModel);
        }

        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var reclamacaoModel = await app.GetForUpdate(id.Value);
            if (reclamacaoModel == null)
            {
                return HttpNotFound();
            }
            return View(reclamacaoModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ReclamacaoUpdateViewModel reclamacaoModel)
        {
            if (ModelState.IsValid)
            {
                await app.Update(reclamacaoModel);
                return RedirectToAction("Index");
            }
            return View(reclamacaoModel);
        }

        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReclamacaoModel reclamacaoModel = await app.Get(id.Value);
            if (reclamacaoModel == null)
            {
                return HttpNotFound();
            }
            return View(reclamacaoModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ReclamacaoModel reclamacaoModel = await app.Get(id);
            app.Delete(reclamacaoModel);
            return RedirectToAction("Index");
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
