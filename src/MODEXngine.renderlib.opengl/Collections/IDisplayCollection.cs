using MODEXngine.renderlib.opengl.Enums;

namespace MODEXngine.renderlib.opengl.Collections
{
    public interface IDisplayCollection
    {
        DisplayCollectionType CollectionType { get; }

        object Generate();
        
        void Render(object argument = null);
    }
}