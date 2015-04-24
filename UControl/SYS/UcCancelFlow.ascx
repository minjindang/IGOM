<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcCancelFlow.ascx.vb" Inherits="UControl_UcCancelFlow" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc2" TagName="UcDDLMember" %>
<%@ Register Src="~/UControl/UcTextBox.ascx" TagPrefix="uc1" TagName="UcTextBox" %>


<style>
    .modalBackground
{
    background-color:Gray;
    filter:alpha(opacity=50);
    opacity:0.5;
}
</style>

<asp:Button ID="cb" runat="server" Text="撤銷" />

<asp:ModalPopupExtender ID="btnQuery_ModalPopupExtender" runat="server" TargetControlID="cb"
    PopupControlID="Panel1"
    BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>

<asp:Panel runat="server" ID="Panel1">
    <div>
        <table id="table" class="tableStyle99" border="1" cellpadding="0" cellspacing ="0" width="100%">
            <tr>
                <td class="htmltable_Left">
                    撤銷原因</td>
                <td class="htmltable_Right">
                    <uc1:UcTextBox runat="server" ID="UcTextBox" TextMode="MultiLine" MaxLength="400"/>
                </td>
            </tr>
            <tr>
                <td colspan="2"  class="htmltable_Bottom">
                    <asp:Button ID="cbConfirm" runat="server" Text="確認" OnClick="cbConfirm_Click" OnClientClick="javascript:if(!confirm('是否確定撤銷?')) return false;" />
                    <asp:Button ID="cbCancel" runat="server" Text="取消" OnClick="cbCancel_Click" />
                </td>
            </tr>
        </table>   
    </div>
    <asp:HiddenField ID="hfOrgcode" runat="server" /> 
    <asp:HiddenField ID="hfFlowId" runat="server" /> 
</asp:Panel>