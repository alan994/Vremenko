using Vremenko.Views;
using Xamarin.Forms;

namespace Vremenko.Pages
{
    public class CityDetailsPage:ContentPage
    {
        public CityDetailsPage(string city)
        {
            Content = new CityDetailsView(city);
        }
    }
}
