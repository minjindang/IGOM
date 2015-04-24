<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcReword.ascx.vb" Inherits="UControl_SYS_UcReword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>



<style>
    .modalBackground
{
    background-color:Gray;
    filter:alpha(opacity=50);
    opacity:0.5;
}
</style>

<asp:Button ID="cbReword" runat="server" Text="發佈獎懲令" OnClick="cbReword_Click" />

<asp:ModalPopupExtender ID="btnQuery_ModalPopupExtender" runat="server" TargetControlID="cbReword"
    PopupControlID="Panel1"
    BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>

<asp:Panel runat="server" ID="Panel1"  >
    <div>
        <table id="table" class="tableStyle99" border = '1' cellpadding="0" cellspacing ="0" width="100%">
            <tr>
                <td colspan = "2" class="htmltable_Title2" style ="text-align:center">
                    發佈獎懲令
                </td>        
            </tr>
            <tr>
                <td class="htmltable_Left">
                    考績會名稱
                </td>
                <td >
                    <asp:TextBox ID="tbCouncil_name" runat="server" MaxLength="100" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    考績會日期
                </td>
                <td >
                    <uc1:UcDate runat="server" ID="UcCouncil_date" />
                </td>
            </tr>
            <tr>                
                <td class="htmltable_Left">
                    考績會考評結果
                </td>
                <td >
                    <asp:DropDownList ID="ddlCouncil_approve" runat="server">
                        <asp:ListItem Value="1">通過</asp:ListItem>
                        <asp:ListItem Value="2">不通過</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    獎勵令日期
                </td>
                <td >
                    <uc1:UcDate runat="server" ID="UcReword_date" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    獎勵令文號
                </td>
                <td >
                    <asp:TextBox ID="tbReword_Doc" runat="server" MaxLength="30" />
                </td>
            </tr>
            <tr>
                <td colspan='2' class="htmltable_Bottom">
                    <asp:Button ID="cbConfirm" runat="server" Text="確定"/>
                    <asp:Button ID="cbCancel" runat="server" Text="取消"/>
                </td>
            </tr>
        </table>   
    </div>
</asp:Panel>