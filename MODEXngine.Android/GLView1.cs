using System;

using OpenTK;
using OpenTK.Platform.Android;
using Android.Content;

namespace MODEXngine.Android {
    class GLView1 : AndroidGameView {
        private Renderer _renderer;

        public GLView1(Context context) : base(context) { }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            Run();
        }

        protected override void CreateFrameBuffer() {
            _renderer = new Renderer();

            _renderer.Init();

            base.CreateFrameBuffer();
        }

        protected override void OnRenderFrame(FrameEventArgs e) {
            base.OnRenderFrame(e);

            _renderer.RenderFrame();

            SwapBuffers();
        }
    }
}