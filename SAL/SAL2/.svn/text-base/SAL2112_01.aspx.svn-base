<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL2112_01.aspx.cs" Inherits="SAL_SAL2_SAL2112" %>
<%@ Register src="../../UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc4" %>
<%@ Register src="../../UControl/SAL/ucSaCode.ascx" tagname="ucSaCode" tagprefix="uc2" %>
<%@ Register src="../../UControl/SAL/UcSelectOrg.ascx" tagname="UcSelectOrg" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">
                年度發放獎金累計查詢
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                單位別
            </td>
            <td class="htmltable_Right">
                <uc2:UcSelectOrg ID="ddltype" runat="server" ShowMulti="True" />
            </td>
            <td class="htmltable_Left">
                員工姓名
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                性別
            </td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="BASE_SEX" runat="server">
                    <asp:ListItem Value="ALL">全部</asp:ListItem>
                    <asp:ListItem Value="M">男</asp:ListItem>
                    <asp:ListItem Value="F">女</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="htmltable_Left">
                人員類別
            </td>
            <td class="htmltable_Right">
                <uc2:ucSaCode ID="ddlcno" runat="server"  Code_Kind="P" Code_sys="002"
                            Code_type="017" ControlType="2" Mode="query" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                員工編號
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="txtno" runat="server"></asp:TextBox>
            </td>
            <td class="htmltable_Left">
                發放日期
            </td>
            <td class="htmltable_Right">
                <uc4:UcDate ID="UcDate1" runat="server" /> ~ 
                <uc4:UcDate ID="UcDate2" runat="server" /> 輸入日期 (例如:1030101)
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                預算來源
            </td>
            <td class="htmltable_Right">
                <uc2:ucSaCode ID="UcSaCode1" runat="server"  Code_Kind="P" Code_sys="002"
                            Code_type="018" ControlType="2" Mode="query" />
            </td>
            <td class="htmltable_Left">
                所得流水號
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="txtnum" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%">
                <asp:Button ID="Button_report" runat="server" Text="匯出 excel" OnClick="Button_report_Click" />
            </td>
        </tr>
       
    </table>
</asp:Content>
