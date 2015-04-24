<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="FSC2119_01.aspx.vb" Inherits="FSC2_FSC2119_01" EnableEventValidation="false"%>

<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register Src="~/UControl/UcDDLDepart02.ascx"  TagName="UcDDLDepart02" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">
                敘獎統計表
            </td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="2">
                查詢條件
            </td>
        </tr>
        <tr>
            <td class="TdHeightLight">
                考績會日期
            </td>
            <td class="TdHeightLight">
                <uc2:UcDate ID="UcCouncilDateStart" runat="server" />&nbsp;~<uc2:UcDate ID="UcCouncilDateEnd" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"  style="width:100px ">
                提報單位
            </td>
            <td class="TdHeightLight">
                <asp:CheckBoxList ID="cblDept" runat="server"></asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"  style="width:100px ">
                報表類型
            </td>
            <td class="TdHeightLight">
                <asp:DropDownList ID="ddlReportType" runat="server">
                    <asp:ListItem Value="1">敘獎提案數統計表</asp:ListItem>
                    <asp:ListItem Value="2">敘獎統計表</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td align="center" colspan="2" style="height: 17px" class="TdHeightLight">
                <asp:Button ID="btnQuery" runat="server" Text="查詢" />&nbsp;
                <asp:Button ID="btnPrint" runat="server" Text="匯出" />
            </td>
        </tr>
    </table>
    <br />
    <table id="dataList" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title2" style="width: 100%" align="center">
                查詢結果
            </td>
        </tr>
        <tr>
            <td style="width: 100%" class="TdHeightLight" valign="top">
                <asp:GridView ID="gvList01" runat="server" CssClass="Grid" Width="100%" ShowFooter="True" EmptyDataText="查無資料!!"></asp:GridView>
                <asp:GridView ID="gvList02" runat="server" CssClass="Grid" Width="100%" ShowFooter="True" EmptyDataText="查無資料!!"></asp:GridView>
            </td>
        </tr>
    </table>
    <asp:GridView ID="grdExcel" runat="server" Visible="False" ShowFooter="True" ></asp:GridView>
</asp:Content>
