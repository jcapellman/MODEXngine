using MODEXngine.renderlib.opengl.Renderables.Base;

using OpenTK.Graphics.OpenGL;

namespace MODEXngine.renderlib.opengl.Renderables
{
    public class Wall : BaseOpenGLRenderable
    {
        public Wall(string textureFileName) : base(textureFileName) { }

        public override void Render()
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.PushMatrix();
            GL.LoadIdentity();

            GL.Ortho(0, 800, 0, 600, -1, 1);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();
            GL.LoadIdentity();

            GL.Disable(EnableCap.Lighting);

            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, TextureId);

            GL.Begin(PrimitiveType.Quads);
                GL.TexCoord2(0, 0);
                GL.Vertex3(0, 0, 0);

                GL.TexCoord2(1, 0);
                GL.Vertex3(256, 0, 0);

                GL.TexCoord2(1, 1);
                GL.Vertex3(256, 256, 0);

                GL.TexCoord2(0, 1);
                GL.Vertex3(0, 256, 0);
            GL.End();

            GL.Disable(EnableCap.Texture2D);
            GL.PopMatrix();

            GL.MatrixMode(MatrixMode.Projection);
            GL.PopMatrix();

            GL.MatrixMode(MatrixMode.Modelview);
        }
    }
}