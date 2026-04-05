using Microsoft.AspNetCore.Mvc;
using DatabaseInsurance.Data;
using DatabaseInsurance.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseInsurance.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        // Ver todos os usuários
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var users = _context.Users
                .Where(u => !u.IsAdmin)
                .Select(u => new {
                    u.Id,
                    u.FullName,
                    u.Email
                })
                .ToList();
            return Ok(users);
        }

        // Ver todas as apólices
        [HttpGet("policies")]
        public IActionResult GetPolicies()
        {
            var policies = _context.Policies
                .Include(p => p.User)
                .Select(p => new {
                    p.Id,
                    p.PolicyNumber,
                    p.CarModel,
                    p.CarPlate,
                    p.PlanType,
                    p.Price,
                    p.Status,
                    p.StartDate,
                    p.EndDate,
                    CustomerName = p.User!.FullName,
                    CustomerEmail = p.User.Email
                })
                .ToList();
            return Ok(policies);
        }

        // Ver todos os claims
        [HttpGet("claims")]
        public IActionResult GetClaims()
        {
            var claims = _context.Claims
                .Include(c => c.User)
                .Include(c => c.Policy)
                .Select(c => new {
                    c.Id,
                    c.Description,
                    c.Status,
                    c.Date,
                    CustomerName = c.User!.FullName,
                    CustomerEmail = c.User.Email,
                    PolicyNumber = c.Policy!.PolicyNumber
                })
                .ToList();
            return Ok(claims);
        }

        // Aprovar ou rejeitar claim
        [HttpPut("claims/{id}")]
        public IActionResult UpdateClaim(int id, [FromBody] string status)
        {
            var claim = _context.Claims.Find(id);
            if (claim == null) return NotFound();

            claim.Status = status;
            _context.SaveChanges();
            return Ok(claim);
        }

        // Ver todos os pagamentos
        [HttpGet("payments")]
        public IActionResult GetPayments()
        {
            var payments = _context.Payments
                .Include(p => p.User)
                .Include(p => p.Policy)
                .Select(p => new {
                    p.Id,
                    p.Amount,
                    p.Date,
                    p.Status,
                    CustomerName = p.User!.FullName,
                    CustomerEmail = p.User.Email,
                    PolicyNumber = p.Policy!.PolicyNumber
                })
                .ToList();
            return Ok(payments);
        }

        // Criar admin
        [HttpPost("create")]
public IActionResult CreateAdmin([FromBody] CreateAdminRequest request)
{
    // Senha mestre para criar admins
    if (request.MasterPassword != "masteradmin")
        return Unauthorized("Invalid master password");

    var exists = _context.Users.FirstOrDefault(u => u.Email == request.Email);
    if (exists != null) return BadRequest("Email already exists");

    var user = new User
    {
        FullName = request.FullName,
        Email = request.Email,
        Password = request.Password,
        IsAdmin = true
    };

    _context.Users.Add(user);
    _context.SaveChanges();
    return Ok(user);
}

public class CreateAdminRequest
{
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string MasterPassword { get; set; }
}

    }
}