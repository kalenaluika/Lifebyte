using System.Web.Security;
using Lifebyte.Web.Models.Core.Interfaces;

namespace Lifebyte.Web.Models.Services
{
    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        private void SetAuthCookie(string username, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(username, createPersistentCookie);
        }

        public bool SignIn(string username, string password, bool createPersistentCookie)
        {
            SetAuthCookie(username, createPersistentCookie);
            return true;
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }        
    }
}
