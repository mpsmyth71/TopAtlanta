using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace TopAtlanta.Common
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString Highlight(this HtmlHelper helper, string formField, string value)
        {
            var request = helper.ViewContext.HttpContext.Request;

            if (request.Form != null && request.Form.AllKeys.Any(x => x.ToLower() == formField.ToLower()) && value != null)
            {
                var search = request.Form[formField] ?? "";
                if (search.Length > 0 && value.ToLower().StartsWith(search.ToLower()))
                    return new MvcHtmlString("<strong>" + value.Substring(0, search.Length) + "</strong>" +
                        value.Substring(search.Length, value.Length - search.Length));
            }
            return new MvcHtmlString(value ?? "");
        }

        public static MvcHtmlString Highlight(this HtmlHelper helper, bool highlight, string value)
        {
            if (highlight)
            {
                return new MvcHtmlString("<strong>" + value + "</strong>");
            }
            return new MvcHtmlString(value);
        }
    }
}
