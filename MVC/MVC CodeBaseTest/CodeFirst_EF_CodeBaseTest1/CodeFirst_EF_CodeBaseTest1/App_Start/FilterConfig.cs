using System.Web;
using System.Web.Mvc;

namespace CodeFirst_EF_CodeBaseTest1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
