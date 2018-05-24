﻿using MODEXngine.lib;

using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace MODEXngine.renderlib.opengl
{
    public class OpenGLRenderer : BaseRenderer
    {
        private OpenTK.GameWindow gWindow;

        public OpenGLRenderer()
        {
            gWindow = new OpenTK.GameWindow(640, 480, GraphicsMode.Default)
            {
                Title = string.Empty
            };

            gWindow.RenderFrame += GWindow_RenderFrame;
        }

        private void GWindow_RenderFrame(object sender, OpenTK.FrameEventArgs e)
        {
            GL.ClearColor(0, 0, 0, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            gWindow.SwapBuffers();
        }

        public override string Name => "OpenGL";

        public override void Render()
        {
            gWindow.Title = GameHeader.GameName;

            gWindow.Run(1.0 / 60.0);
        }
    }
}