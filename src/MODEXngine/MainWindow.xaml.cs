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
    }
}