using FootsalTeam.Entity.Teams.Enum;
using FootsalTeam.Service.Players.Contracts.DTOs;

namespace FootsalTeam.Service.Teams.Contracts.DTOs
{
    public class TeamResultDTO
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public Color FirstColor { get;  set; }
        public Color SecondaryColor { get;  set; }
        public HashSet<PlayerResultDTO> PlayersDTO { get;  set; } = new HashSet<PlayerResultDTO>();
    }
}