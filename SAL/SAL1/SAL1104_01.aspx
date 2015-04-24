<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SAL1104_01.aspx.cs" Inherits="SAL_SAL1_SAL1104_01" %>

<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc1" TagName="ucSaCode" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function checkBASE_IDNO(id) {
            if (id != "") {
                var b = checkID(id);
                if (!b) {
                    if (!confirm("不是身份證字號，是否確定輸入?")) {
                        document.getElementById('<%=txtBASE_IDNO.ClientID%>').value = "";
                        return false;
                    } else
                        return true;
                }
            }
        }
    </script>
    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">評審委員出席審查費、講師鐘點費申請</td>
            </tr>
            <tr>
                <td class="htmltable_Left"><font size="3" color="red">*</font>身分證號/護照</td>
                <td class="htmltable_Right" style="width: 300px">
                    <asp:TextBox ID="txtBASE_IDNO" runat="server" Width="200px" AutoPostBack="true" onblur="checkBASE_IDNO(this.value)" OnTextChanged="txtBASE_IDNO_TextChanged"></asp:TextBox>
                    <asp:HiddenField ID="hfFlow_id" runat="server" />
                    <asp:HiddenField ID="hfExists" runat="server" />
                </td>
                <td class="htmltable_Left"><font size="3" color="red">*</font>姓名</td>
                <td class="htmltable_Right" style="width: 300px">
                    <asp:TextBox ID="txtBASE_NAME" runat="server" Width="80px" Text=""></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">服務單位</td>
                <td class="htmltable_Right" style="width: 300px">
                    <asp:TextBox ID="txtBASE_SERVICE_PLACE_DESC" runat="server" Text=""></asp:TextBox>
                </td>
                <td class="htmltable_Left">職稱</td>
                <td class="htmltable_Right" style="width: 300px">
                    <asp:TextBox ID="txtBASE_DCODE_NAME" runat="server" Text=""></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left"><font size="3" color="red">*</font>職業類別</td>
                <td style="width: 300px">
                    <uc1:ucSaCode runat="server" ID="ucMeeting_pos" Code_sys="002" Code_type="001" ControlType="DropDownList" />
                </td>
                <td class="htmltable_Left">地址</td>
                <td style="width: 326px">
                    <asp:TextBox ID="txtBASE_ADDR" runat="server" Text="" Width="326"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">機關審查是否匯款</td>
                <td style="width: 326px">
                    <asp:DropDownList ID="ddlPay_type" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPay_type_SelectedIndexChanged">
                        <asp:ListItem Value="0">否</asp:ListItem>
                         <asp:ListItem Value="1">是</asp:ListItem>
                       
                    </asp:DropDownList>
                </td>
                <td class="htmltable_Left">帳號</td>
                <td style="width: 300px">
                    <asp:DropDownList ID="ddlBASE_BANK_CODE" runat="server" Enabled="false">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtBASE_BANK_NO" runat="server" Width="200px" Text="" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left"><font size="3" color="red">*</font>預算來源</td>
                <td style="width: 326px">
                    <uc1:ucSaCode ID="ucBudget_code" runat="server" Code_sys="006" Code_type="018" ControlType="DropDownList" />
                </td>
                <td class="htmltable_Left"><font size="3" color="red">*</font>會議日期</td>
                <td style="width: 300px">
                    <uc1:UcDate runat="server" ID="ucMeeting_date" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left"><font size="3" color="red">*</font>會議說明</td>
                <td style="width: 300px">
                    <asp:TextBox ID="txtMeeting_content" runat="server" TextMode="MultiLine" MaxLength="50"></asp:TextBox>
                </td>
                <td class="htmltable_Left"><font size="3" color="red">*</font>金額</td>
                <td style="width: 300px">
                    <asp:TextBox ID="txtApply_amt" runat="server" Width="80px" Text="" MaxLength="6"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">薪資項目</td>
                <td runat="server">
                    <asp:DropDownList ID="ddlItem_code" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="htmltable_Left">列印方式</td>
                <td runat="server">
                    <asp:DropDownList ID="ddlPrintType" runat="server">
                        <asp:ListItem Value="0" >依委員分頁列印</asp:ListItem>
                        <asp:ListItem Value="1" >合併列印</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center" style="width: 100%">
                    <asp:Label Text="請承辦人盡量填寫完整資訊，以利後續費用申請事宜。" ID="lbdesc" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <asp:HiddenField ID="hfModifyIndex" runat="server" />
                    <asp:Button ID="btn_new" runat="server" Text="新增" OnClick="btn_new_Click" />
                    <asp:Button ID="btn_submit" runat="server" Text="送出申請" OnClick="btn_submit_Click" />
                    <asp:Button ID="btn_print_empty" runat="server" Text="列印空白清冊" OnClick="btn_print_empty_Click" Enabled="true" />
                    <asp:Button ID="btn_print" runat="server" Text="列印" OnClick="btn_print_Click" Enabled="false" />
                    <asp:Button ID="btn_back" runat="server" Text="回上頁" OnClick="btn_back_Click" Visible="false" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:GridView ID="GridViewA" runat="server"
            AutoGenerateColumns="False"
            AllowPaging="True" PagerSettings-Visible="false"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" 
            EnableModelValidation="True">
            <PagerSettings Visible="False" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbx" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Meeting_pos_name" HeaderText="身份別" />
                <asp:BoundField DataField="BASE_NAME" HeaderText="姓名" />
                <asp:BoundField DataField="BASE_IDNO" HeaderText="身分證字號" />
                <asp:BoundField DataField="Apply_date" HeaderText="申請日期" />
                <asp:BoundField DataField="BASE_BANK_NO" HeaderText="帳號" />
                <asp:BoundField DataField="BASE_ADDR" HeaderText="地址" />
                <asp:BoundField DataField="Apply_amt" HeaderText="申請金額" />
                <asp:BoundField DataField="Budget_name" HeaderText="預算來源" />
                <asp:BoundField DataField="Item_name" HeaderText="薪資項目" />
                <asp:TemplateField HeaderText="維護">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:HiddenField ID="hfApply_amt" runat="server" Value='<%# Eval("Apply_amt") %>' />
                        <asp:HiddenField ID="hfId" runat="server" Value='<%# Eval("Id") %>' />
                        <asp:Button ID="btnMain" runat="server" Text="維護" CommandName="Maintain" OnClick="btnMain_Click" />
                        <asp:Button ID="btnDelete" CommandName="GoDelete" runat="server" Text="刪除" OnClick="btnDelete_Click" OnClientClick="return confirm('是否確定要刪除?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="Row" />
            <HeaderStyle CssClass="Grid" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle CssClass="EmptyRow" />
        </asp:GridView>
    </div>
</asp:Content>

