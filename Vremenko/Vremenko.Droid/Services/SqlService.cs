using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using Vremenko.Droid.Services;
using Vremenko.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(SqlService))]
namespace Vremenko.Droid.Services
{
    public class SqlService : ISqlService
    {
        public SQLiteConnection GetConnection()
        {
            return
                new SQLite.SQLiteConnection(
                    Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                        "Vremenko.db3"));
        }
    }
}