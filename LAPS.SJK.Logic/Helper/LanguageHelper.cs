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
            //var liTagBuilder = new TagBuilder("li");
            //liTagBuilder.Attributes.Add("class", classAttribute);
            var aTagBuilder = new TagBuilder("a");
            aTagBuilder.AddCssClass("dropdown-item");
            var routeValueDictionary = new RouteValueDictionary(routeData.Values);

            //< a class="dropdown-item" href="#"><img src = "@Url.Content("~/Content/img/blank.gif")" class="flag flag-id" alt="Indonesia" /> ID</a>
            TagBuilder imgTagBuilder = new TagBuilder("img");



            if (name.ToLower() == "Indonesia".ToLower())
            {
                imgTagBuilder.InnerHtml = (" ID");
                imgTagBuilder.AddCssClass("flag flag-id");
            }
            else if (name.ToLower() == "English".ToLower())
            {
                imgTagBuilder.InnerHtml = (" EN");
                imgTagBuilder.AddCssClass("flag flag-us");

            }
            imgTagBuilder.Attributes.Add("alt", name);
            imgTagBuilder.MergeAttribute("src", "/Content/img/blank.gif");

            if (routeValueDictionary.ContainsKey("lang"))
            {
                //if (routeData.Values["lang"] as string == lang)
                //{
                //    liTagBuilder.AddCssClass("active");
                //}
                //else
                //{
                routeValueDictionary["lang"] = lang;
                //}
            }
            aTagBuilder.MergeAttribute("href", url.RouteUrl(routeValueDictionary));
            aTagBuilder.SetInnerText(name);
            // liTagBuilder.InnerHtml = aTagBuilder.ToString();


            //var culture = System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLowerInvariant();
            //var imgSrc = string.Format("/assets/images/flags/{0}.png", culture);
            //TagBuilder tag = new TagBuilder("img");
            //tag.AddCssClass("flag-lang");
            //tag.MergeAttribute("src", imgSrc);
            //return MvcHtmlString.Create(tag.ToString(TagRenderMode.SelfClosing));


            aTagBuilder.InnerHtml = (imgTagBuilder.ToString());
            return new MvcHtmlString(aTagBuilder.ToString());
        }
    }
}
