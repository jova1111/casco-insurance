using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CascoInsurance.Model;

namespace CascoInsurance.Database
{
    public class PolicyDaoImpl : IPolicyDao
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["KaskoOsiguranje"].ConnectionString;

        public void DeletePolicy(int id)
        {
            throw new NotImplementedException();
        }

        public List<Policy> GetAllPolicies()
        {
            string queryString = "SELECT * FROM Polisa JOIN Paket_rizika ON (Polisa.oznaka_paketa_rizika = Paket_rizika.ID_paketa_rizika) JOIN Osiguranik ON (Polisa.ID_osiguranika = Osiguranik.ID_osiguranika) JOIN Filijala ON (Polisa.ID_filijale = Filijala.ID_filijale) JOIN Vozilo ON (Polisa.registarski_broj = Vozilo.registarski_broj) JOIN Agent_osiguranja ON (Polisa.ID_agenta = Agent_osiguranja.ID_agenta)";
            List<Policy> returnList = new List<Policy>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Insured insured = new Insured
                        {
                            Id = reader.GetInt32(6),
                            AccountNumber = reader.GetString(18)
                        };

                        Affiliate affiliate = new Affiliate
                        {
                            Id = reader.GetInt32(19),
                            Name = reader.GetString(20)
                        };

                        RiskPackage riskPackage = new RiskPackage
                        {
                            Id = reader.GetInt32(11),
                            Name = reader.GetString(12)
                        };

                        Vehicle vehicle = new Vehicle
                        {
                            RegisterNumber = reader.GetString(23)
                        };

                        Agent agent = new Agent
                        {
                            Id = reader.GetInt32(31),
                            FirstName = reader.GetString(32),
                            LastName = reader.GetString(33)
                        };

                        Policy policy = new Policy
                        {
                            Id = reader.GetInt32(0),
                            CreatedOn = reader.GetDateTime(1),
                            StartDate = reader.GetDateTime(2),
                            EndDate = reader.GetDateTime(3),
                            Premium = reader.GetDecimal(4),
                            RiskPackage = riskPackage,
                            Insured = insured,
                            Affiliate = affiliate,
                            Vehicle = vehicle,
                            Agent = agent,
                            Bonus = reader.GetInt32(10)
                        };

                        returnList.Add(policy);
                    }

                    reader.Close();
                    return returnList;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return returnList;

                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public Policy GetPolicy(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertPolicy(Policy policy)
        {
            string queryString = "INSERT INTO Polisa (datum_sastavljanja, datum_početka_osiguranja, datum_prestanka_osiguranja, iznos_premije, oznaka_paketa_rizika, ID_osiguranika, ID_filijale, registarski_broj, ID_agenta, bonus) VALUES (@createdOn, @startDate, @endDate, @premium, @riskPackage, @insured, @affiliate, @registerNumber, @agent, @bonus)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                command.Parameters.AddWithValue("@createdOn", policy.CreatedOn);
                command.Parameters.AddWithValue("@startDate", policy.StartDate);
                command.Parameters.AddWithValue("@endDate", policy.EndDate);
                command.Parameters.AddWithValue("@premium", policy.Premium);
                command.Parameters.AddWithValue("@riskPackage", policy.RiskPackage.Id);
                command.Parameters.AddWithValue("@insured", policy.Insured.Id);
                command.Parameters.AddWithValue("@affiliate", policy.Affiliate.Id);
                command.Parameters.AddWithValue("@registerNumber", policy.Vehicle.RegisterNumber);
                command.Parameters.AddWithValue("@agent", policy.Agent.Id);
                command.Parameters.AddWithValue("@bonus", policy.Bonus);

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