using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WeatherApp
{
    public partial class DashboardForm : Form
    {
        private readonly User _user;
        // file path je WeatherApp/user_configs/<username>_config
        private string ConfigFilePath => Path.Combine("user_configs", $"{_user.Username}_config.xml");

        public DashboardForm(User user)
        {
            InitializeComponent();
            _user = user;
            lblWelcome.Text = $"Welcome to the dashboard, {user.Username}!";
            SetupCountryAutocomplete();
            LoadConfiguration();
        }
        
        private void SetupCountryAutocomplete()
        {
            var countries = new[] { "Czechia", "USA", "Canada", "Germany", "France", "Spain", "India", "Japan" };
            var autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(countries);

            txtCountry.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCountry.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCountry.AutoCompleteCustomSource = autoComplete;
        }

        private async void BtnFetchWeather_Click(object sender, EventArgs e)
        {
            string enteredCountry = txtCountry.Text.Trim();
            string enteredCity = txtCity.Text.Trim();

            if (string.IsNullOrWhiteSpace(enteredCountry) && string.IsNullOrWhiteSpace(enteredCity))
            {
                MessageBox.Show("Please enter a city or a country.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string location = string.IsNullOrWhiteSpace(enteredCity) ? enteredCountry : 
                string.IsNullOrWhiteSpace(enteredCountry) ? enteredCity : 
                $"{enteredCity}, {enteredCountry}";

            btnFetchWeather.Text = "Fetching...";
            btnFetchWeather.Enabled = false;
            rtbWeatherInfo.Text = "Fetching weather... Please wait.";

            try
            {
                string weatherData = await FetchWeatherAsync(location);
                string formattedData = FormatWeatherData(location, weatherData);
                rtbWeatherInfo.Text = formattedData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching weather: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnFetchWeather.Text = "Get Weather";
                btnFetchWeather.Enabled = true;
            }
        }
        
        private async Task<string> FetchWeatherAsync(string location)
        {
            string apiUrl = $"https://wttr.in/{Uri.EscapeDataString(location)}?format=4";
            using HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to fetch weather data.");
            }

            return await response.Content.ReadAsStringAsync();
        }

        private string FormatWeatherData(string location, string weatherData)
        {
            try
            {
                string[] parts = weatherData.Split(new[] { ':' }, 2, StringSplitOptions.TrimEntries);
                if (parts.Length < 2) return "Invalid weather data received.";

                string[] details = parts[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string temperatureIcon = details.Length > 0 ? details[0] : "N/A";
                string temperatureNumber = details.Length > 1 ? details[1] : "N/A";
                string windSpeed = details.Length > 2 ? details[2].Replace("→", "").Trim() : "N/A";

                return $"Location: {location}\nTemperature: {temperatureNumber} {temperatureIcon}\nWind Speed: {windSpeed}";
            }
            catch
            {
                return "Error formatting weather data.";
            }
        }

        private void BtnSaveConfig_Click(object sender, EventArgs e)
        {
            string enteredCountry = txtCountry.Text.Trim();
            string enteredCity = txtCity.Text.Trim();
    
            if (string.IsNullOrWhiteSpace(enteredCountry) && string.IsNullOrWhiteSpace(enteredCity))
            {
                MessageBox.Show("Please enter a city or country to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string directoryPath = Path.GetDirectoryName(ConfigFilePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                var config = new XElement("Configuration",
                    new XElement("EnteredCountry", enteredCountry),
                    new XElement("EnteredCity", enteredCity)
                );

                config.Save(ConfigFilePath);

                MessageBox.Show("Configuration saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void LoadConfiguration()
        {
            if (!File.Exists(ConfigFilePath)) return;

            try
            {
                XElement config = XElement.Load(ConfigFilePath);
                string savedCountry = config.Element("EnteredCountry")?.Value;
                string savedCity = config.Element("EnteredCity")?.Value;

                if (!string.IsNullOrWhiteSpace(savedCountry))
                    txtCountry.Text = savedCountry;

                if (!string.IsNullOrWhiteSpace(savedCity))
                    txtCity.Text = savedCity;

                if (!string.IsNullOrWhiteSpace(savedCountry) || !string.IsNullOrWhiteSpace(savedCity))
                {
                    BtnFetchWeather_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }
    }
}
