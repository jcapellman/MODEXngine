using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using MODEXngine.lib.Renderer.Base;
using MODEXngine.lib.Renderer.Objects;

using NLog;

using OpenTK.Graphics.OpenGL;

namespace MODEXngine.renderlib.opengl.Renderables.Base
{
    // ReSharper disable once InconsistentNaming
    public abstract class BaseOpenGLRenderable : BaseRenderable
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        protected int TextureId;
        protected int DisplayListId;

        private static int LoadTexture(string fileName, bool repeated = false)
        {
            var textureId = GL.GenTexture();

            var texture = new Bitmap(fileName);

            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            GL.BindTexture(TextureTarget.Texture2D, textureId);

            var data = texture.LockBits(new Rectangle(0, 0, texture.Width, texture.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, texture.Width, 
                texture.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            texture.UnlockBits(data);

            if (repeated)
            {
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            }
            else
            {
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS,
                    (int) TextureWrapMode.ClampToBorder);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT,
                    (int) TextureWrapMode.ClampToBorder);
            }

            // TODO Make the Filtering configurable
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)All.Linear);

            return textureId;
        }

        public override void Render()
        {
            GL.CallList(DisplayListId);
        }

        protected void Init(RenderableProperties properties)
        {
            Properties = properties;
            
            if (string.IsNullOrEmpty(Properties.TextureFileName))
            {
                Log.Debug("Texture filename was not set");
                return;
            }

            if (!File.Exists(Properties.TextureFileName))
            {
                Log.Error($"Could not find {Properties.TextureFileName}");

                return;
            }

            TextureId = LoadTexture(Properties.TextureFileName, Properties.TextureRepeated);
        }
    }
}