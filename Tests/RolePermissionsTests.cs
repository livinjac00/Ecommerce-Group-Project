using BackEnd;

namespace Tests;

public class RolePermissionsTests
{
    [Fact]
    public void AdminRolePermissions()
    {
        var role = Role.Admin;

        var permissions = RolePermissions.GetPermissionsForRole(role).ToList();

        Assert.Contains(Permissions.EditCategories, permissions);
        Assert.Contains(Permissions.EditProducts, permissions);
        Assert.Contains(Permissions.EditUsers, permissions);
        Assert.NotEmpty(permissions);
    }

    [Fact]
    public void UserRolePermissions()
    {
        var role = Role.User;

        var permissions = RolePermissions.GetPermissionsForRole(role).ToList();

        Assert.DoesNotContain(Permissions.EditCategories, permissions);
        Assert.Empty(permissions);
    }
}
