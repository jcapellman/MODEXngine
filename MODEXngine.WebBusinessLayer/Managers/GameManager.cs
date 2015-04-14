using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

using MODEXngine.DataLayer.Contexts;
using MODEXngine.PCL.Transports.Db;

namespace MODEXngine.WebBusinessLayer.Managers {
    public class GameManager : BaseManager {
        public async Task<Game> GetGame(Guid id) {
            using (var dbContext = new GameDbContext()) {
                return await dbContext.Games.FirstOrDefaultAsync(a => a.ID == id);
            }
        }

        public async Task<Guid> Create(Game game) {
            using (var dbContext = new GameDbContext()) {
                dbContext.Games.AddOrUpdate(game);

                var result = await dbContext.SaveChangesAsync();

                return game.ID;
            }
        }

        public async Task<bool> Update(Game game) {
            using (var dbContext = new GameDbContext()) {
                dbContext.Games.AddOrUpdate(game);

                return await dbContext.SaveChangesAsync() > 0;
            }
        }
    }
}