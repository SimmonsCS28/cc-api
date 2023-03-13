using Domain;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class UserDao:BaseDao 
    {
        private readonly TournamentDao _tournamentDao;

        public List<User> GetAllUsers()
        {
            var sql = @"SELECT 
                        U.UserId,
                        U.TeamId,
                        U.Password,
                        U.FirstName,
                        U.LastName,
                        U.Email,
                        U.VolunteerType,
                        U.PhoneNumber,
                        U.TshirtSize,
                        U.CreatedDate,
                        U.LastModifiedDate,
                        U.LastModifiedUserId
                        FROM dbo.[User] U";

            using (var db = InitializeFactory().GetDatabase())
            {
                return db.Fetch<User>(sql);
            }
        }

        public List<User> GetUsersByTeamId(int teamId)
        {
            var sql = @"SELECT 
                        U.UserId,
                        U.TeamId,
                        U.Password,
                        U.FirstName,
                        U.LastName,
                        U.Email,
                        U.VolunteerType,
                        U.PhoneNumber,
                        U.TshirtSize,
                        U.CreatedDate,
                        U.LastModifiedDate,
                        U.LastModifiedUserId
                        FROM dbo.[User] U
                        WHERE U.TeamId = @0";

            using (var db = InitializeFactory().GetDatabase())
            {
                return db.Fetch<User>(sql, teamId);
            }
        }

        public User GetUserById(int id)
        {
            var sql = @"SELECT 
                        U.UserId,
                        U.TeamId,
                        U.Password,
                        U.FirstName,
                        U.LastName,
                        U.Email,
                        U.VolunteerType,
                        U.PhoneNumber,
                        U.TshirtSize,
                        U.CreatedDate,
                        U.LastModifiedDate,
                        U.LastModifiedUserId
                        FROM dbo.[User] U
                        WHERE U.UserId = @0";

            using (var db = InitializeFactory().GetDatabase())
            {
                return db.SingleOrDefault<User>(sql, id);
            }
        }

        public User InsertUser(User user)
        {
            user.CreatedDate = DateTime.UtcNow;
            user.LastModifiedDate = DateTime.UtcNow;
            using (var db = InitializeFactory().GetDatabase())
            {
                db.Insert(user);
            }
            return user;
        }

        public List<User> InsertUsers(List<User> users)
        {

            using (var db = InitializeFactory().GetDatabase())
            {

                foreach(User user in users)
                {
                    db.Insert(user);
                }
                //InsertBulk is for inserting many items at a time
                //db.InsertBulk(users);
            }
            return users;
        }

        public User UpdateUser(User user)
        {
            using (var db = InitializeFactory().GetDatabase())
            {
                db.Update(user, new[] {"FirstName", "LastName", "Email"} );
            }
            return user;
        }

        public void UpdateTeamCaptainTeamId(int teamId, int captainId)
        {
            var sql = @"UPDATE [User]
                        SET TeamId = @0
                        WHERE UserId = @1";
            using (var db = InitializeFactory().GetDatabase())
            {
               db.Execute(sql, teamId, captainId);
            }
            
        }

        public void DeleteUser(int userId)
        {
            using (var db = InitializeFactory().GetDatabase())
            {
                db.Delete(new User { UserId = userId });
            }
        }

        public User InsertVolunteer(User user, List<int> volunteerRoleIds)
        {
            var sql = @"INSERT INTO [User]
                        (FirstName,
                         LastName,
                         Email,
                         PhoneNumber,
                         TshirtSize,
                         VolunteerType,
                         CreatedDate,
                         LastModifiedDate)
                        Values (@0, 
                                @1, 
                                @2, 
                                @3, 
                                @4, 
                                @5, 
                                CURRENT_TIMESTAMP, 
                                CURRENT_TIMESTAMP)";
            using(var db = InitializeFactory().GetDatabase)
            {
                db.Execute(sql, user.FirstName, user.LastName, user.Email, user.PhoneNumber, user.TshirtSize, user.VolunteerType);
            }

            int currentTournamentId = _tournamentDao.GetCurrentTournamentId();

            foreach (int id in volunteerRoleIds)
            {
                sql = @"INSERT INTO [VolunteerRoleXref]
                        (UserId,
                        VolunteerTypeId,
                        TournamentId,
                        CreationDate,
                        LastModifiedDate)
                        Values (@0,
                        @1,
                        @2,
                        CURRENT_TIMESTAMP,
                        CURRENT_TIMESTAMP)";
                using (var db = InitializeFactory().GetDatabase)
                {
                    db.Execute(sql, user.UserId, id, currentTournamentId);
                }
            }

            return user;
        }

    }
}
