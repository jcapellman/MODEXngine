using MODEXngine.lib.Base;
using MODEXngine.lib.Enums;
using MODEXngine.lib.Renderer.Objects;

using Xamarin.Forms;

namespace MODEXngine.lib.wolfenstein3d
{
    public class GameHeader : BaseGameHeader
    {
        public override string GameName => "Wolfenstein 3D";

        public override ImageSource Image => ImageSource.FromResource("MODEXngine.lib.wolfenstein3d.Resources.boxart.jpg");

        public override void Start()
        {
            renderer.AddRenderable(RenderableTypes.FLOOR, new RenderableProperties(2048, 2048, 0, 10, 0, "floor.png", true));

            renderer.AddRenderable(RenderableTypes.CEILING, new RenderableProperties(2048, 2048, 0, 128, 0, "ceiling.png", true));

            renderer.AddRenderable(RenderableTypes.WALL, new RenderableProperties(128, 128, 0, 0, 0, "wall.png"));
           
            renderer.Start();

            renderer.EventOccurred += Renderer_EventOccurred;
        }

        private void Renderer_EventOccurred(object sender, (EventTypes eventType, object obj) e)
        {
            switch (e.eventType)
            {
                case EventTypes.KEYBOARD_KEY_HIT:
                    
                    break;
            }
        }
    }
}