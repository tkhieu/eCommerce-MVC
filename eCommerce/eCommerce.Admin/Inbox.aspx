<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Inbox.aspx.cs" Inherits="eCommerce.Admin.Inbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    
    <OfficeWebUI:OfficeButton ID="OfficeButton1" runat="server" DisplayType="ImageAboveText" ImageUrl="~/library/img/32/icon115_32.png" Text="Open popup" OnClick="TestPop" />
    
    <p>Popup result :</p>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

    <OfficeWebUI:OfficePopup ID="OfficePopup1" runat="server" OnClickOk="OkPop" Title="Popup title" Height="300">
    <Content>
        <h1>Hello from popup</h1>
        
        <p>Type text :
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        
        <p>Select value : 
        <OfficeWebUI:OfficeCombobox runat="server" ID="Combo1" Width="130">
        <Items>
            <asp:ListItem Value="value1" Text="Item 1" />
            <asp:ListItem Value="value2" Text="Item 2" />
            <asp:ListItem Value="value3" Text="Item 3" />
            <asp:ListItem Value="value4" Text="Item 4" />
            <asp:ListItem Value="value5" Text="Item 5" />
        </Items>
        </OfficeWebUI:OfficeCombobox>
        </p>
        
    </Content>
    </OfficeWebUI:OfficePopup>

    
  
    
    </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
