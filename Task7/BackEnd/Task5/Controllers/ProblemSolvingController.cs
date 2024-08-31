using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task5.Models;

namespace Task5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemSolvingController : ControllerBase
    {

        private readonly MyDbContext _db;

        public ProblemSolvingController(MyDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public IActionResult check(int num1, int num2)
        {

            if (num1 == 30 || num2 == 30 || (num1 + num2) == 30)
            {
                return Ok("True");
            
            }else {
                return Ok("False");
            }

        }


        [HttpGet("multiple")]
        public IActionResult check2(int num)
        {

            if (num > 0 && (num % 3 == 0 || num % 7 == 0)) 
            {
                return Ok("True");

            }
            else
            {
                return Ok("False");
            }

        }
    }
}
