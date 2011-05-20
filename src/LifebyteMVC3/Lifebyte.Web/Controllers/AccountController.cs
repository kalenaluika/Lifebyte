using System.Web.Mvc;
using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Core.Interfaces;
using Lifebyte.Web.Models.ViewModels;

namespace Lifebyte.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IFormsAuthenticationService formsAuthenticationService;

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

        public ActionResult Register()
        {
            return View(new Volunteer());
        }

        [HttpPost]
        public ActionResult Register(Volunteer volunteer)
        {
            if (ModelState.IsValid) return new RedirectResult("Welcome");
            return View(volunteer);
        }
    }
}