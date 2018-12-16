using CascoInsurance.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CascoInsurance.Pages.VehicleBrand
{
    public partial class VehicleBrands : System.Web.UI.Page
    {
        private IVehicleBrandDao vehicleBrandDao = new VehicleBrandDaoImpl();

        protected void Page_Load(object sender, EventArgs e)
        {
            var allVehicleBrands = vehicleBrandDao.GetAllVehicleBrands();
            vehicleBrandsTable.AutoGenerateColumns = true;
            vehicleBrandsTable.DataSource = allVehicleBrands;
            vehicleBrandsTable.DataBind();
        }

        protected void VehicleBrandsTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Id";
                e.Row.Cells[1].Text = "Naziv";
            }
        }
    }
}