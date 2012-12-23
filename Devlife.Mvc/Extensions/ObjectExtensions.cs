using System.Collections.Generic;
using System.Web.Routing;

namespace Devlife.Mvc
{
    public static class ObjectExtensions
    {
        public static IDictionary<string, object> ToDictionary(this object htmlAttributes)
        {
            var dictionary = new RouteValueDictionary(htmlAttributes);

            return dictionary;
        }
    }
}