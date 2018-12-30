<%@ Page Language="C#" MasterPageFile="../../Site.Master" AutoEventWireup="true" CodeBehind="Policies.aspx.cs" Inherits="CascoInsurance.Pages.Policies" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1 style="text-align: center">Polise</h1>
    <br />

    <asp:GridView id="policiesTable" Width="80%" HorizontalAlign="Center" CssClass="table" runat="server">
      
    </asp:GridView>

    <asp:HyperLink NavigateUrl="~/Pages/Policy/PolicyForm.aspx" Text="Dodaj novu polisu" runat="server"></asp:HyperLink>

</asp:Content>