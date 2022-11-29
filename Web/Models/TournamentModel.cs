using System;

namespace Web.Models
{
    public class TournamentModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxTeams { get; set; }   
        public int FeeAmount { get; set; }
        public int CurrentActiveTournmanet { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedUserId { get; set; }

    }
}
