<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcOldMember.ascx.vb" Inherits="UControl_UcOldMember" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:TextBox ID="tbPersonnelId" runat="server" AutoPostBack="True" Width="80px"></asp:TextBox>
        <asp:Label ID="lbMemberName" runat="server" Text=""></asp:Label>
    </ContentTemplate>
</asp:UpdatePanel>
