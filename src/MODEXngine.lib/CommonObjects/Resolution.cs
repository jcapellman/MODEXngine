namespace MODEXngine.lib.CommonObjects
{
    public class Resolution
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public int Bpp { get; set; }

        public float RefreshRate { get; set; }

        public override string ToString() => $"{Width}x{Height}x{Bpp}@{RefreshRate}";
    }
}