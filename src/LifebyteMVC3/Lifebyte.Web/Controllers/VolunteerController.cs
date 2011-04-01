using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Lifebyte.Web.Controllers
{
    public class VolunteerController: Controller
    {
        /// <summary>
        /// This page is for coordinating volunteer efforts
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
