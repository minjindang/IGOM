<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC3108_02.aspx.vb" Inherits="FSC3108_02"  %>

<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table width="100%" class="tableStyle99">
            <tr>
                <td class="htmltable_Title" colspan="2">
                    刷卡記錄更新維護</td>
            </tr>
            <tr>
                <td class="htmltable_Title2" colspan="2">
                    修改記錄</td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    刷卡代碼</td>
                <td class="TdHeightLight">
                    <asp:Label ID="lbPHCARD" runat="server"></asp:Label></td>
            </tr>
            <tr style="color: #000000">
                <td class="htmltable_Left">
                    <span style="color:red">*</span>刷卡日期</td>
                <td class="TdHeightLight">
                    <uc1:UcDate runat="server" ID="tbPHIDATE" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="height: 24px">
                    <span style="color:red">*</span>進出種類</td>
                <td style="height: 24px" class="TdHeightLight">
                    <asp:DropDownList ID="ddlPHITYPE" runat="server">
                        <asp:ListItem Value="A">A:上班進</asp:ListItem>
                        <asp:ListItem Value="D">D:下班出</asp:ListItem>
                        <asp:ListItem Value="E">E:加班進</asp:ListItem>
                        <asp:ListItem Value="F">F:加班出</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    <span style="color:red">*</span>刷卡時間</td>
                <td class="TdHeightLight">
                    <asp:TextBox ID="tbPHITIME" runat="server" MaxLength="4" width="56px" onchange="checkTime(this.id)"></asp:TextBox>
                    <asp:Label ID="lbtip2" runat="server" ForeColor="Blue" Text="※填寫範例:1230" /></td>
            </tr>
            <tr>
                <td align="center" class="TdHeightLight" colspan="2">
                    <asp:Button ID="toConfirm" runat="server" Text="確認" /><asp:Button ID="cbCancel" runat="server" Text="取消" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

