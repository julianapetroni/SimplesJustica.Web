using System;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using SimplesJustica.Application.Interfaces;
using SimplesJustica.Application.Models;

namespace SimplesJustica.Web.Controllers
{
    public class ReclamacaoController : Controller
    {
        private readonly IReclamacaoAppService app;

        public ReclamacaoController(IReclamacaoAppService app)
        {
            this.app = app;
        }

        public async Task<ActionResult> Index()
        {
            var model = await app.List();
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegistrarReclamacaoViewModel reclamacaoModel)
        {
            if (ModelState.IsValid)
            {
                await app.Add(reclamacaoModel);
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
            ReclamacaoModel reclamacaoModel = await app.Get(id.Value);
            if (reclamacaoModel == null)
            {
                return HttpNotFound();
            }
            return View(reclamacaoModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ReclamacaoModel reclamacaoModel)
        {
            if (ModelState.IsValid)
            {
                app.Update(reclamacaoModel);
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
