using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.RelyingParty;
using LifebyteMVC.Web.Models;
using LifebyteMVC.Core;

// TODO Test this before release!
namespace LifebyteMVC.Web.Controllers
{
    /// <summary>
    /// We use Open ID as the way to authenticate a volunteer.
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// This view contains the fields needed to sign into the site.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(new SignInViewModel());
        }

        /// <summary>
        /// This is the post action to the index view.
        /// This action will validate the model and redirect to the Authenticate action result 
        /// passing in the query string parameters.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(SignInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return Redirect(string.Format("/Account/Authenticate/?returnUrl={0}&openIdUrl={1}",
                model.ReturnUrl, model.OpenIdUrl));
        }

        /// <summary>
        /// This is the post from the Index view.
        /// It is also the get request from the provider.
        /// </summary>
        /// <param name="returnUrl">The URL to return the volunteer to after a 
        /// successful sign in.</param>
        /// <returns></returns>
        public ActionResult Authenticate(string returnUrl, string openIdUrl)
        {
            var openid = new OpenIdRelyingParty();

            SignInViewModel model = new SignInViewModel
            {
                AuthenticationResponse = openid.GetResponse(),
                OpenIdUrl = openIdUrl,
                ReturnUrl = returnUrl ?? "/home/index",
            };

            if (model.AuthenticationResponse == null)
            {
                Identifier id;
                if (Identifier.TryParse(model.OpenIdUrl, out id))
                {
                    try
                    {
                        return openid.CreateRequest(model.OpenIdUrl)
                            .RedirectingResponse.AsActionResult();
                    }
                    catch (ProtocolException ex)
                    {
                        ModelState.AddModelError("ProtocolException", ex.Message);
                    }
                }
                else
                {
                    ModelState.AddModelError("OpenIdUrl", "Invalid Open ID URL");
                }
            }            

            if (ModelState.IsValid)
            {
                // The Authenticate method will add model state errors.
                var volunteer = model.Authenticate(ModelState);

                // Guard against an authenticated volunteer who is not in the database yet.
                if (volunteer == null && ModelState.IsValid)
                {   
                    return RedirectToAction("Index", "Profile");
                }
                else if (ModelState.IsValid)
                {
                    return Redirect(model.ReturnUrl);
                }
            }

            return View("Index", model);
        }

        /// <summary>
        /// Signs out the volunteer and redirects back to the home page.
        /// </summary>
        /// <returns></returns>
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}
