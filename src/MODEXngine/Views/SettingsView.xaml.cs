using MODEXngine.ViewModels;

using Xamarin.Forms;

namespace MODEXngine.Views
{	
	public partial class SettingsView : ContentPage
	{
		public SettingsView ()
		{
			InitializeComponent ();

		    BindingContext = new SettingsViewModel();
		}
	}
}