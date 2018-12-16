<%@ Page Language="C#" MasterPageFile="../../Site.Master" AutoEventWireup="true" CodeBehind="VehicleBrands.aspx.cs" Inherits="CascoInsurance.Pages.VehicleBrand.VehicleBrands" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1 style="text-align: center">Marke vozila</h1>
    <br />

    <asp:GridView id="vehicleBrandsTable" Width="80%" HorizontalAlign="Center" CssClass="table" runat="server" OnRowDataBound="VehicleBrandsTable_RowDataBound">
      
    </asp:GridView>

    <asp:HyperLink NavigateUrl="~/Pages/VehicleBrand/VehicleBrandForm.aspx" Text="Dodaj novu marku" runat="server"></asp:HyperLink>

</asp:Content>
