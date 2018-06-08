using System;
using System.Collections.Generic;
using System.Linq;

using MODEXngine.lib.Base;
using MODEXngine.lib.CommonObjects;
using MODEXngine.lib.Enums;
using MODEXngine.renderlib.opengl.Renderables.Base;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace MODEXngine.renderlib.opengl
{
    public class OpenGLRenderer : BaseRenderer
    {
        private OpenTK.GameWindow gWindow;
        KeyboardState keyboardState;
        private float xpos = 0.0f;
        private float zpos = 0.0f;

        private float yrot = 0.0f;
        private float lookupdown = 0.0f;

        private bool KeyPress(Key key) => keyboardState[key];

        private void GWindow_UpdateFrame(object sender, FrameEventArgs e)
        {
            keyboardState = Keyboard.GetState();

            if (!keyboardState.IsAnyKeyDown)
            {
                return;
            }
            
            if (KeyPress(Key.W))
            {
                OnEventOccurred(EventTypes.KEYBOARD_KEY_HIT, KeyboardInput.W);
            } else if (KeyPress(Key.S))
            {
                OnEventOccurred(EventTypes.KEYBOARD_KEY_HIT, KeyboardInput.S);
            } else if (KeyPress(Key.A))
            {
                OnEventOccurred(EventTypes.KEYBOARD_KEY_HIT, KeyboardInput.A);
            } else if (KeyPress(Key.D))
            {
                OnEventOccurred(EventTypes.KEYBOARD_KEY_HIT, KeyboardInput.D);
            }
        }

        private void GWindow_RenderFrame(object sender, OpenTK.FrameEventArgs e)
        {
            GL.ClearColor(1, 0, 0, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            GL.LoadIdentity();

            double xtrans = -xpos;
            double ztrans = -zpos;
            double sceneroty = 360.0f - yrot;

            GL.Rotate(lookupdown, 1.0f, 0.0, 0.0);
            GL.Rotate(sceneroty, 0, 1.0f, 0);

            GL.Translate(xtrans, 0.25f, ztrans);
            
            foreach (var renderable in renderables)
            {
                renderable.Render();
            }

            GL.Flush();

            gWindow.SwapBuffers();
        }

        public override string Name => "OpenGL";

        private static void SetPerspective(double fovY, double aspect, double zNear, double zFar)
        {
            const double pi = 3.1415926535897932384626433832795;

            GL.Frustum(-(Math.Tan(fovY / 360 * pi) * zNear * aspect), Math.Tan(fovY / 360 * pi) * zNear * aspect, -(Math.Tan(fovY / 360 * pi) * zNear), Math.Tan(fovY / 360 * pi) * zNear, zNear, zFar);
        }

        public override void Initialize()
        {
            gWindow = new GameWindow(Settings.Resolution.Width, Settings.Resolution.Height, GraphicsMode.Default)
            {
                Title = GameTitle
            };

            gWindow.RenderFrame += GWindow_RenderFrame;
            gWindow.Closed += GWindow_Closed;
            gWindow.UpdateFrame += GWindow_UpdateFrame;
            
            if (Settings.IsFullScreen)
            {
                gWindow.WindowState = WindowState.Fullscreen;
            }

            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.DepthTest);

            GL.ShadeModel(ShadingModel.Smooth);

            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.5f);
            GL.ClearDepth(1.0f);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            GL.Viewport(0, 0, Settings.Resolution.Width, Settings.Resolution.Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            
            SetPerspective(45.0f, (double)Settings.Resolution.Width / Settings.Resolution.Height, 0.1, 100.0);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            
            InitializeImplementations(typeof(OpenGLRenderer), typeof(BaseOpenGLRenderable));
        }

        public override void Start()
        {
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