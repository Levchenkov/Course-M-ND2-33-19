using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace Validation.Filters
{
    public class CultureFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var cultureCookie = filterContext.HttpContext.Request.Cookies["culture"];

            if (cultureCookie == null)
            {
                SetCulture("en");
            }
            else
            {
                SetCulture(cultureCookie.Value);
            }
        }

        private void SetCulture(string culture)
        {
            var cultureInfo = new CultureInfo(culture);

            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }
    }
}