using System.Text.Json;
using BCrypt.Net;
using BackEnd;

namespace NewUserRegistration;

public class UserCollection
{
    public List<BackEnd.User> Users { get; set; } = new();
    private string fileName = "users.json";

    public void Save()
    {
        string json = JsonSerializer.Serialize(Users);
        File.WriteAllText(fileName, json);
    }

    public void Load()
    {
        if (File.Exists(fileName))
        {
            string json = File.ReadAllText(fileName);
            Users = JsonSerializer.Deserialize<List<BackEnd.User>>(json) ?? new();
        }
    }

    public bool IsEmailUnique(string email)
    {
        return !Users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    public void RegisterUser(string username, string email, string password)
    {
        var newUser = new BackEnd.User();
        newUser.Username = username;
        newUser.Email = email;
        
        // Hashing for security as per requirements
        newUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        
        // Default values for registration draft
        newUser.AccountRole = Role.User;
        newUser.AccountPermissions = 0;
        
        Users.Add(newUser);
        Save();
    }
}
