<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC3110_03.aspx.vb" Inherits="FSC3110_03"  %>

<%@ Register Src="../../UControl/UcTextBox.ascx" TagName="UcTextBox" TagPrefix="uc5" %>
<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc4" %>
<%@ Register Src="../../UControl/FSC/UcLeaveMember.ascx" TagName="UcLeaveMember" TagPrefix="uc3" %>
<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <table id="tb" border = "1" cellpadding = "0" cellspacing = "0" width="100%"   class="tableStyle99">    
        <tr>
            <td class="htmltable_Title" colspan="2">
                �[�Z��ƺ��@ - �ק�</td>
        </tr>    
        <tr>
            <td class="htmltable_Left" style="width:100px">
                <span style="color: #ff0000">*</span>���s��</td>
            <td class="htmltable_Right">
                <asp:Label ID ="lbPrguid" runat="server" Enabled ="false" ></asp:Label>
            </td>
        </tr>

        <tr>
            <td class="htmltable_Left" style="width:100px">
                <span style="color: #ff0000">*</span>�ӽ����O</td>
            <td class="htmltable_Right">
                <asp:RadioButtonList ID="rblType" runat="server" Enabled="false" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1" Text="�@��[�Z"></asp:ListItem>
                    <asp:ListItem Value="2" Text="�M�ץ[�Z"></asp:ListItem>
                    <asp:ListItem Value="3" Text="�j��[�Z"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                <span style="color: #ff0000">*</span>����</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbDept" runat="server" Enabled ="false"></asp:Label>
                <asp:Label ID="lbDept_id" runat="server" Visible ="false" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>���ӽФH</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbname" runat="server" Enabled ="false" ></asp:Label>
                <asp:Label ID="lbidcard" runat="server" Enabled ="false" ></asp:Label>
                <asp:Label ID="lbnext_id" runat="server" Visible="false" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>�[�Z���</td>
            <td class="htmltable_Right" valign="top">
                <asp:Label ID ="UcDate" runat="server" ></asp:Label>
                &nbsp;�ɶ�<asp:TextBox ID="tbTimeb" runat="server" width="40px" MaxLength="4"></asp:TextBox>
                ��
                <asp:TextBox ID="tbTimee" runat="server" width="40px" MaxLength="4"></asp:TextBox>
                �C
                �@�p<asp:TextBox ID="tbHours" runat="server" width="40px" MaxLength="4"></asp:TextBox>�p��
                <asp:Label ID="lbTip2" runat="server" ForeColor="Blue" Text="(���G�ɶ���24�p�ɨ�) "></asp:Label></td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                �ӽ�����</td>
            <td class="htmltable_Right">            
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:RadioButtonList ID="rblmemo" runat="server" RepeatDirection="Horizontal" ForeColor="#555555">
                            <asp:ListItem Value="1" Text="�ӽиɥ�"></asp:ListItem>
                            <asp:ListItem Value="2" Text="�ӽХ[�Z�O" Enabled ="false" ></asp:ListItem>
                        </asp:RadioButtonList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>�[�Z�ƥ�</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="����J�ƥѽФŶW�X30�r"></asp:Label><br />
                <uc5:UcTextBox ID="tbReason" runat="server" EnableViewState="true" MaxLength="30"
                    TextMode="MultiLine" Width="300" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>���ʨƥ�</td>
            <td class="htmltable_Right">
                <asp:Label ID="Label1" runat="server" ForeColor="Blue" Text="����J�ƥѽФŶW�X30�r"></asp:Label><br />
                <uc5:UcTextBox ID="tbChangeReason" runat="server" EnableViewState="true" MaxLength="30"
                    TextMode="MultiLine" Width="300" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                �Ƶ�����</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbMemo" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="3" style="border-top:none;">
                <asp:Button ID="cbSubmit" runat="server" Text="�e�X" /><input id="cbReset" type="button" value="����" onclick="clearForm(this.form)"  /></td>
        </tr>
    </table>
    </asp:Content>

