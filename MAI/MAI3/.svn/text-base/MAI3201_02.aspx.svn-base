<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAI3201_02.aspx.vb" Inherits="MAI_MAI3_MAI3201_02" %>

<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc1" TagName="ucSaCode" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">水電報修基本資料
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">報修單號
            </td>
            <td style="width: 326px">
                <asp:Label ID="lblFlow_id" runat="server"></asp:Label>
            </td>
            <td class="htmltable_Left">報修類別
            </td>
            <td style="width: 326px">
                <asp:HiddenField ID="hfMtClass_type" runat="server" />
                <asp:Label ID="lblMtClass_typeName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">報修人姓名
            </td>
            <td style="width: 326px">
                <asp:Label ID="lblUser_Name" runat="server"></asp:Label>
            </td>
            <td class="htmltable_Left">報修人分機
            </td>
            <td style="width: 326px">
                <asp:Label ID="lblPhone_nos" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">報修人單位
            </td>
            <td style="width: 326px">
                <asp:Label ID="lblUnit_code" runat="server"></asp:Label>
            </td>
            <td class="htmltable_Left">報修時間
            </td>
            <td style="width: 326px">
                <asp:Label ID="lblApplyTime" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">問題描述
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtProblem_desc" runat="server" TextMode="MultiLine" Columns="50" Enabled="false"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">水電報修處理情形及驗收確認
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">維修人員姓名
            </td>
            <td style="width: 326px">
                <asp:DropDownList ID="ddlMaintainer" runat="server"></asp:DropDownList>
            </td>
            <td class="htmltable_Left">預定維修日期
            </td>
            <td style="width: 326px">
                <asp:Label ID="lblElecExpect_type" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">開始處理時間
            </td>
            <td style="width: 326px">
                <asp:Label ID="lblMtStartTime" runat="server"></asp:Label>
            </td>
            <td class="htmltable_Left">完成時間
            </td>
            <td style="width: 326px">
                <asp:Label ID="lblMtEndTime" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">處理情形
            </td>
            <td style="width: 326px">
                <uc1:ucSaCode runat="server" ID="ucMtStatus_type" Code_sys="019" Code_type="006" ControlType="DropDownList" />
            </td>
            <td class="htmltable_Left">處理時數
            </td>
            <td style="width: 326px">
                <asp:Label ID="lblMtTime" runat="server"></asp:Label>
            </td>
        </tr>
        <tr> 
            <td class="htmltable_Left">處理說明
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtMtStatus_desc" runat="server" TextMode="MultiLine" Columns="50" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">是否結案
            </td>
            <td colspan="3">
                <asp:RadioButtonList ID="rblCaseClose_type" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="Y">結案</asp:ListItem>
                    <asp:ListItem Value="N">未結案</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                <asp:Button ID="DoneBtn" runat="server" Text="確認" />
                <asp:Button ID="CancelBtn" runat="server" Text="放棄修改" />
            </td>
        </tr>
    </table>
</asp:Content>

