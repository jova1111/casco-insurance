using CascoInsurance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascoInsurance.Database
{
    interface IVehicleDao
    {
        List<Vehicle> GetAllVehicles();
        Vehicle GetVehicle(string registerNumber);
        void InsertVehicle(Vehicle vehicle);
        void DeleteVehicle(string registerNumber);
        void UpdateVehicle(Vehicle vehicle);
    }
}
