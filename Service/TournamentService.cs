using System;
using DataAccess;
using Domain;

namespace Service
{
    public class TournamentService
    {
        private readonly TeamDao _teamDao;
        private readonly UserDao _userDao;
        private readonly TournamentDao _tournamentDao;
        private readonly TeamService _teamService;

        public TournamentService()
        {
            _teamDao = new TeamDao();
            _userDao = new UserDao();
            _tournamentDao = new TournamentDao();
            _teamService = new TeamService();
        }

        public Tournament GetCurrentTournamentInfo()
        {
            var tournmaent = _tournamentDao.GetCurrentTournamentInfo();
            tournmaent.Teams = _teamDao.GetAllTeamsByTournamentId(tournmaent.TournamentId);

            if(tournmaent.Teams != null)
            {
                foreach (Team team in tournmaent.Teams)
                {
                    team.Users = _userDao.GetUsersByTeamId(tournmaent.TournamentId);
                }
            }
            
            return tournmaent;
        }

        public object GetCurrentTournamentRegisteredTeams()
        {
            int tournamentId = _tournamentDao.GetCurrentTournamentId();
            return _teamService.GetCurrentTournamentRegisteredTeams(tournamentId);
        }
    }
}
