using MODEXngine.ViewModels;

using Xamarin.Forms;

namespace MODEXngine.Views
{	
	public partial class GameSelectionView : ContentPage
	{
		public GameSelectionView ()
		{
			InitializeComponent ();

		    BindingContext = new GameSelectionViewModel();
		}
	}
}