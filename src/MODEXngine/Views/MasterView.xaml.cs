using System;

using MODEXngine.Models;

using Xamarin.Forms;

namespace MODEXngine.Views
{    
    public partial class MasterView : MasterDetailPage
    {
        public MasterView()
        {
            InitializeComponent();
            
            menu.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is MasterViewMenuItem item))
            {
                return;
            }

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            menu.ListView.SelectedItem = null;
        }
    }
}