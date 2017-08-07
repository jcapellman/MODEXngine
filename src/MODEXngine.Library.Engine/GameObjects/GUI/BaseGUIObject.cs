using System;
using System.Collections.Generic;
using MODEXngine.Library.Engine.Objects.Common;
using MODEXngine.Library.Engine.Objects.Element;
using MODEXngine.Library.Engine.Objects.Element.Static;
using MysticChronicles.Engine.Objects.Element;

namespace MODEXngine.Library.Engine.GameObjects.GUI
{
    public class BaseGUIObject : BaseGameObject
    {
        public BaseGUIObject(ElementContainer container) : base(container)
        {
        }

        public override Tuple<List<BaseGraphicElement>, List<StaticText>> LoadContent()
        {
            return new Tuple<List<BaseGraphicElement>, List<StaticText>>(null, null);
        }
    }
}