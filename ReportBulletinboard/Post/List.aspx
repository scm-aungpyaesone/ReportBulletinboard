<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="ReportBulletinboard.PostList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Post List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h3>Post List</h3>
    <div>
    <a href="/Post/Create.aspx">Create</a>
    </div>
    <form id="PostDownloadForm" runat="server" autocomplete="off">
    <asp:button id="BtnDownload" 
              runat="server" Text="Download" Width="70px"
              Height="24px" onclick="BtnDownload_Click"></asp:button>
    </form>
    <asp:Table ID="POST_TABLE"
        GridLines="Both"
        HorizontalAlign="Center"
        Font-Names="Verdana"
        Font-Size="8pt"
        CellPadding="15"
        CellSpacing="0"
        runat="server"
        Style="width: 100%;">
        <asp:TableHeaderRow ID="Table1HeaderRow"
            BackColor="#4CAF50"
            runat="server">
            <asp:TableHeaderCell
                Scope="Column"
                Text="ID" />
            <asp:TableHeaderCell
                Scope="Column"
                Text="TITLE" />
            <asp:TableHeaderCell
                Scope="Column"
                Text="DESCRIPTION" />
            <asp:TableHeaderCell
                Scope="Column"
                Text="Status" />
            <asp:TableHeaderCell
                Scope="Column"
                Text="Operation" />
        </asp:TableHeaderRow>
    </asp:Table>
</asp:Content>
