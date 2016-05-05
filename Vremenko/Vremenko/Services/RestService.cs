using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Vremenko.Models;

namespace Vremenko.Services
{
    public class RestService
    {
        private HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<CityTemperature>>  GetWeatherData()
        {
            var xml = await _client.GetStringAsync("http://vrijeme.hr/hrvatska_n.xml");

            XDocument doc = XDocument.Parse(xml);

            var data = from item in doc.Descendants("Grad")
                       select new CityTemperature()
                       {
                           City = item.Element("GradIme").Value,
                           Temperature = item.Element("Podatci").Element("Temp").Value,
                           DataAt = DateTime.Now
                       };

            return data.ToList();
        }
    }
}


