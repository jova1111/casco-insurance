using CascoInsurance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascoInsurance.Database
{
    interface IInsuredDao
    {
        List<Insured> GetAllInsured();
        Insured GetInsured(int id);
        void InsertInsured(Insured insured);
        void DeleteInsured(int id);
    }
}
