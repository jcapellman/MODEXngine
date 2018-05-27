using MODEXngine.ViewModels;

using Xamarin.Forms;

namespace MODEXngine.Controls
{
	public partial class GameCarouselItem : ContentView
    {
        private GameCarouselViewModel ViewModel => (GameCarouselViewModel)BindingContext;

        public static readonly BindableProperty ImageSrcProperty = BindableProperty.Create(nameof(ImageSrc), typeof(ImageSource), typeof(GameCarouselItem));

	    public ImageSource ImageSrc
	    {
	        get => ViewModel.ImageSrc;
	        set => ViewModel.ImageSrc = value;
	    }

        public static readonly BindableProperty GameNameProperty = BindableProperty.Create(nameof(GameName), typeof(string), typeof(GameCarouselItem));

        public string GameName
        {
            get => ViewModel.GameName;
            set => ViewModel.GameName = value;

        }

        public GameCarouselItem ()
		{
			InitializeComponent();

		    BindingContext = new GameCarouselViewModel();
		}
	}
}