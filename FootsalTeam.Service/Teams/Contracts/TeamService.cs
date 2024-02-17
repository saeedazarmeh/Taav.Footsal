using FootsalTeam.Service.Teams.Contracts.DTOs;

namespace FootsalTeam.Service.Teams.Contracts
{
    public interface TeamService
    {
        Task AddTeam(AddTeamDTO addTeamDTO);
        Task UodareTeam(int teamId, UpdateTeamDTO updateTeamDTO);
        Task<HashSet<TeamResultDTO>> GetTeams();
        Task DeleteTeam(int teamId);


    }
}
