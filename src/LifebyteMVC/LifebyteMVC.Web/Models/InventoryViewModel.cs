using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LifebyteMVC.Core;

namespace LifebyteMVC.Web.Models
{
    public class InventoryViewModel
    {
        public Inventory Inventory { get; set; }

        public List<InventoryStatus> InventoryStatuses
        {
            get
            {
                return new List<InventoryStatus> 
                {
                    new InventoryStatus { Status ="Build", Description="the computer is being built", ID=1},
                    new InventoryStatus { Status ="Delivered", Description="the computer has been delivered", ID=2},
                    new InventoryStatus { Status ="Ready for Delivery", Description="the computer is ready for delivery", ID=3},
                    new InventoryStatus { Status ="Repair", Description="the computer is being repaired", ID=4}
                };
            }
        }
    }
}