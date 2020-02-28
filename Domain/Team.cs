using Domain.Enums;
using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    [TableName ("dbo.Team")]
    [PrimaryKey ("TeamId")]
    public class Team
    {
        [ResultColumn]
        public int TeamId { get; set; }
        public int TournamentId { get; set; }
        public int CaptainUserId { get; set; }
        public string TeamName { get; set; }
        public PaymentTerm PaymentTerm { get; set; }
        public DateTime? PaymentDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedUserId { get; set; }

        [Ignore]
        public List<User> Users { get; set; }
        [Ignore]
        public User CaptainUser => Users?.FirstOrDefault(u => u.UserId == CaptainUserId);
    }
}
