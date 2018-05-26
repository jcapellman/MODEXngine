using MODEXngine.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MODEXngine.Views
{    
    public partial class MenuView : ContentPage
    {
        public ListView ListView;

        public MenuView()
        {
            InitializeComponent();

            BindingContext = new MenuViewModel();
            ListView = menuItemsListView;
        }
    }
}