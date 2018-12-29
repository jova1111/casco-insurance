using CascoInsurance.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static CascoInsurance.Util.DataTableUtils;

namespace CascoInsurance.Pages.Vehicle
{
    public partial class Vehicles : System.Web.UI.Page
    {
        private IVehicleDao vehicleDao = new VehicleDaoImpl();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var allVehicles = vehicleDao.GetAllVehicles();
                vehiclesTable.AutoGenerateColumns = true;
                vehiclesTable.DataSource = GenerateTableData(allVehicles);
                vehiclesTable.DataBind();
            }
        }

        private DataTable GenerateTableData(List<Model.Vehicle> vehicles)
        {
            DataTable dataTable = new DataTable("Vozila");

            dataTable.Columns.Add(CreateDataTableColumn("Registarski broj", "System.String"));
            dataTable.Columns.Add(CreateDataTableColumn("Broj motora", "System.String"));
            dataTable.Columns.Add(CreateDataTableColumn("Broj sasije", "System.String"));
            dataTable.Columns.Add(CreateDataTableColumn("Marka", "System.String"));
            dataTable.Columns.Add(CreateDataTableColumn("Model", "System.String"));
            dataTable.Columns.Add(CreateDataTableColumn("Snaga motora", "System.String"));
            dataTable.Columns.Add(CreateDataTableColumn("Broj mesta za sedenje", "System.Int32"));
            dataTable.Columns.Add(CreateDataTableColumn("Cena", "System.Decimal"));
            dataTable.Columns.Add(CreateDataTableColumn("Godina proizvodnje", "System.Int32"));
            

            DataRow dataRow;
            Model.Vehicle vehicle;


            for (int i = 0; i < vehicles.Count; i++)
            {
                vehicle = vehicles[i];
                dataRow = dataTable.NewRow();
                dataRow["Registarski broj"] = vehicle.RegisterNumber;
                dataRow["Broj motora"] = vehicle.EngineNumber;
                dataRow["Broj sasije"] = vehicle.ChassisNumber;
                dataRow["Snaga motora"] = vehicle.EnginePower;
                dataRow["Broj mesta za sedenje"] = vehicle.NumberOfSeats;
                dataRow["Cena"] = vehicle.Price;
                dataRow["Godina proizvodnje"] = vehicle.ProductionYear;
                dataRow["Marka"] = vehicle.Model.Brand.Name;
                dataRow["Model"] = vehicle.Model.Name;

                dataTable.Rows.Add(dataRow);
            }

            return dataTable;

        }

        protected void VehiclesTable_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = vehiclesTable.Rows[index];
                string registerNumber = row.Cells[1].Text;

                vehicleDao.DeleteVehicle(registerNumber);

                Response.Redirect(Request.RawUrl);
            }

            if (e.CommandName == "edit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = vehiclesTable.Rows[index];
                string registerNumber = row.Cells[1].Text;

                Response.Redirect("~/Pages/Vehicle/VehicleForm.aspx?regNumber=" + registerNumber);
            }

        }

        protected void VehiclesTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }


        protected void VehiclesTable_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}