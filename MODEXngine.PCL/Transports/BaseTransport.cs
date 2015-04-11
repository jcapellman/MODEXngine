using System;
using System.Runtime.Serialization;

namespace MODEXngine.PCL.Transports {
    public class BaseTransport {
        [DataMember]
        public Guid TransactionID { get; set; }
    }
}