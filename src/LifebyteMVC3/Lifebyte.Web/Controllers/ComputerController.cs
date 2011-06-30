using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Lifebyte.Web.Models.Core.Entities;
using Lifebyte.Web.Models.Core.Interfaces;

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
        private readonly IFormsAuthenticationService formsAuthenticationService;
        private readonly IDataService<Volunteer> volunterDataService;
        private readonly IDataService<WindowsLicense> windowsLicenseDataService;
        private IDataService<Recipient> recipientDataService;

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
            volunterDataService = volunteerDataService;
        }

        public ActionResult Index(string id)
        {
            const string blankLBNumber = "LB0000";
            int lbNumber;
            List<Computer> model;

            if (!string.IsNullOrWhiteSpace(id) && int.TryParse(id.ToUpper().Replace("LB",""), out lbNumber))
            {
                id = string.Format(blankLBNumber.Substring(0, blankLBNumber.Length - id.Length) + id);

                model = computerDataService.SelectAll(c => c.Active && c.LifebyteNumber == id)
                .OrderBy(c => c.ComputerStatus)
                .ThenBy(c => c.LifebyteNumber).ToList();

                return View(model);
            }

            if (!string.IsNullOrWhiteSpace(id))
            {
                model = computerDataService.SelectAll(c => c.Active && c.ComputerStatus == Server.HtmlDecode(id))
                    .OrderBy(c => c.ComputerStatus)
                    .ThenBy(c => c.LifebyteNumber).ToList();

                return View(model);
            }

            model = computerDataService.SelectAll(a => a.Active)
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
                WindowsLicense license =
                    windowsLicenseDataService.SelectOne(w => !w.Installed && w.LicenseType == model.LicenseType);
                if (license == null)
                {
                    ModelState.AddModelError("LicenseType",
                                             string.Format("Sorry, we are out of {0} licenses.", model.LicenseType));
                    return View(model);
                }
                model.WindowsLicense = license.Id;
            }

            Volunteer volunteer =
                volunterDataService.SelectOne(v => v.Id == formsAuthenticationService.GetVolunteerID(User));

            model.Active = true;
            model.ComputerStatus = "Build";
            model.CreateByVolunteer = volunteer;
            model.CreateDate = DateTime.Now;
            model.Id = Guid.NewGuid();
            model.LifebyteNumber = computerDataService.NextLbNumber();
            model.LastModByVolunteer = volunteer;
            model.LastModDate = DateTime.Now;

            computerDataService.Insert(model, model.Id);

            return RedirectToAction("Edit", "Computer", new {id = model.Id});
        }

        public ActionResult Edit(Guid id)
        {
            Computer model = computerDataService.SelectOne(c => c.Id == id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Computer model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Volunteer volunteer =
                volunterDataService.SelectOne(v => v.Id == formsAuthenticationService.GetVolunteerID(User));

            Computer originalComputer = computerDataService.SelectOne(c => c.Id == model.Id);

            model.Active = originalComputer.Active;
            model.CreateByVolunteer = originalComputer.CreateByVolunteer;
            model.CreateDate = originalComputer.CreateDate;
            model.LastModByVolunteer = volunteer;
            model.LastModDate = DateTime.Now;

            // You cannot update the license or the LB number.
            model.WindowsLicense = originalComputer.WindowsLicense;
            model.LicenseType = originalComputer.LicenseType;
            model.LifebyteNumber = originalComputer.LifebyteNumber;

            computerDataService.Update(model);

            WindowsLicense windowsLicense = windowsLicenseDataService.SelectOne(w => w.Id == model.WindowsLicense);
            windowsLicense.Installed = true;

            windowsLicenseDataService.Update(windowsLicense);

            return RedirectToAction("Index");
        }
    }
}