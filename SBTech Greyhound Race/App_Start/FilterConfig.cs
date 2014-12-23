using System.Web;
using System.Web.Mvc;

namespace SBTech_Greyhound_Race
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
