using CascoInsurance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascoInsurance.Database
{
    interface IAffiliateDao
    {
        List<Affiliate> GetAllAffiliates();
        Affiliate GetAffiliate(int id);
        void InsertAffiliate(Affiliate affiliate);
        void DeleteAffiliate(int id);
    }
}
