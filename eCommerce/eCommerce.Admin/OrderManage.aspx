<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="OrderManage.aspx.cs" Inherits="eCommerce.Admin.OrderManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


<script>
    $(function () {

        var foodId;
        var foodCount = $("#<%=NewOrderCount.ClientID %>").val();


        $("#radio").buttonset();

        $("#buttonDelete").click(function () {
            var i = $("#buttonDelete").button("option", "count");
            alert(i);
        });

        var count = 0;
        var totalPrice = 0;
        $("#buttonAdd").button().click(function () {
            count++;

            var newfname = "<tr><td id=\"food" + count.toString() + "\">" + $("#<%=NewOrderFood.ClientID %>").val() + "</td>";
            var newfcount = "<td id=\"fcount" + count.toString() + "\">" + $("#<%=NewOrderCount.ClientID %>").val() + "</td>";
            var newfprice = "<td id=\"fprice" + count.toString() + "\">" + $("#<%=NewOrderPrice.ClientID %>").val();
            var newdelbutton = "<div id=\"buttonDelete" + count + "\" >Delete</div></td></tr>";

            var newElement = newfname + newfcount + newfprice + newdelbutton;

            $("#<%=NewFoodArray.ClientID %>").val($("#<%=NewFoodArray.ClientID %>").val() + "," + foodId);
            $("#<%=NewCountArray.ClientID %>").val($("#<%=NewCountArray.ClientID %>").val() + "," + foodCount);

            totalPrice = totalPrice + parseInt($("#<%=NewOrderPrice.ClientID %>").val());

            $("#<%=NewOrderTotal.ClientID %>").val(totalPrice);

            $('#foodTable > tbody:last').append(newElement);

            $("#buttonDelete" + count).button();
            //alert("Running the last action");

            if (count == 5) {
                $("#buttonAdd").button("disable");
            }

            return false;
        });

        $("#buttonClear").button().click(function () {
            $("#<%=NewOrderFood.ClientID %>").val("");
            $("#<%=NewOrderCount.ClientID %>").val("");
            $("#<%=NewOrderPrice.ClientID %>").val("");
        });

        $("#<%=NewOrderUser.ClientID %>").autocomplete({
            source: 'Service/Account.ashx',
            minLenght: 0,
            select: function (event, ui) {
                $("#<%=NewOrderName.ClientID %>").val(ui.item.Name);
                $("#<%=NewOrderTel.ClientID %>").val(ui.item.Tel);
                $("#<%=NewOrderAddress.ClientID %>").val(ui.item.Address);
                $("#<%=NewOrderDistrict.ClientID %>").val(ui.item.District);
                $("#<%=NewOrderCity.ClientID %>").val(ui.item.City);
                $("#<%=NewOrderDistrictId.ClientID %>").val(ui.item.DistrictId);
                $("#<%=NewOrderCityId.ClientID %>").val(ui.item.CityId);
                $("#<%=NewOrderUserId.ClientID %>").val(ui.item.id);
            }

        });

        $("#<%=NewOrderFood.ClientID %>").autocomplete({
            source: 'Service/Food2Order.ashx',
            select: function (event, ui) {
                var foodPrice = ui.item.Price * $("#<%=NewOrderCount.ClientID %>").val();
                Price = ui.item.Price;
                foodId = ui.item.id;
                $("#<%=NewOrderPrice.ClientID %>").val(foodPrice);
            }

        });


        $("#<%=NewOrderCount.ClientID %>").change(
            function () {
                foodCount = $("#<%=NewOrderCount.ClientID %>").val();
                var foodPrice = Price * foodCount;
                $("#<%=NewOrderPrice.ClientID %>").val(foodPrice);

            }
        );
        $('#<%=NewOrderTime.ClientID %>').datetimepicker();
    });
</script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
	<OfficeWebUI:OfficePopup runat="server" ID="OfficePopupNewOrder" Title="Order Add" ShowOkButton="true" ShowCancelButton="true" Width="415px" OnClickOk="NewOrderPopupOk">
		<Content>
			<table style="width: 100%">
                <tr><td>User Type</td>
                    <td>
                        <div id="radio">
                            <asp:RadioButton ID="NewUserIsGuest" runat="server" Text="Guest" GroupName="OrderType"/> 
                            <asp:RadioButton ID="NewUserIsMember" runat="server" Text="Registed" GroupName="OrderType" Checked="true"/>
                        </div>
                    </td>
                </tr>
				<tr>
					<td>
						User
					</td>
					<td>
						<asp:TextBox ID="NewOrderUser" runat="server" Width="300px" Height="15px"></asp:TextBox>
                        <asp:HiddenField runat="server" ID="NewOrderUserId"/>
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
                        <asp:HiddenField runat="server" ID="NewOrderDistrictId"/>
					</td>
				</tr>
				<tr>
					<td>
						City
					</td>
					<td>
						<asp:TextBox ID="NewOrderCity" runat="server" Width="300px" Height="15px"></asp:TextBox>
                        <asp:HiddenField runat="server" ID="NewOrderCityId"/>
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
			
			<table style="width: 100%" id="foodTable">
				<tr>
					<td colspan="3">
						<strong>Food</strong>
					</td>
				</tr>
				<tr id="element">
					<td id="fName">
						Gà Chiên
					</td>
					<td id="fCount">
						1
					</td>
					<td id="fPrice">
						45.000
					</td>
				</tr>
				<tr>
					<td style="width: 180px">
                        <asp:HiddenField runat="server" ID="NewFoodId"/>
                        <asp:TextBox ID="NewOrderFood" runat="server" Width="90%"></asp:TextBox>
					</td>
					<td>
						<asp:TextBox ID="NewOrderCount" runat="server" Width="20px" >1</asp:TextBox>
					</td>
					<td>
						<asp:TextBox ID="NewOrderPrice" runat="server" Width="50px"></asp:TextBox>
                        
                            <div id="buttonAdd">Add</div>
                            <div Id="buttonClear">Clear</div>
                        
                        
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
						<asp:TextBox ID="NewOrderTotal" runat="server" Width="155px" CssClass="float-right"></asp:TextBox>
					</td>
				</tr>
			</table>
            <asp:HiddenField runat="server" ID="NewFoodArray"/>
            <asp:HiddenField runat="server" ID="NewCountArray"/>
		</Content>
	</OfficeWebUI:OfficePopup>

    <%--Hộp thoại khi thêm food thành công--%>
<OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxAddOrderSuccess" Title="Success"
    Text="Insert order infomation success..." ButtonsType="Ok" MessageBoxType="Info" >
</OfficeWebUI:OfficeMessageBox>
<%--Hộp thoại khi thêm food thất bại--%>
<OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxAddOrderFail" Title="Fail"
    Text="Insert order infomation fail..." ButtonsType="Ok" MessageBoxType="Error" OnReturn="OnOfficeMessageBoxOrderFailYes">
</OfficeWebUI:OfficeMessageBox>
</asp:Content>
