using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CascoInsurance.Model
{
    public class Policy
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Premium { get; set; }
        public RiskPackage RiskPackage { get; set; }
        public Affiliate Affiliate { get; set; }
        public Vehicle Vehicle { get; set; }
        public Agent Agent { get; set; }
        public Insured Insured { get; set; }
        public int Bonus { get; set; }
    }
}