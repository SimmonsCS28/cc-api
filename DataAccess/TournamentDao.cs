using Domain;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class TournamentDao:BaseDao
    {
        public List<Tournament> GetAllTournaments()
        {
            var sql = @"SELECT 
                        U.TournamentId,
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
                        U.LastModifiedTournamentId
                        FROM dbo.[Tournament] U";

            using (var db = InitializeFactory().GetDatabase())
            {
                return db.Fetch<Tournament>(sql);
            }
        }

        public List<Tournament> GetTournamentsByTeamId(int teamId)
        {
            var sql = @"SELECT 
                        U.TournamentId,
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
                        U.LastModifiedTournamentId
                        FROM dbo.[Tournament] U
                        WHERE U.TeamId = @0";

            using (var db = InitializeFactory().GetDatabase())
            {
                return db.Fetch<Tournament>(sql, teamId);
            }
        }

        public Tournament GetTournamentById(int id)
        {
            var sql = @"SELECT 
                        U.TournamentId,
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
                        U.LastModifiedTournamentId
                        FROM dbo.[Tournament] U
                        WHERE U.TournamentId = @0";

            using (var db = InitializeFactory().GetDatabase())
            {
                return db.SingleOrDefault<Tournament>(sql, id);
            }
        }

        public Tournament GetCurrentTournamentInfo()
        {
            var sql = @"SELECT
                        U.TournamentId,
                        U.TournamentScheduleId,
                        U.TournamentStartDate,
                        U.TournamentEndDate,
                        U.TournamentMaxTeams,
                        U.TournamentFeeAmount,
                        U.CurrentActiveTournament
                        FROM dbo.[Tournament] U
                        WHERE U.CurrentActiveTournament = 1";

            using (var db = InitializeFactory().GetDatabase())
            {
                return db.SingleOrDefault<Tournament>(sql);
            }
        }


        public int GetTournamentIdByNextStartDate()
        {
            var sql = @""; //TODO write SQL SELECT to retrieve the next upcoming tournament id

            using (var db = InitializeFactory().GetDatabase())
            {
                return db.SingleOrDefault<int>(sql);
            }
        }

        public Tournament InsertTournament(Tournament user)
        {
            user.CreationDate = DateTime.UtcNow;
            using (var db = InitializeFactory().GetDatabase())
            {
                db.Insert(user);
            }
            return user;
        }

        public List<Tournament> InsertTournament(List<Tournament> users)
        {
            using (var db = InitializeFactory().GetDatabase())
            {
                //InsertBulk is for inserting many items at a time
                db.InsertBulk(users);
            }
            return users;
        }

        public Tournament UpdateTournament(Tournament user)
        {
            using (var db = InitializeFactory().GetDatabase())
            {
                db.Update(user, new[] { "FirstName", "LastName", "Email" });
            }
            return user;
        }

        public void DeleteTournament(int userId)
        {
            using (var db = InitializeFactory().GetDatabase())
            {
                db.Delete(new Tournament { TournamentId = userId });
            }
        }
    }
}
