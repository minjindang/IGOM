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
                排班資料維護
            </td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="4">
                自動排班
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                <span style="color:Red">*</span>年月</td>
            <td class="TdHeightLight" colspan="3">
                 <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DD_Year" runat="server" OnSelectedIndexChanged="DD_Year_SelectedIndexChanged">
                        </asp:DropDownList>年
                        <asp:DropDownList ID="DD_Month" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DD_Month_SelectedIndexChanged">
                        </asp:DropDownList>月     
                    </ContentTemplate>
                </asp:UpdatePanel>       
            </td>  
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
               <span style="color:Red">*</span>值班人員
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
                班別</td>
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
                <asp:Label ID="lbTip" runat="server" ForeColor="Red" Text="若遇農曆過年期間，請先行排農曆過年輪值表，再執行一般假日排班。"></asp:Label>
            </td>  
        </tr>

        <tr>
            <td align="center" colspan="4" class="TdHeightLight">
                <asp:Button ID="cbConfirm" runat="server" Text="確定" OnClick="cbConfirm_Click" OnClientClick="blockUI();" />
                <asp:Button ID="cbCancel" runat="server" Text="取消" OnClick="cbCancel_Click" />
            </td>
        </tr>
    </table>
        
    
    
</asp:Content>
