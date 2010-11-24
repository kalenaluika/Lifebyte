using System.Web.Mvc;

namespace LifebyteMVC.Web.Controllers
{
    public class RequestController : Controller
    {
        /// <summary>
        /// This view allows a recipient to request a computer from us.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
