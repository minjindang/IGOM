<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC2121_01.aspx.vb" Inherits="FSC2121_01"  %>

<%@ Register Src="../../UControl/UcPager.ascx" TagName="Ucpager" TagPrefix="uc1" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">
                值班表</td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="4">
                查詢條件</td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px ">
                年月</td>
            <td class="TdHeightLight">            
                <asp:DropDownList ID="DD_Year" runat="server">
                </asp:DropDownList>年
                <asp:DropDownList ID="DD_Month" runat="server">
                </asp:DropDownList>月
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px ">
                單位名稱</td>
            <td class="TdHeightLight">            
                <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                <asp:Button ID="btnQuery" runat="server" Text="查詢" /><input id="Reset2" type="button"
                    value="重填" /></td>
        </tr>
    </table>
    <br />
    <table id="tbQ" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" >
        <tr>
            <td class="htmltable_Title2" style="width: 100%" align="center">
                查詢結果</td>
        </tr>
        <tr>
            <td style="width: 100%" class="TdHeightLight" valign="top">
                
                <asp:Calendar ID="cal" runat="server" OnDayRender="cal_DayRender" Width="100%" 
                    OnVisibleMonthChanged="cal_VisibleMonthChanged" NextPrevFormat="ShortMonth" ShowNextPrevMonth="false" >
                    <DayStyle BorderWidth="1px" BorderColor="" HorizontalAlign="Left" Font-Names="Helvetica" VerticalAlign="Top" Height="85"></DayStyle>
                    <OtherMonthDayStyle BackColor="Gainsboro" />
                    <TitleStyle Height="25" BackColor="AliceBlue" />
                    <DayHeaderStyle  Height="25" />
                    <WeekendDayStyle BackColor="#F691B2" />
                </asp:Calendar>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 100%;" class="TdHeightLight" valign="top">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
