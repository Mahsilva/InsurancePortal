using Microsoft.AspNetCore.Mvc;
using DatabaseInsurance.Data;
using DatabaseInsurance.Models;

namespace DatabaseInsurance.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaymentController(AppDbContext context)
        {
            _context = context;
        }

        // Buscar pagamentos de um usuário
        [HttpGet("{userId}")]
        public IActionResult GetPayments(int userId)
        {
            var payments = _context.Payments
                .Where(p => p.UserId == userId)
                .ToList();
            return Ok(payments);
        }

        // Fazer um pagamento
        [HttpPost("pay")]
        public IActionResult MakePayment(Payment payment)
        {
            payment.Date = DateTime.UtcNow;
            payment.Status = "Paid";

            _context.Payments.Add(payment);
            _context.SaveChanges();
            return Ok(payment);
        }

        // Verificar se apólice já foi paga
[HttpGet("check/{policyId}")]
public IActionResult CheckPayment(int policyId)
{
    var payment = _context.Payments
        .FirstOrDefault(p => p.PolicyId == policyId);
    
    if (payment == null)
        return Ok(new { paid = false });

    // Verificar se a apólice ainda está vigente
    var policy = _context.Policies.Find(policyId);
    if (policy == null)
        return Ok(new { paid = false });

    // Se a apólice expirou, pode pagar novamente
    if (policy.EndDate < DateTime.UtcNow)
        return Ok(new { paid = false });

    return Ok(new { paid = true, expiry = policy.EndDate });
}
    }
}