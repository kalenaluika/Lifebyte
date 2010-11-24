using System;
using System.Web.Mvc;

namespace LifebyteMVC.Web.Controllers
{
    public class RecipientsController : Controller
    {
        /// <summary>
        /// This view allows a volunteer to search for a recipient.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This view allows a volunteer to edit a recipient record.
        /// </summary>
        /// <param name="id">The recipient ID.</param>
        /// <returns></returns>
        public ActionResult Edit(Guid id)
        {
            return View();
        }
    }
}
