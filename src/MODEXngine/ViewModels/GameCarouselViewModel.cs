using MODEXngine.ViewModels.Base;

using Xamarin.Forms;

namespace MODEXngine.ViewModels
{
    public class GameCarouselViewModel : BaseViewModel
    {
        private ImageSource _imageSource;

        public ImageSource ImageSrc
        {
            get => _imageSource;

            set
            {
                _imageSource = value;
                OnPropertyChanged();
            }
        }

        private string _gameName;

        public string GameName
        {
            get => _gameName;

            set
            {
                _gameName = value;
                OnPropertyChanged();
            }
        }
    }
}