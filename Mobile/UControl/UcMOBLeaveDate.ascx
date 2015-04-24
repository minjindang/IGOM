<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UcMOBLeaveDate.ascx.vb" Inherits="UControl_UcMOBLeaveDate" %>
<table>
    <tr>
        <td><asp:TextBox ID="tbStart_date" runat="server" width="80px" MaxLength="9"></asp:TextBox></td>
        <td><img id="imgDateS" runat="server" alt="選擇日期" src="../../images/midea/calendar.gif"  /></td>
        <td>時間</td>
        <td><asp:TextBox ID="tbStart_time" runat="server" width="40px" MaxLength="4"></asp:TextBox></td>
        <td>至</td>

    </tr>
    <tr>
        <td><asp:TextBox ID="tbEnd_date" runat="server" width="80px" MaxLength="9"></asp:TextBox></td>
        <td><img id="ImgDateE" runat="server" alt="選擇日期" src="../../images/midea/calendar.gif" /></td>
        <td>時間</td>
        <td><asp:TextBox ID="tbEnd_time" runat="server" width="40px" MaxLength="4"></asp:TextBox></td>
        <td>止</td>

    </tr>

</table>