using Domain.Enums;
using System.Collections.Generic;

namespace Web.Models
{
    public class TeamRegistrationModel
    {
        public string TeamName { get; set; }
        public PlayerRegistrationModel TeamCaptain { get; set; }
        public List<PlayerRegistrationModel> Players { get; set; }
        public PaymentTerm PaymentTerm { get; set; }
    }
}
