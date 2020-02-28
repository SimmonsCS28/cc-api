using DataAccess;
using Domain;
using System;
using System.Collections.Generic;

namespace Service
{
    public class UserService
    {
        private readonly UserDao _userDao = new UserDao();

        public User CreateUser(User user)
        {
            User insertedUser = _userDao.InsertUser(user);

            return insertedUser;
        }

        public void UpdateTeamCaptainTeamId(int teamId, int captainId)
        {
            _userDao.UpdateTeamCaptainTeamId(teamId, captainId);
        }

        public List<User> InsertTeamPlayers(Team team)
        {
            foreach(User user in team.Users)
            {
                user.TeamId = team.TeamId;
                user.CreatedDate = DateTime.UtcNow;
                user.LastModifiedDate = DateTime.UtcNow;
            }
            List<User> insertedUsers = _userDao.InsertUsers(team.Users);

            return insertedUsers;
        }
    }
}
