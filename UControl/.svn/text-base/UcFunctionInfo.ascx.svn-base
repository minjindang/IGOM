<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcFunctionInfo.ascx.vb" Inherits="FunctionInfo" %>
<table style="text-align:left;">
    <tr>
        <td colspan="2"><asp:Label ID="lbOrgcode_Depart" runat="server" Text="{0} > {1}"></asp:Label>&nbsp;
        </td>
        <td rowspan="2">
            <asp:ImageButton ID="ImgLogout" runat="server" ImageUrl="~/images/logout.gif" CausesValidation="false"  Visible="False" />
            <img alt="登出" src="<%= Page.ResolveClientUrl("~/images/logout.gif")%>" onclick="__doPostBack('<%=ImgLogout.ClientID %>', 'True');" />
        </td>
    </tr>
    <tr>
        <td>
            使用者：<asp:Label ID = "lblUserName" runat = "server" /><asp:Label ID="lbRole" runat="server" />
        </td>
        <!--
        <td >
            預設職務代理人：<asp:Label ID = "lbDeputy_name" runat = "server" />
        </td>                
        -->
    </tr>                        
</table>