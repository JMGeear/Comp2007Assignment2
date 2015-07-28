<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="bible.aspx.cs" Inherits="Comp2007Assignment2.bible" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="well">
        <div class="form-group">
            Book:<asp:DropDownList ID="ddlBook" runat="server" AutoPostBack="True"
                OnSelectedIndexChanged="ddlBook_SelectedIndexChanged" Width="200px" DataTextField="Book"
                DataValueField="Book">
            </asp:DropDownList>
            Chapter:<asp:DropDownList ID="ddlChapter" runat="server" AutoPostBack="True"
                OnSelectedIndexChanged="ddlChapter_SelectedIndexChanged" Width="200px" DataTextField="Chapter"
                DataValueField="Chapter">
            </asp:DropDownList>
        </div>
    </div>

    <asp:Button ID="btnPrevious" runat="server" OnClick="btnPrevious_Click" Text="<< Previous <<" />
    &nbsp;&nbsp;&nbsp;<asp:Label ID="lblCurrentBook" runat="server"  Text="Genesis"/>&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Text=">> Next >>" />

    <asp:ListView ID="lvwBible" runat="server">

    </asp:ListView>


</asp:Content>
