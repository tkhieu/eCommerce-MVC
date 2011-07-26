<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BackstagePage_Resources.ascx.cs" Inherits="ContosoWebApp.Library.ascx.BackstagePage_Resources" %>


<h1>Resources</h1>
<p>Please use official materials for customers.</p>

<hr />

<p>Download materials from the Communication department.</p>

<OfficeWebUI:OfficeListView runat="server" id="OfficeListView1" DisplayMode="Gallery" Height="350" Width="500">
    <Items>
        <OfficeWebUI:ListViewItem ImageUrl="~/Library/img/64/icon1.png" Text="Item 1" ExtraText="Description" />
        <OfficeWebUI:ListViewItem ImageUrl="~/Library/img/64/icon2.png" Text="Item 2" ExtraText="Description" />
        <OfficeWebUI:ListViewItem ImageUrl="~/Library/img/64/icon3.png" Text="Item 3" ExtraText="Description" />
        <OfficeWebUI:ListViewItem ImageUrl="~/Library/img/64/icon4.png" Text="Item 4" ExtraText="Description" />
        <OfficeWebUI:ListViewItem ImageUrl="~/Library/img/64/icon5.png" Text="Item 5" ExtraText="Description" />
        <OfficeWebUI:ListViewItem ImageUrl="~/Library/img/64/icon6.png" Text="Item 6" ExtraText="Description" />
        <OfficeWebUI:ListViewItem ImageUrl="~/Library/img/64/icon7.png" Text="Item 7" ExtraText="Description" />
        <OfficeWebUI:ListViewItem ImageUrl="~/Library/img/64/icon8.png" Text="Item 8" ExtraText="Description" />
        <OfficeWebUI:ListViewItem ImageUrl="~/Library/img/64/icon9.png" Text="Item 9" ExtraText="Description" />
        <OfficeWebUI:ListViewItem ImageUrl="~/Library/img/64/icon10.png" Text="Item 10" ExtraText="Description" />        
    </Items>
</OfficeWebUI:OfficeListView>


<h3>Other materials</h3>
<p>If you need PDF, and printed materials, please contact Communication department at comdept@contoso.com</p>