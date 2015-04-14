using System;
using System.Threading.Tasks;

using MODEXngine.PCL.Transports.Db;
using MODEXngine.WebBusinessLayer.Managers;

namespace MODEXngine.WebAPI.Controllers {
    public class GameController : BaseApiController {
        public async Task<Game> GET(Guid id) {
            return await new GameManager().GetGame(id);
        }

        public async Task<bool> UPDATE(Game game) {
            return await new GameManager().Update(game);
        }

        public async Task<Guid> CREATE(Game game) {
            return await new GameManager().Create(game);
        }
    }
}