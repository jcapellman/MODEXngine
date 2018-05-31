﻿using System.Collections.ObjectModel;
using System.Linq;

using MODEXngine.lib;
using MODEXngine.Resx;
using MODEXngine.ViewModels.Base;

using Xamarin.Forms;

namespace MODEXngine.ViewModels
{
    public class GameSelectionViewModel : BaseViewModel
    {
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

            set { _selectedGameHeader = value; OnPropertyChanged(); }
        }

        public Command LaunchGameCommand => new Command(() =>
        {
            var selectedRenderer = App.Renderers.FirstOrDefault(a => a.Name == App.AppSettings.Renderer);

            if (selectedRenderer == null)
            {
                OnGUIMessage($"{App.AppSettings.Renderer} {AppResources.GameSelection_RendererNotFound}");

                return;
            }

            selectedRenderer.SetGameLaunchItems(SelectedGameHeader, App.AppSettings);

            selectedRenderer.Render();
        });

        public GameSelectionViewModel()
        {
            GameHeaders = new ObservableCollection<BaseGameHeader>(App.GameHeaders.OrderBy(a => a.GameName));
            
            var selectedGame = GameHeaders.FirstOrDefault(a => a.GameName == App.AppSettings.PreviousGame);

            SelectedGameHeader = selectedGame ?? GameHeaders.FirstOrDefault();

            LaunchButtonEnabled = false;
        }
    }
}