<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="ContosoWebApp.UserManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <%--Begin New User Popup--%>
    <OfficeWebUI:OfficePopup ID="OfficePopupNewUser" runat="server" OnClickOk="NewUserPopupOk" Title="New User Information" Height="500" Width="400px">
        <Content>
            <h1>New Customer</h1>
        
            <table>
                <tr>
                    <td colspan="2"><b>Login infomartion</b></td>
                </tr>
                <tr>
                    <td width="150px">Username</td>
                    <td><asp:TextBox runat="server" ID="NewUserUserName" Width="200" Height="15"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td><asp:TextBox runat="server" ID="NewUserPassword" TextMode="Password" Width="200" Height="15"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Retype password</td>
                    <td><asp:TextBox runat="server" ID="NewUserRetypePassword" TextMode="Password" Width="200" Height="15"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Email</td>
                    <td><asp:TextBox runat="server" ID="NewUserEmail" Width="200" Height="15"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Retype email</td>
                    <td><asp:TextBox runat="server" ID="NewUserRetypeEmail" Width="200" Height="15"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2"><b>Security Infomartion</b></td>
                </tr>
                <tr>
                    <td>Question</td>
                    <td>
                        <OfficeWebUI:OfficeCombobox runat="server" ID="NewUserQuestion" Width="200">
                            <Items>
                                <asp:ListItem runat="server" Value="1" Text="123456"></asp:ListItem>
                            </Items>
                        </OfficeWebUI:OfficeCombobox>
                    </td>
                </tr>
                <tr>
                    <td>Answer</td>
                    <td><asp:TextBox runat="server" ID="NewUserAnswer" Width="200" Height="15"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2"><b>User infomartion</b></td>
                </tr>
                <tr>
                    <td>Full name</td>
                    <td>Trần Kim Hiếu</td>
                </tr>
                <tr>
                    <td>Social ID</td>
                    <td>123456789</td>
                </tr>
                <tr>
                    <td>Điện thoại</td>
                    <td>01224569125</td>
                </tr>
                <tr>
                    <td>Địa chỉ</td>
                    <td>155A Bùi Viện</td>
                </tr>
                <tr>
                    <td>Phường</td>
                    <td>P.Phạm Ngũ Lão</td>
                </tr>
                <tr>
                    <td>Quận, huyện</td>
                    <td>Quận 1</td>
                </tr>
                <tr>
                    <td>Tỉnh, thành phố</td>
                    <td>TP.Hồ Chí Minh</td>
                </tr>
            </table>


                
        </Content>
    </OfficeWebUI:OfficePopup>
    <%--End New User Popup--%>
</asp:Content>
