using BackEnd;

namespace Web.Services;

public class UserStorageInfo
{
    public List<User> UserList { get; set; } = new();
    public List<Product> ShoppingCart { get; set; } = new();
}
