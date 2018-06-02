using MODEXngine.lib.Base;
using Xamarin.Forms;

namespace MODEXngine.lib.darkforces
{
    public class GameHeader : BaseGameHeader
    {
        public override string GameName => "Dark Forces";

        public override ImageSource Image => ImageSource.FromResource("MODEXngine.lib.darkforces.Resources.darkforcesboxart.jpg");
    }
}