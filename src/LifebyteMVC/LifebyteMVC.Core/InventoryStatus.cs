using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifebyteMVC.Core
{
    public class InventoryStatus
    {
        /// <summary>
        /// The ID of the inventory status
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The status of the inventory item
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The description of the status
        /// </summary>
        public string Description { get; set; }
    }
}
