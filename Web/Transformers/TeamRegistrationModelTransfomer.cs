using Domain;
using Web.Models;

namespace Web.Transformers
{
    public class TeamRegistrationModelTransfomer
    {
        public static Team TranformerRegistrationModelToTeam(TeamRegistrationModel registrationModel, int teamCaptainId)
        {
            return new Team
            {
                TeamName = registrationModel.TeamName,
                CaptainUserId = teamCaptainId,
                PaymentTerm = registrationModel.PaymentTerm
            };
        }
    }
}
