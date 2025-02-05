﻿namespace WeatherApp;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.TextBox txtUsername;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Button btnLogin;
    private System.Windows.Forms.Button btnRegister;
    private System.Windows.Forms.Label lblUsername;
    private System.Windows.Forms.Label lblPassword;
    private System.Windows.Forms.Label lblHeading;
    private System.Windows.Forms.PictureBox pictureBox;
    private System.Windows.Forms.Button btnQuit;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1350, 830);

        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.BackColor = Color.LightSteelBlue;

        // main menu left side image
        this.pictureBox = new System.Windows.Forms.PictureBox();
        this.pictureBox.Image = Image.FromFile("img/mainmenubg.jpg");
        this.pictureBox.Location = new System.Drawing.Point(0, 0);
        this.pictureBox.Size = new System.Drawing.Size(this.ClientSize.Width / 2, this.ClientSize.Height);
        this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

        // login/register menu screen
        this.lblHeading = new System.Windows.Forms.Label();
        this.lblHeading.Text = "WeatherApp - Login Menu";
        this.lblHeading.Font = new Font("Segoe UI", 18, FontStyle.Bold);
        this.lblHeading.ForeColor = Color.DarkSlateGray;
        this.lblHeading.Location = new System.Drawing.Point(this.ClientSize.Width / 2 + 50, 50);
        this.lblHeading.Size = new System.Drawing.Size(600, 50);

        // login/register menu username label
        this.lblUsername = new System.Windows.Forms.Label();
        this.lblUsername.Text = "Username:";
        this.lblUsername.Location = new System.Drawing.Point(this.ClientSize.Width / 2 + 50, 150);
        this.lblUsername.Size = new System.Drawing.Size(100, 30);
        this.lblUsername.Font = new Font("Segoe UI", 12);
        this.lblUsername.ForeColor = Color.Black;

        // login/register menu username input field
        this.txtUsername = new System.Windows.Forms.TextBox();
        this.txtUsername.Location = new System.Drawing.Point(this.ClientSize.Width / 2 + 150, 150);
        this.txtUsername.Size = new System.Drawing.Size(250, 30);
        this.txtUsername.Font = new Font("Segoe UI", 12);
        this.txtUsername.BorderStyle = BorderStyle.FixedSingle;
        this.txtUsername.BackColor = Color.White;

        // login/register menu password label
        this.lblPassword = new System.Windows.Forms.Label();
        this.lblPassword.Text = "Password:";
        this.lblPassword.Location = new System.Drawing.Point(this.ClientSize.Width / 2 + 50, 200);
        this.lblPassword.Size = new System.Drawing.Size(100, 30);
        this.lblPassword.Font = new Font("Segoe UI", 12);
        this.lblPassword.ForeColor = Color.Black;

        // login/register menu password input field
        this.txtPassword = new System.Windows.Forms.TextBox();
        this.txtPassword.Location = new System.Drawing.Point(this.ClientSize.Width / 2 + 150, 200);
        this.txtPassword.Size = new System.Drawing.Size(250, 30);
        this.txtPassword.Font = new Font("Segoe UI", 12);
        this.txtPassword.PasswordChar = '*';
        this.txtPassword.BorderStyle = BorderStyle.FixedSingle;
        this.txtPassword.BackColor = Color.White;

        // login/register menu login button
        this.btnLogin = new System.Windows.Forms.Button();
        this.btnLogin.Text = "Login";
        this.btnLogin.Location = new System.Drawing.Point(this.ClientSize.Width / 2 + 150, 250);
        this.btnLogin.Size = new System.Drawing.Size(120, 40);
        this.btnLogin.Font = new Font("Segoe UI", 12, FontStyle.Bold);
        this.btnLogin.BackColor = Color.CornflowerBlue;
        this.btnLogin.ForeColor = Color.White;
        this.btnLogin.FlatStyle = FlatStyle.Flat;
        this.btnLogin.FlatAppearance.BorderSize = 0;
        this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);

        // login/register menu register button
        this.btnRegister = new System.Windows.Forms.Button();
        this.btnRegister.Text = "Register";
        this.btnRegister.Location = new System.Drawing.Point(this.ClientSize.Width / 2 + 280, 250);
        this.btnRegister.Size = new System.Drawing.Size(120, 40);
        this.btnRegister.Font = new Font("Segoe UI", 12, FontStyle.Bold);
        this.btnRegister.BackColor = Color.MediumSeaGreen;
        this.btnRegister.ForeColor = Color.White;
        this.btnRegister.FlatStyle = FlatStyle.Flat;
        this.btnRegister.FlatAppearance.BorderSize = 0;
        this.btnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
        
        // login/register menu quit button
        this.btnQuit = new System.Windows.Forms.Button();
        this.btnQuit.Text = "Quit";
        this.btnQuit.Location = new System.Drawing.Point(this.ClientSize.Width / 2 + 150, 300);
        this.btnQuit.Size = new System.Drawing.Size(250, 40);
        this.btnQuit.Font = new Font("Segoe UI", 12, FontStyle.Bold);
        this.btnQuit.BackColor = Color.IndianRed;
        this.btnQuit.ForeColor = Color.White;
        this.btnQuit.FlatStyle = FlatStyle.Flat;
        this.btnQuit.FlatAppearance.BorderSize = 0;
        this.btnQuit.Click += new System.EventHandler(this.BtnQuit_Click);
        
        this.Controls.Add(this.pictureBox);
        this.Controls.Add(this.lblHeading);
        this.Controls.Add(this.lblUsername);
        this.Controls.Add(this.txtUsername);
        this.Controls.Add(this.lblPassword);
        this.Controls.Add(this.txtPassword);
        this.Controls.Add(this.btnLogin);
        this.Controls.Add(this.btnRegister);
        this.Controls.Add(this.btnQuit);

        this.Text = "WeatherApp - Login Menu";
    }
}
