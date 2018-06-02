using MODEXngine.lib.Base;
using MODEXngine.lib.Renderer;

using Xamarin.Forms;

namespace MODEXngine.lib.wolfenstein3d
{
    public class GameHeader : BaseGameHeader
    {
        public override string GameName => "Wolfenstein 3D";

        public override ImageSource Image => ImageSource.FromResource("MODEXngine.lib.wolfenstein3d.Resources.boxart.jpg");

        public override void Start()
        {
            renderer.AddRenderable(new Wall("wall.png", 128, 128, 0, 0));

            renderer.Start();
        }
    }
}