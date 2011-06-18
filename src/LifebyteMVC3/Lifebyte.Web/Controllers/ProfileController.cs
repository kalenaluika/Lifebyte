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
            Volunteer model = volunteerDataService.FindOne(v => v.Id == formsAuthenticationService.GetVolunteerID(User));
            return View(model);
        }
    }
}