<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SAL4108_03.aspx.vb" Inherits="SAL4108_03"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="Table1" runat="server" border="1" cellpadding="0" cellspacing="0" class="tableStyle99"
    width="100%">
    <tr>
        <td class="htmltable_Title2" colspan="2">
            �~�Ĺ�Ӫ���@
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left" >
            ����
        </td>
        <td class="htmltable_Right">
            <asp:Label ID="tbcode_no" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left" >
            ��I���
        </td>
        <td class="htmltable_Right">
            <asp:Label ID="tbymstr" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left" >
            ���I�B�~�B
        </td>
        <td class="htmltable_Right">
            <asp:Label ID="tbStan_Sal_Point" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="htmltable_Left" >
            ���B
        </td>
        <td class="htmltable_Right">
            <asp:TextBox ID="tbStan_Sal" runat="server" MaxLength="6"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="htmltable_Bottom" colspan="2">
            <asp:Button ID="cbConfirm" runat="server" Text="�T�w" />
            <asp:Button ID="cbCancel" runat="server" Text="����" />
        </td>
    </tr>
</table>
</asp:Content>

