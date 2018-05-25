using System;

namespace MODEXngine.lib.CommonObjects
{
    public class Resolution
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public int BPP { get; set; }

        public Single RefreshRate { get; set; }

        public override string ToString() => $"{Width}x{Height}x{BPP}@{RefreshRate}";
    }
}