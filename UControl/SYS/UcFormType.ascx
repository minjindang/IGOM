<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcFormType.ascx.vb" Inherits="UControl_SYS_UcFormKind" %>
<style type="text/css">
    .noLink {
	    font-size: 15px;
	    color: #000000;	
}
</style>
<asp:LinkButton ID="lbFormType" runat="server" Text=""></asp:LinkButton>
<asp:HiddenField ID="hfOrgcode" runat="server" />
<asp:HiddenField ID="hfFlowId" runat="server" />
<asp:HiddenField ID="hfFormId" runat="server" />
<asp:HiddenField ID="hfNextStep" runat="server" />