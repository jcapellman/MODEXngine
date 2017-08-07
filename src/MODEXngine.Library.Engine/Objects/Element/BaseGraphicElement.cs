﻿using Microsoft.Xna.Framework.Graphics;
using MODEXngine.Library.Engine.Objects.Common;

namespace MODEXngine.Library.Engine.Objects.Element
{
    public abstract class BaseGraphicElement : BaseElement
    {
        protected Texture2D TextureElement;
        protected int Window_Width;
        protected int Window_Height;

        protected BaseGraphicElement(ElementContainer elementContainer, string textureName, bool isVisible)
        {
            TextureElement = elementContainer.TextureManager.LoadTexture(textureName);

            Window_Width = elementContainer.Window_Width;
            Window_Height = elementContainer.Window_Height;

            IsVisible = isVisible;
        }

        public abstract void Render(SpriteBatch spriteBatch);
    }
}