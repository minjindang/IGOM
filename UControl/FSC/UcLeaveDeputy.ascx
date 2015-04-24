<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcLeaveDeputy.ascx.vb" Inherits="UControl_UcLeaveDeputy" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<table style="width:auto">
    <tr>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                <ContentTemplate>
                    <asp:RadioButton ID="rb1" runat="server" GroupName="Deputy" AutoPostBack="true" OnCheckedChanged="rb1_CheckedChanged" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td colspan="2">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
                <ContentTemplate>
                    <asp:DropDownList ID="ddlDefaultDeputy" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" >
                <ContentTemplate>
                    <asp:RadioButton ID="rb2" runat="server" GroupName="Deputy" AutoPostBack="true" OnCheckedChanged="rb2_CheckedChanged" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td>
            <uc1:UcDDLDepart runat="server" ID="UcDDLDeputyDepart" />
        </td>
        <td>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server" >
                <ContentTemplate>            
                    <asp:DropDownList runat="server" ID="ddlDeputy"
                        DataValueField="id_card" DataTextField="user_name">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
<asp:HiddenField ID="hfOrgcode" runat="server" />
<asp:HiddenField ID="hfDepartId" runat="server" />
<asp:HiddenField ID="hfDeputyPosid" runat="server" />
<asp:HiddenField ID="hfApplyIdcard" runat="server" />