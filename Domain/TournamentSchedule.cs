using NPoco;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    class TournamentSchedule
    {
        [ResultColumn]
        public int TournamentScheduleId { get; set; }
        public int RinkScheduleId { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedUserId { get; set; }
    }
}
