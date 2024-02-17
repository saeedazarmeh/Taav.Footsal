using FootsalTeam.Entity.Teams.Enum;

namespace FootsalTeam.Service.Teams.Contracts.DTOs
{
    public class UpdateTeamDTO
    {
        public UpdateTeamDTO(string name, Color firstColor, Color secondaryColor)
        {
            Name = name;
            FirstColor = firstColor;
            SecondaryColor = secondaryColor;
        }

        public string Name { get;  set; }
        public Color FirstColor { get;  set; }
        public Color SecondaryColor { get;  set; }
    }
}