using System.ComponentModel;
using System.Windows.Forms;

namespace WeatherApp
{
    partial class DashboardForm
    {
        private IContainer components = null;
        private Label lblWelcome;
        private Button btnLogout;
        private ComboBox cmbCountry;
        private Button btnFetchWeather;
        private RichTextBox rtbWeatherInfo;
        private Button btnSaveConfig;
        private TextBox txtCity;
        private TextBox txtCountry;


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
            //this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.btnFetchWeather = new System.Windows.Forms.Button();
            this.rtbWeatherInfo = new System.Windows.Forms.RichTextBox();
            this.btnSaveConfig = new System.Windows.Forms.Button();

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "DashboardForm";

            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(300, 20);
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

            this.btnFetchWeather.Location = new System.Drawing.Point(350, 110);
            this.btnFetchWeather.Name = "btnFetchWeather";
            this.btnFetchWeather.Size = new System.Drawing.Size(100, 30);
            this.btnFetchWeather.TabIndex = 3;
            this.btnFetchWeather.Text = "Get Weather";
            this.btnFetchWeather.UseVisualStyleBackColor = true;
            this.btnFetchWeather.Click += new System.EventHandler(this.BtnFetchWeather_Click);

            this.rtbWeatherInfo = new System.Windows.Forms.RichTextBox();
            this.rtbWeatherInfo.Location = new System.Drawing.Point(150, 160);
            this.rtbWeatherInfo.Name = "rtbWeatherInfo";
            this.rtbWeatherInfo.ReadOnly = true;
            this.rtbWeatherInfo.Size = new System.Drawing.Size(500, 200);
            this.rtbWeatherInfo.TabIndex = 4;
            this.rtbWeatherInfo.Text = "";
            this.rtbWeatherInfo.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Regular);
            this.rtbWeatherInfo.ScrollBars = RichTextBoxScrollBars.Vertical;

            this.btnSaveConfig.Location = new System.Drawing.Point(350, 50);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(100, 30);
            this.btnSaveConfig.TabIndex = 5;
            this.btnSaveConfig.Text = "Save Config";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.BackColor = Color.LightBlue;
            this.btnSaveConfig.Click += new System.EventHandler(this.BtnSaveConfig_Click);

            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtCity.Location = new System.Drawing.Point(300, 140);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(200, 28);
            this.txtCity.TabIndex = 3;
            this.Controls.Add(this.txtCity);

            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtCountry.Location = new System.Drawing.Point(300, 100);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(200, 28);
            this.txtCountry.TabIndex = 2;
            this.Controls.Add(this.txtCountry);

            this.txtCity.Location = new System.Drawing.Point(300, 140);
            
            this.btnFetchWeather.Location = new System.Drawing.Point(350, 180);
            this.rtbWeatherInfo.Location = new System.Drawing.Point(150, 220);
            
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnLogout);
            //this.Controls.Add(this.cmbCountry);
            this.Controls.Add(this.btnFetchWeather);
            this.Controls.Add(this.rtbWeatherInfo);
            this.Controls.Add(this.btnSaveConfig);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
