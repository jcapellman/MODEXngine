using System.Collections.Generic;

using MODEXngine.Renderer.PCL.Objects.Base;

namespace MODEXngine.Renderer.PCL.Objects {
    public abstract class BaseObject {
        private List<Geometry> _geometry;

        protected BaseObject() {
            _geometry = new List<Geometry>();
        }

        public List<Geometry> GetGeometry() { return _geometry; } 
    }
}