using Microsoft.AspNetCore.Mvc;
using DatabaseInsurance.Data;
using DatabaseInsurance.Models;

namespace DatabaseInsurance.Controllers
{
 [ApiController]
    [Route("api/[controller]")]
    public class ClaimController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClaimController(AppDbContext context)
        {
            _context = context;
        }

        // Buscar claims de um usuário
        [HttpGet("{userId}")]
        public IActionResult GetClaims(int userId)
        {
            var claims = _context.Claims
                .Where(c => c.UserId == userId)
                .ToList();
            return Ok(claims);
        }

        // Submeter um claim
        [HttpPost("submit")]
        public IActionResult SubmitClaim(Claim claim)
        {
            claim.Date = DateTime.Now;
            claim.Status = "Pending";

            _context.Claims.Add(claim);
            _context.SaveChanges();
            return Ok(claim);
        }
    }
}