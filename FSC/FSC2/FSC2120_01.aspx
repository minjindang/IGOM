<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="FSC2120_01.aspx.vb" Inherits="FSC2_FSC2120_01" EnableEventValidation="false"%>

<%@ Register Src="~/UControl/UcDDLDepart02.ascx"  TagName="UcDDLDepart02" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">
                慶生人員名冊
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"  style="width:100px ">
                查詢月份
            </td>
            <td class="TdHeightLight">
                <asp:DropDownList ID="ddlMonth" runat="server">
                    <asp:ListItem Value="-1">請選擇</asp:ListItem>
                    <asp:ListItem Value="1">1月</asp:ListItem>
                    <asp:ListItem Value="2">2月</asp:ListItem>
                    <asp:ListItem Value="3">3月</asp:ListItem>
                    <asp:ListItem Value="4">4月</asp:ListItem>
                    <asp:ListItem Value="5">5月</asp:ListItem>
                    <asp:ListItem Value="6">6月</asp:ListItem>
                    <asp:ListItem Value="7">7月</asp:ListItem>
                    <asp:ListItem Value="8">8月</asp:ListItem>
                    <asp:ListItem Value="9">9月</asp:ListItem>
                    <asp:ListItem Value="10">10月</asp:ListItem>
                    <asp:ListItem Value="11">11月</asp:ListItem>
                    <asp:ListItem Value="12">12月</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="htmltable_Left">
                單位名稱
            </td>
            <td class="TdHeightLight">
                <uc1:UcDDLDepart02 ID="ddlDept" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"  style="width:100px ">
                人員類別
            </td>
            <td class="TdHeightLight" colspan="3">
                
                <asp:CheckBoxList ID="cbEmployeeType" runat="server" RepeatColumns="6">
                </asp:CheckBoxList>
                
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" style="height: 17px" class="TdHeightLight">
                <asp:Button ID="btnQuery" runat="server" Text="查詢" />&nbsp;
                <asp:Button ID="btnPrint" runat="server" Text="匯出名冊" />&nbsp;
                <asp:Button ID="Button1" runat="server" Text="匯出標籤" Visible="false" />
            </td>
        </tr>
    </table>
    <br />
    <table id="dataList" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title2" style="width: 100%" align="center">
                 慶生人員名冊
            </td>
        </tr>
        <tr>
            <td style="width: 100%" class="TdHeightLight" valign="top">
                <asp:GridView ID="gvList" runat="server" CssClass="Grid" Width="100%" EmptyDataText="查無資料!!"></asp:GridView>
                <asp:GridView ID="gvExcel" runat="server" CssClass="Grid" Width="100%" EmptyDataText="查無資料!!"></asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
