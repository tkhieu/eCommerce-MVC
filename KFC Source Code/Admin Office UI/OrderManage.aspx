<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="OrderManage.aspx.cs" Inherits="ContosoWebApp.OrderManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


<script>
    $(function () {
        $("#<%=NewOrderUser.ClientID %>").autocomplete({
            source: 'Service/Account.ashx',
            minLenght: 0,
            select: function (event, ui) {
                $("#<%=NewOrderName.ClientID %>").val(ui.item.Name);
                $("#<%=NewOrderTel.ClientID %>").val(ui.item.Tel);
                $("#<%=NewOrderAddress.ClientID %>").val(ui.item.Address);
                $("#<%=NewOrderDistrict.ClientID %>").val(ui.item.District);
                $("#<%=NewOrderCity.ClientID %>").val(ui.item.City);
            }

        });

        $("#<%=NewOrderFood.ClientID %>").autocomplete({
            source: 'Service/Food2Order.ashx',
            select: function (event, ui) {
                var foodPrice = ui.item.Price * $("#<%=NewOrderCount.ClientID %>").val();
                Price = ui.item.Price;
                $("#<%=NewOrderPrice.ClientID %>").val(foodPrice);
            }

        });

        $("#<%=NewOrderCount.ClientID %>").autocomplete({
            source: ["1", "2", "3", "4", "5", "6", "7", "8", "9"],
            minLenght: 0,
            select: function (event, ui) {
                var foodPrice = ui.item.value * Price;
                $("#<%=NewOrderPrice.ClientID %>").val(foodPrice);
            }

        });

        $('#<%=NewOrderTime.ClientID %>').datetimepicker();
    });
</script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
	<OfficeWebUI:OfficePopup runat="server" ID="OfficePopupNewOrder" Title="Order Add" ShowOkButton="true" ShowCancelButton="true">
		<Content>
			<table style="width: 100%">
				<tr>
					<td>
						User
					</td>
					<td>
						<asp:TextBox ID="NewOrderUser" runat="server" Width="300px" Height="15px"></asp:TextBox>
					</td>
				</tr>
                <tr>
					<td>
						Name
					</td>
					<td>
						<asp:TextBox ID="NewOrderName" runat="server" Width="300px" Height="15px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						Tel
					</td>
					<td>
						<asp:TextBox ID="NewOrderTel" runat="server" Width="300px" Height="15px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						Address
					</td>
					<td>
						<asp:TextBox ID="NewOrderAddress" runat="server" Width="300px" Height="15px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						District
					</td>
					<td>
						<asp:TextBox ID="NewOrderDistrict" runat="server" Width="300px" Height="15px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						City
					</td>
					<td>
						<asp:TextBox ID="NewOrderCity" runat="server" Width="300px" Height="15px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						Order Time
					</td>
					<td>
						<asp:TextBox ID="NewOrderTime" runat="server" Width="300px" Height="15px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						Note
					</td>
					<td>
						<asp:TextBox ID="NewOrderNote" runat="server" TextMode="MultiLine" Width="300px" Height="50px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						Order Status
					</td>
					<td>
						New
					</td>
				</tr>
			</table>
			<p>
				<br />
			</p>
			<table style="width: 100%">
				<tr>
					<td colspan="3">
						<strong>Food</strong>
					</td>
				</tr>
				<tr>
					<td>
						Gà Chiên
					</td>
					<td>
						1
					</td>
					<td>
						45.000
					</td>
				</tr>
				<tr>
					<td>
                        <asp:TextBox ID="NewOrderFood" runat="server"></asp:TextBox>
					</td>
					<td>
						<asp:TextBox ID="NewOrderCount" runat="server" TextMode="SingleLine" >1</asp:TextBox>
					</td>
					<td>
						<asp:TextBox ID="NewOrderPrice" runat="server"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						&nbsp;
					</td>
					<td>
						Tổng
					</td>
					<td>
						<asp:TextBox ID="NewOrderTotal" runat="server"></asp:TextBox>
					</td>
				</tr>
			</table>
		</Content>
	</OfficeWebUI:OfficePopup>
</asp:Content>
