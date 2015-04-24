<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PRO2102_01.aspx.vb" Inherits="PRO2_PRO2102_01" EnableEventValidation="false"%>

<%@ Register Src="~/UControl/UcDDLDepart02.ascx"  TagName="UcDDLDepart" TagPrefix="uc1" %>
<%@ Register Src="~/UControl/UcDate.ascx"  TagName="UcDate" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">
                財產報廢列印
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"  style="width:100px ">
                報廢申請單位
            </td>
            <td class="TdHeightLight">
                <uc1:UcDDLDepart ID="ddlDept" runat="server" />
            </td>
            <td class="htmltable_Left">
                財產別
            </td>
            <td class="TdHeightLight">
                <asp:DropDownList ID="ddlProperty_type" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"  style="width:100px ">
                報廢核准日期起迄
            </td>
            <td class="TdHeightLight" colspan="3">
                <uc2:UcDate runat="server" ID="ucLast_dateS" />
                ~
                <uc2:UcDate runat="server" ID="ucLast_dateE" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" style="height: 17px" class="TdHeightLight">
                <asp:Button ID="btnQuery" runat="server" Text="查詢" />&nbsp;
                <asp:Button ID="btnPrint" runat="server" Text="列印" />
            </td>
        </tr>
    </table>
    <br />
    <table id="dataList" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title2" style="width: 100%" align="center">
                 財產報廢名單
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
