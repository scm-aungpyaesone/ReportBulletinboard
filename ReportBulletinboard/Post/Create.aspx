<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="ReportBulletinboard.PostCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Create Post
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
 <div>
    <h3>Create Post</h3>
    <form id="PostCreateForm" runat="server" autocomplete="off">
        <div>
            <asp:Label id="LblTitle" runat="server">Title</asp:Label>
            <asp:textbox id="TxtTitle" style="Z-INDEX: 102" tabIndex="1" 
                runat="server" Width="300px" Height="22px"></asp:textbox>
        </div>
        <div>
            <asp:Label id="LblDescription" runat="server">Description</asp:Label>
            <asp:textbox id="TxtDescription" style="Z-INDEX: 102" tabIndex="1" 
                runat="server" Width="300px" Height="22px"></asp:textbox>
        </div>
        <div>
           <asp:button id="BtnCreate" 
              runat="server" Text="Create" Width="70px"
              Height="24px" onclick="BtnCreate_Click"></asp:button>
           <asp:button id="BtnCancel" 
              runat="server" Text="Cancel" Width="70px"
              Height="24px"  onclick="BtnCancel_Click"></asp:button>
       </div>
    </form>
 </div>
</asp:Content>
