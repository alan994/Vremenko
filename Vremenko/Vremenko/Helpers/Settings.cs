// Helpers/Settings.cs

using System.Collections.Generic;
using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Vremenko.Models;

namespace Vremenko.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
    private static ISettings AppSettings
    {
      get
      {
        return CrossSettings.Current;
      }
    }

    #region Setting Constants

    private const string SettingsKey = "settings_key";
    private static readonly string SettingsDefault = string.Empty;

      private const string LatestTempsKey = "latesttemps_key";
      private static readonly string LatestTempsDefault = string.Empty;

    #endregion


      public static List<CityTemperature> LatestTemps
      {
          get
          {
              return
                  JsonConvert.DeserializeObject<List<CityTemperature>>(
                      AppSettings.GetValueOrDefault<string>(LatestTempsKey, LatestTempsDefault));
          }
          set { AppSettings.AddOrUpdateValue<string>(LatestTempsKey, JsonConvert.SerializeObject(value)); }
      }
    public static string GeneralSettings
    {
      get
      {
        return AppSettings.GetValueOrDefault<string>(SettingsKey, SettingsDefault);
      }
      set
      {
        AppSettings.AddOrUpdateValue<string>(SettingsKey, value);
      }
    }

  }
}