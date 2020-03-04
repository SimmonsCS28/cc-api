using Domain.Enums;
using System.Collections.Generic;

namespace Web.Models
{
    public class TeamRegistrationModel
    {
        public string TeamName { get; set; }
        public PlayerRegistrationModel CaptainUser { get; set; }
        public List<PlayerRegistrationModel> Users { get; set; }
        public PaymentTerm PaymentTerm { get; set; }
    }
}
