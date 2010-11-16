using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifebyteMVC.Core
{
    public class WindowsLicense
    {
        public string ID { get; set; }

        public LicenseType LicenseType { get; set; }

        /// <summary>
        /// (the date the license was reported to Microsoft)
        /// </summary>
        public string ReportDate { get; set; }

        /// <summary>
        /// ( a code used for internal reporting. Example: 2009.12.21.36)
        /// </summary>
        public string LocationID { get; set; }

    }
}
