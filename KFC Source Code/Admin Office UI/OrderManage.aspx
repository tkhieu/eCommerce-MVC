<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="OrderManage.aspx.cs" Inherits="ContosoWebApp.OrderManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script>
	$(function() {
		var availableTags = [
			"ActionScript",
			"AppleScript",
			"Asp",
			"BASIC",
			"C",
			"C++",
			"Clojure",
			"COBOL",
			"ColdFusion",
			"Erlang",
			"Fortran",
			"Groovy",
			"Haskell",
			"Java",
			"JavaScript",
			"Lisp",
			"Perl",
			"PHP",
			"Python",
			"Ruby",
			"Scala",
			"Scheme"
		];
		$( "#<%=NewOrderUser.ClientID %>" ).autocomplete({
			source: availableTags
		});
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
						<asp:DropDownList ID="NewOrderDistrict" runat="server" Width="300px">
						</asp:DropDownList>
					</td>
				</tr>
				<tr>
					<td>
						City
					</td>
					<td>
						<asp:DropDownList ID="NewOrderCity" runat="server" Width="300px" >
						</asp:DropDownList>
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
						Gà Rán
					</td>
					<td>
						2
					</td>
					<td>
						85000
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
						Tổng cộng
					</td>
				</tr>
			</table>
		</Content>
	</OfficeWebUI:OfficePopup>
</asp:Content>
