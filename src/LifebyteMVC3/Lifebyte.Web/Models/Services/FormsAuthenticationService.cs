using System.Web.Security;
using Lifebyte.Web.Models.Core.Interfaces;

namespace Lifebyte.Web.Models.Services
{
    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        public void SetAuthCookie(string userName, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}
