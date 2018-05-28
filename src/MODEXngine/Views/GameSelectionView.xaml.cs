using MODEXngine.ViewModels;
using MODEXngine.Views.Base;

namespace MODEXngine.Views
{	
	public partial class GameSelectionView : BaseContentPage
	{
		public GameSelectionView ()
		{
			InitializeComponent ();

		    SetBindingContext(new GameSelectionViewModel());
		}
	}
}