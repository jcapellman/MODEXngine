namespace MODEXngine.Renderer.PCL {
    public interface IRenderer {
        public enum RENDEROPTIONS {
            BLENDING,
            TEXTURING
        }

        void RenderFrame();

        void Init();

        void EnableOption(RENDEROPTIONS option);
    }
}