using MODEXngine.Renderer.PCL.Enums;

namespace MODEXngine.Renderer.PCL {
    public abstract class BaseGraphicsRenderer : BaseRenderer {
        public enum RENDEROPTIONS {
            BLENDING,
            TEXTURING
        }

        public override RendererTypes TypeOfRenderer() {
            return RendererTypes.GRAPHICS;
        }

        public abstract void RenderFrame();

        public abstract void Init();

        public abstract void EnableOption(RENDEROPTIONS option);
    }
}