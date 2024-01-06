<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="VT.Ado.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LinkButton ID="lnkCreate" runat="server" PostBackUrl="~/Ado/Create.aspx" Text="Add New" CssClass="btn btn-info"></asp:LinkButton>
    <asp:UpdatePanel ID="upl" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <%--CssClass="table table-hover table-striped"--%>
            <asp:GridView ID="gvList" runat="server" EmptyDataText="No record has been added" OnRowCommand="gvList_RowCommand" AutoGenerateColumns="false" GridLines="None" CssClass="table table-hover table-striped">
                <Columns>
                    <asp:TemplateField HeaderText="MyHeaderName">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Category">
                        <ItemTemplate>
                            <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <%--<asp:LinkButton ID="lnkDetail" runat="server" Text="Detail" PostBackUrl='~/Ado/Create.aspx?id=<%#Eval("Id") %>'></asp:LinkButton>--%>
                            <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" PostBackUrl='<%#Eval("Id","~/Ado/Edit.aspx?id={0}") %>'></asp:LinkButton>
                            <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandArgument='<%#Eval("Id") %>' CommandName="myDelete"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="tm" EventName="Tick" />
        </Triggers>
    </asp:UpdatePanel>

    <%--<asp:UpdatePanel ID="upl2" runat="server">
        <ContentTemplate>
            
        </ContentTemplate>
    </asp:UpdatePanel>--%>
    <asp:Timer ID="tm" runat="server" OnTick="tm_tick" Interval="50000"></asp:Timer>

</asp:Content>

