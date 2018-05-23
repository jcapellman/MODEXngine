using System.Windows;
using MahApps.Metro.Controls;

using MODEXngine.ViewModels;

namespace MODEXngine
{
    public partial class MainWindow : MetroWindow
    {
        private MainWindowViewModel viewModel => (MainWindowViewModel) DataContext;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();

            viewModel.LoadVM();
        }

        private void btnSettings_OnClick(object sender, RoutedEventArgs e)
        {
            FoSettings.IsOpen = true;
        }
    }
}