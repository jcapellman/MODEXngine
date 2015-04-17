using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OpenTK.Graphics.ES11;
using OpenTK.Platform;
using OpenTK.Platform.Android;
using MODEXngine.Renderer.PCL;
using OpenTK;

namespace MODEXngine.Android {
    public class Renderer : IRenderer {
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

        public void Init() {
            
        }

        public void EnableOption(IRenderer.RENDEROPTIONS option) {
            switch (option) {
                case IRenderer.RENDEROPTIONS.BLENDING:
                    GL.Enable(All.Blend);
                    break;
                case IRenderer.RENDEROPTIONS.TEXTURING:
                    GL.Enable(All.Texture2D);
                    break;
            }
        }

        public void RenderFrame() {
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