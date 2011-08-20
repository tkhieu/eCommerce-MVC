<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="OrderManage.aspx.cs" Inherits="ContosoWebApp.OrderManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                        Trần Kim Hiếu
                    </td>
                </tr>
                <tr>
                    <td>
                        Tel
                    </td>
                    <td>
                        01224569125
                    </td>
                </tr>
                <tr>
                    <td>
                        Address
                    </td>
                    <td>
                        155 Bùi Viện
                    </td>
                </tr>
                <tr>
                    <td>
                        District
                    </td>
                    <td>
                        Quận 1
                    </td>
                </tr>
                <tr>
                    <td>
                        City
                    </td>
                    <td>
                        TP.Hồ Chí Minh
                    </td>
                </tr>
                <tr>
                    <td>
                        Order Time
                    </td>
                    <td>
                        Ngày giờ.
                    </td>
                </tr>
                <tr>
                    <td>
                        Note
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        Thông tin
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
