using MODEXngine.renderlib.opengl.Enums;

using OpenTK.Graphics.OpenGL;

namespace MODEXngine.renderlib.opengl.Collections
{
    public class DisplayList : IDisplayCollection
    {
        public DisplayCollectionType CollectionType => DisplayCollectionType.Display_List;

        public object Generate() => GL.GenLists(1);

        public void Render(object argument = null)
        {
            if (!(argument is int))
            {
                return;
            }

            GL.CallList((int)argument);
        }
    }
}