<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC1104_01.aspx.vb" Inherits="FSC1_FSC1104_01" %>
    
<%@ Register Src="../../UControl/UcTextBox.ascx" TagName="UcTextBox" TagPrefix="uc5" %>
<%@ Register Src="~/UControl/FSC/UcAttachment.ascx" TagPrefix="uc2" TagName="UcAttachment" %>
<%@ Register Src="~/UControl/UcDateTime.ascx" TagPrefix="uc2" TagName="UcDateTime" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" >
    <script type="text/javascript">
        function chgUcDate() {
            __doPostBack('Memo_Bind', '');
        }
    </script>
    <table border = "1" cellpadding = "0" cellspacing = "0" width="100%"   class="tableStyle99">  
        <tr>
            <td colspan="2" class="htmltable_Title">
                刷卡補登申請
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                <span style="color: #ff0000">*</span>申請人姓名</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbApply_name" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                <span style="color: #ff0000">*</span>刷卡時間</td>
            <td class="htmltable_Right">
                <uc2:UcDateTime runat="server" ID="UcForgot_date" />
                <span style="color:blue">時間為24小時制，填寫範例:1730</span>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"  style="width:100px">
                <span style="color: #ff0000">*</span>卡別</td>
            <td class="htmltable_Right">
                <asp:RadioButtonList ID="rblCard_type" runat="server" RepeatDirection="Horizontal"
                    ForeColor="#00000">
                    <asp:ListItem Value="A" Selected="True">上班卡</asp:ListItem>
                    <asp:ListItem Value="D">下班卡</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                <span style="color: #ff0000">*</span>補登事由</td>
            <td class="htmltable_Right">
                 <span style="color: #ff0000">*</span>※輸入事由請勿超出30字<br />
                <uc5:uctextbox id="tbReason" runat="server" enableviewstate="true" maxlength="35" textmode="MultiLine" width="300">
                </uc5:uctextbox>
            </td>
        </tr>
     
	  <tr>
            <td class="htmltable_Left" style="width:100px">
                附件
            </td>
            <td class="htmltable_Right">
                <uc2:UcAttachment runat="server" ID="UcAttachment" />
            </td>
        </tr>
        <tr runat="server" id="tr_Remark" style="width:100px">
            <td class="htmltable_Left">
                備註
            </td>
            <td class="htmltable_Right">            
                <asp:Label ID="lbMemo" runat="server" /> </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                <asp:Button ID="cbSubmit" runat="server" Text="送出申請"  />
                <input id="cbReset" onclick="clearForm(this.form)" type="button" value="重填" />
            </td>
        </tr>
    </table>
    <asp:Label ID="lbErr" runat="server" Text="" ForeColor="red"></asp:Label>
</asp:Content>
