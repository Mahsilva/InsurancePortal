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
            payment.Date = DateTime.Now;
            payment.Status = "Paid";

            _context.Payments.Add(payment);
            _context.SaveChanges();
            return Ok(payment);
        }
    }
}