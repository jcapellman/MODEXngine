using System;

using MODEXngine.PCL.Transports.External.Projects;

namespace MODEXngine.WebAPI.Controllers {
    public class ProjectController : BaseApiController {
        public ProjectProfileResponseItem GET(Guid id) {
            return new ProjectProfileResponseItem();
        }
    }
}