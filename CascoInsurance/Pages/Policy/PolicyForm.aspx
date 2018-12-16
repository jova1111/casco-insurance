<%@ Page Language="C#" MasterPageFile="../../Site.Master" AutoEventWireup="true" CodeBehind="PolicyForm.aspx.cs" Inherits="CascoInsurance.Pages.Policy.PolicyForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        <h2>Nova polisa</h2>
        <br />
        <div class="form-group">
            <label>Datum sastavljanja</label>
            <input autofocus class="form-control" type="date"/>
        </div>
        
        <div class="form-group">
            <label>Datum pocetka osiguranja</label>
            <input class="form-control" type="date"/>
        </div>

        <div class="form-group">
            <label>Datum prestanka osiguranja</label>
            <input class="form-control" type="date"/>
        </div>

        <div class="form-group">
            <label>Iznos premije</label>
            <input class="form-control" type="text"/>
        </div>

        <div class="form-group">
            <label>Oznaka paketa rizika</label>
            <select class="form-control">
                <option>1</option>
                <option>2</option>
            </select>
        </div>

        <div class="form-group">
            <label>Osiguranik</label>
            <select class="form-control"></select>
        </div>

        <div class="form-group">
            <label>Filijala</label>
            <select class="form-control"></select>
        </div>

        <div class="form-group">
            <label>Registarski broj</label>
            <input class="form-control" type="text"/>
        </div>

        <div class="form-group">
            <label>Bonus</label>
            <input class="form-control" type="text"/>
        </div>

        <input class="btn btn-primary" type="button" value="Kreiraj"/>
    </div>

</asp:Content>
