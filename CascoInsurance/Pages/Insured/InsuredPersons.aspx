<%@ Page Language="C#" MasterPageFile="../../Site.Master" AutoEventWireup="true" CodeBehind="InsuredPersons.aspx.cs" Inherits="CascoInsurance.Pages.Insured.InsuredPersons" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1 style="text-align: center">Osiguranici</h1>
    <br />

    <asp:GridView id="insuredTable" Width="80%" HorizontalAlign="Center" CssClass="table" runat="server" OnRowDataBound="InsuredTable_RowDataBound">
      
    </asp:GridView>

    <asp:HyperLink NavigateUrl="~/Pages/Insured/InsuredForm.aspx" Text="Dodaj novog osiguranika" runat="server"></asp:HyperLink>

</asp:Content>
