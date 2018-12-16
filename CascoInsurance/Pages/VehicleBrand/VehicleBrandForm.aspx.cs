using CascoInsurance.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CascoInsurance.Pages.VehicleBrand
{
    public partial class VehicleBrandForm : System.Web.UI.Page
    {
        private IVehicleBrandDao vehicleBrandDao = new VehicleBrandDaoImpl();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            Model.VehicleBrand newVehicleBrand = new Model.VehicleBrand
            {
                Name = nameTextBox.Text
            };

            vehicleBrandDao.InsertVehicleBrand(newVehicleBrand);
            Response.Redirect("~/Pages/VehicleBrand/VehicleBrands.aspx");

        }
    }
}