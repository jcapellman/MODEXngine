using System;

namespace MODEXngine.lib.Renderer.Base
{
    public abstract class BaseRenderable
    {
        public abstract Type BaseObject { get; }

        public string TextureFileName { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int OriginX { get; set; }

        public int OriginY { get; set; }

        public abstract void Render();

        public abstract void Initialize<T>(T item) where T : BaseRenderable;
    }
}