using MODEXngine.ViewModels;
using MODEXngine.Views.Base;

namespace MODEXngine.Views
{	
	public partial class SettingsView : BaseContentPage
    {
		public SettingsView ()
		{
			InitializeComponent ();

            SetBindingContext(new SettingsViewModel());
		}
	}
}