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
        private readonly User _activeUser;

        public DashboardForm(User user)
        {
            InitializeComponent();
            _activeUser = user;
            lblWelcome.Text = $"Welcome to the dashboard, {_activeUser.Username}!";

            SetupCountryAutocomplete();
        }
        
        /// <summary>
        /// Sets up the autocomplete feature for the country input field
        /// with a predefined list of countries.
        /// </summary>
        private void SetupCountryAutocomplete()
        {
            var countries = new[] { "Czechia", "USA", "Canada", "Germany", "France", "Spain", "India", "Japan"};
            var autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(countries);

            txtCountry.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCountry.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCountry.AutoCompleteCustomSource = autoComplete;
        }

        /// <summary>
        /// Handles the click event of the Fetch Weather button.
        /// Fetches and displays weather data for the entered location.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
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

            btnFetchWeather.Text = "fetching...";
            btnFetchWeather.Enabled = false;
            weatherInfoBox.Text = "fetching the weather... please wait";

            try
            {
                string weatherData = await FetchWeatherAsync(location);
                string formattedData = FormatWeatherData(location, weatherData);
                weatherInfoBox.Text = formattedData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error fetching weather: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnFetchWeather.Text = "Get Weather";
                btnFetchWeather.Enabled = true;
            }
        }
        
        /// <summary>
        /// Asynchronously fetches weather data for the specified location from the API.
        /// </summary>
        /// <param name="location">The location to fetch weather data for.</param>
        /// <returns>The raw weather data as a string.</returns>
        private async Task<string> FetchWeatherAsync(string location)
        {
            string apiUrl = $"https://wttr.in/{Uri.EscapeDataString(location)}?format=4";
            using HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("failed to fetch weather data");
            }

            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Formats raw weather data into a more readable format.
        /// </summary>
        /// <param name="location">The location associated with the weather data.</param>
        /// <param name="weatherData">The raw weather data string.</param>
        /// <returns>A formatted weather data string.</returns>
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
                return "error during formatting of the weather data";
            }
        }

        /// <summary>
        /// Handles the click event of the Save Config button.
        /// Saves the entered country and city inputs into the user's user_config file
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
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
                string directoryPath = Path.GetDirectoryName(_activeUser.GetUserConfigFile());
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                var config = new XElement("Configuration",
                    new XElement("EnteredCountry", enteredCountry),
                    new XElement("EnteredCity", enteredCity)
                );

                config.Save(_activeUser.GetUserConfigFile());

                MessageBox.Show("Configuration saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Loads the user's saved configuration from the user_config file, and fill the two input fields.
        /// </summary>
        private void LoadConfiguration()
        {
            string configFilePath = _activeUser.GetUserConfigFile();
            if (!File.Exists(configFilePath)) return;

            try
            {
                XElement config = XElement.Load(configFilePath);
                string savedCountry = config.Element("EnteredCountry")?.Value;
                string savedCity = config.Element("EnteredCity")?.Value;

                if (!string.IsNullOrWhiteSpace(savedCountry))
                    txtCountry.Text = savedCountry;

                if (!string.IsNullOrWhiteSpace(savedCity))
                    txtCity.Text = savedCity;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the click event of the Load Config button.
        /// Loads the saved user_config configuration for the current user.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void BtnLoadConfig_Click(object sender, EventArgs e)
        {
            LoadConfiguration();
        }

        /// <summary>
        /// Handles the click event of the Logout button.
        /// Logs the user out by closing the dashboard and reopening the login form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }
    }
}
