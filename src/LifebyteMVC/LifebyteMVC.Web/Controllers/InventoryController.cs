using System;
using System.Web.Mvc;

namespace LifebyteMVC.Web.Controllers
{
    public class InventoryController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(Guid id)
        {
            return View();
        }

        public ActionResult Belarc(Guid id)
        {
            return View();
        }
    }
}
