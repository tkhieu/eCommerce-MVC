<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FoodTypeManager.aspx.cs" Inherits="eCommerce.Admin.FoodTypeManager" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script type="text/javascript">

     $(function () {
         $(".ItemButton").button();
     });
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
<OfficeWebUI:OfficePopup runat="server" ID="OfficePopupNewFoodType" Title="New Food Type" ShowOkButton="true" ShowCancelButton="true" ViewStateMode="Enabled" Width="330px" Height="30px" OnClickOk="NewFoodTypePopupOk">
	<Content>
		<table style="width: 100%">
	<tr>
		<td>Food Type Name</td>
		<td><asp:TextBox runat="server" ID="NewFoodTypeName" Width="200px" Height="15px"></asp:TextBox></td>
	</tr>
</table>

	</Content>
</OfficeWebUI:OfficePopup>

<%--Hộp thoại khi thêm food thành công--%>
<OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxAddFoodTypeSuccess" Title="Success"
    Text="Insert foodtype infomation success..." ButtonsType="Ok" MessageBoxType="Info" >
</OfficeWebUI:OfficeMessageBox>
<%--Hộp thoại khi thêm food thất bại--%>
<OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxAddFoodTypeFail" Title="Fail"
    Text="Insert foodtype infomation fail..." ButtonsType="Ok" MessageBoxType="Error" OnReturn="OnOfficeMessageBoxFoodTypeFailYes">
</OfficeWebUI:OfficeMessageBox>
<%--Hộp thoại báo cập nhật user thành công--%>
    <OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxUpdateFoodTypeSuccess" Title="Success"
        Text="Update user infomation success..." ButtonsType="Ok" MessageBoxType="Info" >
    </OfficeWebUI:OfficeMessageBox>
    <%--Hộp thoại khi cập nhật user thất bại--%>
    <OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxUpdateFoodTypeFail" Title="Fail"
        Text="Update user infomation fail..." ButtonsType="Ok" MessageBoxType="Error" >
    </OfficeWebUI:OfficeMessageBox>

<%--Hộp thoại cảnh báo khi xóa một Record--%>
    <OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxConfirmDelete" Title="Delete Confirm"
        Text="Do you want to delete..." ButtonsType="YesNo" MessageBoxType="Warn" OnReturn="DeleteFoodTypeYes">
    </OfficeWebUI:OfficeMessageBox>

    <%--Hộp thoại cảnh báo khi sửa một Record--%>
    <OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxConfirmEdit" Title="Edit Confirm"
        Text="Do you want to edit..." ButtonsType="YesNo" MessageBoxType="Warn" OnReturn="EditFoodTypeYes">
    </OfficeWebUI:OfficeMessageBox>
<%--Hiển thị list food--%>
<asp:GridView ID="GridViewListFoodType" runat="server"  
                AutoGenerateColumns="False" CellPadding="4" 
        ForeColor="#333333" CssClass="ContentTableBorder" 
        onrowediting="GridViewListFood_RowEditing" 
        onrowdeleting="GridViewListFood_RowDeleting">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowSelectButton="False" ShowDeleteButton="True" 
                        ShowEditButton="True" ><ControlStyle CssClass="ItemButton"/>
            </asp:CommandField>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
                    <asp:BoundField DataField="Count" HeaderText="Count" ReadOnly="True" SortExpression="Count" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                    CssClass="ContentTableHeader" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
</asp:Content>
