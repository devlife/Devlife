using System;
using System.Web.Mvc;

namespace Devlife.Mvc
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Script(this HtmlHelper helper, string fileName, string containingDirectory = "~/Scripts/")
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

            var scriptTab = new TagBuilder("script");
            scriptTab.Attributes["type"] = "text/javascript";

            string path = containingDirectory + fileName;

            scriptTab.Attributes["src"] = urlHelper.Content(path);

            return MvcHtmlString.Create(scriptTab.ToString());
        }

        public static MvcHtmlString StyleSheet(this HtmlHelper helper, string fileName, string containingDirectory = "~/Content/")
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

            var scriptTab = new TagBuilder("link");
            scriptTab.Attributes["rel"] = "stylesheet";
            scriptTab.Attributes["type"] = "text/css";
            scriptTab.Attributes["href"] = urlHelper.Content(containingDirectory + fileName);

            return MvcHtmlString.Create(scriptTab.ToString());
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string fileName, object htmlAttributes = null, string containingDirectory = "~/Content/")
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

            var imgTag = new TagBuilder("img");
            imgTag.Attributes["src"] = urlHelper.Content(containingDirectory + fileName);
            imgTag.MergeAttributes(htmlAttributes.ToDictionary());

            return MvcHtmlString.Create(imgTag.ToString());
        }
    }
}
