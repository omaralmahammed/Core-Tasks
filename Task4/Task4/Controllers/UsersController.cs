using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task4.DTO;
using Task4.Models;

namespace Task4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _db;

        public UsersController(MyDbContext db)
        {
            _db = db;
        }

        [Route("AllUsers")]
        [HttpGet]
        public IActionResult getAllUsers()
        {

            var users = _db.Users.ToList();

            return Ok(users);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        [Route("getUserById/{id}")]
        [HttpGet]
        public IActionResult getUserById(int id)
        {
            var user = _db.Users.Find(id);

            return Ok(user);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        [Route("getUserByName/{name}")]
        [HttpGet]
        public IActionResult getUserByName(string name)
        {
            var user = _db.Users.Where(model => model.Username == name).FirstOrDefault();

            return Ok(user);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPost("AddUser")]
        public IActionResult addUser([FromForm] UsersRequestDTO user)
        {
           

            var newUser = new User()
            {
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
            };

            _db.Users.Add(newUser);
            _db.SaveChanges();
            return Ok();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpPut("EditUser{id}")]
        public IActionResult editCategort(int id, [FromForm] UsersRequestDTO user)
        {


            var userUpdate = _db.Users.Find(id);

            userUpdate.Username = user.Username;
            userUpdate.Password = user.Password;
            userUpdate.Email = user.Email;

            _db.Users.Update(userUpdate);
            _db.SaveChanges();
            return Ok();
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////

        [Route("DeleteUser/{id}")]
        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
           
            var delUser = _db.Users.Where(e => e.UserId == id).FirstOrDefault();
            
            if (delUser != null)
            {
                _db.Users.Remove(delUser);
                _db.SaveChanges();
                return Ok($"Category '{id}' deleted successfully.");
            }
            return NotFound($"Category '{id}' not found.");
        }
    }
}
