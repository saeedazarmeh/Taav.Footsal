using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FootsalTeam.Service.Teams.Contracts
{
    public interface TeamRepository
    {
        void Add(Entity.Teams.Team team);
        void Update(Entity.Teams.Team team);
        Task<Entity.Teams.Team> GetById(int teamId);
        Task<Entity.Teams.Team> GetByIdWithPlayer(int teamId);
        Task<List<Entity.Teams.Team>> GetAll();
        Task<List<Entity.Teams.Team>> FilterTeams(string Name,Entity.Teams.Enum.Color color);
        void Delete(Entity.Teams.Team team);
        bool CheckExistName(string name);
    }
}
