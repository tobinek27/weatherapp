namespace WeatherApp
{
    public partial class DashboardForm : Form
    {
        public DashboardForm(User user)
        {
            InitializeComponent();
            lblWelcome.Text = $"Welcome to the dashboard, {user.Username}!";
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }
    }
}