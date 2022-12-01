using DataAccess;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/tournament")]
    public class TournamentController : Controller
    {
        private readonly TournamentDao _tournamentDao;
        private readonly TournamentService _tournamentService;
        private readonly TeamService _teamService;
        private readonly UserService _userService;

        public TournamentController()
        {
            _tournamentService = new TournamentService();
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var tournament = _tournamentService.GetCurrentTournamentInfo();
            return Ok(tournament);
        }

        [HttpGet("{activeIndicator}/teams")]
        public IActionResult Get(int activeIndicator)
        {
            var teams = _tournamentService.GetCurrentTournamentRegisteredTeams();
            return Ok(teams);
        }

        [HttpPost("new-tournmanet")]
        public IActionResult Post([FromBody]Tournament tournament)
        {
            return Ok(_tournamentService.createNewTournament(tournament));
        }
    }
}
