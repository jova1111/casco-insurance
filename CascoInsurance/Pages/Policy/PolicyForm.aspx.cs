using CascoInsurance.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CascoInsurance.Pages.Policy
{
    public partial class PolicyForm : System.Web.UI.Page
    {
        private IAffiliateDao affiliateDao = new AffiliateDaoImpl();
        private IAgentDao agentDao = new AgentDaoImpl();
        private IRiskPackageDao riskPackageDao = new RiskPackageDaoImpl();
        private IInsuredDao insuredDao = new InsuredDaoImpl();
        private IVehicleDao vehicleDao = new VehicleDaoImpl();
        private IPolicyDao policyDao = new PolicyDaoImpl();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAffiliateDropDownValues();
                BindAgentDropDownValues();
                BindRiskPackageDropDownValues();
                BindInsuredDropDownValues();
                BindVehicleDropDownValues();
            }
        }

        private void BindVehicleDropDownValues()
        {
            List<Model.Vehicle> vehicles = vehicleDao.GetAllVehicles();
            registerNumberDropDown.DataSource = vehicles;
            registerNumberDropDown.DataValueField = "RegisterNumber";
            registerNumberDropDown.DataTextField = "RegisterNumber";
            registerNumberDropDown.DataBind();
            registerNumberDropDown.Items.Insert(0, new ListItem("--Izaberi registarski broj--", "0"));
        }

        private void BindInsuredDropDownValues()
        {
            List<Model.Insured> insuredPersons = insuredDao.GetAllInsured();
            insuredDropDown.DataSource = insuredPersons;
            insuredDropDown.DataValueField = "Id";
            insuredDropDown.DataTextField = "AccountNumber";
            insuredDropDown.DataBind();
            insuredDropDown.Items.Insert(0, new ListItem("--Izaberi osiguranika--", "0"));
        }

        private void BindRiskPackageDropDownValues()
        {
            List<Model.RiskPackage> riskPackages = riskPackageDao.GetAllRiskPackages();
            riskPackageDropDown.DataSource = riskPackages;
            riskPackageDropDown.DataValueField = "Id";
            riskPackageDropDown.DataTextField = "Name";
            riskPackageDropDown.DataBind();
            riskPackageDropDown.Items.Insert(0, new ListItem("--Izaberi paket rizika--", "0"));
        }

        private void BindAgentDropDownValues()
        {
            List<Model.Agent> agents = agentDao.GetAllAgents();
            agentDropDown.DataSource = agents;
            agentDropDown.DataValueField = "Id";
            agentDropDown.DataTextField = "FullName";
            agentDropDown.DataBind();
            agentDropDown.Items.Insert(0, new ListItem("--Izaberi agenta--", "0"));
        }

        private void BindAffiliateDropDownValues()
        {
            List<Model.Affiliate> affiliates = affiliateDao.GetAllAffiliates();
            affiliateDropDown.DataSource = affiliates;
            affiliateDropDown.DataValueField = "Id";
            affiliateDropDown.DataTextField = "Name";
            affiliateDropDown.DataBind();
            affiliateDropDown.Items.Insert(0, new ListItem("--Izaberi filijalu--", "0"));
            
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            Model.Affiliate affiliate = new Model.Affiliate
            {
                Id = Convert.ToInt32(affiliateDropDown.SelectedItem.Value)
            };

            Model.Agent agent = new Model.Agent
            {
                Id = Convert.ToInt32(agentDropDown.SelectedItem.Value)
            };

            Model.RiskPackage riskPackage = new Model.RiskPackage
            {
                Id = Convert.ToInt32(riskPackageDropDown.SelectedItem.Value)
            };

            Model.Insured insured = new Model.Insured
            {
                Id = Convert.ToInt32(insuredDropDown.SelectedItem.Value)
            };

            Model.Vehicle vehicle = new Model.Vehicle
            {
                RegisterNumber = registerNumberDropDown.SelectedItem.Value
            };

            Model.Policy policy = new Model.Policy
            {
                CreatedOn = DateTime.Now,
                StartDate = Convert.ToDateTime(startDateTextBox.Value),
                EndDate = Convert.ToDateTime(expireDateTextBox.Value),
                Affiliate = affiliate,
                Agent = agent,
                Insured = insured,
                Premium = Convert.ToDecimal(premiumTextBox.Text),
                RiskPackage = riskPackage,
                Vehicle = vehicle
            };

            policyDao.InsertPolicy(policy);

            Response.Redirect("~/Pages/Policy/Policies.aspx");

        }

        protected void ValidateStartDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime startDate = DateTime.Parse(args.Value);
            DateTime endDate;
            bool userSelectedEndDate = DateTime.TryParse(expireDateTextBox.Value, out endDate);

            if (!userSelectedEndDate)
            {
                args.IsValid = true;
            }

            else if (startDate < endDate)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }

        }
    }
}