namespace Devlife.Mvc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Routing;

    public static class ObjectExtensions
    {
        public static IDictionary<string, object> ToDictionary(this object htmlAttributes)
        {
            var dictionary = new RouteValueDictionary(htmlAttributes);

            return dictionary;
        }
    }
}
