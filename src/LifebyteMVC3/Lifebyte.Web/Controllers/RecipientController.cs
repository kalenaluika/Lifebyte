using System;
using System.Web.Mvc;
using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Core.Interfaces;

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

        public ActionResult Index()
        {
            var model = recipientDataService.SelectAll(r => r.Active && r.RecipientStatus == "Needs Computer");

            return View(model);
        }

        public ActionResult Add()
        {
            var model = new Recipient
                            {
                                ContactDate = DateTime.Now,
                                RecipientStatus = "Needs Computer",
                                State = "CO",
                            };

            return View(model);
        }

        [HttpPost]
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