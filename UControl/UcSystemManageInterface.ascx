<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcSystemManageInterface.ascx.vb" Inherits="UControl_utl_SystemManageInterface" %>
<table id="tb" runat="server" width="100%">
    <tr>
        <td>
            <div style="float:left">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlOrgcode" runat="server" DataTextField="Orgcode_name" DataValueField="Orgcode" AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlDepart" runat="server" DataTextField="Depart_name" DataValueField="Depart_id" AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlSubDepart" runat="server" DataTextField="Depart_name" DataValueField="Depart_id" AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlUser" runat="server" DataTextField="full_name" DataValueField="Id_card">
                    </asp:DropDownList>
                </ContentTemplate> 
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlOrgcode" />
                    <asp:AsyncPostBackTrigger ControlID="ddlDepart" />
                    <asp:AsyncPostBackTrigger ControlID="ddlSubDepart" />
                </Triggers>
            </asp:UpdatePanel>
            </div>
            <div style="float:left; margin-left:3px;">                
                <asp:ImageButton ID="lkbLogin" runat="server" ImageUrl="~/images/master/login_ico.png"
                    CausesValidation="false" OnClientClick="blockUI()"/>
            </div>
            <asp:HiddenField ID="hfIsManager" runat="server" />
        </td>
    </tr>
</table>