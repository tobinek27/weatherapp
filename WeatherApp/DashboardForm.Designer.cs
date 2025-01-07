using System.ComponentModel;
using System.Windows.Forms;

namespace WeatherApp
{
    partial class DashboardForm
    {
        private IContainer components = null;
        private Label lblWelcome; // Welcome label
        private Button btnLogout; // Logout button
        private ComboBox cmbCountry; // Dropdown for country selection
        private Button btnFetchWeather; // Button to fetch weather
        private TextBox txtWeatherInfo; // Textbox to display weather info

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
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.btnFetchWeather = new System.Windows.Forms.Button();
            this.txtWeatherInfo = new System.Windows.Forms.TextBox();

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "DashboardForm";

            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(300, 50);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(200, 20);
            this.lblWelcome.TabIndex = 0;

            this.btnLogout.Location = new System.Drawing.Point(350, 400);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 40);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);

            this.cmbCountry.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCountry.Location = new System.Drawing.Point(300, 100);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(200, 28);
            this.cmbCountry.TabIndex = 2;

            this.btnFetchWeather.Location = new System.Drawing.Point(350, 150);
            this.btnFetchWeather.Name = "btnFetchWeather";
            this.btnFetchWeather.Size = new System.Drawing.Size(100, 30);
            this.btnFetchWeather.TabIndex = 3;
            this.btnFetchWeather.Text = "Get Weather";
            this.btnFetchWeather.UseVisualStyleBackColor = true;
            this.btnFetchWeather.Click += new System.EventHandler(this.BtnFetchWeather_Click);

            this.txtWeatherInfo.Location = new System.Drawing.Point(150, 200);
            this.txtWeatherInfo.Multiline = true;
            this.txtWeatherInfo.Name = "txtWeatherInfo";
            this.txtWeatherInfo.ReadOnly = true;
            this.txtWeatherInfo.ScrollBars = ScrollBars.Vertical;
            this.txtWeatherInfo.Size = new System.Drawing.Size(500, 150);
            this.txtWeatherInfo.TabIndex = 4;

            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.cmbCountry);
            this.Controls.Add(this.btnFetchWeather);
            this.Controls.Add(this.txtWeatherInfo);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
