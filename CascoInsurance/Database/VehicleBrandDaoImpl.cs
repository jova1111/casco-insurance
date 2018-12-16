using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CascoInsurance.Model;

namespace CascoInsurance.Database
{
    public class VehicleBrandDaoImpl : IVehicleBrandDao
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["KaskoOsiguranje"].ConnectionString;

        public void DeleteVehicleBrand(int id)
        {
            throw new NotImplementedException();
        }

        public List<VehicleBrand> GetAllVehicleBrands()
        {
            string queryString = "SELECT * FROM Marka_vozila";
            List<VehicleBrand> returnList = new List<VehicleBrand>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        VehicleBrand vehicleBrand = new VehicleBrand();
                        vehicleBrand.Id = reader.GetInt32(0);
                        vehicleBrand.Name = reader.GetString(1);
                        returnList.Add(vehicleBrand);
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

        public VehicleBrand GetVehicleBrand(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertVehicleBrand(VehicleBrand vehicleBrand)
        {
            string queryString = "INSERT INTO Marka_vozila (naziv_marke_vozila) VALUES (@name)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                command.Parameters.AddWithValue("@name", vehicleBrand.Name);
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