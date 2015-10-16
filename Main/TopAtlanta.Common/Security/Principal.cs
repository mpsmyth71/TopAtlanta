using System;
using System.Linq;
using System.Security.Principal;
using System.Threading;

namespace TopAtlanta.Common
{
    [Serializable]
    public class Principal : MarshalByRefObject, IPrincipal
    {
        public static Principal Current
        {
            get { return Thread.CurrentPrincipal as Principal; }
        }

        public static Principal GetUnauthorized()
        {
            return new Principal(TopAtlanta.Common.Identity.GetUnauthorized(), new string[0], new string[0]);
        }

        public Principal(Identity identity, string[] roles, string[] permissions)
        {
            this.Identity = identity;
            this.Roles = roles;
            this.Permissions = permissions;
        }

        protected string[] Roles { get; set; }
        protected string[] Permissions { get; set; }

        public IIdentity Identity { get; protected set; }
        public string RoleName { get; set; }

        public bool IsInRole(string role)
        {
            return this.Roles.Any(x => x == role);
        }

        public bool IsAuth(string permission)
        {
            // admins are authorized to do anything
            return this.IsInRole("SYSADM") || this.Permissions.Any(x => x == permission);
        }
    }
}
