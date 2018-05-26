using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using MODEXngine.lib;
using MODEXngine.ViewModels.Base;

using Xamarin.Forms;

namespace MODEXngine.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ICommand GotoWebsiteCommand =>
            new Command(() => System.Diagnostics.Process.Start("https://github.com/jcapellman/MODEXngine"));

        public ICommand OpenSettingsCommand =>
            new Command(() =>
            {
                IsSettingsOpen = true;
            });

        public ICommand SettingsClosedCommand => new Command(() => IsSettingsOpen = false);

        public ICommand LaunchGameCommand => new Command( () =>
        {
            var selectedRenderer = App.Renderers.FirstOrDefault(a => a.Name == App.AppSettings.Renderer);

            if (selectedRenderer == null)
            {
                OnGUIMessage($"{App.AppSettings.Renderer} was not found");

                return;
            }

            selectedRenderer.WindowClosed -= _selectedRenderer_WindowClosed;
            selectedRenderer.WindowClosed += _selectedRenderer_WindowClosed;

            selectedRenderer.SetGameLaunchItems(SelectedGameHeader, App.AppSettings);

            MainWindowVisible = false;

            selectedRenderer.Render();
        });
        
        private bool _mainWindowVisible;

        public bool MainWindowVisible
        {
            get => _mainWindowVisible;
            set { _mainWindowVisible = value; OnPropertyChanged(); }
        }

        private void _selectedRenderer_WindowClosed(object sender, System.EventArgs e)
        {
            MainWindowVisible = true;
        }
        
        private ObservableCollection<BaseGameHeader> _gameHeaders;

        public ObservableCollection<BaseGameHeader> GameHeaders
        {
            get => _gameHeaders;
            set { _gameHeaders = value; OnPropertyChanged(); }
        }
        
        private BaseGameHeader _selectedGameHeader;

        public BaseGameHeader SelectedGameHeader
        {
            get => _selectedGameHeader;

            set { _selectedGameHeader = value; OnPropertyChanged(); }
        }
        
        private bool _btnStartGameEnabled;

        public bool btnStartGameEnabled
        {
            set { _btnStartGameEnabled = value; OnPropertyChanged(); }
            get => _btnStartGameEnabled;
        }

        private bool _isSettingsOpen;

        public bool IsSettingsOpen
        {
            get => _isSettingsOpen;

            set
            {
                _isSettingsOpen = value;
                OnPropertyChanged();
            }
        }

        public void LoadVM()
        {
            btnStartGameEnabled = false;
            
            GameHeaders = new ObservableCollection<BaseGameHeader>(App.GameHeaders.OrderBy(a => a.GameName));

            var selectedGame = GameHeaders.FirstOrDefault(a => a.GameName == App.AppSettings.PreviousGame);

            SelectedGameHeader = selectedGame ?? GameHeaders.FirstOrDefault();
            
            btnStartGameEnabled = true;
        }
    }
}