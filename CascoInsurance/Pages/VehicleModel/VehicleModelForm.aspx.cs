using CascoInsurance.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CascoInsurance.Pages.VehicleModel
{
    public partial class VehicleModelForm : System.Web.UI.Page
    {
        private IVehicleModelDao vehicleModelDao = new VehicleModelDaoImpl();
        private IVehicleBrandDao vehicleBrandDao = new VehicleBrandDaoImpl();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBrandDropDownValues();
                BindFuelTypeRadioButtons();
            }
            
        }

        private void BindBrandDropDownValues()
        {
            List<Model.VehicleBrand> vehicleBrands = vehicleBrandDao.GetAllVehicleBrands();
            vehicleBrandDropDown.DataSource = vehicleBrands;
            vehicleBrandDropDown.DataValueField = "Id";
            vehicleBrandDropDown.DataTextField = "Name";
            vehicleBrandDropDown.DataBind();
            vehicleBrandDropDown.Items.Insert(0, new ListItem("--Izaberi marku--", "0"));
        }

        private void BindFuelTypeRadioButtons()
        {
            var fuelTypes = vehicleModelDao.GetAllVehicleModels()
                .GroupBy(model => model.FuelType.Id)
                .Select(model => model.FirstOrDefault().FuelType);

            fuelTypeRadio.DataSource = fuelTypes;
            fuelTypeRadio.DataValueField = "Id";
            fuelTypeRadio.DataTextField = "Name";
            fuelTypeRadio.DataBind();
            fuelTypeRadio.Items[0].Selected = true;
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            Model.VehicleBrand brand = new Model.VehicleBrand
            {
                Id = Convert.ToInt32(vehicleBrandDropDown.SelectedItem.Value)
            };

            Model.FuelType fuelType = new Model.FuelType
            {
                Id = Convert.ToInt32(fuelTypeRadio.SelectedValue)
            };

            Model.VehicleModel newVehicleModel = new Model.VehicleModel
            {
                Name = nameTextBox.Text,
                Brand = brand,
                EngineCapacity = Convert.ToDecimal(engineCapacityTextBox.Text),
                FuelType = fuelType
            };

            vehicleModelDao.InsertVehicleModel(newVehicleModel);
            Response.Redirect("~/Pages/VehicleModel/VehicleModels.aspx");

        }
    }
}