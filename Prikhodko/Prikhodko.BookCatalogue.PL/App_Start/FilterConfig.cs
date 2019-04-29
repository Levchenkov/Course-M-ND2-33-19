using System.Web;
using System.Web.Mvc;
using Prikhodko.BookCatalogue.PL.Filters.AuthentificationFilters;

namespace Prikhodko.BookCatalogue.PL.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
