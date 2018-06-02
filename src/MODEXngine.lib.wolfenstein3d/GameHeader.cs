using MODEXngine.lib.Base;
using Xamarin.Forms;

namespace MODEXngine.lib.wolfenstein3d
{
    public class GameHeader : BaseGameHeader
    {
        public override string GameName => "Wolfenstein 3D";

        public override ImageSource Image => ImageSource.FromResource("MODEXngine.lib.wolfenstein3d.Resources.boxart.jpg");
    }
}