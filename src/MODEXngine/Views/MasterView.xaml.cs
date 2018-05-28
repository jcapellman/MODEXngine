using System;
using System.Linq;
using MODEXngine.lib.Common;
using MODEXngine.Models;
using MODEXngine.Resx;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MODEXngine.Views
{    
    public partial class MasterView : MasterDetailPage
    {
        public MasterView()
        {
            InitializeComponent();

            if (!App.Renderers.Any())
            {
                
            }

            menu.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterViewMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            menu.ListView.SelectedItem = null;
        }
    }
}