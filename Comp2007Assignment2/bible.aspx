﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="bible.aspx.cs" Inherits="Comp2007Assignment2.bible" %>

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

    <asp:Button ID="btnPreviousBook" runat="server" OnClick="btnPrevious_Click" Text="<< Previous <<" cssClass="btn btn-default"/>
    &nbsp;&nbsp;&nbsp;<asp:Label ID="lblCurrentBook" runat="server" Text="Genesis" />&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnNextBook" runat="server" OnClick="btnNext_Click" Text=">> Next >>" cssClass="btn btn-default" />
    <br />

    <asp:Button ID="btnPreviousChapter" runat="server" OnClick="btnPreviousChapter_Click" Text="<< Previous <<" cssClass="btn btn-default"/>
    &nbsp;&nbsp;&nbsp;<asp:Label ID="lblCurrentChapter" runat="server" Text="Chapter: " />&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnNextChapter" runat="server" OnClick="btnNextChapter_Click" Text=">> Next >>" cssClass="btn btn-default"/>
    <asp:ListView ID="lvwBible" runat="server">
    </asp:ListView>
    <div class="well">
        <asp:GridView ID="grdBible" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="false" DataKeyName="ID">
            <Columns>
                <asp:BoundField DataField="Book" HeaderText="Book" />
                <asp:BoundField DataField="Chapter" HeaderText="Chapter #:" />
                <asp:BoundField DataField="Verse" HeaderText="Verse #:" />
                <asp:BoundField DataField="VerseText" HeaderText="Verse" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
