using Domain;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class UserDao:BaseDao 
    {
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

    }
}
