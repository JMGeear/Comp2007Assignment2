<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="bibleMenu.aspx.cs" Inherits="Comp2007Assignment2.bibleMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblUserId" runat="server" />
      <a href="notes.aspx">Add Note</a>

    <div>
        <label for="ddlPageSize">Records Per Page</label>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
            <asp:ListItem Value="3" Text="3"></asp:ListItem>
            <asp:ListItem Value="5" Text="5"></asp:ListItem>
            <asp:ListItem Value="10" Text="10"></asp:ListItem>
        </asp:DropDownList>
    </div>

    <asp:GridView ID="grdNotes" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false" OnRowDeleting="grdNotes_RowDeleting"
        DataKeyNames="blogID" AllowPaging="true" PageSize="3" OnPageIndexChanging="grdNotes_PageIndexChanging"
        OnRowDataBound="grdNotes_RowDataBound">
        <Columns>
            <asp:BoundField DataField="blogID" Visible="false" />
            <asp:BoundField DataField="bookID" HeaderText="Book" Visible="true"/>
            <asp:BoundField DataField="chapterID" HeaderText="Chapter" />
            <asp:BoundField DataField="verseID" HeaderText="Verse" />
            <asp:BoundField DataField="title" HeaderText="Title" />
        </Columns>
    </asp:GridView>
</asp:Content>
