using System.Web;
using System.Web.Mvc;

namespace TrainerSystem
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());//reforce the user to log in
            filters.Add(new RequireHttpsAttribute());//https
        }
    }
}
