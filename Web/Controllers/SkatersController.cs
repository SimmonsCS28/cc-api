using DataAccess;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/skaters")]
    public class SkatersController : Controller
    {
        //
        private readonly UserDao _userDao;

        public SkatersController ()
        {
            _userDao = new UserDao();
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var skaters = _userDao.GetAllUsers();
            return Ok(skaters);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var skaters = _userDao.GetUserById(id);
            return Ok(skaters);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            var insertedSkater = _userDao.InsertUser(user);
            return Ok(insertedSkater);
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]User user)
        {
            var updatedSkater = _userDao.UpdateUser(user);
            return Ok(updatedSkater);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userDao.DeleteUser(id);
            return Ok();
        }
    }
}
