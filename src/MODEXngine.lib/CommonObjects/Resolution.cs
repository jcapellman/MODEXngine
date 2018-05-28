using System;
using System.Runtime.Serialization;

namespace MODEXngine.lib.CommonObjects
{
    [DataContract]
    public class Resolution
    {
        [DataMember]
        public int Width { get; set; }

        [DataMember]
        public int Height { get; set; }

        [DataMember]
        public int Bpp { get; set; }

        [DataMember]
        public int RefreshRate { get; set; }

        public string DisplayString => $"{Width}x{Height}x{Bpp}@{RefreshRate}";

        public override bool Equals(object obj) => obj is Resolution other && Equals(other);

        public bool Equals(Resolution other)
        {
            if (other == null)
            {
                return false;
            }

            return Bpp == other.Bpp && Width == other.Width && Height == other.Height && RefreshRate == other.RefreshRate;
        }
    }
}