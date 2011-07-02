using System;
using System.Linq;
using System.Web.Mvc;
using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Core.Interfaces;
using System.Collections.Generic;

namespace Lifebyte.Web.Controllers
{
    public class RecipientController : Controller
    {
        private readonly IDataService<Recipient> recipientDataService;
        private readonly IFormsAuthenticationService formsAuthenticationService;
        private readonly IDataService<Volunteer> volunteerDataService;
        
        public RecipientController(IDataService<Recipient> recipientDataService, 
            IDataService<Volunteer> volunteerDataService, 
            IFormsAuthenticationService formsAuthenticationService)
        {
            this.recipientDataService = recipientDataService;
            this.volunteerDataService = volunteerDataService;
            this.formsAuthenticationService = formsAuthenticationService;
        }

        public ActionResult Index(string status, string fname, string lname)
        {
            List<Recipient> model;

            if (!string.IsNullOrWhiteSpace(fname)
                && !string.IsNullOrWhiteSpace(lname)
                && !string.IsNullOrWhiteSpace(status))
            {
                model = recipientDataService.SelectAll(r => r.Active
                    && r.FirstName == Server.UrlDecode(fname)
                    && r.LastName == Server.UrlDecode(lname)
                    && r.RecipientStatus == Server.UrlDecode(status))
                    .OrderBy(r => r.LastName)
                    .ThenBy(r => r.FirstName)
                    .ToList();

                return View(model);
            }

            if(!string.IsNullOrWhiteSpace(fname)
                && !string.IsNullOrWhiteSpace(lname))
            {
                model = recipientDataService.SelectAll(r => r.Active
                    && r.FirstName == Server.UrlDecode(fname)
                    && r.LastName == Server.UrlDecode(lname))
                    .OrderBy(r => r.LastName)
                    .ThenBy(r => r.FirstName)
                    .ToList();

                    return View(model);
            }

            if (!string.IsNullOrWhiteSpace(lname))
            {
                model = recipientDataService.SelectAll(r => r.Active
                    && r.LastName == Server.UrlDecode(lname))
                    .OrderBy(r => r.LastName)
                    .ThenBy(r => r.FirstName)
                    .ToList();

                return View(model);
            }

            if (!string.IsNullOrWhiteSpace(fname))
            {
                model = recipientDataService.SelectAll(r => r.Active
                    && r.FirstName == Server.UrlDecode(fname))
                    .OrderBy(r => r.LastName)
                    .ThenBy(r => r.FirstName)
                    .ToList();

                return View(model);
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                model = recipientDataService.SelectAll(r => r.Active 
                    && r.RecipientStatus == Server.UrlDecode(status))
                    .OrderBy(r => r.LastName)
                    .ThenBy(r => r.FirstName)
                    .ToList();

                    return View(model);
            }

            model = recipientDataService.SelectAll(r => r.Active 
                && r.RecipientStatus == "2")
                .OrderBy(r => r.LastName)
                .ThenBy(r => r.FirstName)
                .ToList();

            return View(model);
        }

        public ActionResult Add()
        {
            var model = new Recipient
                            {
                                ContactDate = DateTime.Now,
                                RecipientStatus = "2",
                                State = "CO",
                            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Recipient model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var volunteer = volunteerDataService.SelectOne(v => v.Id == formsAuthenticationService.GetVolunteerID(User));

            model.Active = true;
            model.CreateDate = DateTime.Now;
            model.CreatedByVolunteer = volunteer;
            model.Id = Guid.NewGuid();
            model.LastModifiedByVolunteer = volunteer;
            model.LastModifiedDate = DateTime.Now;

            recipientDataService.Insert(model, model.Id);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            var model = recipientDataService.SelectOne(r => r.Id == id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Recipient model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var originalRecipeint = recipientDataService.SelectOne(r => r.Id == model.Id);

            var volunteer = volunteerDataService.SelectOne(v => v.Id == formsAuthenticationService.GetVolunteerID(User));

            model.Active = originalRecipeint.Active;
            model.CreateDate = originalRecipeint.CreateDate;
            model.CreatedByVolunteer = originalRecipeint.CreatedByVolunteer;
            model.LastModifiedByVolunteer = volunteer;
            model.LastModifiedDate = DateTime.Now;

            recipientDataService.Update(model);

            return RedirectToAction("Index");
        }        
    }
}