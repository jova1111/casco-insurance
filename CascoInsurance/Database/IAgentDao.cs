using CascoInsurance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CascoInsurance.Database
{
    interface IAgentDao
    {
        List<Agent> GetAllAgents();
        Agent GetAgent(int id);
        void InsertAgent(Agent agent);
        void DeleteAgent(int id);
    }
}
