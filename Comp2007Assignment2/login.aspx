<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Comp2007Assignment2.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Login</h1>
 
    <div class="well col-sm-6">        
        <asp:Label ID="lblStatus" runat="server" />
        <div class="form-group">
            <label for="txtUsername" class="control-label col-sm-3">Username: </label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Username Required" ControlToValidate="txtUsername" CssClass="label label-danger"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="txtPassword" class="control-label col-sm-3">Password: </label>
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Password Required" ControlToValidate="txtPassword" CssClass="label label-danger"></asp:RequiredFieldValidator>
        </div>
        <div class="col-sm-2 col-sm-offset-3">
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        </div>        
    </div>

</asp:Content>
