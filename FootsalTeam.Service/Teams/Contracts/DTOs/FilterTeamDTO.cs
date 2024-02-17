using FootsalTeam.Entity.Teams.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootsalTeam.Service.Teams.Contracts.DTOs
{
    public class FilterTeamDTO
    {
        public string Name { get; set; }
        public Color Color { get; set; }
    }
}
