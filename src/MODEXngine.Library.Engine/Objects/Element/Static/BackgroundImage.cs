﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MODEXngine.Library.Engine.Objects.Common;

namespace MODEXngine.Library.Engine.Objects.Element.Static
{
    public class BackgroundImage : BaseGraphicElement
    {
        public override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureElement, new Rectangle(0, 0, Window_Width, Window_Height), Color.White);
        }

        public BackgroundImage(ElementContainer elementContainer, string textureName, bool isVisible = true) : base(elementContainer, textureName, isVisible)
        {
        }
    }
}