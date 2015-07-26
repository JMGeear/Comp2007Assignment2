<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="note.aspx.cs" Inherits="Comp2007Assignment2.admin.note" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
        &nbsp;Book:<asp:DropDownList ID="ddlBook" runat="server" AutoPostBack="True" 
            OnSelectedIndexChanged="ddlBook_SelectedIndexChanged" Width="110px" DataTextField="Book" DataValueField="Book" >
        </asp:DropDownList>
        <br />
        &nbsp; Chapter:<asp:DropDownList ID="ddlChapter" runat="server" AutoPostBack="True"
            OnSelectedIndexChanged="ddlChapter_SelectedIndexChanged" Width="110px" DataTextField="Chapter" DataValueField="Chapter">
        </asp:DropDownList>
        <br />
        &nbsp;&nbsp; Verse:&nbsp;&nbsp;&nbsp; :<asp:DropDownList ID="ddlVerse" runat="server"
             Width="110px" DataTextField="Verse" DataValueField="Verse">
        </asp:DropDownList>
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Select" OnClick="btnSubmit_Click"
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
    <div class="form-group">
        <asp:Label ID="txtTitle" runat="server" class="control-label col-sm-2">Title:</asp:Label>
    <asp:TextBox ID="txtTitle" runat="server" required MaxLength="100"></asp:TextBox>
</div>
    <div class="form-group">
        <asp:Label ID="txtBlog" runat="server"class="control-label col-sm-2">Note:</asp:Label>
    <asp:TextBox ID="txtBlog" runat="server" Height="400px" Width="600px"></asp:TextBox>
    </div>
    <div class="col-sm-2 col-sm-offset-2">
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary" />
        </div>

</asp:Content>
