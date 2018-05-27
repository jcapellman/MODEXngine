using Xamarin.Forms;

namespace MODEXngine.lib
{
    public abstract class BaseGameHeader
    {
        public abstract string GameName { get; }

        public abstract ImageSource Image { get; }
    }
}