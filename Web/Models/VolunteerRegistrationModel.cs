using System.Collections.Generic;

namespace Web.Models
{
    public class VolunteerRegistrationModel
    {
        public string FirstName {get; set;}
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string TshirtSize { get; set; }
        public List<int> VolunteerTypeIds { get; set; }
    }
}
