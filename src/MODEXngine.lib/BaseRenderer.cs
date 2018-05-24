namespace MODEXngine.lib
{
    public abstract class BaseRenderer
    {
        protected BaseGameHeader GameHeader;

        public void SetGameHeader(BaseGameHeader gameHeader)
        {
            GameHeader = gameHeader;
        }

        public abstract string Name { get; }

        public abstract void Render();
    }
}