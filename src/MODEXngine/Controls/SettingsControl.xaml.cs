using System;
using System.Windows;
using System.Windows.Controls;

using MODEXngine.ViewModels;

namespace MODEXngine.Controls
{
    public partial class SettingsControl : UserControl
    {
        private SettingsViewModel viewModel => (SettingsViewModel) DataContext;

        public event EventHandler Closed;

        public void OnClosed()
        {
            Closed?.Invoke(this, null);
        }

        public SettingsControl()
        {
            InitializeComponent();

            DataContext = new SettingsViewModel();
        }

        private void btnSaveSettings_OnClick(object sender, RoutedEventArgs e)
        {
            viewModel.SaveSettings();
            OnClosed();
        }
    }
}