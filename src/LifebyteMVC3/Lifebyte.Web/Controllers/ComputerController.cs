using System.Web.Mvc;

namespace Lifebyte.Web.Controllers
{
    /// <summary>
    /// This page is to define each computer available
    /// to be assigned to a recipient
    /// 
    /// </summary>
    public class ComputerController: Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
