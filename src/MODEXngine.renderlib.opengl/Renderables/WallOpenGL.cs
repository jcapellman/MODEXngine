using System;

using MODEXngine.renderlib.opengl.Renderables.Base;

using OpenTK.Graphics.OpenGL;

namespace MODEXngine.renderlib.opengl.Renderables
{
    public class WallOpenGL : BaseOpenGLRenderable
    {
        public override Type BaseObject => typeof(lib.Renderer.Wall);

        public override void Initialize<T>(T item)
        {
            Initialize(item);

            DisplayListId = GL.GenLists(1);

            GL.NewList(DisplayListId, ListMode.Compile);
                GL.Enable(EnableCap.Texture2D);
                GL.BindTexture(TextureTarget.Texture2D, TextureId);

                GL.Begin(PrimitiveType.Quads);
                GL.TexCoord2(0, 0);
                GL.Vertex3(OriginX, OriginY, 0);

                GL.TexCoord2(1, 0);
                GL.Vertex3(Width, OriginY, 0);

                GL.TexCoord2(1, 1);
                GL.Vertex3(Width, Height, 0);

                GL.TexCoord2(0, 1);
                GL.Vertex3(OriginX, Height, 0);
                GL.End();

                GL.Disable(EnableCap.Texture2D);
            GL.EndList();
        }
    }
}