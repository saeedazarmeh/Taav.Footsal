using FootsalTeam.Entity.Players.Enum;

namespace FootsalTeam.Service.Players.Contracts.DTOs
{
    public class UpdatePlayertDTO
    {
        public string name { get; set; }
        public DateTime BirthDay { get; set; }
        public int TeamId { get; set; }
        public Role Role { get; set; }
    }
}
