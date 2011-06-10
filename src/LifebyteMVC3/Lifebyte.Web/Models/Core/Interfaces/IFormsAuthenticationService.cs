namespace Lifebyte.Web.Models.Core.Interfaces
{
    public interface IFormsAuthenticationService
    {
        void SignOut();

        bool SignIn(string username, string password, bool createPersistentCookie);
    }
}