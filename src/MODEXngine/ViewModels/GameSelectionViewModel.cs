﻿using System.Collections.ObjectModel;
using System.Linq;

using MODEXngine.Interfaces;
using MODEXngine.lib.Base;
using MODEXngine.lib.Common;
using MODEXngine.lib.Managers;
using MODEXngine.Resx;
using MODEXngine.ViewModels.Base;

using NLog;

using Xamarin.Forms;

namespace MODEXngine.ViewModels
{
    public class GameSelectionViewModel : BaseViewModel
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private string _launchGamePath;

        public string LaunchGamePath
        {
            get => _launchGamePath;
            set
            {
                _launchGamePath = value;
                OnPropertyChanged();

                LaunchButtonEnabled = !string.IsNullOrEmpty(value);
            }
        }

        private bool _launchButtonEnabled;

        public bool LaunchButtonEnabled
        {
            get => _launchButtonEnabled;
            set
            {
                _launchButtonEnabled = value;
                OnPropertyChanged();
            }
        }

        public bool GamesAvailable => GameHeaders.Any();

        public bool NoGamesAvailable => !GamesAvailable;

        private ObservableCollection<BaseGameHeader> _gameHeaders;

        public ObservableCollection<BaseGameHeader> GameHeaders
        {
            get => _gameHeaders;
            set {
                _gameHeaders = value;
                OnPropertyChanged();
            }
        }

        private BaseGameHeader _selectedGameHeader;

        public BaseGameHeader SelectedGameHeader
        {
            get => _selectedGameHeader;

            set
            {
                _selectedGameHeader = value;

                OnPropertyChanged();

                if (value == null)
                {
                    Log.Error("SelectedGameHeader was set to null");
                    return;
                }

                LaunchGamePath = App.AppSettings.GetGameSetting(SelectedGameHeader.GameName, Constants.SETTINGS_GAME_DATA_PATH);
            }
        }

        public Command LaunchGameCommand => new Command(() =>
        {
            var selectedRenderer = App.Renderers.FirstOrDefault(a => a.Name == App.AppSettings.Renderer);

            if (selectedRenderer == null)
            {
                OnGUIMessage($"{App.AppSettings.Renderer} {AppResources.GameSelection_RendererNotFound}");

                return;
            }

            selectedRenderer.SetGameLaunchItems(SelectedGameHeader.GameName, App.AppSettings);

            SelectedGameHeader.Initialize(selectedRenderer, App.AppSettings);

            SelectedGameHeader.Start();
        });

        public Command SelectPathCommand => new Command(() =>
        {
            var result = DependencyService.Get<IFolderSelector>().SelectFolder();

            if (string.IsNullOrEmpty(result))
            {
                return;
            }

            LaunchGamePath = result;

            App.AppSettings.SetGameSetting(SelectedGameHeader.GameName, Constants.SETTINGS_GAME_DATA_PATH, LaunchGamePath);

            SettingsManager.SaveSettings(Constants.FILE_NAME_SETTINGS, App.AppSettings);
        });

        public GameSelectionViewModel()
        {
            LaunchButtonEnabled = false;

            if (App.GameHeaders == null)
            {
                Log.Error("App.GameHeaders is null");

                return;
            }

            GameHeaders = new ObservableCollection<BaseGameHeader>(App.GameHeaders.OrderBy(a => a.GameName));

            if (!GameHeaders.Any())
            {
                Log.Error("GameHeaders is empty");

                return;
            }

            var selectedGame = GameHeaders.FirstOrDefault(a => a.GameName == App.AppSettings.PreviousGame);

            SelectedGameHeader = selectedGame ?? GameHeaders.FirstOrDefault();
        }
    }
}