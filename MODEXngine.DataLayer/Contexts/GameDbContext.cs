using MODEXngine.PCL.Common;

namespace MODEXngine.DataLayer.Contexts {
    public class GameDbContext : BaseDbContext {
        public GameDbContext() : base(Constants.EF_Context_Name) { }
    }
}