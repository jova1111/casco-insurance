using CascoInsurance.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CascoInsurance.Pages.Insured
{
    public partial class InsuredForm : System.Web.UI.Page
    {
        private IInsuredDao insuredDao = new InsuredDaoImpl();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            Model.Insured newInsured = new Model.Insured
            {
                AccountNumber = accountNumberTextBox.Text,
                Address = addressTextBox.Text,
                Email = emailTextBox.Text,
                PhoneNumber = phoneNumberTextBox.Text
            };

            insuredDao.InsertInsured(newInsured);
            Response.Redirect("~/Pages/Insured/InsuredPersons.aspx");

        }
    }
}