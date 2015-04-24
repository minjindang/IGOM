<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcDDLDepart02.ascx.vb" Inherits="UControl_UcDDLDepart02" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <asp:DropDownList ID="ddlDepart" runat="server" DataTextField="Depart_name" DataValueField="Depart_id">
    </asp:DropDownList>
</ContentTemplate>
</asp:UpdatePanel>
<asp:HiddenField ID="hfOrgcode" runat="server" />
