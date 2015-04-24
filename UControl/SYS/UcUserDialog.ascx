<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcUserDialog.ascx.vb" Inherits="UControl_UcUserDialog" %>

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

<asp:TextBox ID="txtUnitInMemberName" runat="server" width="250px"></asp:TextBox>
<asp:ImageButton id="imgbtnGetUnitInTitleName" runat="server" ImageUrl="~/images/icon/icon_select.gif" alt="選擇指定人員" />
<asp:HiddenField ID="hfUnitInMemberName" runat="server" />

<asp:ModalPopupExtender ID="btnQuery_ModalPopupExtender" runat="server" TargetControlID="imgbtnGetUnitInTitleName"
    PopupControlID="Panel1"
    BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>

<asp:Panel runat="server" ID="Panel1"  >
    <div>
        <table id="table" class="tableStyle99" border = '1' cellpadding="0" cellspacing ="0" width="100%">
            <tr>
                <td colspan = "2" class="htmltable_Title2" style ="text-align:center">
                    指定人員
                </td>        
            </tr>
            <tr>
                <td class="htmltable_Left">
                    機關
                </td>
                <td >
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate >
                             <asp:DropDownList ID="ddlOrgcode" runat="server" AutoPostBack="True" DataTextField="Orgcode_shortname" DataValueField="Orgcode" >
                             </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
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
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate >
                            <asp:DropDownList ID="ddlMember" runat="server" DataTextField="User_name" DataValueField="Id_card">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
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
