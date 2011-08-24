<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="Manager.aspx.cs" Inherits="eCommerce.Admin.Manager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            $("#<%=NewManageRole.ClientID %>").buttonset();

            $(".ItemButton").button();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <OfficeWebUI:OfficePopup runat="server" ID="OfficePopupManage" Title="Add Manage"
        Width="450px" Height="120px" OnClickOk="OfficePopupNewManageOk">
        <Content>
            <table>
                <tr>
                    <td width="90px">
                        Name
                    </td>
                    <td>
                        <asp:TextBox ID="NewManageName" runat="server" Width="315"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Email
                    </td>
                    <td>
                        <asp:TextBox ID="NewManageEmail" runat="server" Width="315"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Password
                    </td>
                    <td>
                        <asp:TextBox ID="NewManagePassword" runat="server" Width="315" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Role
                    </td>
                    <td>
                        <asp:RadioButtonList ID="NewManageRole" runat="server" ViewStateMode="Disabled" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem runat="server" Value="1">Super Administrator</asp:ListItem>
                            <asp:ListItem runat="server" Value="2">Sale Manager</asp:ListItem>
                            <asp:ListItem runat="server" Value="3">Food Manager</asp:ListItem>
                        </asp:RadioButtonList>
                </tr>
            </table>
        </Content>
    </OfficeWebUI:OfficePopup>
    <%--Hộp thoại khi thêm food thành công--%>
<OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxAddManageSuccess" Title="Success"
    Text="Insert manager infomation success..." ButtonsType="Ok" MessageBoxType="Info" >
</OfficeWebUI:OfficeMessageBox>
<%--Hộp thoại khi thêm food thất bại--%>
<OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxAddManageFail" Title="Fail"
    Text="Insert manager infomation fail..." ButtonsType="Ok" MessageBoxType="Error" OnReturn="OnOfficeMessageBoxFailYes">
</OfficeWebUI:OfficeMessageBox>
<%--Hộp thoại khi thêm food thất bại--%>
<OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxManagerExist" Title="Fail"
    Text="This manager with email had exits..." ButtonsType="Ok" MessageBoxType="Error" OnReturn="OnOfficeMessageBoxFailYes">
</OfficeWebUI:OfficeMessageBox>

<%--Hộp thoại cảnh báo khi xóa một Record--%>
    <OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxConfirmDelete" Title="Delete Confirm"
        Text="Do you want to delete..." ButtonsType="YesNo" MessageBoxType="Warn" OnReturn="DeleteManagerYes">
    </OfficeWebUI:OfficeMessageBox>
    <%--Hộp thoại cảnh báo khi sửa một Record--%>
    <OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxConfirmEdit" Title="Edit Confirm"
        Text="Do you want to resend password..." ButtonsType="YesNo" MessageBoxType="Warn" OnReturn="ResendManagerInfoYes">
    </OfficeWebUI:OfficeMessageBox>

        <%--Hộp thoại khi thêm user thành công--%>
    <OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxDeleteManagerSuccess" Title="Success"
        Text="Delete manager success..." ButtonsType="Ok" MessageBoxType="Info" >
    </OfficeWebUI:OfficeMessageBox>
    <%--Hộp thoại khi thêm user thất bại--%>
    <OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxDeleteManagerFail" Title="Fail"
        Text="Delete manager fail..." ButtonsType="Ok" MessageBoxType="Error" >
    </OfficeWebUI:OfficeMessageBox>


    <%--Hộp thoại khi thêm user thành công--%>
    <OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxResendPassSuccess" Title="Success"
        Text="Resend manager info success..." ButtonsType="Ok" MessageBoxType="Info" >
    </OfficeWebUI:OfficeMessageBox>
    <%--Hộp thoại khi thêm user thất bại--%>
    <OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxResendPasswordFail" Title="Fail"
        Text="Resend manager info fail..." ButtonsType="Ok" MessageBoxType="Error" >
    </OfficeWebUI:OfficeMessageBox>

    <asp:GridView ID="GridViewListManager" runat="server" AutoGenerateColumns="False"
        CellPadding="4" ForeColor="#333333" CssClass="ContentTableBorder" OnRowDeleting="ManagerDelete" OnRowEditing="ManageResendPassword">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" EditText="Resend Password" ><ControlStyle CssClass="ItemButton"/>
            </asp:CommandField>
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" SortExpression="Email" />
            <asp:BoundField DataField="Role" HeaderText="Role" ReadOnly="True" SortExpression="Role" />
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
