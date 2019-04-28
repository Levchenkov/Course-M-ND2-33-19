using System.Web;
using System.Web.Mvc;
using Validation.Filters;

namespace Validation
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CultureFilter());
        }
    }
}
