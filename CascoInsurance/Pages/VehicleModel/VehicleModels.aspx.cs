using CascoInsurance.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static CascoInsurance.Util.DataTableUtils;

namespace CascoInsurance.Pages.VehicleModel
{
    public partial class VehicleModels : System.Web.UI.Page
    {
        private IVehicleModelDao vehicleModelDao = new VehicleModelDaoImpl();

        protected void Page_Load(object sender, EventArgs e)
        {
            InitTable();
        }

        private void InitTable()
        {
            var allVehicleModels = vehicleModelDao.GetAllVehicleModels();
            vehicleModelsTable.AutoGenerateColumns = true;
            vehicleModelsTable.DataSource = GenerateTableData(allVehicleModels);
            vehicleModelsTable.DataBind();
        }

        private DataTable GenerateTableData(List<Model.VehicleModel> vehicleModels)
        {
            DataTable dataTable = new DataTable("Modeli vozila");

            dataTable.Columns.Add(CreateDataTableColumn("Naziv modela", "System.String"));
            dataTable.Columns.Add(CreateDataTableColumn("Naziv marke", "System.String"));
            dataTable.Columns.Add(CreateDataTableColumn("Zapremina motora", "System.String"));
            dataTable.Columns.Add(CreateDataTableColumn("Vrsta goriva", "System.String"));
            

            DataRow dataRow;
            Model.VehicleModel vehicleModel;

            for (int i = 0; i < vehicleModels.Count; i++)
            {
                vehicleModel = vehicleModels[i];
                dataRow = dataTable.NewRow();
                dataRow["Naziv modela"] = vehicleModel.Name;
                dataRow["Naziv marke"] = vehicleModel.Brand.Name;
                dataRow["Zapremina motora"] = vehicleModel.EngineCapacity;
                dataRow["Vrsta goriva"] = vehicleModel.FuelType.Name;

                dataTable.Rows.Add(dataRow);
            }

            return dataTable;

        }
    }
}