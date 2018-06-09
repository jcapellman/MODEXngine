namespace MODEXngine.lib.Renderer
{
    public interface IRenderingMode
    {
        string Mode { get; }

        object Generate();
        
        void Render(object argument = null);
    }
}