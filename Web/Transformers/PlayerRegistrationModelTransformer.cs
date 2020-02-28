using Domain;
using System.Collections.Generic;
using Web.Models;

namespace Web.Transformers
{
    public class PlayerRegistrationModelTransformer
    {
        public static User TransformPlayerToUser(PlayerRegistrationModel playerRegistrationModel)
        {
            return new User
            {
                FirstName = playerRegistrationModel.FirstName,
                LastName = playerRegistrationModel.LastName,
                Email = playerRegistrationModel.Email,
            };
        }

        public static List<User> TransformPlayersToUsers(List<PlayerRegistrationModel> players)
        {
            List<User> users = new List<User>();
            foreach(PlayerRegistrationModel player in players)
            {
                User user = new User();
                user.FirstName = player.FirstName;
                user.LastName = player.LastName;
                user.Email = player.Email;
                users.Add(user);
            }

            return users;
        }
    }
}
