using CascoInsurance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascoInsurance.Database
{
    interface IRiskPackageDao
    {
        List<RiskPackage> GetAllRiskPackages();
        RiskPackage GetRiskPackage(int id);
        void InsertRiskPackage(RiskPackage riskPackage);
        void DeleteRiskPackage(int id);
    }
}
