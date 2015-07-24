<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="note.aspx.cs" Inherits="Comp2007Assignment2.note" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Notes</h1>

    <div class="form-group">
        <label for="ddlBook" class="control-label col-sm-2">Book:</label>
        <asp:DropDownList ID="ddlBook" runat="server"
            DataTextField="Book" DataValueField="Book" OnSelectedIndexChanged="ddlBook_SelectedIndexChanged" DataSourceID="SqlDataSource1">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BibleConnectionString %>" SelectCommand="SELECT DISTINCT [ID], [Book] FROM [BibleBasicEnglish] ORDER BY [ID]"></asp:SqlDataSource>
        <ajaxToolkit:CascadingDropDown ID="ddlBook_CascadingDropDown" runat="server"
            PromptText="Select Book" ServiceMethod="GetBook" TargetControlID="ddlBook" Category="Book" LoadingText="Loading..." />
    </div>
    <div class="form-group">
        <label for="ddlChapter" class="control-label col-sm-2">Chapter:</label>
        <asp:DropDownList ID="ddlChapter" runat="server"
            DataTextField="Chapter" DataValueField="Chapter" OnSelectedIndexChanged="ddlChapter_SelectedIndexChanged" DataSourceID="SqlDataSource2">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:BibleConnectionString %>" SelectCommand="SELECT DISTINCT [ID], [Book], [Chapter] FROM [BibleBasicEnglish] ORDER BY [ID], [Chapter]"></asp:SqlDataSource>
        <ajaxToolkit:CascadingDropDown ID="ddlChapter_CascadingDropDown" runat="server"
            PromptText="Select Chapter" ServiceMethod="GetChapter" TargetControlID="ddlChapter" ParentControlID="ddlBook" Category="Book" LoadingText="Loading..." />
    </div>
    
    <div class="form-group">
        <label for="ddlVerse" class="control-label col-sm-2">Verse:</label>
        <asp:DropDownList ID="ddlVerse" runat="server"
            DataTextField="Verse" DataValueField="Verse" OnSelectedIndexChanged="ddlVerse_SelectedIndexChanged" DataSourceID="SqlDataSource3">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:BibleConnectionString %>" SelectCommand="SELECT DISTINCT [ID], [Book], [Chapter], [Verse] FROM [BibleBasicEnglish] ORDER BY [ID], [Chapter], [Verse]"></asp:SqlDataSource>
        <ajaxToolkit:CascadingDropDown ID="ddlVerse_CascadingDropDown" runat="server"
            PromptText="Select Verse" ServiceMethod="GetVerse" TargetControlID="ddlVerse" ParentControlID="ddlChapter" Category="Book" LoadingText="Loading..." />
    </div>
    <div class="form-group">
        <asp:TextBox ID="txtVerse" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:TextBox ID="txtBlog" runat="server" Height="400px" Width="600px" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>

        <ajaxToolkit:HtmlEditorExtender ID="TextBox1_HtmlEditorExtender" runat="server" TargetControlID="txtBlog">
        </ajaxToolkit:HtmlEditorExtender>
    </div>
    <div></div>
    <div class="col-sm-2 col-sm-offset-2">
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary" />
    </div>
</asp:Content>
