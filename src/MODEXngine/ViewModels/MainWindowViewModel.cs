using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

using GalaSoft.MvvmLight.CommandWpf;

using MODEXngine.lib;

namespace MODEXngine.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ICommand GotoWebsiteCommand =>
            new RelayCommand(() => System.Diagnostics.Process.Start("https://github.com/jcapellman/MODEXngine"));
        
        public ICommand LaunchGameCommand => new RelayCommand( () =>
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

            MainWindowVisibility = Visibility.Hidden;

            selectedRenderer.Render();
        });
        
        private Visibility _mainWindowVisibility;

        public Visibility MainWindowVisibility
        {
            get => _mainWindowVisibility;
            set { _mainWindowVisibility = value; OnPropertyChanged(); }
        }

        private void _selectedRenderer_WindowClosed(object sender, System.EventArgs e)
        {
            MainWindowVisibility = Visibility.Visible;
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