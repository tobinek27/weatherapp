using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WeatherApp
{
    partial class DashboardForm
    {
        private IContainer components = null;
        private Label lblWelcome;
        private Button btnLogout;
        private Button btnFetchWeather;
        private RichTextBox weatherInfoBox;
        private Button btnSaveConfig;
        private Button btnLoadConfig;
        private TextBox txtCity;
        private TextBox txtCountry;
        private TableLayoutPanel tableLayoutPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnFetchWeather = new System.Windows.Forms.Button();
            this.weatherInfoBox = new System.Windows.Forms.RichTextBox();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.btnLoadConfig = new System.Windows.Forms.Button();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "DashboardForm";

            this.lblWelcome.AutoSize = true;
            //this.lblWelcome.Text = "welcome to the dashboard, test!"; test nahradit username uzivatele
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.TextAlign = ContentAlignment.MiddleCenter;

            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            this.tableLayoutPanel.Dock = DockStyle.Fill;

            this.tableLayoutPanel.Controls.Add(this.lblWelcome, 0, 0);
            this.tableLayoutPanel.SetColumnSpan(this.lblWelcome, 3);
            this.tableLayoutPanel.Controls.Add(this.txtCountry, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.txtCity, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.btnFetchWeather, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.btnSaveConfig, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.btnLoadConfig, 2, 3);
            this.tableLayoutPanel.Controls.Add(this.weatherInfoBox, 0, 4);
            this.tableLayoutPanel.SetColumnSpan(this.weatherInfoBox, 3);
            this.tableLayoutPanel.Controls.Add(this.btnLogout, 1, 5);

            // country input field
            this.txtCountry.Size = new System.Drawing.Size(200, 28);
            this.txtCountry.PlaceholderText = "Enter Country";

            // city input field
            this.txtCity.Size = new System.Drawing.Size(200, 28);
            this.txtCity.PlaceholderText = "Enter City";

            // fetch weather button
            this.btnFetchWeather.Text = "Get Weather";
            this.btnFetchWeather.UseVisualStyleBackColor = true;
            this.btnFetchWeather.Click += new System.EventHandler(this.BtnFetchWeather_Click);

            // save config button
            this.btnSaveConfig.Text = "Save Config";
            this.btnSaveConfig.BackColor = Color.LightBlue;
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.BtnSaveConfig_Click);

            // load config button
            this.btnLoadConfig.Text = "Load Config";
            this.btnLoadConfig.UseVisualStyleBackColor = true;
            this.btnLoadConfig.Click += new System.EventHandler(this.BtnLoadConfig_Click);

            // fetched weather info
            this.weatherInfoBox.ReadOnly = true;
            this.weatherInfoBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.weatherInfoBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            this.weatherInfoBox.Dock = DockStyle.Fill;

            // logout button
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);

            this.Controls.Add(this.tableLayoutPanel);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
