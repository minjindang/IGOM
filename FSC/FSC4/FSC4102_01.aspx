<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC4102_01.aspx.vb" Inherits="FSC4102_01" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"> 
                   
    <asp:Panel ID="pTB1" runat="server" Width="100%">
    
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
            <tr>
                <td class="htmltable_Title" colspan="4">
                    E-mail管理員設定</td>
            </tr>
            <tr>
                <td class="htmltable_Title2" colspan="4">
                    查詢畫面</td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    單位名稱</td>
                <td class="htmltable_Right">
                    <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
                </td>
                <td class="htmltable_Left">
                    姓名</td>
                <td class="htmltable_Right">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlName" runat="server">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel> 
                </td>
            </tr>
            <tr>
                <td class="htmltable_Bottom" colspan="4" align="right">
                    <asp:Button ID="btnFind" runat="server" Text="查詢" />
                    <asp:Button ID="btnReset" runat="server" CausesValidation="False" Text="重填" />
                    <asp:Button ID="btnToFSC4102_02" runat="server" CausesValidation="False" Text="表單通知人員設定" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pTB2" runat="server" Width="100%">
           
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
            <tr>
                <td class="htmltable_Title" colspan="6">
                    E-mail管理員設定</td>
            </tr>
            <tr>
                <td class="htmltable_Title2" colspan="6">
                    設定畫面</td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    單位名稱</td>
                <td class="htmltable_Right">
                    <asp:Label ID="lbDepart_name" runat="server" Text="Label"></asp:Label>
                    <asp:HiddenField ID="HidDepartID" runat="server" />
                </td>
                <td class="htmltable_Left">
                    姓名</td>
                <td class="htmltable_Right">
                    <asp:Label ID="lbUser_name" runat="server" Text="Label"></asp:Label>
                    <asp:HiddenField ID="HidID_card" runat="server" />
                </td>
                <td class="htmltable_Left">
                    職稱</td>
                <td class="htmltable_Right">
                    <asp:Label ID="lbTitleName" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">
                    E-mail通知</td>
                <td class="htmltable_Right">
                            <asp:RadioButtonList id="rblEmail_YN" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblEmail_YN_SelectedIndexChanged">
                                <asp:ListItem Value="Y">接收</asp:ListItem>
                                <asp:ListItem Value="N">不接收</asp:ListItem>
                            </asp:RadioButtonList> 
                </td>
                <td class="htmltable_Left">
                    E-mail頻率</td>
                <td class="htmltable_Right" colspan="3">
                            <asp:DropDownList id="ddlFrequency" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFrequency_SelectedIndexChanged">
                            <asp:ListItem Value="0" Selected="True">無</asp:ListItem>
                            <asp:ListItem Value="1">隨時</asp:ListItem>
                            <asp:ListItem Value="2">指定時間</asp:ListItem>
                            </asp:DropDownList> 
                </td>
            </tr>
            <tr runat="server" id="tr1">
                <td class="htmltable_Left">
                    <asp:Label ID="lbSet" runat="server" Text="指定時間"></asp:Label>
                </td>
                <td class="htmltable_Right" colspan="5">
                            <asp:TextBox id="txtSend_time1" runat="server" width="40" AutoPostBack="True" MaxLength="4" OnTextChanged="txtSend_time1_TextChanged"></asp:TextBox> 
                            <asp:TextBox id="txtSend_time2" runat="server" width="40" AutoPostBack="True" MaxLength="4" OnTextChanged="txtSend_time1_TextChanged"></asp:TextBox> 
                            <asp:TextBox id="txtSend_time3" runat="server" width="40" AutoPostBack="True" MaxLength="4" OnTextChanged="txtSend_time1_TextChanged"></asp:TextBox> 
                            <asp:TextBox id="txtSend_time4" runat="server" width="40" AutoPostBack="True" MaxLength="4" OnTextChanged="txtSend_time1_TextChanged"></asp:TextBox> 
                            <asp:TextBox id="txtSend_time5" runat="server" width="40" AutoPostBack="True" MaxLength="4" OnTextChanged="txtSend_time1_TextChanged"></asp:TextBox> 
                            <asp:TextBox id="txtSend_time6" runat="server" width="40" AutoPostBack="True" MaxLength="4" OnTextChanged="txtSend_time1_TextChanged"></asp:TextBox> 
                            <br/><asp:Label id="lbErr" runat="server" Text="「指定時間」設定格式為HHMM，24小時制，且以整點或半小時為單位，例如0830或1530。" ForeColor="blue"></asp:Label> 
                </td>
            </tr>
            <tr>
                <td class="htmltable_Bottom" colspan="6" align="right" style="height: 28px">
                    <asp:Button ID="btnConfirm" runat="server" CausesValidation="False" Css Text="確認" /><asp:Button
                        ID="btnReSet2" runat="server" CausesValidation="False" Css Text="重填" /><asp:Button
                            ID="btnBack" runat="server" CausesValidation="False" Css Text="回上一頁" />
                </td>
            </tr>
        </table> 
  </asp:Panel>
 

</asp:Content>
