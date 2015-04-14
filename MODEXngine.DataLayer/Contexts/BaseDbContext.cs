using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MODEXngine.PCL.Transports.Db;

namespace MODEXngine.DataLayer.Contexts {
    public class BaseDbContext : DbContext {
        public BaseDbContext(string contextName) : base(contextName) { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()) {
            var changeSet = ChangeTracker.Entries<IEditModel>();

            if (changeSet == null) {
                return base.SaveChangesAsync(cancellationToken);
            }

            foreach (var entry in changeSet.Where(c => c.State != EntityState.Unchanged)) {
                entry.Entity.Modified = DateTime.Now;

                if (entry.State == EntityState.Added) {
                    entry.Entity.Created = DateTime.Now;
                }

                entry.Entity.Active = entry.State != EntityState.Deleted;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}