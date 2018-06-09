using MODEXngine.lib.Enums;
using MODEXngine.lib.Renderer.Objects;
using MODEXngine.renderlib.opengl.Collections;
using MODEXngine.renderlib.opengl.Enums;
using MODEXngine.renderlib.opengl.Renderables.Base;

using NLog;

using OpenTK.Graphics.OpenGL;

namespace MODEXngine.renderlib.opengl.Renderables
{
    public class WallOpenGL : BaseOpenGLRenderable
    {
        public WallOpenGL(BaseOpenGLRenderingMode renderingMode) : base(renderingMode) { }

        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public override RenderableTypes RenderableType => RenderableTypes.WALL;

        protected override void RenderRaw()
        {
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, TextureId);

            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 0);
            GL.Vertex3(Properties.OriginX, Properties.OriginY, 0);

            GL.TexCoord2(1, 0);
            GL.Vertex3(Properties.OriginX + Properties.Width, Properties.OriginY, 0);

            GL.TexCoord2(1, 1);
            GL.Vertex3(Properties.OriginX + Properties.Width, Properties.OriginY + Properties.Height, 0);

            GL.TexCoord2(0, 1);
            GL.Vertex3(Properties.OriginX, Properties.OriginY + Properties.Height, 0);
            GL.End();

            GL.Disable(EnableCap.Texture2D);
        }

        protected override void InitializeDisplayList()
        {
            DisplayListId = (int) RenderingMode.Generate();

            GL.NewList(DisplayListId, ListMode.Compile);
           
            RenderRaw();

            GL.EndList();
        }

        protected override void InitializeVBO()
        {

        }

        public override void Initialize(RenderableProperties renderableProperties)
        {
            Init(renderableProperties);
        }
    }
}