namespace WeatherApp;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Label label1;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1350, 830);

        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;

        this.panel1 = new System.Windows.Forms.Panel();
        this.panel1.Location = new System.Drawing.Point(0, 0);
        this.panel1.Size = new System.Drawing.Size(675, 830);
        this.panel1.BackColor = Color.Fuchsia;

        this.panel2 = new System.Windows.Forms.Panel();
        this.panel2.Location = new System.Drawing.Point(675, 0);
        this.panel2.Size = new System.Drawing.Size(675, 130);
        this.panel2.BackColor = Color.Aqua;

        this.panel3 = new System.Windows.Forms.Panel();
        this.panel3.Location = new System.Drawing.Point(675, this.panel2.Height);
        this.panel3.Size = new System.Drawing.Size(675, this.ClientSize.Height - this.panel2.Height);
        this.panel3.BackColor = Color.DarkGray;

        this.label1 = new System.Windows.Forms.Label();
        this.label1.Text = "ahoj ahoj label 1";
        this.label1.BackColor = Color.Black;
        this.label1.ForeColor = Color.White;
        this.label1.Location = new System.Drawing.Point(50, 50);
        this.label1.Size = new System.Drawing.Size(200, 30);

        this.panel3.Controls.Add(this.label1);

        this.Controls.Add(this.panel1);
        this.Controls.Add(this.panel2);
        this.Controls.Add(this.panel3);

        this.Text = "Form1";
    }


    #endregion
}