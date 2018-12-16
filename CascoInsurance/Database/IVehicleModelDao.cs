using CascoInsurance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascoInsurance.Database
{
    interface IVehicleModelDao
    {
        List<VehicleModel> GetAllVehicleModels();
        VehicleModel GetVehicleModel(int id);
        void InsertVehicleModel(VehicleModel vehicleModel);
        void DeleteVehicleModel(int id);
    }
}
