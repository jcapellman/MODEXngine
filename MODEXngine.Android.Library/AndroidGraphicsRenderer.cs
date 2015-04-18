using OpenTK.Graphics.ES11;

using MODEXngine.Renderer.PCL;

namespace MODEXngine.Android.Library {
    public class AndroidGraphicsRenderer : BaseGraphicsRenderer {
        float[] square_vertices = {
			-0.5f, -0.5f,
			0.5f, -0.5f,
			-0.5f, 0.5f, 
			0.5f, 0.5f,
		};

        byte[] square_colors = {
			255, 255,   0, 255,
			0,   255, 255, 255,
			0,     0,    0,  0,
			255,   0,  255, 255,
		};

        public override void Init() {
            
        }

        public override void EnableOption(RENDEROPTIONS option) {
            switch (option) {
                case RENDEROPTIONS.BLENDING:
                    GL.Enable(All.Blend);
                    break;
                case RENDEROPTIONS.TEXTURING:
                    GL.Enable(All.Texture2D);
                    break;
            }
        }

        public override void RenderFrame() {
            GL.MatrixMode(All.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0f, 1.0f, -1.5f, 1.5f, -1.0f, 1.0f);
            GL.MatrixMode(All.Modelview);
            GL.Rotate(3.0f, 0.0f, 0.0f, 1.0f);

            GL.ClearColor(0.5f, 0.5f, 0.5f, 1.0f);
            GL.Clear((uint)All.ColorBufferBit);

            GL.VertexPointer(2, All.Float, 0, square_vertices);
            GL.EnableClientState(All.VertexArray);
            GL.ColorPointer(4, All.UnsignedByte, 0, square_colors);
            GL.EnableClientState(All.ColorArray);

            GL.DrawArrays(All.TriangleStrip, 0, 4);
        }
    }
}