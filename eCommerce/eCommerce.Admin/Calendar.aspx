<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="eCommerce.Admin.Calendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

<asp:Calendar ID="Calendar1" runat="server" style="width:100%; height:100%"  CellPadding="0"
        NextMonthText="<img src='../library/images/expand.gif' style='cursor:pointer' border='0'/>" PrevMonthText="<img src='../library/images/collapse.gif' style='cursor:pointer' border='0'/>" 
        ShowGridLines="false"
        ondayrender="Calendar1_DayRender" 
        onselectstart="return false" ondragstart="return false" oncontextmenu="return false"
        BorderStyle="None" ShowTitle="False" >
    <TodayDayStyle Font-Bold="True" BorderStyle="Solid" />
    <DayStyle HorizontalAlign="Left" VerticalAlign="Top" Font-Underline="false" 
        BorderStyle="Solid" BorderWidth="1" BorderColor="#F0F0F0" Font-Size="8pt" />
    <DayHeaderStyle Height="20px" Font-Size="8pt" HorizontalAlign="Center" Font-Bold="true" />
    <TitleStyle Height="26px" BackColor="White" Font-Bold="True" Font-Size="10pt" />
    <OtherMonthDayStyle ForeColor="#C0C0C0" />
</asp:Calendar>


<script>
    OfficeWebUI.Ribbon.ShowContext("RibbonContext_Calendar");
    OfficeWebUI.Ribbon.ShowTab("RibbonTab_Calendar1");
</script>

</asp:Content>
