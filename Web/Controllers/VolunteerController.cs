using DataAccess;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Service;
using Web.Models;
using Web.Transformers;

namespace Web.Controllers
{
    [Route("api/volunteer")]
    public class VolunteerController : Controller
    {

        private readonly UserDao _userDao;
        private readonly UserService _userService;

        public VolunteerController()
        {
            _userDao = new UserDao();
            _userService = new UserService();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] VolunteerRegistrationModel volunteerRegistrationModel)
        {

            User volunteer = VolunteerRegistrationModelTransformer.TransformVolunteerToUser(volunteerRegistrationModel);

            var insertedUser = _userDao.InsertVolunteer(volunteer);

            return Ok(volunteer);
        }
    }
}
