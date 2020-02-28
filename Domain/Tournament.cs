using NPoco;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   
    public class Tournament
    {
        [ResultColumn]
        public int TournamentId { get; set; }
        public int ScheduleId { get; set; }
        public DateTime TournamentStartDate { get; set; }
        public DateTime TournamentEndDate { get; set; }
        public int MaxTeams { get; set; }
        public decimal FeeAmount { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedUserId { get; set; }
    }
}
