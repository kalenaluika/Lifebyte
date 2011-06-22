using System.Web.Mvc;
using Lifebyte.Web.Models.Core.Entities;

namespace Lifebyte.Web.Controllers
{
    /// <summary>
    /// This page is to define each computer available
    /// to be assigned to a recipient
    /// </summary>
    [Authorize]
    public class ComputerController : Controller
    {
        public ActionResult Index()
        {
            return View(new Computer());
        }
    }
}
