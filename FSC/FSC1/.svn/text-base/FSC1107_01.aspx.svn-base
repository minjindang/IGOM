<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC1107_01.aspx.vb" Inherits="FSC1_FSC1107_01" %>
<%@ Register Src="~/UControl/FSC/UcAttachment.ascx" TagPrefix="uc6" TagName="UcAttachment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="tb" border="1" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">在職/服務中文證明申請</td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                <span style="color: #ff0000">*</span>申請類別
            </td>
            <td class="htmltable_Right">
                <asp:RadioButtonList ID="rblApplicationType" runat="server" RepeatDirection="Horizontal">
                </asp:RadioButtonList>
            </td>
            <td class="htmltable_Left">
                <span style="color: #ff0000">*</span>申請份數
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbApplyCopies" runat="server" MaxLength="3"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                <span style="color: #ff0000">*</span>用途
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbPurpose" runat="server" Rows="5" TextMode="MultiLine" Width="200" MaxLength="255" />
            </td>
            <td class="htmltable_Left">備註
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbNotes" runat="server" Rows="5" TextMode="MultiLine" Width="200" MaxLength="255" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" style="border-top: none;">附件
            </td>
            <td class="htmltable_Right" colspan="3">
                <uc6:UcAttachment runat="server" ID="UcAttachment" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                <asp:Button ID="cbSubmit" runat="server" Text="送出申請" /><input id="cbReset" type="button" value="重填" onclick="clearForm(this.form)" />
            </td>
        </tr>
    </table>
</asp:Content>

