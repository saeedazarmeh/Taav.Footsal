using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootsalTeam.Service.Players.Contracts
{
    public interface PlayerRepository
    {
        void Add(Entity.Players.Player player);
        void Update(Entity.Players.Player player);
        Task<Entity.Players.Player> GetById(int playerId);
        Task<List<Entity.Players.Player>> GetAll();
        void Delete(Entity.Players.Player player);
        Task<Entity.Players.Player> GetByIdWithTeam(int playerId);
        bool CheckExistName(string name);
    }
}
