<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Comp2007Assignment2.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Login</h1>
    <div>
        <label for="txtUsername">Username: </label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Username Required" ControlToValidate="txtUsername" CssClass="label label-danger"></asp:RequiredFieldValidator>
    </div>
    <div>
        <label for="txtPassword">Password: </label>
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Password Required" ControlToValidate="txtPassword" CssClass="label label-danger"></asp:RequiredFieldValidator>
    </div>
    <div>
        <asp:Button ID="btnLogin" runat="server" Text="Register" OnClick="btnLogin_Click" />
    </div>
</asp:Content>
