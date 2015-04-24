<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcSelectOrg.ascx.vb" Inherits="UControl_UcSelectOrg" %>
<asp:UpdatePanel runat="server" EnableViewState="true" id="updatepanel1" >
    <ContentTemplate>
        <asp:DropDownList ID="ddlorg" runat="server" AutoPostBack="True" >
            <asp:ListItem Value="00">全部</asp:ListItem>
            <asp:ListItem Value="01">複選單位</asp:ListItem>

        </asp:DropDownList>
        <br />
        <asp:CheckBoxList ID="cblorg" runat="server" Visible="false"  AutoPostBack="true" RepeatDirection="Horizontal" RepeatLayout="Flow">
        </asp:CheckBoxList>
        
        <asp:HiddenField ID="hfParentOrgid" runat="server" />
        <asp:HiddenField ID="hfShowMulti" runat="server" />
    </ContentTemplate>
</asp:UpdatePanel>
