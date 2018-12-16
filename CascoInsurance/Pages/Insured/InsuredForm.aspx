<%@ Page Language="C#" MasterPageFile="../../Site.Master" AutoEventWireup="true" CodeBehind="InsuredForm.aspx.cs" Inherits="CascoInsurance.Pages.Insured.InsuredForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    

        <h2>Nov osiguranik</h2>
        <br />

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="addressTextBox">Adresa</asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="addressTextBox"/>
            <asp:RequiredFieldValidator ID="addressRequiredValidator" runat="server" ControlToValidate="addressTextBox" ErrorMessage="Unos adrese je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        </div>
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="phoneNumberTextBox">Broj telefona</asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="phoneNumberTextBox"/>
            <asp:RequiredFieldValidator ID="phoneNumberRequiredValidator" runat="server" ControlToValidate="phoneNumberTextBox" ErrorMessage="Unos broja telefona je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="emailTextBox">Imejl</asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" Id="emailTextBox"/>
            <asp:RequiredFieldValidator ID="emailRequiredValidator" runat="server" ControlToValidate="emailTextBox" ErrorMessage="Unos imejla je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="emailCorrectValidator" runat="server" ControlToValidate="emailTextBox" ErrorMessage="Imejl mora biti u ispravnom formatu" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="accountNumberTextBox">Broj tekuceg racuna</asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" Id="accountNumberTextBox"/>
            <asp:RequiredFieldValidator ID="accountNumberValidator" runat="server" ControlToValidate="accountNumberTextBox" ErrorMessage="Unos broja tekuceg racuna je obavezan" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        </div>
        
        <asp:Button  Runat="server" CssClass="btn btn-primary" OnClick="SubmitButton_Click" ID="submitButtonClick" Text="Kreiraj"/>


</asp:Content>
