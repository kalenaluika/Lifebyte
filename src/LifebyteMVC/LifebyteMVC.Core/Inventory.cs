using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifebyteMVC.Core
{
    public public class Inventory
    {
        /// <summary>
        /// (uniquely identifies the inventory item)
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// (the recipient of the item)
        /// </summary>
        public Recipient Recipient { get; set; }

        /// <summary>
        /// (a number that is written on the back of the item. The format is LB0123. Having this number helps us identify the item)
        /// </summary>
        public string LBNumber { get; set; }

        /// <summary>
        /// (either build, delivered, ready for delivery, or repair)
        /// </summary>
        public InventoryStatus InventoryStatus { get; set; }

        /// <summary>
        /// (any text that the volunteer wishes to enter.)
        /// </summary>    
        public string Notes { get; set; }

        /// <summary>
        /// (we use Belarc to create a manifest of the PC. This is the URL link to the manifest)
        /// </summary>
        public string BelarcURL { get; set; }

        /// <summary>
        /// (we store the manifest in plain HTML along with the inventory item)
        /// </summary>
        public string BelarcHtml { get; set; }

        /// <summary>
        /// (the date the record was created)
        /// </summary>    
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// (the ID of the volunteer who created the record)
        /// </summary>
        public Volunteer CreateByVolunteer { get; set; }

        /// <summary>
        /// (the date the record was last modified)
        /// </summary>
        public DateTime LastModifiedDate { get; set; }

        /// <summary>
        /// (the ID of the volunteer who last modified the record)

        /// </summary>
        public Volunteer LastModifiedByVolunteer { get; set; }

        /// <summary>
        /// (the windows license key for the item. We need this for reporting and license tracking purposes.)
        /// </summary>    
        public WindowsLicense WindowsLicense { get; set; }

    }
}
