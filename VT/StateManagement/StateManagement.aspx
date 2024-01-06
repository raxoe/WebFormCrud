<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StateManagement.aspx.cs" Inherits="VT.StateManagement.StateManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <asp:Button ID="btnSetSession" runat="server" Text="SetSession" OnClick="btnSetSession_Click" />

    <asp:Button ID="btnRetriveSession" runat="server" Text="RetriveSession" OnClick="btnRetriveSession_Click"/>
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
</asp:Content>
