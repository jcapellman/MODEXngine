using MODEXngine.lib.Enums;
using MODEXngine.lib.Renderer.Objects;
using MODEXngine.renderlib.opengl.Renderables.Base;

using OpenTK.Graphics.OpenGL;

namespace MODEXngine.renderlib.opengl.Renderables
{
    public class FloorOpenGL : BaseOpenGLRenderable
    {
        public override RenderableTypes RenderableType => RenderableTypes.FLOOR;
        public override void Initialize(RenderableProperties renderableProperties)
        {
            Init(renderableProperties);

            DisplayListId = GL.GenLists(1);

            GL.NewList(DisplayListId, ListMode.Compile);
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, TextureId);

            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 0);
            GL.Vertex3(Properties.OriginX, Properties.OriginY, Properties.OriginZ);

            GL.TexCoord2(1, 0);
            GL.Vertex3(Properties.OriginX + Properties.Width, Properties.OriginY, Properties.OriginZ);

            GL.TexCoord2(1, 1);
            GL.Vertex3(Properties.OriginX + Properties.Width, Properties.OriginY, Properties.OriginZ + Properties.Height);

            GL.TexCoord2(0, 1);
            GL.Vertex3(Properties.OriginX, Properties.OriginY, Properties.OriginZ + Properties.Height);
            GL.End();

            GL.Disable(EnableCap.Texture2D);
            GL.EndList();
        }
    }
}