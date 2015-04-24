<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcDDLForm.ascx.vb" Inherits="UControl_SYS_UcDDLForm" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:DropDownList ID="ddlCodeType" runat="server" AutoPostBack="true" DataTextField="code_desc1" DataValueField="code_no">
        </asp:DropDownList>
        <asp:DropDownList ID="ddlForm" runat="server" AutoPostBack="true"
            DataTextField="formName" DataValueField="formId">
        </asp:DropDownList>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:HiddenField ID="hfOrgcode" runat="server" />