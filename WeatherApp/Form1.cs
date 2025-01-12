using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            User.InitializeUserFile();
        }

        /// <summary>
        /// Handles the registration process when the Register button is clicked.
        /// Validates the input, checks for existing usernames, and saves new user data.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password can't be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        
        /// <summary>
        /// Handles the login process when the Login button is clicked.
        /// Validates the input, checks user credentials, and opens the dashboard if login is successful.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
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
        
        /// <summary>
        /// Exits the application when the Quit button is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void BtnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
