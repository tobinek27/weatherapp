using System.ComponentModel;
using System.Windows.Forms;

namespace WeatherApp
{
    partial class DashboardForm
    {
        private IContainer components = null;
        private Label lblWelcome; // welcome label
        private Button btnLogout; // logout button

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

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "DashboardForm";

            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(300, 200);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(0, 17);
            this.lblWelcome.TabIndex = 0;

            this.btnLogout.Location = new System.Drawing.Point(350, 250);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 40);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);

            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnLogout);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
