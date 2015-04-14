using System.Data.Entity;

using MODEXngine.PCL.Common;
using MODEXngine.PCL.Transports.Db;

namespace MODEXngine.DataLayer.Contexts {
    public class GameDbContext : BaseDbContext {
        public DbSet<Game> Games { get; set; } 

        public GameDbContext() : base(Constants.EF_Context_Name) { }
    }
}