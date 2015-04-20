using System;
using System.Collections.Generic;

using MODEXngine.DataLayer.PCL;

namespace MODEXngine.DataLayer.SQLServer {
    public class SQLServerLayer : BaseDataLayer {
        public override T GetOne<T>(Guid id) {
            throw new NotImplementedException();
        }

        public override Guid AddOne<T>(T obj) {
            throw new NotImplementedException();
        }

        public override List<T> GetAll<T>() {
            throw new NotImplementedException();
        }

        public override bool DeleteOne<T>(Guid id) {
            throw new NotImplementedException();
        }
    }
}