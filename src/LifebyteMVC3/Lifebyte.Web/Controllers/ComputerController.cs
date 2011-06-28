using System;
using System.Web.Mvc;
using Lifebyte.Web.Models.Core.Entities;
using System.Collections.Generic;
using Lifebyte.Web.Models.Core.Interfaces;
using Lifebyte.Web.Models.Services;
using System.Linq;
using System.Text;

namespace Lifebyte.Web.Controllers
{
    /// <summary>
    /// This page is to define each computer available
    /// to be assigned to a recipient
    /// </summary>
    [Authorize]
    public class ComputerController : Controller
    {
        private readonly IDataService<Computer> computerDataService;


        public ComputerController (IDataService<Computer> computerDataService)
        {
            this.computerDataService = computerDataService;
        }

        public ActionResult Index()
        {
            var model = computerDataService.SelectAll(a => a.Active == true)
                .Select(c => new
                                 {
                                     c.Id,
                                     Status = null == null ? "--" : c.ComputerStatus.Name
                                     ,
                                     statid = null == null ? -1 : c.ComputerStatus.Id
                                     ,
                                     c.LifebyteNumber,
                                     LicenceType = null == null ? "" : c.LicenceType.FullName,
                                     c.License
                                 })
                .OrderBy(ob => ob.statid).ThenBy(tb => tb.LifebyteNumber).ToList();

            
            return View(model);
            
        }
    }
}
