<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="notes.aspx.cs" Inherits="Comp2007Assignment2.admin.notes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="notes.aspx">Add Note</a>
    <asp:GridView ID="grdNotes" runat="server">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title"/>

        </Columns>
    </asp:GridView>
</asp:Content>
