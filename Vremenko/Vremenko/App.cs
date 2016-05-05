using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vremenko.Pages;
using Vremenko.Services;
using Xamarin.Forms;

namespace Vremenko
{
    public class App : Application
    {
        public static DataService DataService { get; set; }

        public App()
        {
            DataService = new DataService();
            DataService.DownloadWeatherData();

            if (Device.Idiom.Equals(TargetIdiom.Phone))
            {
                MainPage = new NavigationPage(new CitiesPage());
            }
            else
            {
                MainPage=new TabletPage();
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
