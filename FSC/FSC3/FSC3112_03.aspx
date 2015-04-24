<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC3112_03.aspx.vb" Inherits="FSC3112_03" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register src="~/UControl/UcShowDate.ascx" tagname="UcShowDate" tagprefix="uc3" %>
<%@ Register src="~/UControl/UcMember.ascx" tagname="UcMember" tagprefix="uc4" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc2" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc2" TagName="UcDDLMember" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">
                �ƯZ��ƺ��@
            </td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="4">
                �۰ʱƯZ
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                <span style="color:Red">*</span>�~��</td>
            <td class="TdHeightLight" colspan="3">
                 <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DD_Year" runat="server" OnSelectedIndexChanged="DD_Year_SelectedIndexChanged">
                        </asp:DropDownList>�~
                        <asp:DropDownList ID="DD_Month" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DD_Month_SelectedIndexChanged">
                        </asp:DropDownList>��     
                    </ContentTemplate>
                </asp:UpdatePanel>       
            </td>  
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
               <span style="color:Red">*</span>�ȯZ�H��
            </td>
            <td class="TdHeightLight" valign="top">
               <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:ListBox ID="lbxMember" runat="server" Width="250" Height="200"
                          DataTextField="User_name" DataValueField="Id_card"></asp:ListBox>                        
                        <asp:CheckBoxList ID="cbxlsex" runat="server" DataTextField="code_desc1" DataValueField="code_no" 
                            OnSelectedIndexChanged="cbxlsex_SelectedIndexChanged" RepeatDirection="Horizontal" AutoPostBack="true"></asp:CheckBoxList>                        
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="htmltable_Left" style="width:100px">
                �Z�O</td>
            <td class="TdHeightLight" valign="top">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:RadioButtonList ID="rblSchedule" runat="server" DataTextField="name" DataValueField="schedule_id" 
                            AutoPostBack="true" OnSelectedIndexChanged="rblSchedule_SelectedIndexChanged"></asp:RadioButtonList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lbTip" runat="server" ForeColor="Red" Text="�Y�J�A��L�~�����A�Х���ƹA��L�~���Ȫ�A�A����@�밲��ƯZ�C"></asp:Label>
            </td>  
        </tr>

        <tr>
            <td align="center" colspan="4" class="TdHeightLight">
                <asp:Button ID="cbConfirm" runat="server" Text="�T�w" OnClick="cbConfirm_Click" OnClientClick="blockUI();" />
                <asp:Button ID="cbCancel" runat="server" Text="����" OnClick="cbCancel_Click" />
            </td>
        </tr>
    </table>
        
    
    
</asp:Content>
