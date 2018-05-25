using System;
using System.Windows;

using MahApps.Metro.Controls.Dialogs;

using MODEXngine.Common;
using MODEXngine.ViewModels;

namespace MODEXngine
{
    public partial class MainWindow
    {
        private MainWindowViewModel ViewModel => (MainWindowViewModel) DataContext;

        public MainWindow()
        {
            InitializeComponent();
            
            DataContext = new MainWindowViewModel();

            ViewModel.GUIMessage += ViewModel_GUIMessage;

            ViewModel.LoadVM();
        }

        private void ViewModel_GUIMessage(object sender, string e)
        {
            this.ShowMessageAsync(Constants.NAME_APP, e);
        }

        private void btnSettings_OnClick(object sender, RoutedEventArgs e)
        {
            FoSettings.IsOpen = true;
        }
        
        private void onSettings_Closed(object sender, EventArgs e)
        {
            FoSettings.IsOpen = false;
        }
    }
}