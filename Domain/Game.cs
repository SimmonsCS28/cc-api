using NPoco;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    class Game
    {
        [ResultColumn]
        public int GameId { get; set; }
        public int TournamentId { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public int GameManager { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedUserId { get; set; }
    }
}

