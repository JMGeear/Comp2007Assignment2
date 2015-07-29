<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="bibleMenu.aspx.cs" Inherits="Comp2007Assignment2.bibleMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <asp:Label ID="lblUserId" runat="server" class="lblWelcome" />
    </div>
    <div>
        <div class="well">
            <ul>
                <li><a href="/admin/note.aspx">Add Note</a></li>
                <li><a href="/admin/notes.aspx">View Notes</a></li>
            </ul>
        </div>

        <div class="well">
            <ul>
                <li><a href="/bible.aspx">View Bible</a></li>
                <li><a href="/contact.aspx">Contact Us</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
