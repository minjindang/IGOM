<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcMember.ascx.vb" Inherits="UControl_UcMember" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:TextBox ID="tbPersonnelId" runat="server" AutoPostBack="True" Width="80px" MaxLength="6"></asp:TextBox>
        <asp:Label ID="lbDepartName" runat="server" Text=""></asp:Label>
        <asp:Label ID="lbMemberName" runat="server" Text=""></asp:Label>
    </ContentTemplate>
</asp:UpdatePanel>
