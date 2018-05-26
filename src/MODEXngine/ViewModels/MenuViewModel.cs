using System.Collections.ObjectModel;

using MODEXngine.Models;
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
                new MasterViewMenuItem { Id = 0, Title = "Games", TargetType = typeof(GameSelectionView) },
                new MasterViewMenuItem { Id = 1, Title = "Settings", TargetType = typeof(SettingsView) },                
                new MasterViewMenuItem { Id = 3, Title = "About", TargetType = typeof(AboutView) },
            });
        }
    }
}