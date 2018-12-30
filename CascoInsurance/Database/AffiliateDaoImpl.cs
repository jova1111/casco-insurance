using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CascoInsurance.Model;

namespace CascoInsurance.Database
{
    public class AffiliateDaoImpl : IAffiliateDao
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["KaskoOsiguranje"].ConnectionString;

        public void DeleteAffiliate(int id)
        {
            throw new NotImplementedException();
        }

        public Affiliate GetAffiliate(int id)
        {
            throw new NotImplementedException();
        }

        public List<Affiliate> GetAllAffiliates()
        {
            string queryString = "SELECT * FROM Filijala";
            List<Affiliate> returnList = new List<Affiliate>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Affiliate affilate = new Affiliate
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Address = reader.GetString(2),
                            City = reader.GetString(3)
                        };
                        returnList.Add(affilate);
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

        public void InsertAffiliate(Affiliate affiliate)
        {
            throw new NotImplementedException();
        }
    }
}