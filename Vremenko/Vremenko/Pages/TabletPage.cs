using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vremenko.Views;
using Xamarin.Forms;

namespace Vremenko.Pages
{
    public class TabletPage:ContentPage
    {
        public TabletPage()
        {
            var grid = new Grid()
            {
                ColumnDefinitions = new ColumnDefinitionCollection()
                {
                    new ColumnDefinition() {Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition() {Width = new GridLength(1, GridUnitType.Star)}
                }
            };

            grid.Children.Add(new CitiesView(), 0, 0);
            grid.Children.Add(new CityDetailsView(), 1, 0);

            Content = grid;
        }
    }
}
