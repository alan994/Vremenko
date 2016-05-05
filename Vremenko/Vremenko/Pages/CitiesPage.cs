using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vremenko.Views;
using Xamarin.Forms;

namespace Vremenko.Pages
{
    public class CitiesPage:ContentPage
    {
        public CitiesPage()
        {
            Content = new CitiesView();
        }
    }
}
