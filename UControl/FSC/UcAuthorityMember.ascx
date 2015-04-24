<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcAuthorityMember.ascx.vb" Inherits="UControl_UcAuthorityMember" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:TextBox ID="tbPersonnelId" runat="server" AutoPostBack="True" Width="80px"></asp:TextBox>
        <asp:Label ID="lbDepartName" runat="server" Text=""></asp:Label>
        <asp:Label ID="lbMemberName" runat="server" Text=""></asp:Label>
    </ContentTemplate>
</asp:UpdatePanel>
