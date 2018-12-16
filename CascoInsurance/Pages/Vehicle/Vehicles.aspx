<%@ Page EnableEventValidation="false" Language="C#" MasterPageFile="../../Site.Master" AutoEventWireup="true" CodeBehind="Vehicles.aspx.cs" Inherits="CascoInsurance.Pages.Vehicle.Vehicles" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1 style="text-align: center">Vozila</h1>
    <br />

    <asp:GridView id="vehiclesTable" Width="80%" HorizontalAlign="Center" CssClass="table" runat="server" OnRowCommand="VehiclesTable_RowCommand" OnRowEditing="VehiclesTable_RowEditing" OnRowDeleting="VehiclesTable_RowDeleting">
        <Columns>

        <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button
                        ID="DeleteButton" 
                        CommandName="delete"
                        CausesValidation="false"
                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                        Text="Izbrisi" 
                        runat="server" />
                    <asp:Button
                        ID="EditButton" 
                        CommandName="edit"
                        CausesValidation="false"
                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                        Text="Izmeni" 
                        runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:HyperLink NavigateUrl="~/Pages/Vehicle/VehicleForm.aspx" Text="Dodaj novo vozilo" runat="server"></asp:HyperLink>

</asp:Content>
