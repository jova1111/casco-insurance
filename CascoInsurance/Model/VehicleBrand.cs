using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CascoInsurance.Model
{
    [Serializable]
    public class VehicleBrand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}