<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SAL2103_01.aspx.vb" Inherits="SAL2103_01" EnableEventValidation="false" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UControl/SAL/ucDateDropDownList.ascx" TagName="UcDate" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border = "0" cellpadding = "0" cellspacing = "0" width = "100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">
                國民旅遊補助費用發放清冊
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"  style="width:100px ">
                發放項目
            </td>
            <td class="TdHeightLight">
                國民旅遊補助費
            </td>
            <td class="htmltable_Left" style="width:100px">
                發放年月
            </td>
            <td class="htmltable_Right" style="width:250px">
                <uc1:UcDate runat="server" ID="UcDDLDate" Kind="YM" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4">
                <asp:Button ID="btnQuery" runat="server" Text="列印" /></td>
        </tr>
    </table>
    <br />
    <table id="tbQ" runat="server" border = "0" cellpadding = "0" cellspacing = "0" width = "100%" class="tableStyle99" visible="false">
        <tr>
            <td align="center" class="htmltable_Title2" colspan="2">
                查詢結果
            </td>
        </tr>    
        <tr>
            <td style="width: 100%;" align="center" colspan="2" class="TdHeightLight">
                <asp:GridView ID="gvList01" runat="server" CssClass="Grid" Width="100%" EmptyDataText="查無資料!!"></asp:GridView>
                <asp:GridView ID="gvList02" runat="server" CssClass="Grid" Width="100%" EmptyDataText="查無資料!!"></asp:GridView>
            </td>
        </tr>
    </table>
    <asp:GridView ID="grdExcel" runat="server" Visible="False"></asp:GridView>
</asp:Content>
