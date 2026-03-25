using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseInsurance.Models
{
    public class Policy
    {
       public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string PolicyNumber { get; set; } = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        
        // Dados do carro
        public string CarModel { get; set; } = string.Empty;
        public int CarYear { get; set; }
        public string CarColor { get; set; } = string.Empty;
        public string CarPlate { get; set; } = string.Empty;
        
        // Dados do condutor
        public int DriverAge { get; set; }
        public int DrivingExperience { get; set; }
        
        // Uso do carro
        public string CarUsage { get; set; } = string.Empty;
        public int KmPerYear { get; set; }
        
        // Plano
        public string PlanType { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = "Active";
    }
}