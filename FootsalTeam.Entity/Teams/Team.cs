using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootsalTeam.Entity.Teams.Enum;

namespace FootsalTeam.Entity.Teams
{
    public class Team
    {
        public Team(string name, Color firstColor, Color secondaryColor)
        {
            Name = name;
            FirstColor = firstColor;
            SecondaryColor = secondaryColor;
        }

        public int Id { get;private set; }
        public string Name { get;private set; }
        public Color FirstColor { get;private set; }
        public Color SecondaryColor { get;private set; }
        public HashSet<Players.Player> Players { get; private set; }=new HashSet<Players.Player>();
        public void Edit(string name, Color firstColor, Color secondaryColor)
        {
            if (name != null)
            {
                Name=name;
            }
            if (firstColor != null)
            {
                FirstColor = firstColor;
            }
            if (secondaryColor != null)
            {
                SecondaryColor = secondaryColor;
            }
        }
        public void AddPlayer(Players.Player player)
        {
            Players.Add(player);
        }
    }
}
