using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseInsurance.Models
{
    public class Claim
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int PolicyId { get; set; }
        public Policy? Policy { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
        public DateTime Date { get; set; } = DateTime.Now;
    }
}