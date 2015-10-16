using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TopAtlanta.Common
{
    public class AuthorizePermission : AuthorizeAttribute
    {
        public string Permission { get; set; }

        public AuthorizePermission()
        {
        }

        public AuthorizePermission(string Permission)
        {
            this.Permission = Permission;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //check your permissions
            return Principal.Current.IsAuth(this.Permission);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                //ToDo:  Add Error Page for unauthorized
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Home", action = "Unauthorized" }));
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}
