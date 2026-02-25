namespace BackEnd;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public Role AccountRole { get; set; } = Role.User;
    public Permissions AccountPermissions { get; set; }
    
    public User() { }

    private Dictionary<Guid, uint> cartItems = new Dictionary<Guid, uint>();
    
    public Dictionary<Guid, uint> GetShoppingCart()
    {
        return cartItems;
    }
    public void SetItemQuantity(Guid productId, uint quantity)
    {
        if (cartItems.ContainsKey(productId))
        {
            cartItems[productId] = quantity;
        }
        else
        {
            cartItems[productId] = quantity;
        }
    }
    public void AddToCart(Guid productId, uint quantity = 1)
    {
        if (cartItems.ContainsKey(productId))
        {
            cartItems[productId] += quantity;
        }
        else
        {
            cartItems[productId] = quantity;
        }
    }
    public void RemoveFromCart(Guid productId, uint quantity = 1)
    {
        if (cartItems.ContainsKey(productId))
        {
            if (cartItems[productId] > quantity)
            {
                cartItems[productId] -= quantity;
            }
            else
            {
                cartItems.Remove(productId);
            }
        }
    }
    public void DeleteCartItem(Guid productId)
    {
        cartItems.Remove(productId);
    }

    public void Register(string email, string username, string passwordHash, string address, Role accountRole, Permissions accountPermissions)
    {
        Id = Guid.NewGuid();
        Email = email;
        Username = username;
        PasswordHash = passwordHash;
        Address = address;
        AccountRole = accountRole;
        AccountPermissions = accountPermissions;
    }
    
    public void Login(string password)
    {
        // Simple draft verification
        if (BCrypt.Net.BCrypt.Verify(password, PasswordHash))
        {
            Console.WriteLine("Login successful.");
        }
        else
        {
            Console.WriteLine("Login failed.");
        }
    }
    
    public void Update()
    {
        //
    }

}
