using System.Collections.Generic;
using System.Linq;

using MODEXngine.lib;
using MODEXngine.lib.Base;
using MODEXngine.lib.CommonObjects;
using MODEXngine.renderlib.opengl.Renderables.Base;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace MODEXngine.renderlib.opengl
{
    public class OpenGLRenderer : BaseRenderer
    {
        private List<BaseOpenGLRenderable> _renderables = new List<BaseOpenGLRenderable>();

        private OpenTK.GameWindow gWindow;
        
        private void GWindow_RenderFrame(object sender, OpenTK.FrameEventArgs e)
        {
            GL.ClearColor(1, 0, 0, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            foreach (var renderable in _renderables)
            {
                renderable.Render();
            }

            gWindow.SwapBuffers();
        }

        public override string Name => "OpenGL";

        public override void Render()
        {
            gWindow = new OpenTK.GameWindow(Settings.Resolution.Width, Settings.Resolution.Height, GraphicsMode.Default)
            {
                Title = GameHeader.GameName
            };

            gWindow.RenderFrame += GWindow_RenderFrame;
            gWindow.Closed += GWindow_Closed;

            if (Settings.IsFullScreen)
            {
                gWindow.WindowState = WindowState.Fullscreen;
            }

            gWindow.Run(1.0 / 60.0);
        }

        private void GWindow_Closed(object sender, System.EventArgs e)
        {
            OnWindowClosed();
        }

        public override List<Resolution> SupportedResolutions() => OpenTK.DisplayDevice.GetDisplay(0).AvailableResolutions.Select(a => new Resolution
        {
            Height = a.Height,
            Width = a.Width,
            Bpp = a.BitsPerPixel,
            RefreshRate = (int) a.RefreshRate
        }).ToList();
    }
}