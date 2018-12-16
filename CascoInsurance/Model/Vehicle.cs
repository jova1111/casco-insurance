using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CascoInsurance.Model
{
    [Serializable]
    public class Vehicle
    {
        public string RegisterNumber { get; set; }
        public string EngineNumber { get; set; }
        public string ChassisNumber { get; set; }
        public int EnginePower { get; set; }
        public decimal Price { get; set; }
        public int NumberOfSeats { get; set; }
        public VehicleModel Model { get; set; }
        public int ProductionYear { get; set; }
    }
}