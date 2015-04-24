<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucDateTextBox.ascx.vb" Inherits="uc_ucDateTextBox" %>
<table id="tdate" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:Label ID="Label_title" runat="server" Text=""></asp:Label>
        </td>
        <td id="Y" runat="server">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:TextBox ID="TextBox_Y" runat="server" MaxLength="3" Width="35"></asp:TextBox>&nbsp;年&nbsp;
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="TextBox_Y" EventName="TextChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
        <td id="M" runat="server">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:TextBox ID="TextBox_M" runat="server" MaxLength="2" Width="24"></asp:TextBox>&nbsp;月&nbsp;
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="TextBox_M" EventName="TextChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
        <td id="D" runat="server">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:TextBox ID="TextBox_D" runat="server" MaxLength="2" Width="24"></asp:TextBox>&nbsp;日&nbsp;
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="TextBox_D" EventName="TextChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>

<div id="info" style="display: none;">
    DateStr =
    <asp:TextBox ID="TextBox_DateStr" runat="server"></asp:TextBox><br />
    Kind =
    <asp:TextBox ID="TextBox_Kind" runat="server"></asp:TextBox><br />
    Return =
    <asp:TextBox ID="TextBox_Return" runat="server" Text="YMD"></asp:TextBox><br />

</div>
