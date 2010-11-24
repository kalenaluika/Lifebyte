using System.Web.Mvc;

namespace LifebyteMVC.Web.Controllers
{
    public class VolunteerController : Controller
    {
        /// <summary>
        /// This view contains information about volunteering with us.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
