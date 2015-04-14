using System;

namespace MODEXngine.PCL.Transports.Db {
    public interface IEditModel {
        Guid ID { get; set; }

        DateTime Modified { get; set; }

        DateTime Created { get; set; }

        bool Active { get; set; }
    }
}