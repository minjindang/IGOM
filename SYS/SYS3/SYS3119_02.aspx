<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SYS3119_02.aspx.vb" Inherits="SYS3119_02"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="Table1" runat="server" border="1" cellpadding="0" cellspacing="0" class="tableStyle99"
    width="100%">
    <tr>
        <td class="htmltable_Title2" colspan="4">
            ����ƺ��@
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left" >
            �����N��
        </td>
        <td class="htmltable_Right">
            <asp:TextBox ID="tbOrgcode" runat="server" MaxLength="10"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left" >
            �����W��
        </td>
        <td class="htmltable_Right">
            <asp:TextBox ID="tbOrgcode_name" runat="server" MaxLength="100"></asp:TextBox>
        </td>
        <td class="htmltable_Left" >
            ����²���W��
        </td>
        <td class="htmltable_Right">
            <asp:TextBox ID="tbOrgcode_shortname" runat="server" MaxLength="50"></asp:TextBox>
        </td>
    </tr>
    <tr>
        
        <td class="htmltable_Left" >
            ����²���W��
        </td>
        <td class="htmltable_Right" colspan="3">
            <asp:FileUpload ID="fuLogo" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="htmltable_Bottom" colspan="4">
            <asp:Button ID="cbConfirm" runat="server" Text="�T�w" />
            <asp:Button ID="cbCancel" runat="server" Text="����" />
        </td>
    </tr>
</table>

</asp:Content>

