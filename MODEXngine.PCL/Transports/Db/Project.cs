using System;

namespace MODEXngine.PCL.Transports.Db {
    public class Project : IEditModel {
        public Guid ID { get; set; }

        public bool Active { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public string Name { get; set; }
    }
}