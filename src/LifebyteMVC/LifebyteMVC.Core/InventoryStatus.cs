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
        public virtual int Id { get; set; }

        /// <summary>
        /// The status of the inventory item
        /// </summary>
        public virtual string Status { get; set; }

        /// <summary>
        /// The description of the status
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// A list of inventory items with a given status.
        /// </summary>
        public IList<Inventory> InventoryItems { get; set; }

        public InventoryStatus()
        {
            InventoryItems = new List<Inventory>();
        }
    }
}
