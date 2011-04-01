using System.Web.Mvc;

namespace Lifebyte.Web.Controllers
{
    public class VolunteerController: Controller
    {
        /// <summary>
        /// This page is for coordinating volunteer efforts
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
