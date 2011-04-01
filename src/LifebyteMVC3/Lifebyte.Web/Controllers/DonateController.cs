using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Lifebyte.Web.Controllers
{
    public class DonateController : Controller
    {
        /// <summary>
        /// Page for Donating to lifebyte
        /// </summary>
        /// <returns></returns>
        public ActionResult index()
        {
            return View();
        }
    }
}
