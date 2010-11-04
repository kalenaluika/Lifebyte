using System;
using System.Web.Mvc;

namespace LifebyteMVC.Web.Controllers
{
    public class RecipientsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(Guid id)
        {
            return View();
        }
    }
}
