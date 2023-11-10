using System.Web;
using System.Web.Mvc;

namespace DatabaseFirst_Customers_CodebaseTest
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
