<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BillManage.aspx.cs" Inherits="eCommerce.Admin.BillManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
<asp:GridView ID="GridViewListBill" runat="server" AutoGenerateColumns="False" CellPadding="4"
        ForeColor="#333333" CssClass="ContentTableBorder" OnRowEditing="GridViewListOrder_RowEditing">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowEditButton="True">
                <ControlStyle CssClass="ItemButton"/>
            </asp:CommandField>
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Username" HeaderText="Username" ReadOnly="True" SortExpression="Username" />
            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
            <asp:BoundField DataField="Tel" HeaderText="Tel" ReadOnly="True" SortExpression="Tel" />
            <asp:BoundField DataField="Address" HeaderText="Address" ReadOnly="True" SortExpression="Address" />
            <asp:BoundField DataField="District" HeaderText="District" ReadOnly="True" SortExpression="District" />
            <asp:BoundField DataField="City" HeaderText="City" ReadOnly="True" SortExpression="City" />
            <asp:BoundField DataField="Time" HeaderText="Time" ReadOnly="True" SortExpression="Time" />
            <asp:BoundField DataField="Time" HeaderText="Time" ReadOnly="True" SortExpression="Time" />
            <asp:BoundField DataField="TotalPayment" HeaderText="Total Payment" ReadOnly="True"
                SortExpression="TotalPayment" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" CssClass="ContentTableHeader" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
</asp:Content>
