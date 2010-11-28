using System;
using System.Web.Mvc;
using LifebyteMVC.Web.Models;

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
    }
}
