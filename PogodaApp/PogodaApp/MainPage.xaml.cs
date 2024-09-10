using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PogodaApp.API;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;
using Xamarin.Forms.Xaml;

namespace PogodaApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            daysEntry.Text = "1";
        }
        public double lat = 61.00318527;
        public double lon = 69.01891327;
        public int limit = 3;

        public void ChangeParameters()
        {
            if(Convert.ToInt32(daysEntry.Text) <=0)
                limit = Math.Max(Convert.ToInt32(daysEntry.Text), 1);
            else
                limit = Math.Min(Convert.ToInt32(daysEntry.Text), 7);

            switch (Cities.SelectedIndex)
            {
                case 0: // город: Х-М
                    lat = 61.00318527;
                    lon = 69.01891327;
                        break;
                case 1: // город: СПБ
                    lat = 59.93867493;
                    lon = 30.31449318;
                        break;
                case 2: // город: Ебург
                    lat = 56.8380127;
                    lon = 60.59747314;
                        break;
                case 3: // город: Тюмень
                    lat = 57.15298462;
                    lon = 65.54122925;
                        break;
                case 4: // город: Москва
                    lat = 55.75581741;
                    lon = 37.61764526;
                        break;
                default: // город: Х-М
                    lat = 61.00318527;
                    lon = 69.01891327;
                        break;
            }
        }

        public async Task MakeGetRequest()
        {
            ChangeParameters();
            const string YandexAPIkey = "4640241d-9081-41d2-b618-b0a4d60ec6bb";
            HttpClient httpClient = new HttpClient();

            string url = $"https://api.weather.yandex.ru/v2/forecast/?lat={lat}&lon={lon}&lang=ru_RU&limit={limit}&hours=false";

            try
            {
                httpClient.DefaultRequestHeaders.Add("X-Yandex-API-Key", YandexAPIkey);
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                string PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "text2.txt");



                System.IO.File.WriteAllText(PATH, responseBody);
                var jsonFile = System.IO.File.ReadAllText(PATH);
                Root pogodaResponse = System.Text.Json.JsonSerializer.Deserialize<Root>(jsonFile);
                List<Forecast> prognozy = pogodaResponse.forecasts;

                                    

                Title.Text = "Прогноз погоды в " + Cities.SelectedItem;
                days.ItemsSource = prognozy;
                const string defCity = "г. Ханты-Мансийск";


                if (Cities.Title == "Город")
                {
                    Cities.Title = defCity;
                    Title.Text = "Прогноз в " + defCity;
                }
            }
            catch (HttpRequestException e) { Console.WriteLine(e.Message); }
        }

        private async void Zapros_Clicked(object sender, EventArgs e)
        {
            await MakeGetRequest();
        }
    }
}
