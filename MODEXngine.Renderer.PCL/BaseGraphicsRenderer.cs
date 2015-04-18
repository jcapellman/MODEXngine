namespace MODEXngine.Renderer.PCL {
    public abstract class BaseGraphicsRenderer {
        public enum RENDEROPTIONS {
            BLENDING,
            TEXTURING
        }

        public abstract void RenderFrame();

        public abstract void Init();

        public abstract void EnableOption(RENDEROPTIONS option);
    }
}