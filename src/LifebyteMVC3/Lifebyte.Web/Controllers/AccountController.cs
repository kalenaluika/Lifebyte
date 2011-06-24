using System;
using System.Web.Mvc;
using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Core.Interfaces;
using Lifebyte.Web.Models.ViewModels;

namespace Lifebyte.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IFormsAuthenticationService formsAuthenticationService;
        private readonly IDataService<Volunteer> volunteerDataService;

        /// <summary>
        /// Creates a new instance of the AccountController. This controller is 
        /// responsible for administrating Volunteers such as logging in, registering, 
        /// and logging out.
        /// </summary>
        /// <param name="formsAuthenticationService">This service authenticates the volunteer.</param>
        /// <param name="volunteerDataService">This service handles volunteer database functions.</param>
        public AccountController(IFormsAuthenticationService formsAuthenticationService,
                                 IDataService<Volunteer> volunteerDataService)
        {
            this.formsAuthenticationService = formsAuthenticationService;
            this.volunteerDataService = volunteerDataService;
        }

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var volunteer = volunteerDataService.SelectOne(v => v.Username == model.Username);

            if (volunteer != null &&
                volunteer.Password == volunteerDataService.HashPassword(model.Password, volunteer.Id))
            {        
                formsAuthenticationService.SetAuthCookie(volunteer, model.RememberMe);

                return Redirect(returnUrl ?? "~/");
            }

            ModelState.AddModelError("Username", "Invalid username or password.");
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
        public ActionResult Register(Volunteer model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Active = true;
            model.Id = Guid.NewGuid();
            model.LastSignInDate = DateTime.Now;
            model.Password = volunteerDataService.HashPassword(model.Password, model.Id);
            model.CreateByVolunteerId = model.Id;
            model.CreateDate = DateTime.Now;
            model.LastModByVolunteerId = model.Id;
            model.LastModDate = DateTime.Now;

            volunteerDataService.Insert(model, model.Id);

            formsAuthenticationService.SetAuthCookie(model, false);

            return new RedirectResult("Welcome");
        }
    }
}