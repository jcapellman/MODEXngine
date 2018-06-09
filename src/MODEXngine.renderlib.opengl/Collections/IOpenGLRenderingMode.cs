using MODEXngine.lib.Renderer;
using MODEXngine.renderlib.opengl.Enums;

namespace MODEXngine.renderlib.opengl.Collections
{
    public abstract class BaseOpenGLRenderingMode : IRenderingMode
    {
        public abstract RenderingModeType RenderingModeType { get; }
        
        string IRenderingMode.Mode => RenderingModeType.ToString();

        public abstract object Generate();
        
        public abstract void Render(object argument = null);
    }
}