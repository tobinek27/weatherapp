using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        private const string UserFilePath = "userlogins.json";

        public Form1()
        {
            InitializeComponent();
            InitializeUserFile();
        }

        private void InitializeUserFile()
        {
            if (!File.Exists(UserFilePath))
            {
                var emptyUserList = new List<User>();
                User.SaveUsers(emptyUserList);
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var users = User.LoadUsers();

            if (users.Exists(u => u.Username == username))
            {
                MessageBox.Show("This username is already registered. Please choose another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var hashedPassword = User.HashPassword(password);
            users.Add(new User { Username = username, PasswordHash = hashedPassword });
            User.SaveUsers(users);

            MessageBox.Show("Registration successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }
        
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password can't be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var users = User.LoadUsers();
            var user = users.Find(u => u.Username == username);

            if (user == null || !User.VerifyPassword(password, user.PasswordHash))
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            user.LoggedIn = true;
            MessageBox.Show($"Login successful! Welcome back {user.Username}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // open the second app window
            DashboardForm dashboard = new DashboardForm(user);
            dashboard.Show();
            this.Hide();
        }
        
        private void BtnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
