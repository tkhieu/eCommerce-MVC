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
                        <asp:DropDownList ID="NewUserQuestion" runat="server">
                        </asp:DropDownList>
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
                    <td>
                        <asp:TextBox ID="NewUserFullName" runat="server"  Width="200" Height="15"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Social ID</td>
                    <td>
                        <asp:TextBox ID="NewUserSocalId" runat="server"  Width="200" Height="15"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Điện thoại</td>
                    <td>
                        <asp:TextBox ID="NewUserTelephone" runat="server"  Width="200" Height="15"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Địa chỉ</td>
                    <td>
                        <asp:TextBox ID="NewUserAddress" runat="server"  Width="200" Height="15"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Phường</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"  Width="200" Height="15"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td width="150px">Quận, huyện</td>
                    <td>
                        <asp:DropDownList ID="NewUserDistrict" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Tỉnh, thành phố</td>
                    <td>
                        <asp:DropDownList CssClass="NewUserCity" ID="NewUserCity" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </Content>
    </OfficeWebUI:OfficePopup>
    <%--End New User Popup--%>
</asp:Content>
