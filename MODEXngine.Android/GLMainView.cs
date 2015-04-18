using System;

using OpenTK;
using OpenTK.Platform.Android;

using Android.Content;

using MODEXngine.Android.Library;

namespace MODEXngine.Android {
    class GLMainView : AndroidGameView {
        private GraphicsRenderer _graphicsRenderer;

        public GLMainView(Context context) : base(context) { }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            Run();
        }

        protected override void CreateFrameBuffer() {
            _graphicsRenderer = new GraphicsRenderer();

            _graphicsRenderer.Init();

            base.CreateFrameBuffer();
        }

        protected override void OnRenderFrame(FrameEventArgs e) {
            base.OnRenderFrame(e);

            _graphicsRenderer.RenderFrame();

            SwapBuffers();
        }
    }
}