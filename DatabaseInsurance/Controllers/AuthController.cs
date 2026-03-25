using Microsoft.AspNetCore.Mvc;
using DatabaseInsurance.Data;
using DatabaseInsurance.Models;
using System.Linq;

namespace DatabaseInsurance.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        // REGISTER
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            var exists = _context.Users.FirstOrDefault(u => u.Email == user.Email);

            if (exists != null)
                return BadRequest("Email already exists");

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(user);
        }

        // LOGIN
        [HttpPost("login")]
        public IActionResult Login(User login)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);

            if (user == null)
                return Unauthorized("Invalid credentials");

            return Ok(user);
        }
    }
}