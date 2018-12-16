using CascoInsurance.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CascoInsurance.Pages.Insured
{
    public partial class InsuredPersons : System.Web.UI.Page
    {
        private IInsuredDao insuredDao = new InsuredDaoImpl();

        protected void Page_Load(object sender, EventArgs e)
        {
            var allInsured = insuredDao.GetAllInsured();
            insuredTable.AutoGenerateColumns = true;
            insuredTable.DataSource = allInsured;
            insuredTable.DataBind();
            
        }

        protected void InsuredTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Id";
                e.Row.Cells[1].Text = "Adresa";
                e.Row.Cells[2].Text = "Broj telefona";
                e.Row.Cells[3].Text = "Imejl";
                e.Row.Cells[4].Text = "Broj tekuceg racuna";
            }
        }
    }
}