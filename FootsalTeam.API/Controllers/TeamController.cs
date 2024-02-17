using FootsalTeam.Service.Teams.Contracts;
using FootsalTeam.Service.Teams.Contracts.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootsalTeam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly TeamService _teamService;

        public TeamController(TeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost]
        public async Task AddTeam([FromBody] AddTeamDTO addTeamDTO)
        {
            await _teamService.AddTeam(addTeamDTO);
        }

        [HttpPatch("teamId")]
        public async Task UpdateTeam([FromRoute] int teamId, [FromBody] UpdateTeamDTO updatedto)
        {
            await _teamService.UodareTeam(teamId, updatedto);
        }

        [HttpGet]
        public async Task<HashSet<TeamResultDTO>> GetAll()
        {
            return await _teamService.GetTeams();
        }
        [HttpGet("teamId")]
        public async Task DeleteTeam([FromRoute] int teamId)
        {
            await _teamService.DeleteTeam(teamId);
        }
    }
}
