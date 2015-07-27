<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="note.aspx.cs" Inherits="Comp2007Assignment2.admin.note" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<div class="well col-sm-7">
    <div class="form-group">
        &nbsp;&nbsp;&nbsp;Book:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlBook" runat="server" AutoPostBack="True" 
            OnSelectedIndexChanged="ddlBook_SelectedIndexChanged" Width="120px" DataTextField="Book" 
            DataValueField="Book" onChange="EnableOrDisableButton(true);">
        </asp:DropDownList>
        </div>
    <div class="form-group">
        &nbsp; Chapter:&nbsp;<asp:DropDownList ID="ddlChapter" runat="server" AutoPostBack="True"
            OnSelectedIndexChanged="ddlChapter_SelectedIndexChanged" Width="120px" DataTextField="Chapter" 
            DataValueField="Chapter" onChange="EnableOrDisableButton(true);">
        </asp:DropDownList>
       </div>
    <div class="form-group">
        &nbsp;&nbsp; Verse:&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddlVerse" runat="server"
             Width="120px" DataTextField="Verse" DataValueField="Verse" onChange="onChange();">
        </asp:DropDownList>
        </div>
    <div >
        <asp:Button ID="btnSubmit" runat="server" Text="Select" OnClick="btnSubmit_Click" CssClass="btn btn-primary" 
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
        <asp:Label for="titleTxt" class="control-label col-sm-2">Title:</asp:Label>
    <asp:TextBox ID="titleTxt" runat="server" required MaxLength="100"></asp:TextBox>
</div>
    <div class="form-group col-sm-offset-2"">
        <asp:Label for="txtBlog" class="control-label col-sm-2">Note:</asp:Label>
    <asp:TextBox ID="txtBlog" runat="server" Height="300px" Width="655px" TextMode="MultiLine"></asp:TextBox>
    </div>
    <div class="col-sm-2 col-sm-offset-2">
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary" />
        </div>
    </div>
</asp:Content>
