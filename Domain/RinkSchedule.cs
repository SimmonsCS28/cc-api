using NPoco;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    class RinkSchedule
    {
        [ResultColumn]
        public int RinkScheduleId { get; set; }
        public int GameId { get; set; }
        public string RinkName { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedUserId { get; set; }
    }
}
