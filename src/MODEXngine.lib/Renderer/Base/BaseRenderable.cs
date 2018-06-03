using MODEXngine.lib.Enums;
using MODEXngine.lib.Renderer.Objects;

namespace MODEXngine.lib.Renderer.Base
{
    public abstract class BaseRenderable
    {
        public RenderableProperties Properties { get; set; }

        public abstract RenderableTypes RenderableType { get; }
        
        public abstract void Render();

        public abstract void Initialize(RenderableProperties renderableProperties);
    }
}