<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="eCommerce.Admin.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Library/css/jquery-ui/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Library/js/jquery-1.6.2.js"></script>
    <script type="text/javascript" src="Library/js/jquery-ui-1.8.16.custom.js"></script>
    <script type="text/javascript">
        $(function () {
            // a workaround for a flaw in the demo system (http://dev.jqueryui.com/ticket/4375), ignore!


            $("#dialog:ui-dialog").dialog("destroy");

            $("#<%=ButtonLogin.ClientID %>").button();

            $("#dialog-modal").dialog({
                height: 150,
                width: 310,
                modal: true,
                resizable: false,
                draggable: false,
                close: function (event, ui) {
                    window.location = 'Login.aspx';
                }
            });


        });
    </script>
</head>
<body>
    <div id="dialog-modal" title="eCommerce Admin System - Login">
        <form id="Form1" runat="server">
        <table>
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Label ID="LabelLoginNotice" runat="server" Font-Bold="True" 
                        ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="60px">
                    Email
                </td>
                <td>
                    <asp:TextBox ID="ManageEmail" runat="server" Width="215"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Password
                </td>
                <td>
                    <asp:TextBox ID="ManagePassword" runat="server" Width="215" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="ManagerLogin" Width="280px" />
                </td>
            </tr>
        </table>
        </form>
    </div>
</body>
</html>
