using System.Web.Mvc;

namespace LifebyteMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// The homepage.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
