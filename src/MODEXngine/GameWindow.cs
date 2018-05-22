using MODEXngine.lib;

using OpenTK.Graphics;

namespace MODEXngine
{
    public class GameWindow
    {
        private OpenTK.GameWindow gWindow;

        public GameWindow(BaseGameHeader gameHeader)
        {
            gWindow = new OpenTK.GameWindow(640, 480, GraphicsMode.Default)
            {
                Title = gameHeader.GameName
            };
        }

        public void Run()
        {
            gWindow.Run(1.0 / 60.0);
        }
    }
}