using System.Web.Mvc;
using log4net;
using System.Reflection;

namespace Lifebyte.Web.Controllers
{
    /// <summary>
    /// The HomeController will hold the public facing pages.
    /// </summary>
    public class HomeController : Controller
    {
        // TODO Delete this!
        /// <summary>
        /// This is just a test of log4net.
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The Index is the home page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {            
            Log.Info("Hello World");
            return View();
        }
    }
}
