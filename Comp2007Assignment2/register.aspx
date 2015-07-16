<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Comp2007Assignment2.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Registration</h1>
    <h5>All Fields Are Required</h5>

    <div>
        <label for="txtFName">First Name: </label>
        <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="First Name Required" ControlToValidate="txtFName" CssClass="label label-danger"></asp:RequiredFieldValidator>
    </div>
    <div>
        <label for="txtLName">Last Name: </label>
        <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last Name Required" ControlToValidate="txtLName" CssClass="label label-danger"></asp:RequiredFieldValidator>
    </div>
    <div>
        <label for="txtUsername">Username: </label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Username Required" ControlToValidate="txtUsername" CssClass="label label-danger"></asp:RequiredFieldValidator>
    </div>
    <div>
        <label for="txtPassword">Password: </label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Password Required" ControlToValidate="txtPassword" CssClass="label label-danger"></asp:RequiredFieldValidator>
    </div>
    <div>
        <label for="txtPassword">Confirm Password: </label>
        <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Password Required" ControlToValidate="txtConfirm" CssClass="label label-danger"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passwords Do Not Match" ControlToCompare="txtPassword" Operator="Equal" ControlToValidate="txtConfirm" CssClass="label label-danger"></asp:CompareValidator>
    </div>
    <div>
        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
    </div>
</asp:Content>
