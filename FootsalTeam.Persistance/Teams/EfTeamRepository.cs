using FootsalTeam.Entity.Teams;
using FootsalTeam.Entity.Teams.Enum;
using FootsalTeam.Service.Teams.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootsalTeam.Persistance.Teams
{
    public class EfTeamRepository : TeamRepository
    {
        private readonly EFDbContext _context;

        public EfTeamRepository(EFDbContext context)
        {
            _context = context;
        }

        public void Add(Team team)
        {
            _context.Teams.Add(team);
        }

        public bool CheckExistName(string name)
        {
            return _context.Teams.Any(t => t.Name == name);
        }

        public void Delete(Team team)
        {
            _context.Teams.Remove(team);
        }

        public async Task<List<Team>> FilterTeams(string Name, Color color)
        {
           return await _context.Teams.Include(t=>t.Players).ToListAsync();
            if (Name != null)
            {
                var teams = await _context.Teams.Where(t=>t.Name.Contains(Name)).ToListAsync();
            }
            if (color != null)
            {
                var teams = await _context.Teams.Where(t => t.FirstColor== color || t.SecondaryColor == color).ToListAsync();
            }
        }

        public async Task<List<Team>> GetAll()
        {
            return await _context.Teams.Include(t => t.Players).ToListAsync();
        }

        public async Task<Team> GetById(int teamId)
        {
            return await _context.Teams.FirstOrDefaultAsync(t=>t.Id==teamId);
        }

        public async Task<Team> GetByIdWithPlayer(int teamId)
        {
            return await _context.Teams.Include(t=>t.Players).FirstOrDefaultAsync(t => t.Id == teamId);
        }

        public void Update(Team team)
        {
            _context.Teams.Update(team);
        }
    }
}
