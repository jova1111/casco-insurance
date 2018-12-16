using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CascoInsurance.Model;

namespace CascoInsurance.Database
{
    public class VehicleDaoImpl : IVehicleDao
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["KaskoOsiguranje"].ConnectionString;

        public void DeleteVehicle(string registerNumber)
        {
            string queryString = "DELETE FROM Vozilo WHERE registarski_broj = @registerNumber";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                command.Parameters.AddWithValue("@registerNumber", registerNumber);

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

        public List<Vehicle> GetAllVehicles()
        {
            string queryString = "SELECT Vozilo.registarski_broj, Vozilo.broj_motora, Vozilo.broj_sasije, Vozilo.snaga_motora, Vozilo.broj_mesta_za_sedenje, Vozilo.cena, Vozilo.godina_proizvodnje, Model_vozila.broj_modela_vozila, Model_vozila.naziv_modela, Model_vozila.vrsta_goriva, Model_vozila.zapremina_motora, Marka_vozila.ID_marke_vozila, Marka_vozila.naziv_marke_vozila FROM Vozilo JOIN Model_vozila ON (Vozilo.broj_modela_vozila = Model_vozila.broj_modela_vozila) JOIN Marka_vozila ON (Model_vozila.ID_marke_vozila = Marka_vozila.ID_marke_vozila)";
            List<Vehicle> returnList = new List<Vehicle>();

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
                            Id = reader.GetInt32(11),
                            Name = reader.GetString(12)
                        };

                        VehicleModel vehicleModel = new VehicleModel
                        {
                            Id = reader.GetInt32(7),
                            Name = reader.GetString(8),
                            Brand = vehicleBrand,
                            EngineCapacity = reader.GetDecimal(10),
                            FuelType = reader.GetString(9)
                        };

                        Vehicle vehicle = new Vehicle
                        {
                            RegisterNumber = reader.GetString(0),
                            EngineNumber = reader.GetString(1),
                            ChassisNumber = reader.GetString(2),
                            EnginePower = reader.GetInt32(3),
                            NumberOfSeats = reader.GetInt32(4),
                            Price = reader.GetDecimal(5),
                            ProductionYear = reader.GetInt32(6),
                            Model = vehicleModel
                        };

                        returnList.Add(vehicle);
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

        public Vehicle GetVehicle(string registerNumber)
        {
            string queryString = "SELECT Vozilo.registarski_broj, Vozilo.broj_motora, Vozilo.broj_sasije, Vozilo.snaga_motora, Vozilo.broj_mesta_za_sedenje, Vozilo.cena, Vozilo.godina_proizvodnje, Model_vozila.broj_modela_vozila, Model_vozila.naziv_modela, Model_vozila.vrsta_goriva, Model_vozila.zapremina_motora, Marka_vozila.ID_marke_vozila, Marka_vozila.naziv_marke_vozila FROM Vozilo JOIN Model_vozila ON (Vozilo.broj_modela_vozila = Model_vozila.broj_modela_vozila) JOIN Marka_vozila ON (Model_vozila.ID_marke_vozila = Marka_vozila.ID_marke_vozila) WHERE Vozilo.registarski_broj = @registerNumber";
            Vehicle returnValue = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                command.Parameters.AddWithValue("@registerNumber", registerNumber);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        VehicleBrand vehicleBrand = new VehicleBrand
                        {
                            Id = reader.GetInt32(11),
                            Name = reader.GetString(12)
                        };

                        VehicleModel vehicleModel = new VehicleModel
                        {
                            Id = reader.GetInt32(7),
                            Name = reader.GetString(8),
                            Brand = vehicleBrand,
                            EngineCapacity = reader.GetDecimal(10),
                            FuelType = reader.GetString(9)
                        };

                        returnValue = new Vehicle
                        {
                            RegisterNumber = reader.GetString(0),
                            EngineNumber = reader.GetString(1),
                            ChassisNumber = reader.GetString(2),
                            EnginePower = reader.GetInt32(3),
                            NumberOfSeats = reader.GetInt32(4),
                            Price = reader.GetDecimal(5),
                            ProductionYear = reader.GetInt32(6),
                            Model = vehicleModel
                        };
                    }

                    reader.Close();
                    return returnValue;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return returnValue;

                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void InsertVehicle(Vehicle vehicle)
        {
            string queryString = "INSERT INTO Vozilo (registarski_broj, broj_motora, broj_sasije, snaga_motora, broj_mesta_za_sedenje, cena, godina_proizvodnje, broj_modela_vozila) VALUES (@registerNumber, @engineNumber, @chassisNumber, @enginePower, @numberOfSeats, @price, @productionYear, @modelId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                command.Parameters.AddWithValue("@registerNumber", vehicle.RegisterNumber);
                command.Parameters.AddWithValue("@engineNumber", vehicle.EngineNumber);
                command.Parameters.AddWithValue("@chassisNumber", vehicle.ChassisNumber);
                command.Parameters.AddWithValue("@enginePower", vehicle.EnginePower);
                command.Parameters.AddWithValue("@numberOfSeats", vehicle.NumberOfSeats);
                command.Parameters.AddWithValue("@price", vehicle.Price);
                command.Parameters.AddWithValue("@productionYear", vehicle.ProductionYear);
                command.Parameters.AddWithValue("@modelId", vehicle.Model.Id);

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

        public void UpdateVehicle(Vehicle vehicle)
        {
            string queryString = "UPDATE Vozilo SET broj_motora = @engineNumber, broj_sasije = @chassisNumber, snaga_motora = @enginePower, broj_mesta_za_sedenje = @numberOfSeats, cena = @price, godina_proizvodnje = @productionYear, broj_modela_vozila = @modelId WHERE registarski_broj = @registerNumber";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                command.Parameters.AddWithValue("@registerNumber", vehicle.RegisterNumber);
                command.Parameters.AddWithValue("@engineNumber", vehicle.EngineNumber);
                command.Parameters.AddWithValue("@chassisNumber", vehicle.ChassisNumber);
                command.Parameters.AddWithValue("@enginePower", vehicle.EnginePower);
                command.Parameters.AddWithValue("@numberOfSeats", vehicle.NumberOfSeats);
                command.Parameters.AddWithValue("@price", vehicle.Price);
                command.Parameters.AddWithValue("@productionYear", vehicle.ProductionYear);
                command.Parameters.AddWithValue("@modelId", vehicle.Model.Id);

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