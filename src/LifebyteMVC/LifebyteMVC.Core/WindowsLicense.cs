using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifebyteMVC.Core
{
    public class WindowsLicense
    {
        public virtual string Id { get; private set; }

        public virtual LicenseType LicenseType { get; set; }

        /// <summary>
        /// (the date the license was reported to Microsoft)
        /// </summary>
        public virtual string ReportDate { get; set; }

        /// <summary>
        /// ( a code used for internal reporting. Example: 2009.12.21.36)
        /// </summary>
        public virtual string LocationID { get; set; }

    }
}
