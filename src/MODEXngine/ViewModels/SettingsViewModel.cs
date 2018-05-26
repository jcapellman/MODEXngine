using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

using GalaSoft.MvvmLight.CommandWpf;

using MODEXngine.Common;
using MODEXngine.lib;
using MODEXngine.lib.CommonObjects;
using MODEXngine.lib.Managers;

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

        public event EventHandler SavedSettings;

        private void OnSavedSettings()
        {
            SavedSettings?.Invoke(this, null);
        }

        public ICommand SaveSettingsCommand => new RelayCommand(() =>
        {
            SaveSettings();
            OnSavedSettings();
        });

        public void SaveSettings()
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