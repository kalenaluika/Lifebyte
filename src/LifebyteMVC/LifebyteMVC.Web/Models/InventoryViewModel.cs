using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LifebyteMVC.Core;
using LifebyteMVC.Core.Model;

namespace LifebyteMVC.Web.Models
{
    public class ComputerViewModel
    {
        public Computer Computer { get; set; }

        public List<ComputerStatus> ComputerStatuses
        {
            get
            {
                return new List<ComputerStatus> 
                {
                    new ComputerStatus { Status ="Build", Description="the computer is being built", Id=1},
                    new ComputerStatus { Status ="Delivered", Description="the computer has been delivered", Id=2},
                    new ComputerStatus { Status ="Ready for Delivery", Description="the computer is ready for delivery", Id=3},
                    new ComputerStatus { Status ="Repair", Description="the computer is being repaired", Id=4}
                };
            }
        }
    }
}