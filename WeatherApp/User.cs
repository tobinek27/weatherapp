namespace WeatherApp;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

public class User
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public bool LoggedIn { get; set; }

    /// <summary>
    /// Initializes the user login file by creating an empty JSON file if it does not exist.
    /// </summary>
    public static void InitializeUserFile()
    {
        if (!File.Exists("userlogins.json"))
        {
            var emptyUserList = new List<User>();
            SaveUsers(emptyUserList);
        }
    }
    
    /// <summary>
    /// Returns the path to the user's configuration file.
    /// </summary>
    /// <returns>The full path of the user's configuration file.</returns>
    public string GetUserConfigFile()
    {
        string userConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "user_configs", $"{Username}_config.json");
        return userConfigPath;
    }
    
    /// <summary>
    /// Loads the list of users from the "userlogins.json" file.
    /// If the file does not exist, returns an empty user list.
    /// </summary>
    /// <returns>A list of users loaded from the JSON file.</returns>
    public static List<User> LoadUsers()
    {
        if (!File.Exists("userlogins.json"))
            return new List<User>();

        string jsonData = File.ReadAllText("userlogins.json");
        return JsonSerializer.Deserialize<List<User>>(jsonData) ?? new List<User>();
    }
    
    /// <summary>
    /// Saves the list of users to the "userlogins.json" file in JSON format.
    /// </summary>
    /// <param name="users">The list of users to save.</param>
    public static void SaveUsers(List<User> users)
    {
        string jsonData = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("userlogins.json", jsonData);
    }

    /// <summary>
    /// Hashes a plain-text password using the SHA-256 algorithm.
    /// </summary>
    /// <param name="password">The plain-text password to hash.</param>
    /// <returns>The hashed password as a Base64-encoded string.</returns>
    public static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hashBytes);
        }
    }

    /// <summary>
    /// Verifies a plain-text password against a stored hashed password.
    /// </summary>
    /// <param name="password">The plain-text password to verify.</param>
    /// <param name="storedPasswordHash">The stored hashed password for comparison.</param>
    /// <returns>True if the password matches the stored hash, false otherwise.</returns>
    public static bool VerifyPassword(string password, string storedPasswordHash)
    {
        string hashedPassword = HashPassword(password);
        return hashedPassword == storedPasswordHash;
    }

    // default constructor
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
