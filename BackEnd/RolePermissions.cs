namespace BackEnd;

public static class RolePermissions
{
    public static IEnumerable<Permissions> GetPermissionsForRole(Role role)
    {
        return role switch
        {
            Role.Admin => new[] { Permissions.EditProducts, Permissions.EditCategories, Permissions.EditUsers },
            Role.Employee => new[] { Permissions.EditProducts, Permissions.EditCategories },
            Role.User => Array.Empty<Permissions>(),
            _ => Array.Empty<Permissions>()
        };
    }
} 