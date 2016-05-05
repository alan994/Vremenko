using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Vremenko.Interfaces;
using Vremenko.Models;
using Xamarin.Forms;

namespace Vremenko.Services
{
    public class DbService
    {
        private SQLiteConnection _database;

        public DbService()
        {
            _database = DependencyService.Get<ISqlService>().GetConnection();

            _database.CreateTable<CityTemperature>();
        }

        public void AddData(List<CityTemperature> list)
        {
            _database.InsertAll(list);
        }

        public List<CityTemperature> GetHistoricalCityTemperatures(string cityName)
        {
            return _database.Table<CityTemperature>().Where(x => x.City.Equals(cityName)).ToList();
        }

        //public List<CityTemperature> GetLatestCityTemperatures()
        //{ 
        //    var res = from city in _database.Table<CityTemperature>()
        //        group city by city.City
        //        into groups
        //        select groups.OrderByDescending(p => p.DataAt).First();

        //    return res.ToList();
        //} 
    }
}
