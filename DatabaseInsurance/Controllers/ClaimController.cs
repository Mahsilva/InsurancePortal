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
        private readonly IWebHostEnvironment _env;

        public ClaimController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetClaims(int userId)
        {
            var claims = _context.Claims
                .Where(c => c.UserId == userId)
                .ToList();
            return Ok(claims);
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitClaim([FromForm] int userId,
                                                      [FromForm] int policyId,
                                                      [FromForm] string description,
                                                      IFormFile? photo)
        {
            var claim = new Claim
            {
                UserId = userId,
                PolicyId = policyId,
                Description = description,
                Date = DateTime.UtcNow,
                Status = "Pending"
            };

            if (photo != null && photo.Length > 0)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath ?? "wwwroot", "uploads");
                Directory.CreateDirectory(uploadsFolder);

                var fileName = $"{Guid.NewGuid()}_{photo.FileName}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(stream);
                }

                claim.PhotoPath = $"/uploads/{fileName}";
            }

            _context.Claims.Add(claim);
            _context.SaveChanges();
            return Ok(claim);
        }
    }
}