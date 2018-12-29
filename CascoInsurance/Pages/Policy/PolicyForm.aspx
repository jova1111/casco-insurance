<%@ Page Language="C#" MasterPageFile="../../Site.Master" AutoEventWireup="true" CodeBehind="PolicyForm.aspx.cs" Inherits="CascoInsurance.Pages.Policy.PolicyForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
   <h2>Nova polisa</h2>
        <br />

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="startDateTextBox">Datum pocetka osiguranja</asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="startDateTextBox"/>
            <asp:RequiredFieldValidator ID="startDateRequiredValidator" runat="server" ControlToValidate="startDateTextBox" ErrorMessage="Datum pocetka je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="endDateTextBox">Datum prestanka osiguranja</asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="endDateTextBox"/>
            <asp:RequiredFieldValidator ID="endDateRequiredValidator" runat="server" ControlToValidate="endDateTextBox" ErrorMessage="Datum prestanka je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:DropDownList runat="server" CssClass="form-control" ID="vehicleBrandDropDown"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="requiredBrandSelectValidator" runat="server" ControlToValidate="vehicleBrandDropDown" InitialValue="0" ErrorMessage="Izbor marke je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="engineCapacityTextBox">Zapremina motora</asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="engineCapacityTextBox"/>
            <asp:RequiredFieldValidator ID="engineCapacityValidator" runat="server" ControlToValidate="engineCapacityTextBox" ErrorMessage="Unos kapaciteta je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            <br />
            <asp:RangeValidator ID="engineCapacityRangeValidator" runat="server" ControlToValidate="engineCapacityTextBox" Type="Double" ErrorMessage="Kapacitet mora biti izmedju 0.1 i 10" MaximumValue="10" MinimumValue="0.1" ForeColor="#FF3300"></asp:RangeValidator>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="fuelTypeTextBox">Tip goriva</asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="fuelTypeTextBox"/>
            <asp:RequiredFieldValidator ID="fuelTypeRequiredValidator" runat="server" ControlToValidate="fuelTypeTextBox" ErrorMessage="Unos tipa goriva je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        </div>
        
        <asp:Button  Runat="server" CssClass="btn btn-primary" OnClick="SubmitButton_Click" ID="submitButtonClick" Text="Kreiraj"/>

</asp:Content>
