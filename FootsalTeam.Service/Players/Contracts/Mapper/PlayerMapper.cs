using FootsalTeam.Entity.Players;
using FootsalTeam.Entity.Teams;
using FootsalTeam.Service.Players.Contracts.DTOs;
using FootsalTeam.Service.Teams.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootsalTeam.Service.Players.Contracts.Mapper
{
    public static class PlayerMapper
    {
        public static HashSet<PlayerResultDTO> PlayersMap(this HashSet<Player> players)
        {
            var playersDTO = new HashSet<PlayerResultDTO>();
            foreach (var player in players)
            {
                var playerDTO = new PlayerResultDTO()
                {
                    Id = player.Id,
                    Name = player.Name,
                    Age =Contract.CommonServices.CommonServices.CalAge(player.BirthDay),
                    Role = player.Role,
                };
                playersDTO.Add(playerDTO);
            }
            return playersDTO;
        }
    }
}
