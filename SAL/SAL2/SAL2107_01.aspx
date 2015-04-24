<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SAL2107_01.aspx.cs" Inherits="SAL_SAL2_SAL2107_01" %>
<%@ Register Src="../../UControl/SAL/ucDateDropDownList.ascx" TagName="ucDateDropDownList"
    TagPrefix="uc2" %>
<%@ Register Src="../../UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">
                考績獎金發放清冊
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                列印類別
            </td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddl_PAYO_PRONO" runat="server">
                    <asp:ListItem Value="1">全部(含臨時工)</asp:ListItem>
                    <asp:ListItem Value="2">全部(不含臨時工)</asp:ListItem>
                    <asp:ListItem Value="3">臨時工</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="htmltable_Left">
                薪資年月
            </td>
            <td class="htmltable_Right">
                <uc2:ucDateDropDownList ID="ddl_PAYO_YYMM" runat="server" Kind="Y" />
            </td>
        </tr>
        <tr>
          <!--  <td class="htmltable_Left">
                預算來源
            </td>
            <td class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <uc3:ucSaCode ID="ddl_Budget_code" runat="server" Code_Kind="P" Code_sys="002" Code_type="018"
                            ControlType="2" Mode="query" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>   -->
            <td class="htmltable_Left">考績種類
            </td>
            <td class="htmltable_Right" colspan ="3">
                <asp:DropDownList ID="ddl_PAYO_KIND" runat="server">
                    <asp:ListItem Value="002">考績獎金</asp:ListItem>
                    <asp:ListItem Value="003">考績升等</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" align="center">
                <asp:Button ID="Button_report" runat="server" Text="列印" OnClick="Button_report_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

