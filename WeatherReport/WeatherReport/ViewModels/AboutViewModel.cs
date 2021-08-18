using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeatherReport.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            client.BaseAddress = new Uri("https://api.openweathermap.org");
            YuhAsync(city);


            Title = "Weather";
            Image = "Important.jpg";
            Placeholder = "Search";
            Search = "";

            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));

            SwipeCommand = new Command(() => Console.WriteLine("Test"));

            GrabWeather = new Command(async () => YuhAsync(Search));

            

        }

        public async void YuhAsync(string City)
        {
            try
            {

                Console.WriteLine("Start");

                string result = await client.GetStringAsync("/data/2.5/weather?q=" + City + "&appid=2bdeffc5d0e12aa66c7ea773357f320d");
                //string result = await client.GetStringAsync("/data/2.5/weather?q=Viborg&appid=2bdeffc5d0e12aa66c7ea773357f320d");
                client.CancelPendingRequests();

                var report = JsonConvert.DeserializeObject<Root>(result);

                Console.WriteLine("Finish");

                temp = Math.Round(report.main.temp - 273.15) + "°";
                desc = report.weather[0].description;
                
                Temperature = temp;
                Description = desc;
                Image = "Important.jpg";
                if (Description.Contains("rain"))
                {
                        Image = "eddie.gif";
                }
                
            } catch
            {
                client.CancelPendingRequests();
                Placeholder = "This city does not exist";
                Search = "";
            }
            
        }

        HttpClient client = new HttpClient();

        public string city = "Viborg";
        public string temp;
        public string desc;
        

        //I have an idea these might be usefull, or maybe not, who knows lmao im 2 tired 420 this shit, fix our future sleep scheudule 
        

        public class Coord
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }

        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class Main
        {
            public double temp { get; set; }
            public double feels_like { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public int pressure { get; set; }
            public int humidity { get; set; }
            public int sea_level { get; set; }
            public int grnd_level { get; set; }
        }

        public class Wind
        {
            public double speed { get; set; }
            public int deg { get; set; }
            public double gust { get; set; }
        }

        public class Clouds
        {
            public int all { get; set; }
        }

        public class Sys
        {
            public int type { get; set; }
            public int id { get; set; }
            public string country { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }
        }

        public class Root
        {
            public Coord coord { get; set; }
            public List<Weather> weather { get; set; }
            public string @base { get; set; }
            public Main main { get; set; }
            public int visibility { get; set; }
            public Wind wind { get; set; }
            public Clouds clouds { get; set; }
            public int dt { get; set; }
            public Sys sys { get; set; }
            public int timezone { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int cod { get; set; }
        }

       

        public ICommand SwipeCommand { get; }
        public ICommand GrabWeather { get; }
        public ICommand OpenWebCommand { get; }
    }
}