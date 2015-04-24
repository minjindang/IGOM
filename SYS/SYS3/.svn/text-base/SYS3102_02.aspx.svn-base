<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS3102_02.aspx.vb" Inherits="SYS3102_02"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="Table1" runat="server" border="1" cellpadding="0" cellspacing="0" class="tableStyle99"
    width="100%">
    <tr>
        <td class="htmltable_Title2" colspan="4">
            單位資料維護
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left" >
            機關代號
        </td>
        <td class="htmltable_Right">
            <asp:TextBox ID="tbOrgcode" runat="server" MaxLength="10"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left" >
            機關名稱
        </td>
        <td class="htmltable_Right">
            <asp:TextBox ID="tbOrgcode_name" runat="server" MaxLength="100"></asp:TextBox>
        </td>
        <td class="htmltable_Left" >
            機關簡易名稱
        </td>
        <td class="htmltable_Right">
            <asp:TextBox ID="tbOrgcode_shortname" runat="server" MaxLength="50"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left" >
            單位代號
        </td>
        <td class="htmltable_Right">
            <asp:TextBox ID="tbDepart_id" runat="server" MaxLength="6"></asp:TextBox>
        </td>
        <td class="htmltable_Left" >
            單位名稱
        </td>
        <td class="htmltable_Right">
            <asp:TextBox ID="tbDepart_name" runat="server" MaxLength="50"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left" >
            上層單位代號
        </td>
        <td class="htmltable_Right">
            <asp:TextBox ID="tbParent_Depart_id" runat="server"></asp:TextBox>
        </td>
        <td class="htmltable_Left" >
            單位層級
        </td>
        <td class="htmltable_Right">
            <asp:DropDownList ID="ddlDepart_Level" runat="server" AutoPostBack="true">
                <asp:ListItem Value="">無</asp:ListItem>
                <asp:ListItem Value="1">一層</asp:ListItem>
                <asp:ListItem Value="2">二層</asp:ListItem>
                <asp:ListItem Value="3">三層</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left" >
            排序
        </td>
        <td class="htmltable_Right">
            <asp:TextBox ID="tbSeq" runat="server" Width="50" MaxLength="3"></asp:TextBox>
        </td>
        <td class="htmltable_Left" >
            是否顯示
        </td>
        <td class="htmltable_Right">
            <asp:DropDownList ID="ddlVisable_flag" runat="server">
                <asp:ListItem Text="是" Value="Y"></asp:ListItem>
                <asp:ListItem Text="否" Value="N"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left" >
            銀行轉換代號
        </td>
        <td class="htmltable_Right" colspan="3" >
            <asp:TextBox ID="tbChangeCode" runat="server" Width="50" MaxLength="3"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Bottom" colspan="4">
            <asp:Button ID="cbConfirm" runat="server" Text="確定" />
            <asp:Button ID="cbCancel" runat="server" Text="取消" />
        </td>
    </tr>
</table>

</asp:Content>

