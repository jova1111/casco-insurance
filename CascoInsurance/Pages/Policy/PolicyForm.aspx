<%@ Page Language="C#" MasterPageFile="../../Site.Master" AutoEventWireup="true" CodeBehind="PolicyForm.aspx.cs" Inherits="CascoInsurance.Pages.Policy.PolicyForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
   <h2>Nova polisa</h2>
        <br />

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="startDateTextBox">Datum pocetka osiguranja</asp:Label>
            <input type="date" runat="server" class="form-control" ID="startDateTextBox"/>
            <asp:RequiredFieldValidator ID="startDateRequiredValidator" runat="server" ControlToValidate="startDateTextBox" ErrorMessage="Datum pocetka je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            <br />
            <asp:CustomValidator runat="server"
                ID="validateStartDate" 
                ControlToValidate="startDateTextBox"
                onservervalidate="ValidateStartDate_ServerValidate" 
                ErrorMessage="Datum pocetka mora biti pre datuma kraja." 
                ForeColor="#FF3300" />
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="expireDateTextBox">Datum kraja osiguranja</asp:Label>
            <input type="date" runat="server" class="form-control" ID="expireDateTextBox"/>
            <asp:RequiredFieldValidator ID="endDateRequiredValidator" runat="server" ControlToValidate="expireDateTextBox" ErrorMessage="Datum kraja je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="riskPackageDropDown">Paket rizika</asp:Label>
            <asp:DropDownList runat="server" CssClass="form-control" ID="riskPackageDropDown"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="riskPackageRequiredValidator" runat="server" ControlToValidate="riskPackageDropDown" InitialValue="0" ErrorMessage="Izbor paketa rizika je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="insuredDropDown">Osiguranik</asp:Label>
            <asp:DropDownList runat="server" CssClass="form-control" ID="insuredDropDown"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="requiredInsuredSelectValidator" runat="server" ControlToValidate="insuredDropDown" InitialValue="0" ErrorMessage="Izbor osiguranika je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="affiliateDropDown">Filijala</asp:Label>
            <asp:DropDownList runat="server" CssClass="form-control" ID="affiliateDropDown"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="requiredAffiliateSelectValidator" runat="server" ControlToValidate="affiliateDropDown" InitialValue="0" ErrorMessage="Izbor filijale je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="agentDropDown">Agent</asp:Label>
            <asp:DropDownList runat="server" CssClass="form-control" ID="agentDropDown"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="requiredAgentSelectValidator" runat="server" ControlToValidate="agentDropDown" InitialValue="0" ErrorMessage="Izbor agenta je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="registerNumberDropDown">Registarski broj vozila</asp:Label>
            <asp:DropDownList runat="server" CssClass="form-control" ID="registerNumberDropDown"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="requiredRegisterNumberValidator" runat="server" ControlToValidate="registerNumberDropDown" InitialValue="0" ErrorMessage="Izbor registarskog broja je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        </div>

         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="premiumTextBox">Iznos premije</asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="premiumTextBox"/>
            <asp:RequiredFieldValidator ID="premiumRequiredValidator" runat="server" ControlToValidate="premiumTextBox" ErrorMessage="Unos premije je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            <br />
            <asp:RangeValidator ID="premiumRangeValidator" runat="server" ControlToValidate="premiumTextBox" Type="Double" ErrorMessage="Premija mora biti izmedju 0.1 i 100000000" MaximumValue="100000000" MinimumValue="0.1" ForeColor="#FF3300"></asp:RangeValidator>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="bonusTextBox">Bonus</asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="bonusTextBox"/>
            <asp:RequiredFieldValidator ID="bonusRequiredValidator" runat="server" ControlToValidate="bonusTextBox" ErrorMessage="Unos bonusa je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            <br />
            <asp:RangeValidator ID="bounsRangeValidator" runat="server" ControlToValidate="bonusTextBox" Type="Integer" ErrorMessage="Bonus mora biti izmedju 0 i 100" MaximumValue="100" MinimumValue="0" ForeColor="#FF3300"></asp:RangeValidator>
        </div>
        
        <asp:Button  Runat="server" CssClass="btn btn-primary" OnClick="SubmitButton_Click" ID="submitButtonClick" Text="Kreiraj"/>

</asp:Content>
