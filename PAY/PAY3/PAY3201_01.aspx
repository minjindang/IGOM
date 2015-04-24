<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="PAY3201_01.aspx.vb" Inherits="PAY_PAY3_PAY3201_01" %>

<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>
<%@ Register Src="~/UControl/UcPayer.ascx" TagPrefix="uc1" TagName="UcPayer" %>
<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc1" TagName="ucSaCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">審查收入維護作業
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">收入類別
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtExamineIncome_type" runat="server" Enabled="false"></asp:TextBox>
                <asp:DropDownList ID="ddlExamineIncome" runat="server" AutoPostBack="true"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">收據編號
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtReceipt" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" ID="REV0" ControlToValidate="txtReceipt"
                    ValidationExpression="^\d+?$" ErrorMessage="收據編號要為數字!!!!" />
            </td>
            <td class="htmltable_Left">收款日期
            </td>
            <td style="width: 326px">
                <uc1:UcDate runat="server" ID="ucReceipt_date" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">付款人
            </td>
            <td colspan="3">
                <uc1:UcPayer runat="server" ID="UcPayer" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">付款方式
            </td>
            <td style="width: 326px">
                <asp:DropDownList ID="ddlPayMode_type" runat="server"></asp:DropDownList>
            </td>
            <td class="htmltable_Left">收據已作廢
            </td>
            <td style="width: 326px">
                <asp:CheckBox ID="cbReceiptScrap_type" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">支票號碼一
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtCheck1_nos" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" ID="REV1" ControlToValidate="txtCheck1_nos"
                    ValidationExpression="^\d+?$" ErrorMessage="只能輸入數字!!" />
            </td>
            <td class="htmltable_Left">支票號碼二
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtCheck2_nos" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" ID="REV2" ControlToValidate="txtCheck2_nos"
                    ValidationExpression="^\d+?$" ErrorMessage="只能輸入數字!!" />
            </td>
        </tr>
    </table>
    <div align="center">
        <asp:Button ID="AddBtn" runat="server" Text="新增" />
        <asp:Button ID="QryBtn" runat="server" Text="查詢" />
        <asp:Button ID="ClrBtn" runat="server" Text="清空重填" />
    </div>

    <div id="div1" runat="server" visible="false">
        <asp:GridView ID="GridViewA" runat="server"
            AutoGenerateColumns="False"
            AllowPaging="True" PagerSettings-Visible="false"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%">
            <PagerSettings Visible="false" />
            <Columns>
                <asp:BoundField DataField="ExamineIncome_typeName" HeaderText="收入類別" />
                <asp:BoundField DataField="ReceiptStart_id" HeaderText="收據編號" />
                <asp:BoundField DataField="Receipt_date" HeaderText="收款日期" />
                <asp:BoundField DataField="UnitPrice_amt" HeaderText="金額" />
                <asp:BoundField DataField="Payer_id" HeaderText="付款人代號" />
                <asp:BoundField DataField="Payer_name" HeaderText="付款人名稱" />
                <asp:BoundField DataField="PayMode_type" HeaderText="付款方式" />
                <asp:BoundField DataField="Check1_nos" HeaderText="支票號碼一" />
                <asp:BoundField DataField="Check2_nos" HeaderText="支票號碼二" />
                <asp:BoundField DataField="ReceiptScrap_type" HeaderText="收據已作廢" />
                <asp:TemplateField HeaderText="維護">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:HiddenField ID="hfExamineIncome_type" runat="server" Value='<%# Eval("ExamineIncome_type")%>' />
                            <asp:HiddenField ID="hf" runat="server" Value='<%# Eval("ReceiptStart_id")%>' />
                            <asp:Button ID="btn1" runat="server" Text="維護" CommandArgument='<%# Eval("ExamineIncome_type") & ";" & Eval("ReceiptStart_id")%>' CommandName="Maintain" />
                            <asp:Button ID="btn2" CommandName="GoDelete" 
                                runat="server" Text="刪除" OnClientClick="return confirm('是否確定要刪除?');" CommandArgument='<%# Eval("ExamineIncome_type") & ";" & Eval("ReceiptStart_id")%>' />
                            <asp:Button ID="btn3" CommandName="GoPrint" runat="server" Text="收據列印" CommandArgument='<%# Eval("ExamineIncome_type") & ";" & Eval("ReceiptStart_id")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="Row" />
            <HeaderStyle CssClass="Grid" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle CssClass="EmptyRow" />
        </asp:GridView>
        <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="GridViewA"
            PNow="1" PSize="10" Visible="true" />
    </div>

</asp:Content>

