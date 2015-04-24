<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcRoleDialog.ascx.vb" Inherits="UControl_UcRoleDialog" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>

<style>
    .modalBackground
{
    background-color:Gray;
    filter:alpha(opacity=50);
    opacity:0.5;
}
</style>

<asp:TextBox ID="txtUnitInRoleName" runat="server" width="250px"></asp:TextBox>
<asp:ImageButton id="imgbtnGetUnitInRoleName" runat="server" ImageUrl="~/images/icon/icon_select.gif" alt="選擇指定角色" />
<asp:HiddenField id="hfUnitInRoleName" runat="server" />

<asp:ModalPopupExtender ID="btnQuery_ModalPopupExtender" runat="server" TargetControlID="imgbtnGetUnitInRoleName"
    PopupControlID="Panel1"
    BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>

<asp:Panel runat="server" ID="Panel1"  >
    <div>
        <table id="table" class="tableStyle99" border = '1' cellpadding="0" cellspacing ="0" width="100%">
            <tr>
                <td colspan = "2" class="htmltable_Title2" style ="text-align:center">
                    指定角色
                </td>        
            </tr>
            <tr>
                <td class="htmltable_Left">
                    機關
                </td>
                <td >
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlOrgcode" runat="server" AutoPostBack="true" DataTextField="Orgcode_shortname" DataValueField="Orgcode"
                                OnSelectedIndexChanged="ddlOrgcode_SelectedIndexChanged"></asp:DropDownList>
                        </ContentTemplate>                        
                    </asp:UpdatePanel>
                </td>
                
            </tr>
            <tr>                
                <td class="htmltable_Left">
                    角色
                </td>
                <td >
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlRole" runat="server"
                                DataTextField="Role_name" DataValueField="Role_id">
                            </asp:DropDownList>
                        </ContentTemplate>                        
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>                
                <td class="htmltable_Left">
                    是否依申請單位
                </td>
                <td >
                    <asp:CheckBox ID="cbxUnitFlag" runat="server" />                    
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
