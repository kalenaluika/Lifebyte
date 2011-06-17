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

            var volunteer = volunteerDataService.FindOne(v => v.Username == model.Username);

            if (volunteer != null &&
                volunteer.Password == volunteerDataService.EncryptPassword(model.Password, volunteer.Id))
            {
                var name = string.Format("{0} {1}", volunteer.FirstName ?? "", volunteer.LastName ?? "");

                formsAuthenticationService.SetAuthCookie(name.Trim(), model.RememberMe);

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
        public ActionResult Register(Volunteer volunteer)
        {
            if (!ModelState.IsValid)
            {
                return View(volunteer);
            }

            volunteer.Active = true;
            volunteer.Id = Guid.NewGuid();
            volunteer.LastSignInDate = DateTime.Now;
            volunteer.Password = volunteerDataService.EncryptPassword(volunteer.Password, volunteer.Id);
            volunteer.CreateByVolunteerId = volunteer.Id;
            volunteer.CreateDate = DateTime.Now;
            volunteer.LastModByVolunteerId = volunteer.Id;
            volunteer.LastModDate = DateTime.Now;
            volunteerDataService.Save(volunteer, volunteer.Id);

            return new RedirectResult("Welcome");
        }
    }
}