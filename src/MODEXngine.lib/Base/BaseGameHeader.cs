using MODEXngine.lib.CommonObjects;

using Xamarin.Forms;

namespace MODEXngine.lib.Base
{
    public abstract class BaseGameHeader
    {
        public abstract string GameName { get; }

        public abstract ImageSource Image { get; }

        protected BaseRenderer renderer;
        protected Settings settings;

        public void Initialize(BaseRenderer renderer, Settings settings)
        {
            this.renderer = renderer;
            this.settings = settings;

            renderer.Initialize();
        }

        public abstract void Start();
    }
}