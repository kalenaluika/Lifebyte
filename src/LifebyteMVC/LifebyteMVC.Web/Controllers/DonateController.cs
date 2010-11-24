using System.Web.Mvc;

namespace LifebyteMVC.Web.Controllers
{
    public class DonateController : Controller
    {
        /// <summary>
        /// This view contains information about donating to us.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
