using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vremenko.Models;
using Vremenko.Pages;
using Vremenko.Services;
using Xamarin.Forms;

namespace Vremenko.Views
{
    public class CitiesView:ContentView
    {
        private ListView _listView;
        public CitiesView()
        {
            MessagingCenter.Subscribe<DataService>(this, "FetchedWeatherData",
                service =>
                {
                    _listView.ItemsSource = App.DataService.CityTemperatures;
                });

            var dataTemplate = new DataTemplate(typeof (TextCell));
            dataTemplate.SetBinding(TextCell.TextProperty, nameof(CityTemperature.City));
            dataTemplate.SetBinding(TextCell.DetailProperty, nameof(CityTemperature.Temperature));


            _listView = new ListView()
            {
                ItemTemplate = dataTemplate,
                BindingContext = App.DataService.CityTemperatures,
                ItemsSource = App.DataService.CityTemperatures,
                IsPullToRefreshEnabled = true,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            _listView.ItemTapped += ListView_ItemSelected;
            _listView.Refreshing += ListView_Refreshing;

            Content = _listView;
        }

        private void ListView_Refreshing(object sender, EventArgs e)
        {
            ((ListView) sender).IsRefreshing = false;
        }

        private void ListView_ItemSelected(object sender, ItemTappedEventArgs e)
        {
            if (Device.Idiom.Equals(TargetIdiom.Phone))
            {
                Navigation.PushAsync(new CityDetailsPage(((CityTemperature) e.Item).City));
                ((ListView) sender).SelectedItem = null;
                return;
            }
            MessagingCenter.Send(this, "NewCitySelected", ((CityTemperature) e.Item).City);
        }
    }
}
