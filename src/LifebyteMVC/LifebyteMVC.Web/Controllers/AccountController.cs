using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace LifebyteMVC.Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LogOn()
        {
            return View();
        }

        public ActionResult Index()
        {
            return RedirectToAction("LogOn");
        }
    }
}
