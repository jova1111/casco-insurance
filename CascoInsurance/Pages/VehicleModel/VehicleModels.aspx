<%@ Page Language="C#" MasterPageFile="../../Site.Master" AutoEventWireup="true" CodeBehind="VehicleModels.aspx.cs" Inherits="CascoInsurance.Pages.VehicleModel.VehicleModels" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1 style="text-align: center">Modeli vozila</h1>
    <br />

    <asp:GridView id="vehicleModelsTable" Width="80%" HorizontalAlign="Center" CssClass="table" runat="server">
      
    </asp:GridView>

    <asp:HyperLink NavigateUrl="~/Pages/VehicleModel/VehicleModelForm.aspx" Text="Dodaj novi model" runat="server"></asp:HyperLink>

</asp:Content>
