namespace MODEXngine.lib
{
    public abstract class BaseRenderer
    {
        protected BaseGameHeader GameHeader;

        protected BaseRenderer(BaseGameHeader gameHeader)
        {
            GameHeader = gameHeader;
        }

        public abstract void Render();
    }
}