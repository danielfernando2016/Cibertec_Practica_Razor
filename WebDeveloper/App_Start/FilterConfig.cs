
using System.Web.Mvc;

namespace WebDeveloper
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new Elmah.Contrib.Mvc.ElmahHandleErrorAttribute());
        }
    }
}
