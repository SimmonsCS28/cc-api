


using DataAccess;
using Domain;
using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Service
{
    public class TeamService
    {

        private readonly TeamDao _teamDao;
        private readonly UserDao _userDao;
        private readonly TournamentDao _tournamentDao;

        public TeamService()
        {
            _teamDao = new TeamDao();
            _userDao = new UserDao();
            _tournamentDao = new TournamentDao();
        }

        public List<Team> GetAllTeams()
        {
            var teams = _teamDao.GetAllTeams();
            foreach(Team team in teams)
            {
                User captain = _userDao.GetUserById(team.CaptainUserId);
                //team.CaptainUser = captain;
            }

            return teams;
        }

        public Team GetTeamById(int teamId)
        {
            var team = _teamDao.GetTeamById(teamId);

            PopulateUsers(team);

            return team;
        }

        public List<Team> GetCurrentTournamentRegisteredTeams(int currentTournamentId)
        {
            var currentRegisteredTeams = _teamDao.GetAllTeamsByTournamentId(currentTournamentId);
            foreach (Team team in currentRegisteredTeams)
            {
                PopulateUsers(team);
            }
            return currentRegisteredTeams;
        }

        public Team RegisterTeam(Team team)
        {
            
            Team insertedTeam = team;

            //TODO retrieve next tournament id for registration
            team.TournamentId = 1;

            if (team.PaymentTerm.Equals(PaymentTerm.PaidUponRegistering))
            {
                team.PaymentDate = DateTime.UtcNow;
                team.PaymentMethod = PaymentMethod.PayPal;
            }

            _teamDao.InsertTeam(team);
            return insertedTeam;
        }

        private void PopulateUsers (Team team)
        {
            if(team == null)
            {
                return;
            }

            team.Users = _userDao.GetUsersByTeamId(team.TeamId);
        }

        private void PopulateTournamentId(Team team)
        {
            team.TournamentId = _tournamentDao.GetTournamentIdByNextStartDate();
        }

    }
}
