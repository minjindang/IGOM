<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcROCYear.ascx.vb" Inherits="UControl_UcROCYear" %>


<asp:Panel ID="panel" runat="server">
    民國
    <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" >
    </asp:DropDownList>
    年
    <asp:HiddenField runat="server" ID="hfYear" />
</asp:Panel> 