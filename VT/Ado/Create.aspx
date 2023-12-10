<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="VT.Ado.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--    <h2>Create Form</h2>
    <div class="form-group">
        <asp:Label runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label runat="server" Text="Category"></asp:Label>
        <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label runat="server" Text="Description"></asp:Label>
        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <hr />
    <div class="form-group">
        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Create" OnClick="btnSubmit_Click" />
    </div>--%>


    <h2>Create Form</h2>
    Name
    <asp:TextBox ID="txtNameFoo" runat="server" ></asp:TextBox>      
    <br />

    Category
    <asp:TextBox ID="txtCategory" runat="server" ></asp:TextBox>
    <br />

    Description
    <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
    <br />

    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />    

    
</asp:Content>
