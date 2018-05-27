namespace MODEXngine.lib
{
    public abstract class BaseGameHeader
    {
        public abstract string GameName { get; }

        public abstract byte[] Image { get; }
    }
}