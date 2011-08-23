<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="UserManage.aspx.cs" Inherits="eCommerce.Admin.UserManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <OfficeWebUI:OfficePopup ID="OfficePopupNewUser" runat="server" OnClickOk="NewUserPopupOk"
        Title="New User Information" Height="550px" Width="400px">
        <Content>
        <div class="OfficeTextStyle">
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
                        <asp:TextBox runat="server" ID="NewUserUserName" Width="200" Height="15"></asp:TextBox><br />
                        <asp:Label ID="LabelUserName" runat="server" Text="Label" CssClass="validate-error"
                            Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Password
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="NewUserPassword" TextMode="Password" Width="200"
                            Height="15"></asp:TextBox><br />
                        <asp:Label ID="LabelPassword" runat="server" Text="Label" Visible="false" CssClass="validate-error"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Retype password
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="NewUserRetypePassword" TextMode="Password" Width="200"
                            Height="15"></asp:TextBox><br />
                        <asp:Label ID="LabelRetypePassword" runat="server" Text="Label" Visible="false" CssClass="validate-error"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Email
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="NewUserEmail" Width="200" Height="15"></asp:TextBox><br />
                        <asp:Label ID="LabelEmail" runat="server" Text="Label" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Retype email
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="NewUserRetypeEmail" Width="200" Height="15"></asp:TextBox><br />
                        <asp:Label ID="LabelRetypeEmail" runat="server" Text="Label" CssClass="validate-error"
                            Visible="false"></asp:Label>
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
                        <asp:TextBox runat="server" ID="NewUserAnswer" Width="200" Height="15"></asp:TextBox><br />
                        <asp:Label ID="LabelAnswer" runat="server" Text="Label" CssClass="validate-error"
                            Visible="false"></asp:Label>
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
                        <asp:TextBox runat="server" ID="NewUserFullName" Width="200" Height="15"></asp:TextBox><br />
                        <asp:Label ID="LabelFullName" runat="server" Text="Label" CssClass="validate-error"
                            Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Social ID
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="NewUserSocialId" Width="200" Height="15"></asp:TextBox><br />
                        <asp:Label ID="LabelSocialId" runat="server" Text="Label" CssClass="validate-error"
                            Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Phone Number
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="NewUserPhone" Width="200" Height="15"></asp:TextBox><br />
                        <asp:Label ID="LabelPhone" runat="server" Text="Label" CssClass="validate-error"
                            Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Address
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="NewUserAddress" Width="200" Height="15"></asp:TextBox><br />
                        <asp:Label ID="LabelAddress" runat="server" Text="Label" CssClass="validate-error"
                            Visible="false"></asp:Label>
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
                        <asp:DropDownList ID="NewUserDistrict" runat="server" Width="200">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        City
                    </td>
                    <td>
                        <asp:DropDownList ID="NewUserCity" runat="server" Width="200" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            </div>
        </Content>
    </OfficeWebUI:OfficePopup>

    <%--Hộp thoại cảnh báo khi xóa một Record--%>
    <OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxConfirmDelete" Title="Delete Confirm"
        Text="Do you want to delete..." ButtonsType="YesNo" MessageBoxType="Warn" OnReturn="DeleteAccountYes">
    </OfficeWebUI:OfficeMessageBox>
    <%--Hộp thoại cảnh báo khi sửa một Record--%>
    <OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxConfirmEdit" Title="Edit Confirm"
        Text="Do you want to edit..." ButtonsType="YesNo" MessageBoxType="Warn" OnReturn="EditAccountYes">
    </OfficeWebUI:OfficeMessageBox>
    <%--Hộp thoại báo cập nhật user thành công--%>
    <OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxUpdateAccountSuccess" Title="Success"
        Text="Update user infomation success..." ButtonsType="Ok" MessageBoxType="Info" >
    </OfficeWebUI:OfficeMessageBox>
    <%--Hộp thoại khi cập nhật user thất bại--%>
    <OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxUpdateAccountFail" Title="Fail"
        Text="Update user infomation fail..." ButtonsType="Ok" MessageBoxType="Error" >
    </OfficeWebUI:OfficeMessageBox>
    <%--Hộp thoại khi thêm user thành công--%>
    <OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxAddAccountSuccess" Title="Success"
        Text="Insert user infomation success..." ButtonsType="Ok" MessageBoxType="Info" >
    </OfficeWebUI:OfficeMessageBox>
    <%--Hộp thoại khi thêm user thất bại--%>
    <OfficeWebUI:OfficeMessageBox runat="server" ID="OfficeMessageBoxAddAccountFail" Title="Fail"
        Text="Insert user infomation fail..." ButtonsType="Ok" MessageBoxType="Error" >
    </OfficeWebUI:OfficeMessageBox>

    <%--Hiển thị Danh sách User qua GridView--%>

    <asp:GridView ID="GridViewListUser" runat="server"  
                AutoGenerateColumns="False" CellPadding="4" 
        ForeColor="#333333" CssClass="ContentTableBorder" 
        onrowediting="GridViewListUser_RowEditing" 
        onrowdeleting="GridViewListUser_RowDeleting">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowSelectButton="False" ShowDeleteButton="True" 
                        ShowEditButton="True" />
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="Username" HeaderText="Username" ReadOnly="True" SortExpression="Username" />
                    <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
                    <asp:BoundField DataField="Address" HeaderText="Address" ReadOnly="True" SortExpression="Address" />
                    
                    <asp:BoundField DataField="District" HeaderText="District" ReadOnly="True" SortExpression="District" />
                    <asp:BoundField DataField="City" HeaderText="City" ReadOnly="True" SortExpression="City" />
                    
                    <asp:BoundField DataField="Tel" HeaderText="Tel" ReadOnly="True" SortExpression="Tel" />
                    <asp:BoundField DataField="SocialID" HeaderText="SocialID" ReadOnly="True" SortExpression="SocialID" />
                    <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" SortExpression="Email" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
                    CssClass="ContentTableHeader" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
    
</asp:Content>
