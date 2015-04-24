<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC3110_02.aspx.vb" Inherits="FSC3110_02"  %>

<%@ Register Src="../../UControl/UcTextBox.ascx" TagName="UcTextBox" TagPrefix="uc5" %>
<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc4" %>
<%@ Register Src="../../UControl/FSC/UcLeaveMember.ascx" TagName="UcLeaveMember" TagPrefix="uc3" %>
<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc2" TagName="UcDDLDepart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <table id="tb" border = "1" cellpadding = "0" cellspacing = "0" width="100%"   class="tableStyle99">    
        <tr>
            <td class="htmltable_Title" colspan="2">
                加班資料維護 - 新增</td>
        </tr>        
        <tr>
            <td class="htmltable_Left" style="width:100px">
                <span style="color: #ff0000">*</span>申請類別</td>
            <td class="htmltable_Right">
                <asp:RadioButtonList ID="rblType" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1" Text="一般加班"></asp:ListItem>
                    <asp:ListItem Value="2" Text="專案加班"></asp:ListItem>
                    <asp:ListItem Value="3" Text="大批加班" Selected="True"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>表單申請人</td>
            <td class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">                   
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <uc2:UcDDLDepart runat="server" ID="UcDDLDepart" />
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>                                    
                                    <asp:ListBox ID="lbUnSelectMember" runat="server" DataTextField="User_name" DataValueField="Id_card" 
                                                    SelectionMode="Multiple"  Width="280" Height="200">
                                    </asp:ListBox>      
                                </td>
                                <td>
                                    <asp:Button ID="cbToR" runat="server" Text="選擇>>" />
                                    <br />
                                    <asp:Button ID="cbToL" runat="server" Text="<<取消" />
                                </td>
                                <td>                                                        
                                    <asp:ListBox ID="lbMember" runat="server" DataTextField="full_name" SelectionMode="Multiple" Width="280" Height="200">
                                    </asp:ListBox>   
                                </td>
                            </tr>
                        </table>
                        
                    </ContentTemplate>
                </asp:UpdatePanel></td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>加班日期</td>
            <td class="htmltable_Right" valign="top">
                <uc2:UcDate ID="UcDate" runat="server" />
                &nbsp;時間<asp:TextBox ID="tbTimeb" runat="server" width="40px" MaxLength="4"></asp:TextBox>
                至
                <asp:TextBox ID="tbTimee" runat="server" width="40px" MaxLength="4"></asp:TextBox>
                。
                共計<asp:TextBox ID="tbHours" runat="server" width="40px" MaxLength="4"></asp:TextBox>小時
                <asp:Label ID="lbTip2" runat="server" ForeColor="Blue" Text="(註：時間為24小時制) "></asp:Label></td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:100px">
                申請類型</td>
            <td class="htmltable_Right">            
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:RadioButtonList ID="rblmemo" runat="server" RepeatDirection="Horizontal" ForeColor="#555555">
                            <asp:ListItem Value="1" Text="申請補休"></asp:ListItem>
                            <asp:ListItem Value="2" Text="申請加班費"></asp:ListItem>
                        </asp:RadioButtonList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width:120px">
                <span style="color: #ff0000">*</span>事由</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※輸入事由請勿超出30字"></asp:Label><br />
                <asp:TextBox ID="tbReason" runat="server" 
                    TextMode="MultiLine" Width="300"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">
                備註說明</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbMemo" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="3" style="border-top:none;">
                <asp:Button ID="cbSubmit" runat="server" Text="確定" /><input id="cbReset" type="button" value="重填" onclick="clearForm(this.form)"  /></td>
        </tr>
    </table>
    </asp:Content>

