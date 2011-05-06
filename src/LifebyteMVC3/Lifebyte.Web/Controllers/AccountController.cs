using System.Web.Mvc;
using Lifebyte.Web.Models.ViewModels;
using Lifebyte.Web.Models.Core.Interfaces;

namespace Lifebyte.Web.Controllers
{
    public class AccountController : Controller
    {
        private IFormsAuthenticationService formsAuthenticationService;

        public AccountController(IFormsAuthenticationService formsAuthenticationService)
        {
            this.formsAuthenticationService = formsAuthenticationService;
        }

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnViewModel model, string returnUrl)
        {
            returnUrl = returnUrl ?? "~/";

            if (ModelState.IsValid)
            {
                formsAuthenticationService.SetAuthCookie(model.Username, model.RememberMe);
                return Redirect(returnUrl);
            }

            return View();
        }

        public ActionResult LogOff()
        {
            formsAuthenticationService.SignOut();
            return View();
        }
    }
}