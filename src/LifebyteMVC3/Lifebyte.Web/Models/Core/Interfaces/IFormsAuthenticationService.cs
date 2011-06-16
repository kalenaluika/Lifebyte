namespace Lifebyte.Web.Models.Core.Interfaces
{
    public interface IFormsAuthenticationService
    {
        void SignOut();

        void SetAuthCookie(string username, bool createPersistentCookie);
    }
}