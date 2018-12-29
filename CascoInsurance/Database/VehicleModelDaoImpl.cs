using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CascoInsurance.Model;

namespace CascoInsurance.Database
{
    public class VehicleModelDaoImpl : IVehicleModelDao
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["KaskoOsiguranje"].ConnectionString;


        public void DeleteVehicleModel(int id)
        {
            throw new NotImplementedException();
        }

        public List<VehicleModel> GetAllVehicleModels()
        {
            string queryString = "SELECT Model_vozila.*, Marka_vozila.naziv_marke_vozila, Tip_goriva.naziv FROM Model_vozila INNER JOIN Marka_vozila ON Model_vozila.ID_marke_vozila = Marka_vozila.ID_marke_vozila INNER JOIN Tip_goriva ON Model_vozila.ID_tipa_goriva = Tip_goriva.id";
            List<VehicleModel> returnList = new List<VehicleModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        VehicleBrand vehicleBrand = new VehicleBrand
                        {
                            Id = reader.GetInt32(1),
                            Name = reader.GetString(5)
                        };

                        FuelType fuelType = new FuelType
                        {
                            Id = reader.GetInt32(4),
                            Name = reader.GetString(6)
                        };

                        VehicleModel vehicleModel = new VehicleModel
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(2),
                            Brand = vehicleBrand,
                            EngineCapacity = reader.GetDecimal(3),
                            FuelType = fuelType
                        };
         
                        returnList.Add(vehicleModel);
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

        public VehicleModel GetVehicleModel(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertVehicleModel(VehicleModel vehicleModel)
        {
            string queryString = "INSERT INTO Model_vozila (ID_marke_vozila, naziv_modela, zapremina_motora, ID_tipa_goriva) VALUES (@vehicleBrandId, @name, @engineCapacity, @fuelType)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                command.Parameters.AddWithValue("@vehicleBrandId", vehicleModel.Brand.Id);
                command.Parameters.AddWithValue("@name", vehicleModel.Name);
                command.Parameters.AddWithValue("@engineCapacity", vehicleModel.EngineCapacity);
                command.Parameters.AddWithValue("@fuelType", vehicleModel.FuelType.Id);

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