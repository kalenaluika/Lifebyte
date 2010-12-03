using System.Collections.Generic;
using LifebyteMVC.Core.Interfaces;

namespace LifebyteMVC.Core.Model
{
    public class LicenseType : ICoreEntity
    {
        public virtual int Id { get; set; }

        /// <summary>
        /// The type of license.
        /// </summary>
        /// <example>Windows XP</example>
        public virtual string FullName { get; set; }

        /// <summary>
        /// A list of Windows licenses with a given type.
        /// This is needed by the ORM to link to a Windows license.
        /// </summary>
        public virtual IList<WindowsLicense> WindowsLicenses { get; set; }

        public LicenseType()
        {
            WindowsLicenses = new List<WindowsLicense>();
        }
    }
}
