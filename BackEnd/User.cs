namespace BackEnd;

public class User
{
    public Guid ID { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    private string Password { get; set; }
    public string Address { get; set; }
    public Role AccountRole { get; set; }
    public Permissions AccountPermissions { get; set; }
    public User() { }
    public void Register(string email, string userName, string password, string address, Role accountRole, Permissions accountPermissions)
    {
        ID = Guid.NewGuid();
        Email = email;
        UserName = userName;
        Password = password;
        Address = address;
        AccountRole = accountRole;
        AccountPermissions = accountPermissions;
    }
    public void Login(string password)
    {
        if (password == Password)
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