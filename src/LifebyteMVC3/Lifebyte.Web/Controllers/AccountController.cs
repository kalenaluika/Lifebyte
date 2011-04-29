using System.Web.Mvc;
using Lifebyte.Web.Models.ViewModels;

namespace Lifebyte.Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnViewModel model, string returnUrl)
        {
            return Redirect(returnUrl);
        }
    }
}