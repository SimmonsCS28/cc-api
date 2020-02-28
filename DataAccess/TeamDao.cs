using System;
using System.Collections.Generic;
using Domain;

namespace DataAccess
{
    public class TeamDao : BaseDao
    {
        public List<Team> GetAllTeams()
        {
            var sql = @"SELECT 
                        T.TeamId,
                        T.TournamentId,
                        T.CaptainUserId,
                        T.TeamName,
                        T.PaymentTerm,
                        T.PaymentDate,
                        T.PaymentMethod,
                        T.RegistrationDate
                        FROM dbo.Team T";

            using (var db = InitializeFactory().GetDatabase())
            {
                return db.Fetch<Team>(sql);
            }
        }

        public Team GetTeamById(int id)
        {
            var sql = @"SELECT  T.TeamId
      ,T.TournamentId
      ,T.CaptainUserId
      ,T.TeamName
      ,T.PaymentTerm
      ,T.PaymentDate
      ,T.PaymentMethod
      ,T.RegistrationDate
      ,T.LastModifiedDate
      ,T.LastModifiedUserId
  FROM dbo.Team T
WHERE T.TeamId = @0";

            using (var db = InitializeFactory().GetDatabase())
            {
                return db.SingleOrDefault<Team>(sql, id);
            }
        }

        public Team InsertTeam(Team team)
        {
            team.RegistrationDate = DateTime.UtcNow;
            team.LastModifiedDate = DateTime.UtcNow;
            using (var db = InitializeFactory().GetDatabase())
            {
                db.Insert(team);
            }
            return team;
        }

        public object UpdateTeam(Team team)
        {
            team.LastModifiedDate = DateTime.UtcNow;
            throw new NotImplementedException();
        }

        public void DeleteTeam(int id)
        {
            throw new NotImplementedException();
        }
    }
}
