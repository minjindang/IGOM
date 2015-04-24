<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcCustomNext.ascx.vb" Inherits="UControl_SYS_UcCustomNext" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc2" TagName="UcDDLMember" %>


<style>
    .modalBackground
{
    background-color:Gray;
    filter:alpha(opacity=50);
    opacity:0.5;
}
</style>

<asp:Button ID="cbNext" runat="server" Text="分文" OnClick="cbNext_Click" />
<asp:HiddenField ID="hfNextOrgcode" runat="server" />
<asp:HiddenField ID="hfNextDepartid" runat="server" />
<asp:HiddenField ID="hfNextposid" runat="server" />
<asp:HiddenField ID="hfNextIdcard" runat="server" />
<asp:HiddenField ID="hfNextName" runat="server" />

<asp:ModalPopupExtender ID="btnQuery_ModalPopupExtender" runat="server" TargetControlID="cbNext"
    PopupControlID="Panel1"
    BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>

<asp:Panel runat="server" ID="Panel1">
    <div>
        <table id="table" class="tableStyle99" border="1" cellpadding="0" cellspacing ="0" width="100%">
            <tr>
                <td colspan = "2" class="htmltable_Title2" style ="text-align:center">
                    <%=Text%>
                </td>        
            </tr>
            <tr>
                <td class="htmltable_Left">
                    機關
                </td>
                <td >
                    <asp:DropDownList ID="ddlOrgcode" runat="server" AutoPostBack="True" 
                        DataTextField="Orgcode_shortname" DataValueField="Orgcode" >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    單位
                </td>
                <td >
                    <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
                </td>
            </tr>
            <tr>                
                <td class="htmltable_Left">
                    人員
                </td>
                <td >
                    <uc2:UcDDLMember runat="server" ID="UcDDLMember" />
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