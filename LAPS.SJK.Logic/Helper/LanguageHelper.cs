using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LAPS.SJK.Logic.Helper
{

    //public static class CustomHelpers
    //{


    //    public static IHtmlString File(this HtmlHelper helper, string id)
    //    {
    //        TagBuilder tb = new TagBuilder("input");
    //        tb.Attributes.Add("type", "file");
    //        tb.Attributes.Add("id", id);
    //        return new MvcHtmlString(tb.ToString());
    //    }
    //}

    public static class LanguageHelper
    {

        public static MvcHtmlString LangSwitcher(this UrlHelper url, string name, RouteData routeData, string lang)
        {
            var liTagBuilder = new TagBuilder("li");
            //liTagBuilder.Attributes.Add("class", classAttribute);
            var aTagBuilder = new TagBuilder("a");
            var routeValueDictionary = new RouteValueDictionary(routeData.Values);
            if (routeValueDictionary.ContainsKey("lang"))
            {
                if (routeData.Values["lang"] as string == lang)
                {
                    liTagBuilder.AddCssClass("active");
                }
                else
                {
                    routeValueDictionary["lang"] = lang;
                }
            }
            aTagBuilder.MergeAttribute("href", url.RouteUrl(routeValueDictionary));
            aTagBuilder.SetInnerText(name);
            liTagBuilder.InnerHtml = aTagBuilder.ToString();
            return new MvcHtmlString(liTagBuilder.ToString());
        }
    }
}
