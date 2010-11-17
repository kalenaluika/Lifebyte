using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifebyteMVC.Core
{
    public class LicenseType
    {
        /// <summary>
        /// The ID of the license status
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// The type of the license item
        /// </summary>
        public virtual string FullName { get; set; }

        /// <summary>
        /// A list of Windows licenses with a given type.
        /// </summary>
        public IList<WindowsLicense> WindowsLicenses { get; set; }

        public LicenseType()
        {
            WindowsLicenses = new List<WindowsLicense>();
        }
    }
}
