using FootsalTeam.Contract.Exeption;
using FootsalTeam.Contract.UnitOfWork;
using FootsalTeam.Entity.Players;
using FootsalTeam.Service.Players.Contracts;
using FootsalTeam.Service.Players.Contracts.DTOs;
using FootsalTeam.Service.Players.Contracts.Mapper;
using FootsalTeam.Service.Teams.Contracts;
using FootsalTeam.Service.Teams.Contracts.DTOs;
using FootsalTeam.Service.Teams.Contracts.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootsalTeam.Service.Players
{
    public class PlayerAppService:PlayerService
    {
        private readonly TeamRepository _teamRepository;
        private readonly PlayerRepository _playerRepository;
        private readonly UnitOfWork _unit;

        public PlayerAppService(TeamRepository teamRepository, UnitOfWork unit, PlayerRepository playerRepository)
        {
            _teamRepository = teamRepository;
            _playerRepository=playerRepository;
            _unit = unit;
        }
        public async Task AddPlayer(AddPlayerDTO addPlayerDTO)
        {
            if (_playerRepository.CheckExistName(addPlayerDTO.name))
            {
                throw new InvalidDataException("Name is Repeatede");
            }
            var player = new Entity.Players.Player(addPlayerDTO.name, addPlayerDTO.BirthDay, addPlayerDTO.Role);

            _playerRepository.Add(player);
            await _unit.Save();
        }
        public async Task UodarePlayer(int plaiyerId, UpdatePlayertDTO updatePlayerDTO)
        {
            var player = await _playerRepository.GetById(plaiyerId);
            if (player == null)
            {
                throw new NotFoundExeption("Data Not Found");
            }
            if (_playerRepository.CheckExistName(updatePlayerDTO.name))
            {
                throw new InvalidDataException("Name is Repeatede");
            }
            player.Edit(updatePlayerDTO.name,updatePlayerDTO.BirthDay,updatePlayerDTO.Role);
            _playerRepository.Update(player);
            await _unit.Save();
        }
        public async Task<HashSet<PlayerResultDTO>> GetPlayers()
        {
            var players = await _playerRepository.GetAll();
            return players.ToHashSet().PlayersMap();
        }
        public async Task AddPlayerToTeam(int teamId,int playerId)
        {
            var team = await _teamRepository.GetByIdWithPlayer(teamId);
            if (team == null)
            {
                throw new NotFoundExeption("Data Not Found");
            }
            if (team.Players.Count == 5)
            {
                throw new InvalidDataExeption("Teamcapacity is full");
            }
            var player = await _playerRepository.GetById(playerId);
            if (player == null)
            {
                throw new NotFoundExeption("Data Not Found");
            }
          
            if(team.Players.Any(p=>p.Role==Entity.Players.Enum.Role.DarvazeBan) && player.Role == Entity.Players.Enum.Role.DarvazeBan)
            {
                throw new NotFoundExeption("There is one gole keeper");
            }
            if (team.Players.Any(p => p.Role != Entity.Players.Enum.Role.DarvazeBan) && player.Role != Entity.Players.Enum.Role.DarvazeBan && team.Players.Count == 4)
            {
                throw new NotFoundExeption(" shuild be there is There is one gole keeper");
            }
            player.AddTeam(team);
            _playerRepository.Update(player);
            _unit.Save();
        }
        public async Task RemovePlayerFromTeam(int teamId, int playerId)
        {
            var team = await _teamRepository.GetByIdWithPlayer(teamId);
            if (team == null)
            {
                throw new NotFoundExeption("Data Not Found");
            }
            var player = await _playerRepository.GetById(playerId);
            if (player == null)
            {
                throw new NotFoundExeption("Data Not Found");
            }
            player.RemoveTeam(team);
            _playerRepository.Update(player);
            _unit.Save();
        }

            public async Task DeletePlayer(int playerId)
        {
            var player = await _playerRepository.GetById(playerId);
            if (player == null)
            {
                throw new NotFoundExeption("Data Not Found");
            }
            _playerRepository.Delete(player);
            await _unit.Save();
        }
    }
}
