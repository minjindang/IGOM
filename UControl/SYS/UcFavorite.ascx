<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcFavorite.ascx.vb" Inherits="UControl_SYS_UcFavorite" %>
<table>
    <tr>
        <td>
            我的最愛
        </td>
        <td>
            <asp:DropDownList ID="ddlFavorite" runat="server" DataTextField="Func_name" DataValueField="Func_id"
                AutoPostBack="true" OnSelectedIndexChanged="ddlFavorite_SelectedIndexChanged"></asp:DropDownList></td>
    </tr>
</table>