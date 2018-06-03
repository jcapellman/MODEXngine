namespace MODEXngine.lib.Renderer.Objects
{
    public class RenderableProperties
    {
        public string TextureFileName { get; set; }

        public bool TextureRepeated { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int OriginX { get; set; }

        public int OriginY { get; set; }

        public int OriginZ { get; set; }

        public RenderableProperties() { }

        public RenderableProperties(int width, int height, int originX, int originY, int originZ,
            string textureFileName = null, bool textureRepeated = false)
        {
            TextureFileName = textureFileName;
            TextureRepeated = textureRepeated;

            Width = width;
            Height = height;

            OriginX = originX;
            OriginY = originY;
            OriginZ = originZ;
        }
    }
}