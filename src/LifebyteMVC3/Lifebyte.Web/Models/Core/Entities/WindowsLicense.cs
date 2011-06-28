using System;
using System.ComponentModel.DataAnnotations;
using Lifebyte.Web.Models.Core.Interfaces;

namespace Lifebyte.Web.Models.Core.Entities
{
    public class WindowsLicense : ICoreEntity
    {
        public virtual string Id { get; set; }

        public virtual string LicenseType { get; set; }

        public virtual bool Installed { get; set; }

        [ScaffoldColumn(false)]
        public virtual Volunteer CreateByVolunteer { get; set; }

        [ScaffoldColumn(false)]
        public virtual DateTime CreateDate { get; set; }
    }
}