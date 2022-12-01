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

        public List<Tournament> GetCurrentTournamentRegisteredTeams()
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
                return db.Fetch<Tournament>(sql);
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

        public int GetCurrentTournamentId()
        {
            var sql = @"SELECT
                        U.TournamentId
                        FROM dbo.[Tournament] U
                        WHERE U.CurrentActiveTournament = 1";
            using (var db = InitializeFactory().GetDatabase())
            {
                return db.SingleOrDefault<int>(sql);
            };
        }


        public int GetTournamentIdByNextStartDate()
        {
            var sql = @""; //TODO write SQL SELECT to retrieve the next upcoming tournament id

            using (var db = InitializeFactory().GetDatabase())
            {
                return db.SingleOrDefault<int>(sql);
            }
        }

        public Tournament InsertTournament(Tournament tournament)
        {
            tournament.CreationDate = DateTime.UtcNow;
            tournament.LastModifiedDate= DateTime.UtcNow;
            using (var db = InitializeFactory().GetDatabase())
            {
                db.Insert(tournament);
            }
            return tournament;
        }

        public void SetCurrentTournamentToNotActive(int activeTournamentId)
        {
            using (var db = InitializeFactory().GetDatabase())
            {

            }
        }

        public List<Tournament> InsertTournament(List<Tournament> tournaments)
        {
            using (var db = InitializeFactory().GetDatabase())
            {
                //InsertBulk is for inserting many items at a time
                db.InsertBulk(tournaments);
            }
            return tournaments;
        }

        public Tournament UpdateTournament(Tournament tournament)
        {
            using (var db = InitializeFactory().GetDatabase())
            {
                db.Update(tournament, new[] { "FirstName", "LastName", "Email" });
            }
            return tournament;
        }

        public void DeleteTournament(int tournamentId)
        {
            using (var db = InitializeFactory().GetDatabase())
            {
                db.Delete(new Tournament { TournamentId = tournamentId });
            }
        }
    }
}
