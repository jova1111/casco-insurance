using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CascoInsurance.Model;
using System.Data.SqlClient;

namespace CascoInsurance.Database
{
    public class InsuredDaoImpl : IInsuredDao
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["KaskoOsiguranje"].ConnectionString;


        public InsuredDaoImpl()
        {
        }

        public void DeleteInsured(int id)
        {
            throw new NotImplementedException();
        }

        public List<Insured> GetAllInsured()
        {
            string queryString = "SELECT * FROM Osiguranik";
            List<Insured> returnList = new List<Insured>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Insured insured = new Insured();
                        insured.Id = reader.GetInt32(0);
                        insured.Address = reader.GetString(1);
                        insured.PhoneNumber = reader.GetString(2);
                        insured.Email = reader.GetString(3);
                        insured.AccountNumber = reader.GetString(4);
                        returnList.Add(insured);
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

        public Insured GetInsured(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertInsured(Insured insured)
        {
            string queryString = "INSERT INTO Osiguranik (adresa, broj_telefona, email, broj_tekućeg_računa) VALUES (@address, @phoneNumber, @email, @accountNumber)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                command.Parameters.AddWithValue("@address", insured.Address);
                command.Parameters.AddWithValue("@phoneNumber", insured.PhoneNumber);
                command.Parameters.AddWithValue("@email", insured.Email);
                command.Parameters.AddWithValue("@accountNumber", insured.AccountNumber);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
