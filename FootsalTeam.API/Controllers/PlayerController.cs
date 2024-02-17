using FootsalTeam.Service.Players.Contracts;
using FootsalTeam.Service.Players.Contracts.DTOs;
using FootsalTeam.Service.Teams.Contracts;
using FootsalTeam.Service.Teams.Contracts.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootsalTeam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerService _playerService;

        public PlayerController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost]
        public async Task AddPlayer([FromBody] AddPlayerDTO addPlayermDTO)
        {
            await _playerService.AddPlayer(addPlayermDTO);
        }
        [HttpPatch("playerId")]
        public async Task UpdatePlayer([FromRoute ] int playerId, [FromForm] UpdatePlayertDTO updatePlayertDTO)
        {
            await _playerService.UodarePlayer(playerId, updatePlayertDTO);
        }
        [HttpDelete("playerId")]
        public async Task DeletePlayer([FromRoute] int playerId)
        {
            await _playerService.DeletePlayer(playerId);
        }
        [HttpPatch("AddPlayerToeam")]
        public async Task AddPlayerToeam([FromQuery] int playerId, int teamId)
        {
            await _playerService.AddPlayerToTeam(playerId, teamId);
        }
        [HttpPatch("RemovePlayerFromTeam")]
        public async Task RemovePlayerFromTeam([FromQuery] int playerId, int teamId)
        {
            await _playerService.RemovePlayerFromTeam(playerId, teamId);
        }
        [HttpGet("RemovePlayerFromTeam")]
        public async Task<HashSet<PlayerResultDTO>> GetAll()
        {
           return await _playerService.GetPlayers();
        }
    }
}
