using System.IO;

using MODEXngine.lib.CommonObjects;
    
using Newtonsoft.Json;

namespace MODEXngine.lib.Managers
{
    public static class SettingsManager
    {
        private static Settings GetDefaultSettings() => new Settings
        {
            Resolution = new Resolution {Width = 640, Height = 480, RefreshRate = 60, Bpp = 32},
            Renderer = "OpenGL",
            PreviousGame = "Dark Forces",
            IsFullScreen = true,
            SoundEnabled = true
        };

        public static void SaveSettings(string fileName, Settings settings)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(settings));
        }

        public static Settings LoadSettings(string fileName)
        {
            if (File.Exists(fileName))
            {
                return JsonConvert.DeserializeObject<Settings>(File.ReadAllText(fileName));
            }

            var defaultSettings = GetDefaultSettings();

            File.WriteAllText(fileName, JsonConvert.SerializeObject(defaultSettings));

            return defaultSettings;
        }
    }
}