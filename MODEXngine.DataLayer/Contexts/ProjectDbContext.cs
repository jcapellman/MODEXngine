using System.Data.Entity;

using MODEXngine.PCL.Transports.External.Projects;

namespace MODEXngine.DataLayer.Contexts {
    public class ProjectDbContext : BaseDbContext {
        public DbSet<ProjectProfileResponseItem> Projects { get; set; } 
    }
}