using System.Collections.Generic;
using MODEXngine.lib.CommonObjects;

namespace MODEXngine.lib
{
    public abstract class BaseRenderer
    {
        protected BaseGameHeader GameHeader;
        protected Settings Settings;

        public void SetGameLaunchItems(BaseGameHeader gameHeader, Settings settings)
        {
            GameHeader = gameHeader;
            Settings = settings;
        }

        public abstract string Name { get; }

        public abstract void Render();

        public abstract List<Resolution> SupportedResolutions();
    }
}