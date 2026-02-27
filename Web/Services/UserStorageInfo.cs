using BackEnd;

namespace Web.Services;

public class UserStorageInfo
{
    public List<User> UserList { get; set; } = new();
    public List<Product> ShoppingCart { get; set; } = new();

    public User GetByID(string ID)
    {
        Guid guid = Guid.Parse(ID);
        return UserList.FirstOrDefault(u => u.Id == guid);
    }
}
