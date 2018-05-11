using System.Web.Mvc;

namespace SimplesJustica.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return Content("SimplesJutiça Api");
        }
    }
}
