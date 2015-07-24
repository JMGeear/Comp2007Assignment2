<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="note.aspx.cs" Inherits="Comp2007Assignment2.admin.note" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
        &nbsp;Book:<asp:DropDownList ID="ddlBook" runat="server" AutoPostBack="True"
            OnSelectedIndexChanged="ddlBook_SelectedIndexChanged" Width="110px" onChange="EnableOrDisableButton(true);">
        </asp:DropDownList>
        <br />
        &nbsp; Chapter:<asp:DropDownList ID="ddlChapter" runat="server" AutoPostBack="True"
            OnSelectedIndexChanged="ddlChapter_SelectedIndexChanged" Width="110px" onChange="EnableOrDisableButton(true);">
        </asp:DropDownList>
        <br />
        &nbsp;&nbsp; Verse:&nbsp;&nbsp;&nbsp; :<asp:DropDownList ID="ddlVerse" runat="server"
            onChange="onChange();" Width="110px">
        </asp:DropDownList>
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
            Width="66px" />
    </div>
    <p>
        <asp:Label ID="lblResult" runat="server"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:HiddenField ID="hdfDdlVerseSelectIndex" runat="server" />
    </p>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/notes.aspx">Go Back To Default page</asp:HyperLink>
</asp:Content>
