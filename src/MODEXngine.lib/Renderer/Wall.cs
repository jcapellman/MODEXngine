using System;

using MODEXngine.lib.Renderer.Base;

namespace MODEXngine.lib.Renderer
{
    public class Wall : BaseRenderable
    {
        public Wall(string textureFileName, int width, int height, int originX, int originY)
        {
            TextureFileName = textureFileName;
            Width = width;
            Height = height;
            OriginX = originX;
            OriginY = originY;
        }

        public override Type BaseObject => typeof(Wall);

        public override void Render()
        {
            throw new NotImplementedException();
        }

        public override void Initialize<T>(T item)
        {
            throw new NotImplementedException();
        }
    }
}