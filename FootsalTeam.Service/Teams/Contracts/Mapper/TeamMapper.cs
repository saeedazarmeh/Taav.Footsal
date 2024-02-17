using FootsalTeam.Entity.Teams;
using FootsalTeam.Service.Players.Contracts.Mapper;
using FootsalTeam.Service.Teams.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootsalTeam.Service.Teams.Contracts.Mapper
{
    public static class TeamMapper
    {
        public static HashSet<TeamResultDTO> TeamMap(this HashSet<Team> teams)
        {
            var teamsDTO=new HashSet<TeamResultDTO>();
            foreach(var team in teams)
            {
                var teamDTO=new TeamResultDTO()
                {
                    Name = team.Name,
                    Id = team.Id,
                    FirstColor = team.FirstColor,
                    SecondaryColor = team.SecondaryColor,
                    PlayersDTO=team.Players.PlayersMap()
                };
            }
            return teamsDTO;
        }
    }
}
