using System.Web;
using System.Web.Mvc;
using LAPS.SJK.Logic.Attributes;

namespace LAPS.SJK.UI
{
    public class FilterConfig
    {    
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LocalizationAttribute("id"), 0);
            filters.Add(new HandleErrorAttribute());
        }
    }
}
