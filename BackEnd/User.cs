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
