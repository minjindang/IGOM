<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC3111_02.aspx.vb" Inherits="FSC3111_02" %>

<%@ Register src="../../UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc2" %>

<%@ Register src="../../UControl/UcTextBox.ascx" tagname="UcTextBox" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">
                班別資料維護</td>
        </tr> 
        <tr>
            <td class="htmltable_Title2" colspan="2">
                班別資料</td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                <span style="color: #ff0000">*</span>班別名稱</td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbName" runat="server" MaxLength="50" ></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                <span style="color: #ff0000">*</span>上班時間</td>
            <td class="htmltable_Right">                
                <asp:TextBox ID="tbStart_time" runat="server" Width="40" MaxLength="4"></asp:TextBox> ~
                <asp:TextBox ID="tbEnd_time" runat="server" Width="40" MaxLength="4"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                午休時間</td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbNoon_stime" runat="server" Width="40" MaxLength="4"></asp:TextBox> ~
                <asp:TextBox ID="tbNoon_etime" runat="server" Width="40" MaxLength="4"></asp:TextBox>               
                </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                中午刷卡時間</td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbNooncard_stime" runat="server" Width="40" MaxLength="4"></asp:TextBox> ~
                <asp:TextBox ID="tbNooncard_etime" runat="server" Width="40" MaxLength="4"></asp:TextBox>               
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                <asp:Button ID="cbConfirm" runat="server" Text="確認" /><asp:Button ID="btnBack" runat="server"
                    Text="取消" CausesValidation="False" /></td>
        </tr>
    </table>
</asp:Content>
