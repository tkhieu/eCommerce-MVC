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
</asp:Content>
