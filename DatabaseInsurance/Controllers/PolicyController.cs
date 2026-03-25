using Microsoft.AspNetCore.Mvc;
using DatabaseInsurance.Data;
using DatabaseInsurance.Models;

namespace DatabaseInsurance.Controllers
{
   [ApiController]
    [Route("api/[controller]")]
    public class PolicyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PolicyController(AppDbContext context)
        {
            _context = context;
        }

        // Buscar todas as apólices de um usuário
        [HttpGet("{userId}")]
        public IActionResult GetPolicies(int userId)
        {
            var policies = _context.Policies
                .Where(p => p.UserId == userId)
                .ToList();
            return Ok(policies);
        }

        // Comprar um seguro
        [HttpPost("buy")]
        public IActionResult BuyPolicy(Policy policy)
        {
            policy.StartDate = DateTime.Now;
            policy.EndDate = DateTime.Now.AddYears(1);
            policy.Status = "Active";

            _context.Policies.Add(policy);
            _context.SaveChanges();
            return Ok(policy);
        }
    }
}