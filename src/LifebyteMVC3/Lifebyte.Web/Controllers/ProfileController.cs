using System.Web.Mvc;

namespace Lifebyte.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        /// <summary>
        /// This page allows volunteers to view their profile.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}