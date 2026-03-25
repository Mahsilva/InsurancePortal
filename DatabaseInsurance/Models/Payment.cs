using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseInsurance.Models
{
    public class Payment
    {
         public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int PolicyId { get; set; }
        public Policy? Policy { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Paid";
    }
}