<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcComment.ascx.vb" Inherits="UControl_SYS_UcComment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<style>
    .modalBackground
{
    background-color:Gray;
    filter:alpha(opacity=50);
    opacity:0.5;
}
</style>

<asp:TextBox ID="tbComment" runat="server" Width="100px" MaxLength="100"></asp:TextBox>
<asp:ImageButton id="img" runat="server" alt="常用片語" ImageUrl="~/images/icon/icon_select.gif" />

<asp:ModalPopupExtender ID="btnQuery_ModalPopupExtender" runat="server" TargetControlID="img"
    PopupControlID="Panel1"
    BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>

<asp:Panel runat="server" ID="Panel1">
<div>
    <table id="table" class="tableStyle99" border = '1' cellpadding="0" cellspacing ="0" width="100%">
        <tr>
            <td colspan = "2" class="htmltable_Title2" style ="text-align:center">
                常用片語
            </td>        
        </tr>
        <tr>
            <td class="htmltable_Left">
                常用片語
            </td>
            <td >
                <asp:DropDownList ID="ddlPhases" runat="server" 
                    DataTextField="phrases" DataValueField="id"  AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan='4' class="htmltable_Bottom">
                <asp:Button ID="cbConfirm" runat="server" Text="確認" OnClick="cbConfirm_Click" />
                <asp:Button ID="cbCancel" runat="server" Text="取消" OnClick="cbCancel_Click" />
            </td>
        </tr>
    </table>   
    <asp:HiddenField ID="hfFormId" runat="server" /> 
    <asp:HiddenField ID="hfTextBoxId" runat="server" /> 
</div>
</asp:Panel>