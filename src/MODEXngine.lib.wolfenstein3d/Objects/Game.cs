using MODEXngine.lib.wolfenstein3d.Enums;

namespace MODEXngine.lib.wolfenstein3d.Objects
{
    public class Game
    {
        public int Health { get; set; }

        public Difficulty Difficulty { get; set; }

        public int Ammo { get; set; }

        public Episode Episode { get; set; }

        public Game() { }

        public Game NewGame(Difficulty difficulty, Episode episode)
        {
            Difficulty = difficulty;
            Ammo = Common.Constants.NEWGAME_AMMO;
            Health = Common.Constants.NEWGAME_HEALTH;
            Episode = episode;

            return this;
        }

        public Game SetGame(Difficulty difficulty, int health, int ammo)
        {
            Difficulty = difficulty;
            Ammo = ammo;
            Health = health;

            return this;
        }
    }
}