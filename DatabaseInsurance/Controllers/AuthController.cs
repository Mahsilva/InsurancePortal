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

        // CHANGE PASSWORD
[HttpPut("change-password")]
public IActionResult ChangePassword([FromBody] ChangePasswordRequest request)
{
    var user = _context.Users.FirstOrDefault(u => u.Id == request.UserId);

    if (user == null)
        return NotFound("User not found");

    if (user.Password != request.CurrentPassword)
        return BadRequest("Current password is incorrect");

    user.Password = request.NewPassword;
    _context.SaveChanges();

    return Ok("Password updated successfully");
}

        // LOGIN
        [HttpPost("login")]
        public IActionResult Login(User login)
        {
    var user = _context.Users
        .FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);

    if (user == null)
        return Unauthorized("Invalid credentials");

    return Ok(new {
        user.Id,
        user.FullName,
        user.Email,
        user.IsAdmin
    });
}
    }

    public class ChangePasswordRequest
{
    public int UserId { get; set; }
    public required string CurrentPassword { get; set; }
    public required string NewPassword { get; set; }
}
}