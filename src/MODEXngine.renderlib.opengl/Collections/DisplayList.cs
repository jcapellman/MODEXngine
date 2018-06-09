using MODEXngine.renderlib.opengl.Enums;

using OpenTK.Graphics.OpenGL;

namespace MODEXngine.renderlib.opengl.Collections
{
    public class DisplayList : BaseOpenGLRenderingMode
    {
        public override RenderingModeType RenderingModeType => RenderingModeType.Display_List;

        public override void Render(object argument = null)
        {
            if (!(argument is int))
            {
                return;
            }

            GL.CallList((int)argument);
        }

        public override object Generate() => GL.GenLists(1);
    }
}