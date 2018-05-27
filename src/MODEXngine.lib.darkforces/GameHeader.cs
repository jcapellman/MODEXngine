using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace MODEXngine.lib.darkforces
{
    public class GameHeader : BaseGameHeader
    {
        public override string GameName => "Dark Forces";

        public override ImageSource Image
        {
            get
            {

                var source = ImageSource.FromResource("MODEXngine.lib.darkforces.Resources.darkforcesboxart.jpg");

                var assembly = typeof(GameHeader).GetTypeInfo().Assembly;
                var resource = assembly.GetManifestResourceStream(@"MODEXngine.lib.darkforces.Resources.darkforcesboxart.jpg");

                var ms = new MemoryStream();
                resource?.CopyTo(ms);

                var source2 = ImageSource.FromStream(() => ms);

                return source2;
            }
        }
    }
}