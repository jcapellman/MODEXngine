using System.Collections.ObjectModel;
using System.Linq;

using MODEXngine.lib.Base;
using MODEXngine.ViewModels.Base;

using NLog;

namespace MODEXngine.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public bool NoRenderersAvailable => !RenderersAvailable;

        public bool RenderersAvailable => AvailableRenderers.Any();

        public bool GamesAvailable => AvailableGames.Any();

        public bool NoGamesAvailable => !GamesAvailable;

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
            if (App.Renderers == null)
            {
                Log.Error("App.Renderers is null");
            }
            else
            {
                AvailableRenderers = new ObservableCollection<BaseRenderer>(App.Renderers);
            }

            if (App.GameHeaders == null)
            {
                Log.Error("App.GameHeaders is null");
            }
            else
            {
                AvailableGames = new ObservableCollection<BaseGameHeader>(App.GameHeaders);
            }
        }
    }
}