using Domain;
using System;
using System.Collections.Generic;
using Web.Models;

namespace Web.Transformers
{
    public class VolunteerRegistrationModelTransformer
    {
        public static User TransformVolunteerToUser(VolunteerRegistrationModel volunteer)
        {
            return new User
            {
                FirstName = volunteer.FirstName,
                LastName = volunteer.LastName,
                Email = volunteer.Email,
                PhoneNumber = volunteer.Phone,
                TshirtSize = volunteer.TshirtSize
            };
        }
    }
}
