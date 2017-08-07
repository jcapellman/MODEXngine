﻿using MODEXngine.Library.Engine.GameObjects;
using MODEXngine.Library.Engine.Objects.Common;

namespace MysticChronicles.Engine.GameObjects.Characters
{
    public abstract class BaseCharacterObject : BaseGameObject
    {
        protected string Name { get; set; }

        protected BaseCharacterObject(ElementContainer container) : base(container) { }
    }
}