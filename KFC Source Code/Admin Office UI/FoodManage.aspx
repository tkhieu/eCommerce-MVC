<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FoodManage.aspx.cs" Inherits="ContosoWebApp.FoodManage" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="Scripts/JScriptFileUpload.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
<OfficeWebUI:OfficePopup runat="server" ID="OfficePopupNewFood" Title="New Food" ShowOkButton="true" ShowCancelButton="true" ViewStateMode="Enabled" Width="900px" OnClickOk="NewFoodPopupOk">
	<Content>
		<table style="width: 100%">
	<tr>
		<td>Food Name</td>
		<td><asp:TextBox runat="server" ID="NewFoodName" Width="400px" Height="15px"></asp:TextBox></td>
	</tr>
	<tr>
		<td>Food Price</td>
		<td><asp:TextBox runat="server" ID="NewFoodPrice" Width="400px" Height="15px"></asp:TextBox></td>
	</tr>
	<tr>
		<td>Food Image</td>
		<td><asp:FileUpload runat="server" ID="NewFoodImage" Width="400px" Height="20px"/>
		</td>
	</tr>
    <tr>
        <td>Food Type</td>
		<td>
            <asp:DropDownList ID="NewFoodType" runat="server" Width="400px">
            </asp:DropDownList>
		</td>
    </tr>
	<tr>
		<td colspan="2">Food Detail</td>
	</tr>
	<tr>
		<td colspan="2"><CKEditor:CKEditorControl runat="server" ID="CKEditorNewFood"></CKEditor:CKEditorControl></td>
	</tr>
</table>

	</Content>
</OfficeWebUI:OfficePopup>

<%--Hộp thoại khi thêm food thành công--%>
<OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxAddFoodSuccess" Title="Success"
    Text="Insert food infomation success..." ButtonsType="Ok" MessageBoxType="Info" >
</OfficeWebUI:OfficeMessageBox>
<%--Hộp thoại khi thêm food thất bại--%>
<OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxAddFoodFail" Title="Fail"
    Text="Insert food infomation fail..." ButtonsType="Ok" MessageBoxType="Error" OnReturn="OnOfficeMessageBoxFoodFailYes">
</OfficeWebUI:OfficeMessageBox>
<%--Hộp thoại báo cập nhật user thành công--%>
    <OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxUpdateFoodSuccess" Title="Success"
        Text="Update user infomation success..." ButtonsType="Ok" MessageBoxType="Info" >
    </OfficeWebUI:OfficeMessageBox>
    <%--Hộp thoại khi cập nhật user thất bại--%>
    <OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxUpdateFoodFail" Title="Fail"
        Text="Update user infomation fail..." ButtonsType="Ok" MessageBoxType="Error" >
    </OfficeWebUI:OfficeMessageBox>

<%--Hộp thoại cảnh báo khi xóa một Record--%>
    <OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxConfirmDelete" Title="Delete Confirm"
        Text="Do you want to delete..." ButtonsType="YesNo" MessageBoxType="Warn" OnReturn="DeleteFoodYes">
    </OfficeWebUI:OfficeMessageBox>

    <%--Hộp thoại cảnh báo khi sửa một Record--%>
    <OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxConfirmEdit" Title="Edit Confirm"
        Text="Do you want to edit..." ButtonsType="YesNo" MessageBoxType="Warn" OnReturn="EditFoodYes">
    </OfficeWebUI:OfficeMessageBox>
<%--Hiển thị list food--%>
<asp:GridView ID="GridViewListFood" runat="server"  
                AutoGenerateColumns="False" CellPadding="4" 
        ForeColor="#333333" CssClass="ContentTableBorder" 
        onrowediting="GridViewListFood_RowEditing" 
        onrowdeleting="GridViewListFood_RowDeleting">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowSelectButton="False" ShowDeleteButton="True" 
                        ShowEditButton="True" />
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
                    <asp:BoundField DataField="FoodType" HeaderText="Type" ReadOnly="True" SortExpression="Type" />
                    <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" SortExpression="Price" />                    
                    <asp:BoundField DataField="Image" HeaderText="Image Link" ReadOnly="True" SortExpression="Image" />
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
