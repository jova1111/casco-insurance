using CascoInsurance.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static CascoInsurance.Util.DataTableUtils;

namespace CascoInsurance.Pages
{
    public partial class Policies : System.Web.UI.Page
    {
        private IPolicyDao policyDao = new PolicyDaoImpl();

        protected void Page_Load(object sender, EventArgs e)
        {
            InitTableData();
        }

        private void InitTableData()
        {
            var allPolicies = policyDao.GetAllPolicies();
            policiesTable.AutoGenerateColumns = true;
            policiesTable.DataSource = GenerateTableData(allPolicies);
            policiesTable.DataBind();
        }

        private DataTable GenerateTableData(List<Model.Policy> policies)
        {
            DataTable dataTable = new DataTable("Polise");

            dataTable.Columns.Add(CreateDataTableColumn("Datum sastavljanja", "System.DateTime"));
            dataTable.Columns.Add(CreateDataTableColumn("Datum pocetka osiguranja", "System.DateTime"));
            dataTable.Columns.Add(CreateDataTableColumn("Datum prestanka osiguranja", "System.DateTime"));
            dataTable.Columns.Add(CreateDataTableColumn("Iznos premije", "System.Decimal"));
            dataTable.Columns.Add(CreateDataTableColumn("Paket rizika", "System.String"));
            dataTable.Columns.Add(CreateDataTableColumn("Osiguranik", "System.String"));
            dataTable.Columns.Add(CreateDataTableColumn("Filijala", "System.String"));
            dataTable.Columns.Add(CreateDataTableColumn("Registarski broj", "System.String"));
            dataTable.Columns.Add(CreateDataTableColumn("Agent", "System.String"));
            dataTable.Columns.Add(CreateDataTableColumn("Bonus", "System.Int32"));

            DataRow dataRow;
            Model.Policy policy;

            for (int i = 0; i < policies.Count; i++)
            {
                policy = policies[i];
                dataRow = dataTable.NewRow();
                dataRow["Datum sastavljanja"] = policy.CreatedOn;
                dataRow["Datum pocetka osiguranja"] = policy.StartDate;
                dataRow["Datum prestanka osiguranja"] = policy.EndDate;
                dataRow["Iznos premije"] = policy.Premium;
                dataRow["Paket rizika"] = policy.RiskPackage.Name;
                dataRow["Osiguranik"] = policy.Insured.AccountNumber;
                dataRow["Filijala"] = policy.Affiliate.Name;
                dataRow["Registarski broj"] = policy.Vehicle.RegisterNumber;
                dataRow["Agent"] = policy.Agent.FullName;
                dataRow["Bonus"] = policy.Bonus;

                dataTable.Rows.Add(dataRow);
            }

            return dataTable;

        }
    }
}