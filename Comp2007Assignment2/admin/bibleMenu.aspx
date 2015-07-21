<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="bibleMenu.aspx.cs" Inherits="Comp2007Assignment2.bibleMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Booklist</h1>
    <div class="well">
        <div>
            <label for="ddlPageSize">Records Per Page:</label>
            <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true"
                OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                <asp:ListItem Value="15" Text="15" />
                <asp:ListItem Value="25" Text="25" />
                <asp:ListItem Value="999999" Text="All" />
            </asp:DropDownList>
        </div>

        <asp:GridView ID="grdBible" runat="server" CssClass="table table-striped"
            AutoGenerateColumns="false" DataKeyNames="ID" AllowPaging="true" PageSize="3"
            OnPageIndexChanging="grdBible_PageIndexChanging" AllowSorting="true" OnSorting="grdBible_Sorting">
            <Columns>
                <asp:BoundField DataField="Book" HeaderText="Book" />
                <asp:BoundField DataField="Chapter" HeaderText="Chapter" DataFormatString="{0}" />
                <asp:BoundField DataField="Verse" HeaderText="Verse" DataFormatString="{0}" />
                <asp:BoundField DataField="VerseText" HeaderText="Verse" />
            </Columns>

        </asp:GridView>
    </div>
</asp:Content>
