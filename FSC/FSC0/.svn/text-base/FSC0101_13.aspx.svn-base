<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC0101_13.aspx.vb" Inherits="FSC0101_13" %>
<%@ Register Src="~/UControl/SYS/UcFlowDetail.ascx" TagPrefix="uc2" TagName="UcFlowDetail" %>
<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div>
<table width="100%">
    <tr>
        <td class="htmltable_Title" colspan="2">
            表單明細<!--庶務類申請-廣播申請--></td>
    </tr>
    <tr>
        <td class="htmltable_Left" style="width:140px">第一次廣播時間
        </td>
        <td class="htmltable_Right">            
            <asp:Label ID="lbBroadcast_date1" runat="server"></asp:Label>
            <asp:Label ID="lbBroadcast_time1" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left">第二次廣播時間<br/>(不須者免填)
        </td>
        <td class="htmltable_Right">
            <asp:Label ID="lbBroadcast_date2" runat="server"></asp:Label>
            <asp:Label ID="lbBroadcast_time2" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left">廣播系統開放樓層
        </td>
        <td class="htmltable_Right">
            <asp:CheckBoxList ID="cbxBroadcast_floors" runat="server" DataTextField="code_desc1" DataValueField="code_no" RepeatDirection="Horizontal"></asp:CheckBoxList>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left">廣播內容
        </td>
        <td class="htmltable_Right">
            <asp:Label ID="lbBroadcast_content" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Bottom" colspan="2">
            <asp:Button ID="cbConfirm" runat="server" Text="確認" OnClick="cbConfirm_Click" />
            <asp:Button ID="cbBack" runat="server" Text="回上頁" OnClick="cbBack_Click" />
        </td>
    </tr>
</table>
<uc2:UcFlowDetail runat="server" ID="UcFlowDetail" />
</div>

</asp:Content>