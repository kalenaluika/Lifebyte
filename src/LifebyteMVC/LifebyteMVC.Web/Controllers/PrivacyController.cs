using System.Web.Mvc;

namespace LifebyteMVC.Web.Controllers
{
    public class PrivacyController : Controller
    {
        /// <summary>
        /// This view displays our privacy policy.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
