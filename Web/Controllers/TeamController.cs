using DataAccess;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Service;
using Web.Models;
using Web.Transformers;

namespace Web.Controllers
{
    [Route("api/team")]
    public class TeamController : Controller
    {
        //
        private readonly TeamDao _teamDao;
        private readonly TeamService _teamService;
        private readonly UserService _userService;

        public TeamController ()
        {
            _teamDao = new TeamDao();
            _teamService = new TeamService();
            _userService = new UserService();
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var tournamentTeams = _teamDao.GetAllTeams();
            return Ok(tournamentTeams);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var team = _teamService.GetTeamById(id);
            return Ok(team);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]TeamRegistrationModel teamRegistrationModel)
        {
            
            var teamCaptainUser = PlayerRegistrationModelTransformer.TransformPlayerToUser(teamRegistrationModel.CaptainUser);
            var teamCaptain = _userService.CreateUser(teamCaptainUser);

            var team = TeamRegistrationModelTransfomer.TranformerRegistrationModelToTeam(teamRegistrationModel, teamCaptain.UserId);

            var insertedTeam = _teamService.RegisterTeam(team);

            _userService.UpdateTeamCaptainTeamId(team.TeamId, teamCaptain.UserId);

            team.Users = PlayerRegistrationModelTransformer.TransformPlayersToUsers(teamRegistrationModel.Users);

            var insertedPlayers = _userService.InsertTeamPlayers(team);

            insertedTeam.Users = insertedPlayers;

            return Ok(insertedTeam);
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]Team team)
        {
            var updatedTeam = _teamDao.UpdateTeam(team);
            return Ok(updatedTeam);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _teamDao.DeleteTeam(id);
            return Ok();
        }

    }
}
