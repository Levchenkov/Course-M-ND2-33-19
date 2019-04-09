using System.Web.Mvc.Filters;
using System.Web.Mvc;
using System.Web.Routing;

namespace Prikhodko.BookCatalogue.FrontEnd.Filters.AuthentificationFilters
{
    public class AuthenticateAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if(!filterContext.Principal.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
                    {"controller", "Account"},
                    {"action", "Login" },
                    {"returnUrl", filterContext.HttpContext.Request.RawUrl}
                });
            }
        }
    }
}