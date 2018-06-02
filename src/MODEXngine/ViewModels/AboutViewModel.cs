using System.Collections.ObjectModel;
using System.Linq;

using MODEXngine.lib;
using MODEXngine.lib.Base;
using MODEXngine.ViewModels.Base;

namespace MODEXngine.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public bool NoRenderersAvailable
        {
            get => !RenderersAvailable;
        }
        
        public bool RenderersAvailable
        {
            get => AvailableRenderers.Any();
        }
        
        public bool GamesAvailable
        {
            get => AvailableGames.Any();
        }
        
        public bool NoGamesAvailable
        {
            get => !GamesAvailable;
        }

        private ObservableCollection<BaseRenderer> _availableRenderers;

        public ObservableCollection<BaseRenderer> AvailableRenderers
        {
            get => _availableRenderers;
            set {
                _availableRenderers = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<BaseGameHeader> _availableGames;

        public ObservableCollection<BaseGameHeader> AvailableGames
        {
            get => _availableGames;
            set {
                _availableGames = value;
                OnPropertyChanged();
            }
        }

        public AboutViewModel()
        {
            AvailableRenderers = new ObservableCollection<BaseRenderer>(App.Renderers);
            AvailableGames = new ObservableCollection<BaseGameHeader>(App.GameHeaders);
        }
    }
}