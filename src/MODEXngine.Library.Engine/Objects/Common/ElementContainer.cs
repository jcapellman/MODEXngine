﻿using Microsoft.Xna.Framework.Graphics;
using MODEXngine.Library.Engine.Managers;

namespace MODEXngine.Library.Engine.Objects.Common
{
    public class ElementContainer
    {
        public int Window_Width { get; set; }

        public int Window_Height { get; set; }

        public TextureManager TextureManager { get; set; }

        public SpriteFont Font { get; set; }
        
        public GameContainer GContainer { get; set; }
    }
}