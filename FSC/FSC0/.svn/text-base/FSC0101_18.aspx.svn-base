<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC0101_18.aspx.vb" Inherits="FSC0101_18" %>
    
<%@ Register Src="../../UControl/UcTextBox.ascx" TagName="UcTextBox" TagPrefix="uc5" %>
<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register Src="~/UControl/SYS/UcFlowDetail.ascx" TagPrefix="uc2" TagName="UcFlowDetail" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" >
    <table border = "1" cellpadding = "0" cellspacing = "0" width="100%"   class="tableStyle99">  
        <tr>
            <td colspan="2" class="htmltable_Title">
                刷卡補登
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                <span style="color: #ff0000">*</span>申請人姓名</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbApply_name" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                <span style="color: #ff0000">*</span>刷卡時間</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbForgot_date" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"  style="width:100px">
                <span style="color: #ff0000">*</span>卡別</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbCard_type" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                <span style="color: #ff0000">*</span>補登事由</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbReason" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                <input id="cbPrint" type="button" value="列印" onclick="javascript: window.print();" class="nonPrinted" />                
                <asp:Button ID="cbBack" runat="server" Text="回上頁" OnClick="cbBack_Click" />
            </td>
        </tr>
    </table>
    <uc2:UcFlowDetail runat="server" ID="UcFlowDetail" />
</asp:Content>
