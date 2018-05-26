using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using MODEXngine.lib;
using MODEXngine.lib.Common;
using MODEXngine.lib.CommonObjects;
using MODEXngine.lib.Managers;
using MODEXngine.ViewModels.Base;

using Xamarin.Forms;

namespace MODEXngine.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
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

            set
            {
                _selectedRenderer = value; OnPropertyChanged();
                AvailableResolutions = new ObservableCollection<Resolution>(_selectedRenderer.SupportedResolutions());
            }
        }

        private ObservableCollection<BaseRenderer> _renderers;

        public ObservableCollection<BaseRenderer> Renderers
        {
            get => _renderers;
            set { _renderers = value; OnPropertyChanged(); }
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
            Settings = App.AppSettings;

            Renderers = new ObservableCollection<BaseRenderer>(App.Renderers.OrderBy(a => a.Name));

            var selectedRenderer = Renderers.FirstOrDefault(a => a.Name == Settings.Renderer);

            SelectedRenderer = selectedRenderer ?? Renderers.FirstOrDefault();
        }
    }
}