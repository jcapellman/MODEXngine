using MODEXngine.lib.wolfenstein3d.Enums;

namespace MODEXngine.lib.wolfenstein3d.Objects
{
    public class GameState
    {
        public int Lives { get; set; }

        public int Health { get; set; }

        public Difficulty Difficulty { get; set; }

        public int Ammo { get; set; }
    }
}