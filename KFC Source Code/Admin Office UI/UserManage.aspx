<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="UserManage.aspx.cs" Inherits="ContosoWebApp.UserManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <OfficeWebUI:OfficePopup ID="OfficePopupNewUser" runat="server" OnClickOk="NewUserPopupOk"
        Title="New User Information" Height="500" Width="400px">
        <Content>
            <h1>
                New Customer</h1>
            <table>
                <tr>
                    <td colspan="2">
                        <b>Login infomartion</b>
                    </td>
                </tr>
                <tr>
                    <td width="150px">
                        Username
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="NewUserUserName" Width="200" Height="15"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Password
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="NewUserPassword" TextMode="Password" Width="200"
                            Height="15"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Retype password
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="NewUserRetypePassword" TextMode="Password" Width="200"
                            Height="15"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Email
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="NewUserEmail" Width="200" Height="15"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Retype email
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="NewUserRetypeEmail" Width="200" Height="15"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <b>Security Infomartion</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        Question
                    </td>
                    <td>
                        <asp:DropDownList ID="NewUserQuestion" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Answer
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="NewUserAnswer" Width="200" Height="15"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <b>User infomartion</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        Full name
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="NewUserFullName" Width="200" Height="15"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Social ID
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="NewUserSocialId" Width="200" Height="15"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Phone Number
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="NewUserPhone" Width="200" Height="15"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Address
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="NewUserAddress" Width="200" Height="15"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Ward
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="NewUserWard" Width="200" Height="15"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        District
                    </td>
                    <td>
                        <asp:DropDownList ID="NewUserDistrict" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        City
                    </td>
                    <td>
                        <asp:DropDownList ID="NewUserCity" runat="server">
                        </asp:DropDownList>                        
                    </td>
                </tr>
            </table>
        </Content>
    </OfficeWebUI:OfficePopup>
</asp:Content>
