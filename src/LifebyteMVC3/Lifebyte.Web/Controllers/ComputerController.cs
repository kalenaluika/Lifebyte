using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Core.Interfaces;
using System;

namespace Lifebyte.Web.Controllers
{
    /// <summary>
    /// This page is to define each computer available
    /// to be assigned to a recipient
    /// </summary>
    [Authorize]
    public class ComputerController : Controller
    {
        private readonly IDataService<Computer> computerDataService;
        private IFormsAuthenticationService formsAuthenticationService;
        private IDataService<WindowsLicense> windowsLicenseDataService;
        private IDataService<Recipient> recipientDataService;
        private IDataService<Volunteer> volunterDataService;

        public ComputerController(IDataService<Computer> computerDataService, 
            IFormsAuthenticationService formsAuthenticationService, 
            IDataService<Recipient> recipientDataService, 
            IDataService<WindowsLicense> windowsLicenseDataService, 
            IDataService<Volunteer> volunteerDataService)
        {
            this.computerDataService = computerDataService;
            this.formsAuthenticationService = formsAuthenticationService;
            this.recipientDataService = recipientDataService;
            this.windowsLicenseDataService = windowsLicenseDataService;
            this.volunterDataService = volunteerDataService;
        }

        public ActionResult Index()
        {
            List<Computer> model = computerDataService.SelectAll(a => a.Active)
                .Select(c => new Computer
                                 {
                                     Id = c.Id,
                                     ComputerStatus = c.ComputerStatus,
                                     LifebyteNumber = c.LifebyteNumber,
                                     LicenseType = c.LicenseType,
                                 })
                .OrderBy(c => c.ComputerStatus)
                .ThenBy(c => c.LifebyteNumber)
                .ToList();

            return View(model);
        }

        /// <summary>
        /// Adding a computer asks the volunteer to choose a license type.
        /// A new computer will be added and then the volunteer will redirect to 
        /// the edit page for the computer.
        /// We do this so that the computer has a license.
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View(new Computer());
        }

        [HttpPost]
        public ActionResult Add(Computer model)
        {
            // Only Windows machines require a license.
            if (!string.IsNullOrEmpty(model.LicenseType))
            {
                var license = windowsLicenseDataService.SelectOne(w => !w.Installed && w.LicenseType == model.LicenseType);
                if (license == null)
                {
                    ModelState.AddModelError("LicenseType", string.Format("Sorry, we are out of {0} licenses.", model.LicenseType));
                    return View(model);
                }
                model.WindowsLicense = license.Id;
            }

            var volunteer = volunterDataService.SelectOne(v => v.Id == formsAuthenticationService.GetVolunteerID(User));

            model.Active = true;
            model.ComputerStatus = "Build";
            model.CreateByVolunteer = volunteer;
            model.CreateDate = DateTime.Now;
            model.Id = Guid.NewGuid();
            model.LastModByVolunteer = volunteer;
            model.LastModDate = DateTime.Now;
            
            computerDataService.Insert(model, model.Id);

            return RedirectToAction("Edit", "Computer", new { id = model.Id });
        }

        public ActionResult Edit(Guid id)
        {
            var model = computerDataService.SelectOne(c => c.Id == id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Computer model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var volunteer = volunterDataService.SelectOne(v => v.Id == formsAuthenticationService.GetVolunteerID(User));
            var originalComputer = computerDataService.SelectOne(c => c.Id == model.Id);

            model.Active = originalComputer.Active;
            model.CreateByVolunteer = originalComputer.CreateByVolunteer;
            model.CreateDate = originalComputer.CreateDate;
            model.LastModByVolunteer = volunteer;
            model.LastModDate = DateTime.Now;
            
            // You cannot update the license.
            model.WindowsLicense = originalComputer.WindowsLicense;
            model.LicenseType = originalComputer.LicenseType;            

            computerDataService.Update(model);

            var windowsLicense = windowsLicenseDataService.SelectOne(w => w.Id == model.WindowsLicense);
            windowsLicense.Installed = true;
            
            windowsLicenseDataService.Update(windowsLicense);

            return RedirectToAction("Index");
        }
    }
}