using System;
using System.Collections.Generic;

using MODEXngine.DataLayer.PCL.Objects;

namespace MODEXngine.DataLayer.PCL {
    public abstract class BaseDataLayer {
        public abstract T GetOne<T>(Guid id) where T : BaseObject;

        public abstract Guid AddOne<T>(T obj) where T : BaseObject;

        public abstract List<T> GetAll<T>() where T : BaseObject;

        public abstract bool DeleteOne<T>(Guid id) where T : BaseObject;
    }
}