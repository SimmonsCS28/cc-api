using Domain.Enums;
using NPoco;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    [TableName ("dbo.[User]")]
    [PrimaryKey ("UserId")]
    public class User
    {
        [ResultColumn]
        public int UserId { get; set; }
        public int TeamId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public VolunteerType VolunteerType { get; set; }
        public string TshirtSize { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedUserId { get; set; }
    }
}
