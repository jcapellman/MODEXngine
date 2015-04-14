using System;

namespace MODEXngine.PCL.Transports.Db {
    public class Game : IEditModel {
        public Guid ID { get; set; }

        public DateTime Modified { get; set; }

        public DateTime Created { get; set; }

        public bool Active { get; set; }

        public string Name { get; set; }
    }
}