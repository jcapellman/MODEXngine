using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using MODEXngine.Common;
using MODEXngine.lib;
using MODEXngine.lib.CommonObjects;
using MODEXngine.lib.Managers;

using Prism.Commands;

namespace MODEXngine.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ICommand GotoWebsiteCommand =>
            new DelegateCommand(() => System.Diagnostics.Process.Start("https://github.com/jcapellman/MODEXngine"));
        
        public ICommand LaunchGameCommand => new DelegateCommand( () =>
        {
            _selectedRenderer.SetGameLaunchItems(SelectedGameHeader, Settings);
            _selectedRenderer.Render();
        });

        public ICommand SaveSettingsCommand => new DelegateCommand(SaveSettings);

        public void SaveSettings()
        {
            SettingsManager.SaveSettings(Constants.FILE_NAME_SETTINGS, Settings);
        }
        
        private Settings _settings;

        public Settings Settings
        {
            set { _settings = value; OnPropertyChanged(); }
            get => _settings;
        }

        private ObservableCollection<Resolution> _availableResolutions;

        public ObservableCollection<Resolution> AvailableResolutions
        {
            get => _availableResolutions;
            set
            {
                _availableResolutions = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<BaseGameHeader> _gameHeaders;

        public ObservableCollection<BaseGameHeader> GameHeaders
        {
            get => _gameHeaders;
            set { _gameHeaders = value; OnPropertyChanged(); }
        }

        private ObservableCollection<BaseRenderer> _renderers;

        public ObservableCollection<BaseRenderer> Renderers
        {
            get => _renderers;
            set { _renderers = value; OnPropertyChanged(); }
        }

        private BaseGameHeader _selectedGameHeader;

        public BaseGameHeader SelectedGameHeader
        {
            get => _selectedGameHeader;

            set { _selectedGameHeader = value; OnPropertyChanged(); }
        }
        
        public Resolution SelectedResolution
        {
            get => Settings.Resolution;
            set { Settings.Resolution = value; OnPropertyChanged(); }
        }

        public bool IsFullScreen
        {
            get => Settings.IsFullScreen;
            set { Settings.IsFullScreen = value; OnPropertyChanged(); }
        }

        private BaseRenderer _selectedRenderer;

        public BaseRenderer SelectedRenderer
        {
            get => _selectedRenderer;

            set { _selectedRenderer = value; OnPropertyChanged();
                AvailableResolutions = new ObservableCollection<Resolution>(_selectedRenderer.SupportedResolutions());
            }
        }
        
        private bool _btnStartGameEnabled;

        public bool btnStartGameEnabled
        {
            set { _btnStartGameEnabled = value; OnPropertyChanged(); }
            get => _btnStartGameEnabled;
        }

        public MainWindowViewModel()
        {
            Settings = SettingsManager.LoadSettings(Constants.FILE_NAME_SETTINGS);
        }
        
        public void LoadVM()
        {
            btnStartGameEnabled = false;
            
            GameHeaders = new ObservableCollection<BaseGameHeader>(LoadAssemblies<BaseGameHeader>(Constants.ASSEMBLY_MASK_GAME_LIBS).OrderBy(a => a.GameName));

            var selectedGame = GameHeaders.FirstOrDefault(a => a.GameName == Settings.PreviousGame);

            SelectedGameHeader = selectedGame ?? GameHeaders.FirstOrDefault();

            Renderers = new ObservableCollection<BaseRenderer>(LoadAssemblies<BaseRenderer>(Constants.ASSEMBLY_MASK_RENDER_LIBS).OrderBy(a => a.Name));

            var selectedRenderer = Renderers.FirstOrDefault(a => a.Name == Settings.Renderer);

            SelectedRenderer = selectedRenderer ?? Renderers.FirstOrDefault();
            
            btnStartGameEnabled = true;
        }
    }
}