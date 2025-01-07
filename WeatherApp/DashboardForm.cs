using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class DashboardForm : Form
    {
        private readonly User _user;

        public DashboardForm(User user)
        {
            InitializeComponent();
            _user = user;
            lblWelcome.Text = $"Welcome to the dashboard, {user.Username}!";
            PopulateCountries();
        }

        private void PopulateCountries()
        {
            var countries = new[] { "Czechia", "USA", "Canada", "Germany", "France", "Spain", "India", "Japan" };
            cmbCountry.Items.AddRange(countries);
            cmbCountry.SelectedIndex = 0;
        }

        private async void BtnFetchWeather_Click(object sender, EventArgs e)
        {
            string selectedCountry = cmbCountry.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(selectedCountry))
            {
                MessageBox.Show("Please select a country first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnFetchWeather.Text = "Fetching...";
            btnFetchWeather.Enabled = false;
            txtWeatherInfo.Text = "Please wait, fetching weather...";

            try
            {
                string weatherData = await FetchWeatherAsync(selectedCountry);
                txtWeatherInfo.Text = weatherData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching weather: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnFetchWeather.Text = "Get Weather";
                btnFetchWeather.Enabled = true;
            }
        }

        private async Task<string> FetchWeatherAsync(string country)
        {
            string apiUrl = $"https://wttr.in/{Uri.EscapeDataString(country)}?format=4";
            using HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to fetch weather data. Please try again later.");
            }

            return await response.Content.ReadAsStringAsync();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }
    }
}
