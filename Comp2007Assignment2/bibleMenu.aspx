<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="bibleMenu.aspx.cs" Inherits="Comp2007Assignment2.bibleMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Booklist</h1>

    <asp:GridView ID="grdBible" runat="server" CssClass="table table-striped"
        AutoGenerateColumns="false" DataKeyNames="ID">
        <Columns>        
            <asp:BoundField DataField="Book" HeaderText="Book" />
            <asp:BoundField DataField="Chapter" HeaderText="Chapter" DataFormatString="{0}" />
            <asp:BoundField DataField="Verse" HeaderText="Verse" DataFormatString="{0}" />
            <asp:BoundField DataField="VerseText" HeaderText="Verse" />
        </Columns>

    </asp:GridView>
</asp:Content>
