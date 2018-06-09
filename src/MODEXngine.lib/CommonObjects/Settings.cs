using System.Collections.Generic;

namespace MODEXngine.lib.CommonObjects
{
    public class Settings
    {
        public string PreviousGame { get; set; }

        public string Renderer { get; set; }

        public Resolution Resolution { get; set; }

        public bool IsFullScreen { get; set; }

        public bool SoundEnabled { get; set; }

        public Dictionary<string, string> GameSettings { get; set; }

        public string RenderingMode { get; set; }

        public Settings()
        {
            GameSettings = new Dictionary<string, string>();
        }

        private string SettingKey(string gameName, string gameSetting) => $"{gameSetting}_{gameName}";

        public string GetGameSetting(string gameName, string gameSetting) => !GameSettings.ContainsKey(SettingKey(gameName, gameSetting)) ? string.Empty : GameSettings[SettingKey(gameName, gameSetting)];

        public void SetGameSetting(string gameName, string gameSetting, string gameValue)
        {
            var key = SettingKey(gameName, gameSetting);

            if (GameSettings.ContainsKey(key))
            {
                GameSettings[key] = gameValue;
            }
            else
            {
                GameSettings.Add(key, gameValue);
            }
        }
    }
}