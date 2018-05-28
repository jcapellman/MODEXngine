using System.Collections.ObjectModel;
using System.Linq;

using MODEXngine.lib;
using MODEXngine.ViewModels.Base;

namespace MODEXngine.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private bool _noRenderersAvailable;

        public bool NoRenderersAvailable
        {
            get => _noRenderersAvailable;
            set { _noRenderersAvailable = value; OnPropertyChanged(); }
        }

        private bool _renderersAvailable;

        public bool RenderersAvailable
        {
            set { _renderersAvailable = value; OnPropertyChanged(); }
            get => _renderersAvailable;
        }

        private bool _gamesAvailable;

        public bool GamesAvailable
        {
            get => _gamesAvailable;
            set
            {
                _gamesAvailable = value;
                OnPropertyChanged();
            }
        }

        private bool _noGamesAvailable;

        public bool NoGamesAvailable
        {
            get => _noGamesAvailable;
            set
            {
                _noGamesAvailable = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<BaseRenderer> _availableRenderers;

        public ObservableCollection<BaseRenderer> AvailableRenderers
        {
            get => _availableRenderers;
            set { _availableRenderers = value; OnPropertyChanged(); }
        }

        private ObservableCollection<BaseGameHeader> _availableGames;

        public ObservableCollection<BaseGameHeader> AvailableGames
        {
            get => _availableGames;
            set { _availableGames = value; OnPropertyChanged(); }
        }

        public AboutViewModel()
        {
            AvailableRenderers = new ObservableCollection<BaseRenderer>(App.Renderers);
            AvailableGames = new ObservableCollection<BaseGameHeader>(App.GameHeaders);

            NoRenderersAvailable = !AvailableRenderers.Any();
            RenderersAvailable = AvailableRenderers.Any();

            GamesAvailable = AvailableGames.Any();
            NoGamesAvailable = !AvailableGames.Any();
        }
    }
}