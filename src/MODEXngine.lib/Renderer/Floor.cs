using System;

using MODEXngine.lib.Renderer.Base;

namespace MODEXngine.lib.Renderer
{
    public class Floor : BaseRenderable
    {
        public Floor(string textureFileName, bool repeated, int width, int height, int originX, int originY, int originZ)
        {
            TextureFileName = textureFileName;
            Width = width;
            Height = height;
            OriginX = originX;
            OriginY = originY;
            OriginZ = originZ;
            TextureRepeated = repeated;
        }

        public override Type BaseObject => typeof(Floor);

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