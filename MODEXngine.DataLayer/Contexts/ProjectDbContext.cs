using System.Data.Entity;

using MODEXngine.PCL.Common;
using MODEXngine.PCL.Transports.Db;

namespace MODEXngine.DataLayer.Contexts {
    public class ProjectDbContext : BaseDbContext {
        public DbSet<Project> Projects { get; set; }

        public ProjectDbContext() : base(Constants.EF_Context_Name) { }
    }
}