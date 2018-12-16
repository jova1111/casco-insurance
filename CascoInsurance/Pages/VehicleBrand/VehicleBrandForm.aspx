<%@ Page Language="C#" MasterPageFile="../../Site.Master" AutoEventWireup="true" CodeBehind="VehicleBrandForm.aspx.cs" Inherits="CascoInsurance.Pages.VehicleBrand.VehicleBrandForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    

        <h2>Nova marka</h2>
        <br />

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="nameTextBox">Naziv</asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="nameTextBox"/>
            <asp:RequiredFieldValidator ID="nameRequiredValidator" runat="server" ControlToValidate="nameTextBox" ErrorMessage="Unos naziva je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        </div>
        
        <asp:Button  Runat="server" CssClass="btn btn-primary" OnClick="SubmitButton_Click" ID="submitButtonClick" Text="Kreiraj"/>

</asp:Content>

