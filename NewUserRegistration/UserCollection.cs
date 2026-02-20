using System.Text.Json;
using BCrypt.Net;

namespace NewUserRegistration;

public class UserCollection
{
    
    public List<User> Users { get; set; } = new();
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
            Users = JsonSerializer.Deserialize<List<User>>(json) ?? new();
        }
    }

    
    public bool IsEmailUnique(string email)
    {
        foreach (var user in Users)
        {
            if (user.Email.ToLower() == email.ToLower())
            {
                return false;
            }
        }
        return true;
    }

   
    public void RegisterUser(string username, string email, string password)
    {
        User newUser = new User();
        newUser.Username = username;
        newUser.Email = email;
        
        
        newUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        
        Users.Add(newUser);
        Save();
    }
}
