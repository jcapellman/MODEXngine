using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MODEXngine.Library.Engine.Enums;
using MODEXngine.Library.Engine.Objects.Common;
using MODEXngine.Library.Engine.Objects.Element;
using MODEXngine.Library.Engine.Objects.Element.Static;
using MysticChronicles.Engine.Objects.Element;

namespace MODEXngine.Library.Engine.GameObjects
{
    public abstract class BaseGameObject
    {
        protected ElementContainer _container;

        protected BaseGameObject(ElementContainer container)
        {
            _container = container;
        }

        public abstract Tuple<List<BaseGraphicElement>, List<StaticText>> LoadContent();

        public StaticText AddText(SpriteFont font, string text, Color color, int scale, TextAlignment textAlignment)
        {
            var position = Vector2.One;

            switch (textAlignment)
            {
                case TextAlignment.HORIZONTALLY_AND_VERTICALLY_CENTERED:
                    position.X = (_container.Window_Width - font.MeasureString(text).X) / 2;
                    position.Y = (_container.Window_Height - font.MeasureString(text).Y) / 2;
                    break;
            }

            return AddText(font, text, color, position.X, position.Y, scale);
        }

        public StaticText AddText(SpriteFont font, string text, Color color, float xPosition, float yPosition, int scale)
        {
            return new StaticText(font, text, color, scale, xPosition, yPosition);
        }
    }
}