using Ecommerce_BackEnd.DTO;
using Ecommerce_BackEnd.Models;
using Ecommerce_BackEnd.myClass;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_BackEnd.Controllers
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

        [HttpGet("GetUserInfo/{id}")]
        public IActionResult GetUserInfo(int id)
        {

            var userInfo = _db.UserInformations.Find(id);

            return Ok(userInfo);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
       

        [HttpGet("Login/{email}/{password}")]
        public IActionResult Login(string email, string password)
        {

            var checkUser = _db.UserInformations.FirstOrDefault(u => u.Email == email);

            if (checkUser == null || !PasswordHasher.VerifyPasswordHash(password, checkUser.PasswordHash, checkUser.PasswordSalt))
            {
                return Unauthorized("Invalid username or password.");
            }


           return Ok(checkUser);
        }


        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      

        [HttpPost("Register")]
        public IActionResult Register(RegisterRequestDTO newUser)
        {
            var existingUser = _db.UserInformations.FirstOrDefault(user => user.Email == newUser.Email);

            if (existingUser != null)
            {
                return BadRequest("User already registered.");
            }

            byte[] passwordHash, passwordSalt;

            PasswordHasher.CreatePasswordHash(newUser.Password, out passwordHash, out passwordSalt);

            var addNewUser = new UserInformation
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                Password = newUser.Password,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _db.UserInformations.Add(addNewUser);
            _db.SaveChanges();

            var addNewCart = new ShoppingCart
            {
                UserId = addNewUser.Id,
                CreatedAt = DateTime.Now,
            };

            _db.ShoppingCarts.Add(addNewCart);
            _db.SaveChanges();

            return Ok("User registered successfully.");
        }

    }
}
