using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MODEXngine.PCL.Transports.Internal {
    [DataContract]
    public class AuthUserToken {
        [DataMember]
        public Guid ID { get; set; }

        [DataMember]
        public List<Guid> AccessibleProjects { get; set; }
    }
}