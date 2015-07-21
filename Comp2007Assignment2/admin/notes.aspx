<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="notes.aspx.cs" Inherits="Comp2007Assignment2.admin.notes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="notes.aspx">Add Note</a>
    <asp:GridView ID="grdNotes" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false" OnRowDeleting="grdNotes_RowDeleting"
         DataKeyNames="blog_ID" AllowPaging="true" PageSize="3" OnPageIndexChanging="grdNotes_PageIndexChanging"
         OnRowDataBound="grdNotes_RowDataBound">
        <Columns>
            <asp:BoundField DataField="blog_ID" Visible="false"/>
            <asp:BoundField DataField="blog_title" HeaderText="Title"/>
            <asp:BoundField DataField="Book" HeaderText="Book" />
            <asp:BoundField DataField="Chapter" HeaderText="Chapter" />
            <asp:BoundField DataField="Verse" HeaderText="Verse" />
        </Columns>
    </asp:GridView>
</asp:Content>
