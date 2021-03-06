﻿using System;
using System.Web.Mvc;
using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Core.Interfaces;

namespace Lifebyte.Web.Controllers
{
    [Authorize]
    [RequireHttps]
    public class ProfileController : Controller
    {
        private const string PasswordChars = "******";
        private readonly IFormsAuthenticationService formsAuthenticationService;
        private readonly IDataService<Volunteer> volunteerDataService;

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
            Volunteer model =
                volunteerDataService.SelectOne(v => v.Id == formsAuthenticationService.GetVolunteerID(User));

            // Change password for display purposes.
            model.Password = PasswordChars;

            return View(model);
        }

        public ActionResult Edit()
        {
            Guid id = formsAuthenticationService.GetVolunteerID(User);
            Volunteer model = volunteerDataService.SelectOne(v => v.Id == id);
            model.Password = PasswordChars;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Volunteer model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Volunteer originalModel =
                volunteerDataService.SelectOne(v => v.Id == formsAuthenticationService.GetVolunteerID(User));

            model.Id = originalModel.Id;

            // This is a HACK. We should have a separate view to change a password, or a better method.
            model.Password = UpdatedPassword(model, originalModel);

            model.LastSignInDate = DateTime.Now;
            model.CreateByVolunteerId = originalModel.CreateByVolunteerId;
            model.CreateDate = originalModel.CreateDate;
            model.LastModByVolunteerId = originalModel.Id;
            model.LastModDate = DateTime.Now;
            model.Active = originalModel.Active;

            volunteerDataService.Update(model);

            return View("Index");
        }

        /// <summary>
        /// Checks to see if the volunteer updated their password on the form.
        /// </summary>
        /// <param name="model">The updated model.</param>
        /// <param name="originalModel">The original model.</param>
        /// <returns>The new hashed password or the original password.</returns>
        private string UpdatedPassword(Volunteer model, Volunteer originalModel)
        {
            return model.Password != PasswordChars
                       ? volunteerDataService.HashPassword(model.Password)
                       : originalModel.Password;
        }
    }
}