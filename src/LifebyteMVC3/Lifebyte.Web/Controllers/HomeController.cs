using System.Web.Mvc;

namespace Lifebyte.Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// The Index is the home page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }
    }
}