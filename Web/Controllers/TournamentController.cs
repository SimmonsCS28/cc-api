using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
