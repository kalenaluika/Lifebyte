using System;
using System.Web.Mvc;
using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Core.Interfaces;

namespace Lifebyte.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IFormsAuthenticationService formsAuthenticationService;
        private readonly IDataService<Volunteer> volunteerDataService;
        private const string PasswordChars = "******";

        public ProfileController(IDataService<Volunteer> volunteerDataService,
                                 IFormsAuthenticationService formsAuthenticationService)
        {
            this.volunteerDataService = volunteerDataService;
            this.formsAuthenticationService = formsAuthenticationService;
        }

        /// <summary>
        /// This page allows volunteers to view their profile.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            Volunteer model = volunteerDataService.SelectOne(v => v.Id == formsAuthenticationService.GetVolunteerID(User));

            // Change password for display purposes.
            model.Password = PasswordChars;

            return View(model);
        }

        public ActionResult Edit()
        {
            Volunteer model = volunteerDataService.SelectOne(v => v.Id == formsAuthenticationService.GetVolunteerID(User));
            model.Password = PasswordChars;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Volunteer model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            Volunteer originalModel = volunteerDataService.SelectOne(v => v.Id == formsAuthenticationService.GetVolunteerID(User));
           
            model.Password = model.Password != PasswordChars 
                ? volunteerDataService.EncryptPassword(model.Password, originalModel.Id) 
                : originalModel.Password;

            model.LastSignInDate = DateTime.Now;
            model.CreateByVolunteerId = originalModel.CreateByVolunteerId;
            model.CreateDate = originalModel.CreateDate;
            model.LastModByVolunteerId = model.Id;
            model.LastModDate = DateTime.Now;
            model.Active = originalModel.Active;

            volunteerDataService.Update(model);

            return View("Index");
        }
    }
}