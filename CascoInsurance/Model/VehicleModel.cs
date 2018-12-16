using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CascoInsurance.Model
{
    [Serializable]
    public class VehicleModel
    {
        public int Id { get; set; }
        public VehicleBrand Brand { get; set; }
        public string Name { get; set; }
        public decimal EngineCapacity { get; set; }
        public string FuelType { get; set; }


        public override string ToString()
        {
            return Brand != null ? Brand.Name + " " + Name : Name;
        }
    }
}