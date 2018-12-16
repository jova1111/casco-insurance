using CascoInsurance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascoInsurance.Database
{
    interface IVehicleBrandDao
    {
        List<VehicleBrand> GetAllVehicleBrands();
        VehicleBrand GetVehicleBrand(int id);
        void InsertVehicleBrand(VehicleBrand vehicleBrand);
        void DeleteVehicleBrand(int id);
    }
}
