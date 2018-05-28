using MODEXngine.ViewModels;
using MODEXngine.Views.Base;

namespace MODEXngine.Views
{	
	public partial class AboutView : BaseContentPage
    {
		public AboutView ()
		{
			InitializeComponent ();

            SetBindingContext(new AboutViewModel());
		}
	}
}