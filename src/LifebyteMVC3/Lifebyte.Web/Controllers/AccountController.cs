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

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(SignInViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var volunteer = volunteerDataService.SelectOne(v => v.Username == model.Username);

            if (volunteer != null && !volunteer.Active)
            {
                ModelState.AddModelError("Username",
                                         "You account is inactive. Please contact us to activate your account.");
                return View();
            }

            if (volunteer != null &&
                volunteer.Password == volunteerDataService.HashPassword(model.Password, volunteer.Id))
            {
                formsAuthenticationService.SetAuthCookie(volunteer, model.RememberMe);

                return Redirect(returnUrl ?? "~/");
            }

            ModelState.AddModelError("Username", "Invalid username or password.");
            return View();
        }

        public ActionResult SignOff()
        {
            formsAuthenticationService.SignOut();
            return RedirectToAction("SignIn");
        }

        public ActionResult Register()
        {
            return View(new Volunteer());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Volunteer model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var existingVolunteer = volunteerDataService.SelectOne(v => v.Username == model.Username);
            if (existingVolunteer != null)
            {
                ModelState.AddModelError("Username", "That username already exists.");
                return View();
            }

            // Initially the account is inactive. An administrator has to activate the account in order
            // for the volunteer to access the site.
            // This is a HACK until we get role based authentication working.
            model.Active = false;

            model.Id = Guid.NewGuid();
            model.LastSignInDate = DateTime.Now;
            model.Password = volunteerDataService.HashPassword(model.Password, model.Id);
            model.CreateByVolunteerId = model.Id;
            model.CreateDate = DateTime.Now;
            model.LastModByVolunteerId = model.Id;
            model.LastModDate = DateTime.Now;

            volunteerDataService.Insert(model, model.Id);

            // Do not sign the new registration into the website until we have roles in place!
            // That will be explained in the Welcome page.

            return RedirectToAction("Welcome");
        }

        public ActionResult Welcome()
        {
            return View();
        }
    }
}