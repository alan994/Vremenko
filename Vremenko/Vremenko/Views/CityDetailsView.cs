using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vremenko.Models;
using Vremenko.Services;
using Xamarin.Forms;

namespace Vremenko.Views
{
    public class CityDetailsView:ContentView
    {
        private ListView _listView;
        public CityDetailsView()
        {
            BuildView();

            MessagingCenter.Subscribe<DataService,string>(this, "NewCitySelected",
                (service,s) => _listView.ItemsSource = App.DataService.GetHistoricalCityTemperatures(s));
        }

        public CityDetailsView(string cityName)
        {
            BuildView();

            _listView.ItemsSource = App.DataService.GetHistoricalCityTemperatures(cityName);
        }

        private void BuildView()
        {
            var dataTemplate = new DataTemplate(typeof (TextCell));
            dataTemplate.SetBinding(TextCell.TextProperty, nameof(CityTemperature.Temperature));
            dataTemplate.SetBinding(TextCell.DetailProperty, nameof(CityTemperature.DataAt));

            _listView=new ListView()
            {
                ItemTemplate = dataTemplate,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            Content = _listView;
        }
    }
}
