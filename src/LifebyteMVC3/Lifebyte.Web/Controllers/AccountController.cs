using System.Web.Mvc;
using Lifebyte.Web.Models.ViewModels;
using System.Web.Security;

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
            if (ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
                return Redirect(returnUrl);
            }

            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return View();
        }
    }
}