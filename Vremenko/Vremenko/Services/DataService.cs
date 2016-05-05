using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vremenko.Helpers;
using Vremenko.Models;
using Xamarin.Forms;

namespace Vremenko.Services
{
    public class DataService
    {
        private RestService _restService;
        private DbService _dbService;

        public List<CityTemperature> CityTemperatures { get; set; }


        public DataService()
        {
            _restService = new RestService();
            _dbService = new DbService();

            CityTemperatures = new List<CityTemperature>();

            var storedTemperatures = Settings.LatestTemps;
            if (storedTemperatures != null)
            {
                CityTemperatures = storedTemperatures;
            }
        }

        public async Task DownloadWeatherData()
        {
            var data = await _restService.GetWeatherData();

            if (data != null && data.Count > 0)
            {
                CityTemperatures = data;
                Settings.LatestTemps = data;
                _dbService.AddData(data);

                MessagingCenter.Send(this, "FetchedWeatherData");
            }
        }

        public List<CityTemperature> GetHistoricalCityTemperatures(string cityName)
        {
            return _dbService.GetHistoricalCityTemperatures(cityName);
        }
    }
}
