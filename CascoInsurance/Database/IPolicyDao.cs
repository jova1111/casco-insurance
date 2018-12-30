using CascoInsurance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascoInsurance.Database
{
    interface IPolicyDao
    {
        List<Policy> GetAllPolicies();
        Policy GetPolicy(int id);
        void InsertPolicy(Policy policy);
        void DeletePolicy(int id);
    }
}
