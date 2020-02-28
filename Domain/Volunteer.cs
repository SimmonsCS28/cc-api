using NPoco;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    class Volunteer
    {
        [ResultColumn]
        public int VolunteerId { get; set; }
        public User User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public int VolunteerRole { get; set; }
        public string TshirtSize { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedUserId { get; set; }
    }
}
