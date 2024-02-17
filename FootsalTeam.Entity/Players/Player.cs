using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using FootsalTeam.Entity.Players.Enum;

namespace FootsalTeam.Entity.Players
{
    public class Player
    {
        public Player(string name, DateTime birthDay,Role role)
        {
            this.Name = name;
            BirthDay = birthDay;
            Role = role;
        }

        public int Id { get;private set; }
        public string Name { get;private set; }
        public DateTime BirthDay { get;private set; }
        public Role Role { get;private set; }
        public int TeamId { get; private set; }
        public Teams.Team Team { get; private set; }
        public void Edit(string name, DateTime birthDay, Role role)
        {
            if (name != null)
            {
                Name = name;
            }
            if (birthDay != null)
            {
                BirthDay = birthDay;
            }
            if (role != null)
            {
                Role = role;
            }
        }
        public void AddTeam(Teams.Team team)
        {
            Team = team;
        }
        public void RemoveTeam(Teams.Team team)
        {
            Team = null;
        }

    }
}
