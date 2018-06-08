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
        public WallOpenGL(IDisplayCollection renderingCollectionMode) : base(renderingCollectionMode) { }

        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public override RenderableTypes RenderableType => RenderableTypes.WALL;

        private void GenerateDisplayList()
        {
            DisplayListId = (int) RenderingCollectionMode.Generate();

            GL.NewList(DisplayListId, ListMode.Compile);
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
            GL.EndList();
        }

        public override void Initialize(RenderableProperties renderableProperties)
        {
            Init(renderableProperties);
            
            switch (RenderingCollectionMode.CollectionType)
            {
                case DisplayCollectionType.Display_List:
                    GenerateDisplayList();
                    break;
                case DisplayCollectionType.Raw:
                    break;
                case DisplayCollectionType.Vertex_Buffer_Object:
                    break;
                default:
                    Log.Error($"Rendering Collection not implemented for {RenderingCollectionMode.CollectionType}");
                    break;
            }
        }
    }
}