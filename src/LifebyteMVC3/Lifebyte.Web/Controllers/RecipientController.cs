using System.Web.Mvc;
using Lifebyte.Web.Models.Core.Entities;

namespace Lifebyte.Web.Controllers
{
    public class RecipientController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View(new Recipient());
        }
    }
}