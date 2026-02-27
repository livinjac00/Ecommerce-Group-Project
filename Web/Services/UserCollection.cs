using System.Text.Json;
using BCrypt.Net;
using BackEnd;

namespace Web.Services;

public static class UserCollection
{
    public static List<User> Users { get; set; } = new();
    private static string fileName = "users.json";

    static UserCollection()
    {
        Load();
    }

    public static void Save()
    {
        string json = JsonSerializer.Serialize(Users);
        File.WriteAllText(fileName, json);
    }

    public static void Load()
    {
        if (File.Exists(fileName))
        {
            string json = File.ReadAllText(fileName);
            Users = JsonSerializer.Deserialize<List<BackEnd.User>>(json) ?? new();
        }
    }

    public static bool IsEmailUnique(string email)
    {
        return !Users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    public static void RegisterUser(string username, string email, string password)
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

    public static User GetByID(string ID)
    {
        Guid guid = Guid.Parse(ID);
        return Users.FirstOrDefault(u => u.Id == guid);
    }
}
