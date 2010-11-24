using System;
using System.Web.Mvc;

namespace LifebyteMVC.Web.Controllers
{
    [Authorize]
    public class InventoryController : Controller
    {
        /// <summary>
        /// This view allows a volunteer to search for a computer.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This view allows a volunteer to edit a computer record.
        /// </summary>
        /// <param name="id">The computer ID.</param>
        /// <returns></returns>
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        /// <summary>
        /// We use Belarc to make a manifest of a computer.
        /// The manifest is HTML and includes information about the processor, 
        /// memory, etc.
        /// This HTML data cannot be trusted as it may contain malicious code.
        /// </summary>
        /// <param name="id">The computer ID.</param>
        /// <returns></returns>
        public ActionResult Manifest(Guid id)
        {
            return View();
        }
    }
}
