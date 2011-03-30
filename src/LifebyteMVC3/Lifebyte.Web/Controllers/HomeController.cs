using System.Web.Mvc;

namespace Lifebyte.Web.Controllers
{
    /// <summary>
    /// The HomeController will hold the public facing pages.
    /// </summary>
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
    }
}
