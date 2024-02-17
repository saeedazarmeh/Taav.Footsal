using FootsalTeam.Contract.Exeption;
using FootsalTeam.Contract.UnitOfWork;
using FootsalTeam.Entity.Teams;
using FootsalTeam.Service.Teams.Contracts;
using FootsalTeam.Service.Teams.Contracts.DTOs;
using FootsalTeam.Service.Teams.Contracts.Mapper;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootsalTeam.Service.Teams
{
    public class TeamAppService: TeamService
    {
        private readonly TeamRepository _teamRepository;
        private readonly UnitOfWork _unit;

        public TeamAppService(TeamRepository teamRepository, UnitOfWork unit)
        {
            _teamRepository = teamRepository;
            _unit = unit;
        }

        public async Task AddTeam( AddTeamDTO addTeamDTO)
        {
            if (_teamRepository.CheckExistName(addTeamDTO.Name))
            {
                throw new InvalidDataException("Name is Repeatede");
            }
            var team = new Entity.Teams.Team(addTeamDTO.Name, addTeamDTO.FirstColor, addTeamDTO.SecondaryColor);
         
            _teamRepository.Add(team);
            await _unit.Save();
        }
        public async Task UodareTeam(int teamId, UpdateTeamDTO updateTeamDTO)
        {
            var team =await _teamRepository.GetById(teamId);
            if(team == null)
            {
                throw new NotFoundExeption("Data Not Found");
            }
            if (_teamRepository.CheckExistName(updateTeamDTO.Name))
            {
                throw new InvalidDataException("Name is Repeatede");
            }
            team.Edit(updateTeamDTO.Name, updateTeamDTO.FirstColor, updateTeamDTO.SecondaryColor);
            _teamRepository.Update(team);
            await _unit.Save();
        }
        public async Task<HashSet<TeamResultDTO>> GetTeams()
        {
            var teams = await _teamRepository.GetAll();
            return teams.ToHashSet().TeamMap();
        }
        public async Task DeleteTeam(int teamId)
        {
            var team = await _teamRepository.GetById(teamId);
            if (team == null)
            {
                throw new NotFoundExeption("Data Not Found");
            }
            _teamRepository.Delete(team);
            await _unit.Save();
        }


    }
}
