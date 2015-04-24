<%@ Control Language="VB" AutoEventWireup="false" CodeFile="uc_Media_f040_tdpfTB.ascx.vb" Inherits="uc_uc_Media_f040_tdpfTB" %>
<table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:TextBox ID="TextBox_bankno" runat="server"
            ReadOnly="true">
            </asp:TextBox>
        </td>
        <td runat="server" visible="false" id="div_medi">
            -<asp:TextBox ID="TextBox_medi" runat="server" 
            ReadOnly="true" Width="48" >
            </asp:TextBox>
        </td>
    </tr>
</table>
<div id="div_info" runat="server" visible="false">
    Seqno=<asp:TextBox ID="TextBox_Seqno" runat="server"></asp:TextBox>
</div>