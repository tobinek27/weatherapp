namespace WeatherApp;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

public class User
{
    //private const string "userlogins.json" = "userlogins.json";

    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public bool LoggedIn { get; set; }

    private static readonly List<User> users = new();

    public static bool Login(string username, string password)
    {
        string passwordHash = HashPassword(password);
        return users.Any(u => u.Username == username && u.PasswordHash == passwordHash);
    }

    public string GetUserConfigFile()
    {
        return Path.Combine("user_configs", $"{Username}_config.xml");
    }
    
    public static List<User> LoadUsers()
    {
        if (!File.Exists("userlogins.json"))
            return new List<User>();

        string jsonData = File.ReadAllText("userlogins.json");
        return JsonSerializer.Deserialize<List<User>>(jsonData) ?? new List<User>();
    }
    
    public static void SaveUsers(List<User> users)
    {
        string jsonData = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("userlogins.json", jsonData);
    }

    public static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hashBytes);
        }
    }

    public static bool VerifyPassword(string password, string storedPasswordHash)
    {
        string hashedPassword = HashPassword(password);
        return hashedPassword == storedPasswordHash;
    }

    public User()
    {
    }
    
    public User(string username, string passwordHash)
    {
        Username = username;
        PasswordHash = passwordHash;
    }
    
    public User(string username, string passwordHash, bool loggedIn)
    {
        Username = username;
        PasswordHash = passwordHash;
        LoggedIn = loggedIn;
    }
}
