using System.Web.Security;
using Lifebyte.Web.Models.Core.Interfaces;

namespace Lifebyte.Web.Models.Services
{
    public class FormsAuthenticationService : IFormsAuthenticationService
    {        
        public void SetAuthCookie(string username, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(username, createPersistentCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }        
    }
}
