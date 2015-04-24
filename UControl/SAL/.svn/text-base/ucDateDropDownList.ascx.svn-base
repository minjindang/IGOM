<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucDateDropDownList.ascx.vb" Inherits="uc_ucDateDropdownList" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table runat="server" style="width: 300px;">

            <tr>
                <td runat="server" id="Y">
                    <asp:Label ID="Label_title" runat="server" Text=""></asp:Label>
                    <asp:DropDownList ID="DropDownList_Y" runat="server" AutoPostBack="true">
                    </asp:DropDownList><asp:Label ID="LabelY" runat="server" Text="年"></asp:Label>
                </td>
                <td runat="server" id="M">
                    <asp:DropDownList ID="DropDownList_M" runat="server" AutoPostBack="true">
                    </asp:DropDownList><asp:Label ID="LabelM" runat="server" Text="月"></asp:Label>
                </td>
                <td runat="server" id="D">
                    <asp:DropDownList ID="DropDownList_D" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:Label ID="LabelD" runat="server" Text="日"></asp:Label>
                </td>
                <td runat="server" id="S">
                    第
                    <asp:DropDownList ID="DropDownList_S" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:Label ID="LabelS" runat="server" Text="學期" visible="false"></asp:Label>
                    &nbsp;學期
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<div id="info" style="display: none">
    Year_S =
    <asp:TextBox ID="TextBox_year_s" runat="server"></asp:TextBox><br />
    Year_E =
    <asp:TextBox ID="TextBox_year_e" runat="server"></asp:TextBox><br />
    Title =
    <asp:TextBox ID="TextBox_title" runat="server"></asp:TextBox><br />
    Datestr =
    <asp:TextBox ID="TextBox_datestr" runat="server"></asp:TextBox><br />
    Kind =
    <asp:TextBox ID="TextBox_Kind" runat="server"></asp:TextBox><br />
    Return =
    <asp:TextBox ID="TextBox_Return" runat="server" Text="YMD"></asp:TextBox><br />
</div>
