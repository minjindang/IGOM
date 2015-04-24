<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcDDLMember.ascx.vb" Inherits="UControl_UcDDLMember" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <asp:DropDownList ID="ddlMember" runat="server" DataTextField="full_name" DataValueField="Id_card" AutoPostBack="true">
    </asp:DropDownList>
</ContentTemplate>
</asp:UpdatePanel>
<asp:HiddenField ID="hfOrgcode" runat="server" />
<asp:HiddenField ID="hfDepartId" runat="server" />
