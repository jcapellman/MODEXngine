using MODEXngine.renderlib.opengl.Renderables.Base;

using OpenTK.Graphics.OpenGL;

namespace MODEXngine.renderlib.opengl.Renderables
{
    public class Wall : BaseOpenGLRenderable
    {
        public override void Render()
        {
            GL.Begin(PrimitiveType.Quads);
                GL.TexCoord2(0, 1); GL.Vertex2(0, 32);
                GL.TexCoord2(1, 1); GL.Vertex2(32, 32);
                GL.TexCoord2(1, 0); GL.Vertex2(32, 0);
                GL.TexCoord2(0, 0); GL.Vertex2(0, 0);
            GL.End();
        }
    }
}