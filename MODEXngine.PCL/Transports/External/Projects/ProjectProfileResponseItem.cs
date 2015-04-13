using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MODEXngine.PCL.Transports.External.Projects {
    public class ProjectProfileResponseItem : BaseTransport {
        [DataMember]
        public Guid ID { get; set; }
    }
}