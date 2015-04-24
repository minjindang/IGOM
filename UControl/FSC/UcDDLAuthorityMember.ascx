<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcDDLAuthorityMember.ascx.vb" Inherits="UControl_UcDDLAuthorityMember" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <asp:DropDownList ID="ddlMember" runat="server" DataTextField="Full_name" DataValueField="Id_card" AutoPostBack="true">
    </asp:DropDownList>
</ContentTemplate>
</asp:UpdatePanel>
<asp:HiddenField ID="hfOrgcode" runat="server" />
<asp:HiddenField ID="hfDepart_id" runat="server" />
