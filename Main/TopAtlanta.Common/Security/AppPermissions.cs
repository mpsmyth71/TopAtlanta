using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopAtlanta.Common
{
    public static class AppPermissions
    {
        // c = create, r = read, u = update, d = delete, m = manage (all)
        public const string HierarchyCreateUpdate = "HIER-CU";
        public const string HierarchyRead = "HIER-R";
        public const string RoleManage = "ROL-M";
        public const string UserManage = "USR-M";
    }
}
