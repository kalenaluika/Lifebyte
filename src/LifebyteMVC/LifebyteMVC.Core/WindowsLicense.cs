
namespace LifebyteMVC.Core
{
    public class WindowsLicense
    {
        public virtual string Id { get; private set; }

        public virtual LicenseType LicenseType { get; set; }

        /// <summary>
        /// The date the license was reported to Microsoft.
        /// </summary>
        public virtual string ReportDate { get; set; }

        /// <summary>
        /// A code used for internal reporting.
        /// </summary>
        /// <example>2009.12.21.36</example>
        public virtual string LocationID { get; set; }

        /// <summary>
        /// We do not delete from the website. We only set records to be inactive and 
        /// filter them out of search results.
        /// </summary>
        public virtual bool Active { get; set; }
    }
}
