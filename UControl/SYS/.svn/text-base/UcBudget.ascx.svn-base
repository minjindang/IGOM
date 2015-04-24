<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcBudget.ascx.vb" Inherits="UControl_SYS_UcBudget" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<style>
    .modalBackground
{
    background-color:Gray;
    filter:alpha(opacity=50);
    opacity:0.5;
}
</style>

<asp:Button ID="cbBudget" runat="server" Text="預算來源" OnClick="cbBudget_Click" />
<asp:HiddenField ID="hfOrgcode" runat="server" />
<asp:HiddenField ID="hfBudgetType" runat="server" />


<asp:ModalPopupExtender ID="btnQuery_ModalPopupExtender" runat="server" TargetControlID="cbBudget"
    PopupControlID="Panel1"
    BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>


<asp:Panel runat="server" ID="Panel1">
    <div>
        <table id="table" class="tableStyle99" border="1" cellpadding="0" cellspacing ="0" width="100%">
            <tr>
                <td class="htmltable_Title2" style ="text-align:center">
                    預算來源
                </td>        
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlBudgetType" runat="server" DataTextField="code_desc1" DataValueField="code_no"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Bottom">
                    <asp:Button ID="cbConfirm" runat="server" Text="確定"/>
                    <asp:Button ID="cbCancel" runat="server" Text="取消"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
