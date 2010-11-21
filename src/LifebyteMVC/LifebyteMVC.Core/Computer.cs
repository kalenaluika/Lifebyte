using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifebyteMVC.Core
{    
    public class Computer
    {
        /// <summary>
        /// Uniquely identifies the computer
        /// </summary>
        
        public virtual Guid Id { get; private set; }

        /// <summary>
        /// The recipient of the computer
        /// </summary>
        public virtual Recipient Recipient { get; set; }

        /// <summary>
        /// A number that is written on the back of the item. The format is LB0123. Having this number helps us identify the item)
        /// </summary>
        public virtual string LBNumber { get; set; }

        /// <summary>
        /// The current status of the computer.
        /// </summary>
        public virtual ComputerStatus ComputerStatus { get; set; }

        /// <summary>
        /// Any text that the volunteer wishes to enter.
        /// </summary>    
        public virtual string Notes { get; set; }

        /// <summary>
        /// We use Belarc to create a manifest of the PC. 
        /// This is the URL link to the manifest.
        /// </summary>
        public virtual string BelarcURL { get; set; }

        /// <summary>
        /// We store the manifest in plain HTML along with the computer.
        /// </summary>
        public virtual string BelarcHtml { get; set; }

        /// <summary>
        /// The date the record was created.
        /// </summary>    
        public virtual DateTime CreateDate { get; set; }

        /// <summary>
        /// The volunteer who created the record.
        /// </summary>
        public virtual Volunteer CreateByVolunteer { get; set; }

        /// <summary>
        /// The date the record was last modified.
        /// </summary>
        public virtual DateTime LastModifiedDate { get; set; }

        /// <summary>
        /// The volunteer who last modified the record.
        /// </summary>
        public virtual Volunteer LastModifiedByVolunteer { get; set; }

        /// <summary>
        /// The Windows license key for the item. 
        /// We need this for reporting and license tracking purposes.
        /// </summary>    
        public virtual WindowsLicense WindowsLicense { get; set; }

    }
}
