using System;
using Lifebyte.Web.Models.Core.Entities;
using System.Security.Principal;

namespace Lifebyte.Web.Models.Core.Interfaces
{
    public interface IFormsAuthenticationService
    {
        void SignOut();

        void SetAuthCookie(Volunteer volunteer, bool createPersistentCookie);

        Guid GetVolunteerID(IPrincipal user);
    }
}