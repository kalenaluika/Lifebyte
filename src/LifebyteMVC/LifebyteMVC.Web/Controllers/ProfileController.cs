using System.Web.Mvc;
using LifebyteMVC.Web.Models;
using LifebyteMVC.Data.Repositories;
using LifebyteMVC.Core;
using System;
using System.Web.Security;

namespace LifebyteMVC.Web.Controllers
{
    public class ProfileController : Controller
    {
        /// <summary>
        /// The index view allows the authenticated volunteer to 
        /// edit their profile.
        /// </summary>
        /// <returns></returns>
        
        public ActionResult Index()
        {
            return View(new ProfileViewModel());
        }

        [HttpPost]
        public ActionResult Index(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var volunteerRepository = new VolunteerRepository();
            var volunteer = new Volunteer();
            UpdateModel(volunteer);

            volunteer.LastSignInDate = DateTime.Now;
            volunteer.Active = true;
            //volunteer.Id = Guid.NewGuid();
            
            //var cookie = FormsAuthentication.GetAuthCookie("",false);

            //TODO:  get this to work
            //volunteer.ClaimedIdentifier = cookie.Values["Id"].ToString();
            volunteerRepository.Save(volunteer);
            return View(model);
            
        }
    }
}
