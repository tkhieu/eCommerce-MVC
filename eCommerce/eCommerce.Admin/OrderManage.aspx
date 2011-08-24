<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="OrderManage.aspx.cs" Inherits="eCommerce.Admin.OrderManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Library/css/jquery-ui/superTabs.css" rel="stylesheet" type="text/css"/>
    <script type="text/javascript" src="Library/js/superTabs.js"></script>
    <script>
        $(function () {

            var foodId;
            var foodCount = $("#<%=NewOrderCount.ClientID %>").val();

            var totalPaymentRow = "<tr><td colspan=\"4\">Tổng</td><td>" + $("#<%=OrderDetailTotal.ClientID %>").val() + "</td></tr>";

            $("#<%=GridViewOrderDetail.ClientID %> tr:last").after(totalPaymentRow);

            $("#<%=OrderStatus.ClientID %>").buttonset();

            $("#<%=OrderPaymentMethor.ClientID %>").buttonset();

            $(".ItemButton").button();

            $("#OrderContentTab").verticalTabs().removeAttr("style");

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
<%--Office Popup for Order--%>
    <OfficeWebUI:OfficePopup runat="server" ID="OfficePopupNewOrder" Title="Order Add"
        ShowOkButton="true" ShowCancelButton="true" Width="415px" OnClickOk="NewOrderPopupOk">
        <Content>
            <div class="OfficeTextStyle">
                <table style="width: 100%">
                    <tr>
                        <td>
                            User Type
                        </td>
                        <td>
                            <div id="radio">
                                <asp:RadioButton ID="NewUserIsGuest" runat="server" Text="Guest" GroupName="OrderType" />
                                <asp:RadioButton ID="NewUserIsMember" runat="server" Text="Registed" GroupName="OrderType"
                                    Checked="true" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            User
                        </td>
                        <td>
                            <asp:TextBox ID="NewOrderUser" runat="server" Width="300px" Height="15px"></asp:TextBox>
                            <asp:HiddenField runat="server" ID="NewOrderUserId" />
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
                            <asp:HiddenField runat="server" ID="NewOrderDistrictId" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            City
                        </td>
                        <td>
                            <asp:TextBox ID="NewOrderCity" runat="server" Width="300px" Height="15px"></asp:TextBox>
                            <asp:HiddenField runat="server" ID="NewOrderCityId" />
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
                            <asp:TextBox ID="NewOrderNote" runat="server" TextMode="MultiLine" Width="300px"
                                Height="50px"></asp:TextBox>
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
                            <asp:HiddenField runat="server" ID="NewFoodId" />
                            <asp:TextBox ID="NewOrderFood" runat="server" Width="90%"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="NewOrderCount" runat="server" Width="20px">1</asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="NewOrderPrice" runat="server" Width="50px"></asp:TextBox>
                            <div id="buttonAdd">
                                Add</div>
                            <div id="buttonClear">
                                Clear</div>
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
                <asp:HiddenField runat="server" ID="NewFoodArray" />
                <asp:HiddenField runat="server" ID="NewCountArray" />
            </div>
        </Content>
    </OfficeWebUI:OfficePopup>


    <%--Hộp thoại khi thêm food thành công--%>
<OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxUpdateStateSuccess" Title="Success"
    Text="Update order status success..." ButtonsType="Ok" MessageBoxType="Info" >
</OfficeWebUI:OfficeMessageBox>
<%--Hộp thoại khi thêm food thất bại--%>
<OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxUpdateStateFail" Title="Fail"
    Text="Update order status fail..." ButtonsType="Ok" MessageBoxType="Error">
</OfficeWebUI:OfficeMessageBox>

<%--Office Popup for View--%>
    <OfficeWebUI:OfficePopup runat="server" ID="OfficePopupViewOrder" Title="Order Detail Infomation" Height="265px" OnClickOk="OfficePopupOrderOk">
        <Content>
            <div id="OrderContentTab" class="OfficeTextStyle">
                <ul>
                    <li><a href="#tabs-1">Order Account Info</a></li>
                    <li><a href="#tabs-2">Order Address</a></li>
                    <li><a href="#tabs-3">Order Detail</a></li>
                </ul>
                <div id="tabs-1">
                    <p>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    User ID
                                </td>
                                <td>
                                    <asp:Label ID="OrderUserId" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Username
                                </td>
                                <td>
                                    <asp:Label ID="OrderUserUsername" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Full name
                                </td>
                                <td>
                                    <asp:Label ID="OrderUserFullName" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Tel
                                </td>
                                <td>
                                    <asp:Label ID="OrderUserTel" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Email
                                </td>
                                <td>
                                    <asp:Label ID="OrderUserEmail" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Address
                                </td>
                                <td>
                                    <asp:Label ID="OrderUserAddress" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    District
                                </td>
                                <td>
                                    <asp:Label ID="OrderUserDistrict" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    City
                                </td>
                                <td>
                                    <asp:Label ID="OrderUserCity" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </p>
                </div>
                <div id="tabs-2">
                    <p>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    Full name
                                </td>
                                <td>
                                    <asp:Label ID="OrderAddressFullName" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Tel
                                </td>
                                <td>
                                    <asp:Label ID="OrderAddressTel" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Address
                                </td>
                                <td>
                                    <asp:Label ID="OrderAddressAddress" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    District
                                </td>
                                <td>
                                    <asp:Label ID="OrderAddressDistrict" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    City
                                </td>
                                <td>
                                    <asp:Label ID="OrderAddressCity" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </p>
                </div>
                <div id="tabs-3">
                    <p>
                        <asp:HiddenField ID="OrderDetailTotal" runat="server" />
                        <asp:GridView ID="GridViewOrderDetail" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" CssClass="ContentTableBorder" OnRowEditing="GridViewListOrder_RowEditing">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="Name" HeaderText="Food Name" ReadOnly="True" SortExpression="Name" />
                                <asp:BoundField DataField="Type" HeaderText="Food Type" ReadOnly="True" SortExpression="Type" />
                                <asp:BoundField DataField="Count" HeaderText="Count" ReadOnly="True" SortExpression="Count" />
                                <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" SortExpression="Price" />
                                <asp:BoundField DataField="Total" HeaderText="Payment" ReadOnly="True" SortExpression="Total" />
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

                        <table width="100%">
                        <tr><td>Order State:</td>
                        <td><asp:RadioButtonList ID="OrderStatus" runat="server" 
                            RepeatDirection="Horizontal" RepeatLayout="Flow" ViewStateMode="Disabled">
                            <asp:ListItem Value="1">New</asp:ListItem>
                            <asp:ListItem Value="2">Processing</asp:ListItem>
                            <asp:ListItem Value="3">Finish</asp:ListItem>
                        </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                        <td>Payment Method:</td>
                        <td>
                        <asp:RadioButtonList ID="OrderPaymentMethor" runat="server" 
                            RepeatDirection="Horizontal" RepeatLayout="Flow" ViewStateMode="Disabled">
                            <asp:ListItem Value="1">Paypal</asp:ListItem>
                            <asp:ListItem Value="2">Ngân Lượng</asp:ListItem>
                            <asp:ListItem Value="3">Tradition</asp:ListItem>
                        </asp:RadioButtonList>
                        </td>
                        </tr>
                        </table>
                    </p>
                </div>
            </div>
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

<%--Bắt đầu GridView--%>
    <asp:GridView ID="GridViewListOrder" runat="server" AutoGenerateColumns="False" CellPadding="4"
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
            <asp:BoundField DataField="State" HeaderText="State" ReadOnly="True" SortExpression="State" />
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
