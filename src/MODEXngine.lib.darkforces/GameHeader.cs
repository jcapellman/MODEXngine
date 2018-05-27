using System.IO;
using System.Reflection;

namespace MODEXngine.lib.darkforces
{
    public class GameHeader : BaseGameHeader
    {
        public override string GameName => "Dark Forces";

        public override byte[] Image
        {
            get
            {
                var assembly = typeof(GameHeader).GetTypeInfo().Assembly;
                var resource = assembly.GetManifestResourceStream(@"Resources\darkforcesboxart.jpg");

                var memoryStream = new MemoryStream();
                resource?.CopyTo(memoryStream);

                return memoryStream.ToArray();
            }
        }
    }
}