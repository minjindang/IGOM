<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC1105_01.aspx.vb" Inherits="FSC1105_01" %>

<%@ Register src="~/UControl/UcDate.ascx" tagprefix="uc2" tagname="UcDate" %>
<%@ Register src="~/UControl/UcTextBox.ascx" tagprefix="uc3" tagname="UcTextBox" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/FSC/UcAttachment.ascx" TagPrefix="uc6" TagName="UcAttachment" %>
<%@ Register Src="~/UControl/UcDateTime.ascx" TagPrefix="uc1" TagName="UcDateTime" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">
                專簽加班簽核</td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                專案代號</td>
            <td class="htmltable_Right">
                <asp:Label ID="lbProjectCode" runat="server" />
                <asp:Label ID="lbTip" runat="server" Text="註:由系統自動產生專案代號"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                <span style="color: #ff0000">*</span>專案名稱</td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbProjectName" runat="server" MaxLength="100" Width="300px" ></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                專案說明</td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbProjectDesc" runat="server" TextMode="MultiLine" Width="500px" Rows="5" ></asp:TextBox>
                <br /><span style="color:blue">專案說明最多輸入250個中文字。</span>
            </td>
        </tr>   
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                 <span style="color: #ff0000">*</span>專案類別</td>
            <td class="htmltable_Right">
                <asp:RadioButtonList ID="rblProjectKind" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                    DataTextField="code_desc1" DataValueField="code_no" >                    
                </asp:RadioButtonList>
            </td>         
        </tr>     
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                 <span style="color: #ff0000">*</span>加班性質</td>
            <td class="htmltable_Right">
                <asp:RadioButtonList ID="rblCheckType" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">一般加班</asp:ListItem>
                    <asp:ListItem Value="2">專案加班</asp:ListItem>    
                </asp:RadioButtonList>
            </td>         
        </tr>  
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                 <span style="color: #ff0000">*</span>加班地點</td>
            <td class="htmltable_Right">
                <asp:RadioButtonList ID="rblLocation" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">機關內</asp:ListItem>
                    <asp:ListItem Value="2">機關外</asp:ListItem>    
                </asp:RadioButtonList>
            </td>         
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                 <span style="color: #ff0000">*</span>專案加班起</td>
            <td class="htmltable_Right">
                <uc1:UcDateTime runat="server" ID="UcDateTimeS" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                 <span style="color: #ff0000">*</span>專案加班迄</td>
            <td class="htmltable_Right">
                <uc1:UcDateTime runat="server" ID="UcDateTimeE" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                 <span style="color: #ff0000">*</span>是否刷卡</td>
            <td class="htmltable_Right">
                <asp:RadioButtonList ID="rblisCard" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">是</asp:ListItem>
                    <asp:ListItem Value="0">否</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                 <span style="color: #ff0000">*</span>是否僅限補休</td>
            <td class="htmltable_Right">
                <asp:RadioButtonList ID="rblisOnlyLeave" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" >
                    <asp:ListItem Value="1">是</asp:ListItem>
                    <asp:ListItem Value="0">否</asp:ListItem>
                </asp:RadioButtonList>
                <span id="spLeaveHours" runat="server" Visible="false">
                    補休時數<asp:TextBox id="tbLeaveHours" runat="server" Width="150px" MaxLength="3" />
                </span>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                <span style="color: #ff0000">*</span>員工姓名</td>
            <td class="htmltable_Right">
                <uc1:UcDDLDepart runat="server" id="UcDDLDepart" OnSelectedIndexChanged="UcDDLDepart_SelectedIndexChanged" />
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>                                    
                                    <asp:ListBox ID="lbUnSelectMember" runat="server" DataTextField="full_name" DataValueField="cos" 
                                                    SelectionMode="Multiple"  Width="280" Height="200">
                                    </asp:ListBox>      
                                </td>
                                <td>
                                    <asp:Button ID="cbToR" runat="server" Text="選擇>>" OnClick="cbToR_Click" />
                                    <br />
                                    <asp:Button ID="cbToL" runat="server" Text="<<取消" OnClick="cbToL_Click" />
                                </td>
                                <td>                                                        
                                    <asp:ListBox ID="lbMember" runat="server" SelectionMode="Multiple" Width="280" Height="200">
                                    </asp:ListBox>   
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                 每日加班時數上限</td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbDailyOTHr" runat="server" Width="80" MaxLength="2" ></asp:TextBox>
            </td>         
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                 每日加班費時數上限</td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbDailyOTPayHr" runat="server" Width="80" MaxLength="2" ></asp:TextBox>
            </td>         
        </tr>        
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                 每月加班時數上限</td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbMonOTHr" runat="server" Width="80" MaxLength="2" ></asp:TextBox>
            </td>         
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">
                 每月加班費時數上限</td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbMonOTPayHr" runat="server" Width="80" MaxLength="2" ></asp:TextBox>
            </td>         
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">附件</td>
            <td class="htmltable_Right">
                <uc6:UcAttachment runat="server" ID="UcAttachment" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                <asp:Button ID="cbConfirm" runat="server" Text="確認" OnClick="cbConfirm_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>
