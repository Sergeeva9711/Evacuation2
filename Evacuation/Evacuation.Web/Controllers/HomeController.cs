using System.Web.Mvc;


namespace Evacuation.Web.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Partial()
        {            
            return PartialView();
        }
    }
}