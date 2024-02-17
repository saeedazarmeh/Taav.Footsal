using FootsalTeam.Entity.Players;
using FootsalTeam.Entity.Teams;
using FootsalTeam.Service.Players.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FootsalTeam.Persistance.Players
{
    public class EFPlayerRepository : PlayerRepository
    {
        private readonly EFDbContext _context;

        public EFPlayerRepository(EFDbContext context)
        {
            _context = context;
        }
        public void Add(Player player)
        {
            _context.Players.Add(player);
        }

        public async Task<List<Player>> GetAll()
        {
            return await _context.Players.Include(p => p.Team).ToListAsync();
        }

        public void Delete(Player player)
        {
            _context.Players.Remove(player);
        }

        public async Task<Player> GetById(int playerId)
        {
            return await _context.Players.FirstOrDefaultAsync(p=>p.Id==playerId);
        }

        public void Update(Player player)
        {
            _context.Players.Update(player);
        }

        public async Task<Player> GetByIdWithTeam(int playerId)
        {
            return await _context.Players.Include(p => p.Team).FirstOrDefaultAsync(p => p.Id == playerId);
        }

        public bool CheckExistName(string name)
        {
            return _context.Players.Any(t => t.Name == name);
        }
    }
    }
