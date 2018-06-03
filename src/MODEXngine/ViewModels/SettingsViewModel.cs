using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using MODEXngine.lib.Base;
using MODEXngine.lib.Common;
using MODEXngine.lib.CommonObjects;
using MODEXngine.lib.Managers;
using MODEXngine.ViewModels.Base;

using NLog;

using Xamarin.Forms;

namespace MODEXngine.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public Resolution SelectedResolution
        {
            get => Settings.Resolution;
            set
            {
                if (Settings == null)
                {
                    Log.Error("Settings was null upon setting Resolution");

                    return;
                }

                Settings.Resolution = value;
                OnPropertyChanged();
            }
        }

        public bool IsFullScreen
        {
            get => Settings.IsFullScreen;
            set { Settings.IsFullScreen = value; OnPropertyChanged(); }
        }

        public bool SoundEnabled
        {
            get => Settings.SoundEnabled;
            set { Settings.SoundEnabled = value; OnPropertyChanged(); }
        }

        public bool NoRenderersAvailable => !RenderersAvailable;

        public bool RenderersAvailable => Renderers.Any();

        private BaseRenderer _selectedRenderer;

        public BaseRenderer SelectedRenderer
        {
            get => _selectedRenderer;

            set
            {
                _selectedRenderer = value;
                OnPropertyChanged();

                if (value == null)
                {
                    Log.Error("Selected Renderer is null");

                    return;
                }

                AvailableResolutions = new ObservableCollection<Resolution>(_selectedRenderer.SupportedResolutions());

                SelectedResolution = AvailableResolutions.FirstOrDefault(a => a.Equals(Settings?.Resolution)) ?? AvailableResolutions.FirstOrDefault();
            }
        }

        private ObservableCollection<BaseRenderer> _renderers;

        public ObservableCollection<BaseRenderer> Renderers
        {
            get => _renderers;
            set {
                _renderers = value;
                OnPropertyChanged();
            }
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

        public ICommand SaveSettingsCommand => new Command(SaveSettings);

        private void SaveSettings()
        {
            SettingsManager.SaveSettings(Constants.FILE_NAME_SETTINGS, Settings);

            App.AppSettings = Settings;
        }

        private Settings _settings;

        public Settings Settings
        {
            set
            {
                _settings = value;
                OnPropertyChanged();
            }
            get => _settings;
        }

        public SettingsViewModel()
        {
            if (App.AppSettings == null)
            {
                Log.Error("App.AppSettings is null");

                return;
            }

            Settings = App.AppSettings;

            if (App.Renderers == null)
            {
                Log.Error("No Renderers found");
                return;
            }

            Renderers = new ObservableCollection<BaseRenderer>(App.Renderers.OrderBy(a => a.Name));
            
            if (!Renderers.Any())
            {
                return;
            }

            var selectedRenderer = Renderers.FirstOrDefault(a => a.Name == Settings.Renderer);

            SelectedRenderer = selectedRenderer ?? Renderers.FirstOrDefault();
        }
    }
}