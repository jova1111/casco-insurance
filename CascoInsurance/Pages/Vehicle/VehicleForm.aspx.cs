using CascoInsurance.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CascoInsurance.Pages.Vehicle
{
    public partial class VehicleForm : System.Web.UI.Page
    {
        private IVehicleDao vehicleDao = new VehicleDaoImpl();
        private IVehicleModelDao vehicleModelDao = new VehicleModelDaoImpl();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindModelDropDownValues();
                string regNumber = Request.QueryString["regNumber"];
                if (!string.IsNullOrEmpty(regNumber)) {
                    Model.Vehicle vehicleForEditing = vehicleDao.GetVehicle(regNumber);

                    if (vehicleForEditing == null) {
                        throw new Exception("Nema vozila sa tim registarskim brojem.");
                    }

                    heading.Text = "<h1>Izmeni vozilo</h1>";
                    submitButton.Text = "Izmeni";
                    registerNumberTextBox.ReadOnly = true;
                    registerNumberTextBox.Text = vehicleForEditing.RegisterNumber;
                    engineNumberTextBox.Text = vehicleForEditing.EngineNumber;
                    chassisNumberTextBox.Text = vehicleForEditing.ChassisNumber;
                    enginePowerTextBox.Text = Convert.ToString(vehicleForEditing.EnginePower);
                    numberOfSeatsTextBox.Text = Convert.ToString(vehicleForEditing.NumberOfSeats);
                    vehicleModelDropDown.SelectedValue = Convert.ToString(vehicleForEditing.Model.Id);
                    priceTextBox.Text = Convert.ToString(vehicleForEditing.Price);
                    productionYearTextBox.Text = Convert.ToString(vehicleForEditing.ProductionYear);
                }
            }
        }

        private void BindModelDropDownValues()
        {
            List<Model.VehicleModel> vehicleModels = vehicleModelDao.GetAllVehicleModels();
            vehicleModelDropDown.DataSource = vehicleModels;
            vehicleModelDropDown.DataValueField = "Id";
            vehicleModelDropDown.DataTextField = "Name";
            vehicleModelDropDown.DataBind();
            vehicleModelDropDown.Items.Insert(0, new ListItem("--Izaberi model--", "0"));
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            Model.VehicleModel model = new Model.VehicleModel
            {
                Id = Convert.ToInt32(vehicleModelDropDown.SelectedItem.Value)
            };

            Model.Vehicle vehicle = new Model.Vehicle
            {
                RegisterNumber = registerNumberTextBox.Text,
                EngineNumber = engineNumberTextBox.Text,
                ChassisNumber = chassisNumberTextBox.Text,
                EnginePower = Convert.ToInt32(enginePowerTextBox.Text),
                NumberOfSeats = Convert.ToInt32(numberOfSeatsTextBox.Text),
                Model = model,
                Price = Convert.ToDecimal(priceTextBox.Text),
                ProductionYear = Convert.ToInt32(productionYearTextBox.Text)
            };

            string regNumber = Request.QueryString["regNumber"];
            if (string.IsNullOrEmpty(regNumber))
            {
                vehicleDao.InsertVehicle(vehicle);
            }
            else
            {
                vehicleDao.UpdateVehicle(vehicle);
            }

            Response.Redirect("~/Pages/Vehicle/Vehicles.aspx");
        }
    }
}