using FootsalTeam.Entity.Players.Enum;
using FootsalTeam.Entity.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootsalTeam.Service.Players.Contracts.DTOs
{
    public class PlayerResultDTO
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public int Age { get;  set; }
        public Role Role { get;  set; }

        public Team Team { get;  set; }
    }
}
