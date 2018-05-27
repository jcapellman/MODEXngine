using Xamarin.Forms;

namespace MODEXngine.Controls
{
	public partial class GameCarouselItem : ContentPage
	{
	    public static readonly BindableProperty ImageBytesProperty = BindableProperty.Create(nameof(ImageBytes), typeof(byte[]), typeof(GameCarouselItem));

	    public byte[] ImageBytes
	    {
	        get => (byte[])GetValue(ImageBytesProperty);
	        set => SetValue(ImageBytesProperty, value);
	    }

        public GameCarouselItem ()
		{
			InitializeComponent();
		}
	}
}