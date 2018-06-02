using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using MODEXngine.lib.Renderer.Base;

using OpenTK.Graphics.OpenGL;

namespace MODEXngine.renderlib.opengl.Renderables.Base
{
    // ReSharper disable once InconsistentNaming
    public abstract class BaseOpenGLRenderable : BaseRenderable
    {
        protected readonly int TextureId;

        private static int LoadTexture(string fileName)
        {
            var textureId = GL.GenTexture();

            var texture = new Bitmap(fileName);

            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            GL.BindTexture(TextureTarget.Texture2D, textureId);
            var data = texture.LockBits(new Rectangle(0, 0, texture.Width, texture.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, texture.Width, texture.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            texture.UnlockBits(data);

            
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Clamp);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Clamp);

            // TODO Make the Filtering configurable
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)All.Linear);

            return textureId;
        }

        protected BaseOpenGLRenderable(string textureFileName = null)
        {
            if (string.IsNullOrEmpty(textureFileName) || !File.Exists(textureFileName))
            {
                return;
            }

            TextureId = LoadTexture(textureFileName);
        }
    }
}