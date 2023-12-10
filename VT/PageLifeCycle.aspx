<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PageLifeCycle.aspx.cs" Inherits="VT.PageLifeCycle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>ClassMates</h2>
    <asp:Button ID="btnsubmit" runat="server" OnClick="btnsubmit_click" Text="Submit" />
    <asp:Label ID="lblmessage" runat="server"></asp:Label>
</asp:Content>
