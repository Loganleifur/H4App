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
            //Lat and long moment.
            var location = Geolocation.GetLastKnownLocationAsync();
            Console.WriteLine(location.Result.Latitude + " lmao " + location.Result.Longitude);

            //Setting the base address and calling the first function
            client.BaseAddress = new Uri("https://api.openweathermap.org");

            startupGeo(location.Result.Latitude, location.Result.Longitude);

            
            Placeholder = "Search";

            SwipeCommand = new Command(() => Console.WriteLine("Test"));

            GrabWeather = new Command(async () => YuhAsync(Search));

            

        }
        
        public async void startupGeo(double lat, double lon)
        {
            string result = await client.GetStringAsync("/data/2.5/forecast?lat=" + lat + "&lon=" + lon + "&appid=2bdeffc5d0e12aa66c7ea773357f320d");

            var report = JsonConvert.DeserializeObject<Root>(result);

            Console.WriteLine("Finish");

            temp = Math.Round(report.list[0].main.temp - 273.15) + "°";
            desc = report.list[0].weather[0].description;

            Temperature = temp;
            Description = desc;
            CityName = report.city.name;
            Image = "https://openweathermap.org/img/wn/" + report.list[0].weather[0].icon + "@4x.png";
            Console.WriteLine(Image);
            Future1 = report.list[11].dt_txt;
            FutureTemp1 = Math.Round(report.list[11].main.temp - 273.15) + "°";
            Future2 = report.list[19].dt_txt;
            FutureTemp2 = Math.Round(report.list[19].main.temp - 273.15) + "°";
            Future3 = report.list[27].dt_txt;
            FutureTemp3 = Math.Round(report.list[27].main.temp - 273.15) + "°";
            Future4 = report.list[35].dt_txt;
            FutureTemp4 = Math.Round(report.list[35].main.temp - 273.15) + "°";

            if (Description.Contains("rain"))
            {
                Image = "eddie.gif";
            }
        }
        public async void YuhAsync(string City)
        {
            try
            {

                Console.WriteLine("Start");

                string result = await client.GetStringAsync("/data/2.5/forecast?q=" + City + "&appid=2bdeffc5d0e12aa66c7ea773357f320d");
                
                client.CancelPendingRequests();

                var report = JsonConvert.DeserializeObject<Root>(result);

                Console.WriteLine("Finish");

                temp = Math.Round(report.list[0].main.temp - 273.15) + "°";
                desc = report.list[0].weather[0].description;
                
                
                Temperature = temp;
                Description = desc;
                CityName = report.city.name;


                Image = "https://openweathermap.org/img/wn/" + report.list[0].weather[0].icon + "@4x.png";

                Future1 = report.list[11].dt_txt;
                FutureTemp1 = Math.Round(report.list[11].main.temp - 273.15) + "°";
                Future2 = report.list[19].dt_txt;
                FutureTemp2 = Math.Round(report.list[19].main.temp - 273.15) + "°";
                Future3 = report.list[27].dt_txt;
                FutureTemp3 = Math.Round(report.list[27].main.temp - 273.15) + "°";
                Future4 = report.list[35].dt_txt;
                FutureTemp4 = Math.Round(report.list[35].main.temp - 273.15) + "°";

               
                if (CityName.Contains("Zato"))
                {
                        Image = "eddie.gif";
                }
                
            } catch
            {
                Placeholder = "City not found";
                Search = "";
                client.CancelPendingRequests();
                Console.WriteLine(Search);
            }
            
        }

        HttpClient client = new HttpClient();

        
        public string temp;
        public string desc;


        //I have an idea these might be usefull, or maybe not, who knows lmao im 2 tired 420 this shit, fix our future sleep scheudule 
        //This only works for the singular ones

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Main
        {
            public double temp { get; set; }
            public double feels_like { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public int pressure { get; set; }
            public int sea_level { get; set; }
            public int grnd_level { get; set; }
            public int humidity { get; set; }
            public double temp_kf { get; set; }
        }

        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class Clouds
        {
            public int all { get; set; }
        }

        public class Wind
        {
            public double speed { get; set; }
            public int deg { get; set; }
            public double gust { get; set; }
        }

        public class Sys
        {
            public string pod { get; set; }
        }

        public class Rain
        {
            public double _3h { get; set; }
        }

        public class List
        {
            public int dt { get; set; }
            public Main main { get; set; }
            public List<Weather> weather { get; set; }
            public Clouds clouds { get; set; }
            public Wind wind { get; set; }
            public int visibility { get; set; }
            public double pop { get; set; }
            public Sys sys { get; set; }
            public string dt_txt { get; set; }
            public Rain rain { get; set; }
        }

        public class Coord
        {
            public double lat { get; set; }
            public double lon { get; set; }
        }

        public class City
        {
            public int id { get; set; }
            public string name { get; set; }
            public Coord coord { get; set; }
            public string country { get; set; }
            public int population { get; set; }
            public int timezone { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }
        }

        public class Root
        {
            public string cod { get; set; }
            public int message { get; set; }
            public int cnt { get; set; }
            public List<List> list { get; set; }
            public City city { get; set; }
        }





        public ICommand SwipeCommand { get; }
        public ICommand GrabWeather { get; }
        public ICommand OpenWebCommand { get; }
    }
}