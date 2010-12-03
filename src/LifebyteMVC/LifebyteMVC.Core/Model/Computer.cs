using System;
using LifebyteMVC.Core.Interfaces;

namespace LifebyteMVC.Core.Model
{
    public class Computer : ICoreEntity
    {
        public virtual Guid Id { get; private set; }

        public virtual Recipient Recipient { get; set; }

        /// <summary>
        /// A number that is written on the back of the item. The format is LB0123. 
        /// Having this number helps us identify the computer.
        /// </summary>
        public virtual string LBNumber { get; set; }

        public virtual ComputerStatus ComputerStatus { get; set; }

        /// <summary>
        /// General notes about the computer. A detailed manifest is contained in the 
        /// Belarc HTML property.
        /// </summary>
        public virtual string Notes { get; set; }

        /// <summary>
        /// We use Belarc to create a manifest about a computer. 
        /// The manifest is HTML that includes processor, memory, etc.
        /// We need to be very careful displaying this information as it 
        /// could contain malicious code.
        /// </summary>
        /// <remarks>http://belarc.com/</remarks>
        public virtual string ManifestHtml { get; set; }

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
        /// As Microsoft Authorised Refurbishers, we need this for reporting 
        /// and license tracking purposes.
        /// </summary>    
        public virtual WindowsLicense WindowsLicense { get; set; }

        /// <summary>
        /// We do not delete from the website. We only set records to be inactive and 
        /// filter them out of search results.
        /// </summary>
        public virtual bool Active { get; set; }
    }
}
