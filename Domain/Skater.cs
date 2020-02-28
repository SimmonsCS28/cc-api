using NPoco;
using System;

namespace Domain
{
    [TableName ("dbo.Skater")]
    [PrimaryKey ("SkaterId")]
    public class Skater
    {
        [ResultColumn]
        public int SkaterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string TshirtSize { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedUserId { get; set; }
        [Ignore]
        public string DisplayDate => CreatedTimestamp.ToLongDateString();
    }
}
