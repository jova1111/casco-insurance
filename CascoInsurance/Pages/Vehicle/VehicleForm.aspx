<%@ Page MasterPageFile="../../Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="VehicleForm.aspx.cs" Inherits="CascoInsurance.Pages.Vehicle.VehicleForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" ID="heading"><h1>Novo vozilo</h1></asp:Label>
    <br />
    
    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="registerNumberTextBox">Registarski broj</asp:Label>
        <asp:TextBox runat="server" CssClass="form-control" ID="registerNumberTextBox"/>
        <asp:RequiredFieldValidator ID="registerNumberRequiredValidator" runat="server" ControlToValidate="registerNumberTextBox" ErrorMessage="Unos registracionog broja je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="engineNumberTextBox">Broj motora</asp:Label>
        <asp:TextBox runat="server" CssClass="form-control" ID="engineNumberTextBox"/>
        <asp:RequiredFieldValidator ID="engineNumberRequiredValidator" runat="server" ControlToValidate="engineNumberTextBox" ErrorMessage="Unos broja motora je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="chassisNumberTextBox">Broj sasije</asp:Label>
        <asp:TextBox runat="server" CssClass="form-control" ID="chassisNumberTextBox"/>
        <asp:RequiredFieldValidator ID="chassisNumberRequiredValidator" runat="server" ControlToValidate="chassisNumberTextBox" ErrorMessage="Unos broja sasije je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="enginePowerTextBox">Snaga motora</asp:Label>
        <asp:TextBox runat="server" CssClass="form-control" ID="enginePowerTextBox"/>
        <asp:RequiredFieldValidator ID="enginePowerRequiredValidator" runat="server" ControlToValidate="enginePowerTextBox" ErrorMessage="Unos snage motora je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <br />
        <asp:RangeValidator ID="enginPowerRangeValidator" runat="server" ControlToValidate="enginePowerTextBox" Type="Integer" ErrorMessage="Snaga motora mora biti izmedju 1 i 500" MaximumValue="500" MinimumValue="1" ForeColor="#FF3300"></asp:RangeValidator>
    </div>

    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="numberOfSeatsTextBox">Broj sedista za sedenje</asp:Label>
        <asp:TextBox runat="server" CssClass="form-control" ID="numberOfSeatsTextBox"/>
        <asp:RequiredFieldValidator ID="numberOfSeatsRequiredValidator" runat="server" ControlToValidate="numberOfSeatsTextBox" ErrorMessage="Unos broja sedista je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <br />
        <asp:RangeValidator ID="numberOfSeatsRangeValidator" runat="server" ControlToValidate="numberOfSeatsTextBox" Type="Integer" ErrorMessage="Broj mesta mora biti izmedju 1 i 100" MaximumValue="100" MinimumValue="1" ForeColor="#FF3300"></asp:RangeValidator>
    </div>

    <div class="form-group">
        <asp:DropDownList runat="server" CssClass="form-control" ID="vehicleModelDropDown"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="requiredModelSelectValidator" runat="server" ControlToValidate="vehicleModelDropDown" InitialValue="0" ErrorMessage="Izbor modela je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="priceTextBox">Cena</asp:Label>
        <asp:TextBox runat="server" CssClass="form-control" ID="priceTextBox"/>
        <asp:RequiredFieldValidator ID="priceRequiredValidator" runat="server" ControlToValidate="priceTextBox" ErrorMessage="Unos cene je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <br />
        <asp:RangeValidator ID="priceRangeValidator" runat="server" ControlToValidate="priceTextBox" Type="Double" ErrorMessage="Cena mora biti izmedju 1 i 1000000000" MaximumValue="1000000000" MinimumValue="1" ForeColor="#FF3300"></asp:RangeValidator>
    </div>

    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="productionYearTextBox">Godina proizvodnje</asp:Label>
        <asp:TextBox runat="server" CssClass="form-control" ID="productionYearTextBox"/>
        <asp:RequiredFieldValidator ID="productionYearRequiredValidator" runat="server" ControlToValidate="productionYearTextBox" ErrorMessage="Unos godine proizvodnje je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <br />
        <asp:RangeValidator ID="productionYearRangeValidator" runat="server" ControlToValidate="productionYearTextBox" Type="Integer" ErrorMessage="Godina proizvodnje mora biti izmedju 1950 i 2019" MaximumValue="2019" MinimumValue="1950" ForeColor="#FF3300"></asp:RangeValidator>
    </div>

    <asp:Button runat="server" CssClass="btn btn-primary" OnClick="SubmitButton_Click" ID="submitButton" Text="Kreiraj"/>

</asp:Content>