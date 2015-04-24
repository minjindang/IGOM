<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS3116_02.aspx.vb" Inherits="SYS3116_02"  %>

<%@ Register Src="~/UControl/SYS/UcDDLForm.ascx" TagPrefix="uc1" TagName="UcDDLForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">
                表單規則說明</td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                表單種類
            </td>
            <td class="htmltable_Right">           
                <uc1:UcDDLForm runat="server" id="UcDDLForm" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                表單說明</td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbDesc" runat="server" Height="90px" TextMode="MultiLine" Width="420px"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                是否允許補上傳附件</td>
            <td class="htmltable_Right">
                <asp:RadioButtonList id="rblReAttachYN" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="0" Selected="True">是</asp:ListItem>
                    <asp:ListItem Value="1">否</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                 <asp:Button ID="cbConfirm" runat="server" Text="確認" />
                 <input id="cbReset" type="button" value="重填" />
                 <asp:Button ID="cbCancel" runat="server" Text="取消" />
            </td>
        </tr>
    </table>
</asp:Content>

