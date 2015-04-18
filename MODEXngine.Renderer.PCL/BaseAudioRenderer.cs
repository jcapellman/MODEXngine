using MODEXngine.Renderer.PCL.Enums;

namespace MODEXngine.Renderer.PCL {
    public abstract class BaseAudioRenderer : BaseRenderer {
        public override RendererTypes TypeOfRenderer() {
            return RendererTypes.AUDIO;
        }

        public abstract void Render();
    }
}