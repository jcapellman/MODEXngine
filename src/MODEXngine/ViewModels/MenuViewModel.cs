using System.Collections.ObjectModel;

using MODEXngine.Models;
using MODEXngine.Resx;
using MODEXngine.ViewModels.Base;
using MODEXngine.Views;

namespace MODEXngine.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public ObservableCollection<MasterViewMenuItem> MenuItems { get; set; }

        public MenuViewModel()
        {
            MenuItems = new ObservableCollection<MasterViewMenuItem>(new[]
            {
                new MasterViewMenuItem { Id = 0, Title = AppResources.GameSelection_Title, TargetType = typeof(GameSelectionView) },
                new MasterViewMenuItem { Id = 1, Title = AppResources.Settings_Title, TargetType = typeof(SettingsView) },                
                new MasterViewMenuItem { Id = 3, Title = AppResources.About_Title, TargetType = typeof(AboutView) },
            });
        }
    }
}