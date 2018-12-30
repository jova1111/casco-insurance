using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CascoInsurance.Model;

namespace CascoInsurance.Database
{
    public class AgentDaoImpl : IAgentDao
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["KaskoOsiguranje"].ConnectionString;

        public void DeleteAgent(int id)
        {
            throw new NotImplementedException();
        }

        public Agent GetAgent(int id)
        {
            throw new NotImplementedException();
        }

        public List<Agent> GetAllAgents()
        {
            string queryString = "SELECT * FROM Agent_osiguranja JOIN Filijala ON (Agent_osiguranja.ID_filijale = Filijala.ID_filijale)";
            List<Agent> returnList = new List<Agent>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Affiliate affiliate = new Affiliate
                        {
                            Id = reader.GetInt32(6),
                            Name = reader.GetString(7),
                            Address = reader.GetString(8),
                            City = reader.GetString(9)
                        };

                        Agent agent = new Agent
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            PhoneNumber = reader.GetString(3),
                            Email = reader.GetString(4),
                            Affiliate = affiliate
                        };


                        returnList.Add(agent);
                    }

                    reader.Close();
                    return returnList;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void InsertAgent(Agent agent)
        {
            throw new NotImplementedException();
        }
    }
}