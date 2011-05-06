namespace Lifebyte.Web.Models.Core.Interfaces
{
    public interface IFormsAuthenticationService
    {
        void SetAuthCookie(string userName, bool createPersistentCookie);

        void SignOut();
    }
}