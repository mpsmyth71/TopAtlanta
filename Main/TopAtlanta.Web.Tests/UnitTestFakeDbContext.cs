using Repository.Infrastructure.UnitTest;
using Rollins.OperationHierarchy.Entities;
using System;



namespace Rollins.OperationHierarchy.Tests.Fakes
{
    public class UnitTestFakeDbContext : FakeDbContext
    {
        public UnitTestFakeDbContext()
        {
            AddFakeDbSet<Login, LoginDbSet>();
            AddFakeDbSet<LoginRole, LoginRoleDbSet>();
            AddFakeDbSet<Role, RoleDbSet>();
            AddFakeDbSet<Permission, PermissionDbSet>();
            AddFakeDbSet<RolePermission, RolePermissionDbSet>();
            AddFakeDbSet<Entity, EntityDbSet>();
            AddFakeDbSet<Hierarchy, HierarchyDbSet>();
        }
    }
}
