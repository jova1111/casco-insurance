using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CascoInsurance.Model;

namespace CascoInsurance.Database
{
    public class RiskPackageDaoImpl : IRiskPackageDao
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["KaskoOsiguranje"].ConnectionString;

        public void DeleteRiskPackage(int id)
        {
            throw new NotImplementedException();
        }

        public List<RiskPackage> GetAllRiskPackages()
        {
            string queryString = "SELECT * FROM Paket_rizika";
            List<RiskPackage> returnList = new List<RiskPackage>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        RiskPackage riskPackage = new RiskPackage
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            PercentageValue = reader.GetDecimal(2)
                        };
                        returnList.Add(riskPackage);
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

        public RiskPackage GetRiskPackage(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertRiskPackage(RiskPackage riskPackage)
        {
            throw new NotImplementedException();
        }
    }
}