using FootsalTeam.Service.Players.Contracts.DTOs;

namespace FootsalTeam.Service.Players.Contracts
{
    public interface PlayerService
    {

        Task AddPlayer(AddPlayerDTO addPlayerDTO);
        Task UodarePlayer(int plaiyerId, UpdatePlayertDTO updatePlayerDTO);
        Task<HashSet<PlayerResultDTO>> GetPlayers();
        Task AddPlayerToTeam(int teamId, int playerId);
        Task RemovePlayerFromTeam(int teamId, int playerId);
        Task DeletePlayer(int playerId);
    }
}
