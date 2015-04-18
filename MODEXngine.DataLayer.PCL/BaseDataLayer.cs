using System;
using MODEXngine.DataLayer.PCL.Objects;

namespace MODEXngine.DataLayer.PCL {
    public abstract class BaseDataLayer {
        public abstract T GetOne<T>(Guid id) where T : BaseObject;

        public abstract Guid AddOne<T>(T obj) where T : BaseObject;
    }
}