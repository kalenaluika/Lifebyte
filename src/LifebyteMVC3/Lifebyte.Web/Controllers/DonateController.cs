using System.Web.Mvc;

namespace Lifebyte.Web.Controllers
{
    public class DonateController : Controller
    {
        /// <summary>
        /// Page for Donating to lifebyte
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
