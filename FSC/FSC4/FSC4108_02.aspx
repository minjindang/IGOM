<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC4108_02.aspx.vb" Inherits="FSC4108_02"  %>
<%@ Register Src="~/UControl/UcLeaveDate.ascx" TagName="UcLeaveDate" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">
                假別規則說明</td>
        </tr>
        <tr id="TR01" runat="server" >
            <td class="htmltable_Left">
                差勤組別
            </td>
            <td class="htmltable_Right">           
                <asp:DropDownList ID="ddlLeaveKind" runat="server">
                </asp:DropDownList></td>
        </tr>
        <tr id="TR02" runat="server" >
            <td class="htmltable_Left">
                <span style="color:Red">*</span>假別
            </td>
            <td class="htmltable_Right">
                 <asp:DropDownList ID="ddlLeaveType" runat="server" AutoPostBack="true">
                 </asp:DropDownList>
            </td>
        </tr>        
        <tr id="TR03" runat="server" >
            <td class="htmltable_Left">
                <span style="color: #ff0000">*</span>職務類別</td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddlMEMCOD" runat="server">
                </asp:DropDownList></td>
        </tr>
        <tr id="TR04" runat="server" >
            <td class="htmltable_Left">
                假別說明</td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbDesc" runat="server" Height="90px" TextMode="MultiLine" Width="420px"></asp:TextBox>註：假別說明可輸250中文字</td>
        </tr>
        <tr id="TR05" runat="server" >
            <td class="htmltable_Left">
                <asp:Label ID="Label_TR05" runat="server" Text="申請期限日期/天數" /></td>
            <td class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:RadioButton ID="rbdate" runat="server" GroupName="limit" AutoPostBack="true" Checked="true" />
                        <asp:TextBox ID="tblimit_Date" runat="server" Width="50" MaxLength="4"></asp:TextBox>
                        <span style="color:blue">日期填寫範例:0101</span>
                        <br />
                        <asp:RadioButton ID="rbdays" runat="server" AutoPostBack="true" GroupName="limit" />
                        <asp:TextBox ID="tbLimit" runat="server" Width="35" MaxLength="3" Enabled="false" ></asp:TextBox>天
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr id="TR06" runat="server" >
            <td class="htmltable_Left">
                請畢天數</td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbReciprocalDays" runat="server" Width="100"></asp:TextBox>天(幾日內須請畢)</td>
        </tr>
        <tr id="TR07" runat="server" >
            <td class="htmltable_Left" style="width:120px">
                停止申請請假期間</td>
            <td class="htmltable_Right" valign="top">
                <uc1:UcLeaveDate ID="UcStopDate" runat="server" />
                <asp:Label ID="Label2" runat="server" ForeColor="Blue" Text="※日期填寫範例:101/01/01、時間為24小時制"></asp:Label>
                </td>
        </tr>
        <tr id="TR08" runat="server" >
            <td class="htmltable_Left">
                假別最小單位時數</td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddlMinHour" runat="server">
                    <asp:ListItem Value="8">天</asp:ListItem>
                    <asp:ListItem Value="4">半天</asp:ListItem>
                    <asp:ListItem Value="1">時</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr id="TR09" runat="server" >
            <td class="htmltable_Left">
                是否可分次申請</td>
            <td class="htmltable_Right">
                <asp:RadioButtonList id="rblBatchApply" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="0" Selected="True">是</asp:ListItem>
                    <asp:ListItem Value="1">否</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr id="TR10" runat="server" >
            <td class="htmltable_Left">
                是否含假日</td>
            <td class="htmltable_Right">
                <asp:RadioButtonList id="rblHolidayYN" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="0" Selected="True">是</asp:ListItem>
                    <asp:ListItem Value="1">否</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr id="TR11" runat="server">
            <td class="htmltable_Left">
                是否含事實發生日</td>
            <td class="htmltable_Right">
                <asp:RadioButtonList id="rblOccurDateYN" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="0" Selected="True">是</asp:ListItem>
                    <asp:ListItem Value="1">否</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr id="TR12" runat="server">
            <td class="htmltable_Left">
                是否必須上傳附件</td>
            <td class="htmltable_Right">
                <asp:RadioButtonList id="rblMustAttachYN" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" >
                    <asp:ListItem Value="0" Selected="True">是</asp:ListItem>
                    <asp:ListItem Value="1">否</asp:ListItem>
                </asp:RadioButtonList>
                <asp:TextBox ID="tbManyDays" runat="server" Width="100" Visible="false"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Text="天(多少天以上必須上傳附件)" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr id="TR13" runat="server">
            <td class="htmltable_Left">
                是否允許補上傳附件</td>
            <td class="htmltable_Right">
                <asp:RadioButtonList id="rblReAttachYN" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="0" Selected="True">是</asp:ListItem>
                    <asp:ListItem Value="1">否</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <!--
        <tr>
            <td class="htmltable_Left">
                系統提示</td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbMessage" runat="server" Width="100"></asp:TextBox>天(超過天數時，系統提示超過天數訊息)
            </td>
        </tr>
        -->
        <tr>
            <td class="htmltable_Bottom" colspan="2">
                 <asp:Button ID="cbConfirm" runat="server" Text="確認" />
                 <input id="cbReset" type="button" value="重填" />
                 <asp:Button ID="cbCancel" runat="server" Text="取消" />
                 <asp:Button ID="cbJoin" runat="server" Text="加入親屬設定" Visible="false" />
                 <asp:Button ID="cbSet" runat="server" Text="加入流產假設定" Visible="false" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" CssClass="Grid" width="100%">            
                <Columns>
                    <asp:TemplateField HeaderText="親屬稱謂">
                        <ItemTemplate>
                            <asp:Label ID="lbDetailCode" runat="server" Text='<%# Bind("Detail_code_id")%>' Width="280" Visible="false"></asp:Label>
                            <asp:DropDownList ID="ddlDetailCode" runat="server"></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="可休天數">
                        <ItemTemplate>
                            <asp:TextBox ID="ltbLimitdays" runat="server" Text='<%# Bind("Limitdays")%>' Width="280"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField  HeaderText="">
                        <ItemTemplate>
                            <asp:Label ID="lbID" runat="server" Text='<%# Bind("id")%>' Width="280" Visible="false"></asp:Label>
                            <asp:Button ID="btnDel" runat="server" Text="刪除" OnClientClick="javascript:if(!confirm('是否確定刪除?')) return false;" onclick="doDelete"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>        
     </asp:GridView>

    <asp:GridView ID="gvList02" runat="server" AutoGenerateColumns="false" CssClass="Grid" width="100%">            
                <Columns>
                    <asp:TemplateField HeaderText="懷孕日數">
                        <ItemTemplate>
                            <asp:Label ID="lbDetailCode02" runat="server" Text='<%# Bind("Detail_code_id")%>' Width="280" Visible="false"></asp:Label>
                            <asp:DropDownList ID="ddlDetailCode02" runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="可休天數">
                        <ItemTemplate>
                            <asp:TextBox ID="ltbLimitdays02" runat="server" Text='<%# Bind("Limitdays")%>' Width="280"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField  HeaderText="">
                        <ItemTemplate>
                            <asp:Label ID="lbID02" runat="server" Text='<%# Bind("id")%>' Width="280" Visible="false"></asp:Label>
                            <asp:Button ID="btnDel02" runat="server" Text="刪除" OnClientClick="javascript:if(!confirm('是否確定刪除?')) return false;" onclick="doDelete02"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>        
     </asp:GridView>
</asp:Content>

