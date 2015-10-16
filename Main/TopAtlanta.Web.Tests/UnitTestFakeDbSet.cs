using Repository.Infrastructure.UnitTest;
using Rollins.OperationHierarchy.Entities;
using System;
using System.Linq;

namespace Rollins.OperationHierarchy.Tests.Fakes
{

    public class LoginDbSet : FakeDbSet<Login>
    {
        public override Login Find(params object[] keyValues)
        {
            return this.SingleOrDefault(t => t.LoginId == (int)keyValues.FirstOrDefault());
        }

    }

    public class LoginRoleDbSet : FakeDbSet<LoginRole>
    {
        public override LoginRole Find(params object[] keyValues)
        {
            return this.SingleOrDefault(t => t.LoginId == (int)keyValues.FirstOrDefault());
        }

    }

    public class RoleDbSet : FakeDbSet<Role>
    {
        public override Role Find(params object[] keyValues)
        {
            return this.SingleOrDefault(t => t.RoleCode == (string)keyValues.FirstOrDefault());
        }

    }

    public class PermissionDbSet : FakeDbSet<Permission>
    {
        public override Permission Find(params object[] keyValues)
        {
            return this.SingleOrDefault(t => t.PermissionCode == (string)keyValues.FirstOrDefault());
        }

    }

    public class RolePermissionDbSet : FakeDbSet<RolePermission>
    {
        public override RolePermission Find(params object[] keyValues)
        {
            return this.SingleOrDefault(t => t.PermissionCode == (string)keyValues[0] && t.RoleCode == (string)keyValues[1]);
        }

    }

    public class EntityDbSet : FakeDbSet<Entity>
    {
        public override Entity Find(params object[] keyValues)
        {
            return this.SingleOrDefault(t => t.EntityId == (int)keyValues[0]);
        }

    }

    public class HierarchyDbSet : FakeDbSet<Hierarchy>
    {
        public override Hierarchy Find(params object[] keyValues)
        {
            return this.SingleOrDefault(t => t.HierarchyId == (int)keyValues[0]);
        }

    }

}
