namespace WeatherApp;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

public class User
{
    private const string UserFilePath = "userlogins.json";

    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public bool LoggedIn { get; set; }

    private static readonly List<User> users = new();
    private static readonly object lockObj = new();
    

    public static bool Register(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Username and password cannot be empty.");

        if (users.Any(u => u.Username == username))
            return false;

        string passwordHash = HashPassword(password);

        var newUser = new User { Username = username, PasswordHash = passwordHash };
        users.Add(newUser);

        SaveUsers();
        return true;
    }

    public static bool Login(string username, string password)
    {
        string passwordHash = HashPassword(password);

        return users.Any(u => u.Username == username && u.PasswordHash == passwordHash);
    }

    private static void LoadUsers()
    {
        lock (lockObj)
        {
            if (!File.Exists(UserFilePath))
            {
                File.WriteAllText(UserFilePath, JsonSerializer.Serialize(new List<User>()));
            }

            string jsonData = File.ReadAllText(UserFilePath);
            users.Clear();
            users.AddRange(JsonSerializer.Deserialize<List<User>>(jsonData) ?? new List<User>());
        }
    }

    private static void SaveUsers()
    {
        lock (lockObj)
        {
            string jsonData = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(UserFilePath, jsonData);
        }
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
    
    /*static User()
    {
        LoadUsers();
    }*/

    /*public User()
    {
        LoadUsers();
    }*/

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
