using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascoInsurance.Model
{
    public class RiskPackage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PercentageValue { get; set; }
    }
}
