using MODEXngine.lib.Common;
using MODEXngine.Resx;
using MODEXngine.ViewModels.Base;

using Xamarin.Forms;

namespace MODEXngine.Views.Base
{
	public class BaseContentPage : ContentPage
	{
	    protected void SetBindingContext(BaseViewModel viewModel)
	    {
	        BindingContext = viewModel;
	        ((BaseViewModel)BindingContext).GUIMessage += BaseContentPage_GUIMessage;
        }

        private void BaseContentPage_GUIMessage(object sender, string e)
        {
            ShowDialogAsync(e);
        }

        public async void ShowDialogAsync(string message)
	    {
	        await DisplayAlert(Constants.NAME_APP, message, AppResources.Global_Ok);
        }
	}
}