<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="PAY3101_01.aspx.vb" Inherits="PAY_PAY3_PAY3101_01" %>

<%@ Register Src="~/UControl/UcROCYear.ascx" TagPrefix="uc1" TagName="UcROCYear" %>
<%@ Register Src="~/UControl/UcBeneficiary.ascx" TagPrefix="uc1" TagName="UcBeneficiary" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">預借零用金維護
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">會計年度
                </td>
                <td>
                    <uc1:UcROCYear runat="server" ID="ucFiscalYear_id" />
                </td>
                <td class="htmltable_Left">墊付款編號 
                </td>
                <td>
                    <asp:TextBox ID="txtPrepay_id_S" runat="server" Width="80"></asp:TextBox>
                    ~
                    <asp:TextBox ID="txtPrepay_id_E" runat="server" Width="80"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">零用金清單編號
                </td>
                <td>
                    <asp:TextBox ID="txtPCList_id" runat="server"></asp:TextBox>
                </td>
                <td class="htmltable_Left">是否核銷
                </td>
                <td>
                    <asp:RadioButtonList ID="rblWriteOff_date" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="Y">已核銷</asp:ListItem>
                        <asp:ListItem Value="N">未核銷</asp:ListItem>
                    </asp:RadioButtonList>

                </td>
            </tr>

            <tr>
                <td class="htmltable_Left">借款日期
                </td>
                <td>
                    <uc1:UcDate runat="server" ID="uc_Borrow_date_S" />
                    ~
                    <uc1:UcDate runat="server" ID="uc_Borrow_date_E" />
                </td>
                <td class="htmltable_Left">零用金流水號
                </td>
                <td>

                    <asp:TextBox ID="txtPettyCash_nos_S" runat="server" Width="80"></asp:TextBox>
                    ~
                    <asp:TextBox ID="txtPettyCash_nos_E" runat="server" Width="80"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="htmltable_Left">受款人
                </td>
                <td>
                    <uc1:UcBeneficiary runat="server" ID="ucBeneficiary" />
                </td>
                <td class="htmltable_Left">用途別</td>
                <td>
                    <asp:TextBox ID="txtUse_type" runat="server" Enabled="False" Width="80"></asp:TextBox>
                    <asp:DropDownList ID="ddlUse_type" runat="server" AutoPostBack="true"></asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td class="htmltable_Left">發票日期
                </td>
                <td>
                    <uc1:UcDate runat="server" ID="ucInvoice_date" />
                </td>
                <td class="htmltable_Left">付款憑單編號
                </td>
                <td>
                    <asp:TextBox ID="txtPaymentVoucher_id" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div align="center">
            <asp:Button ID="AddBtn" runat="server" Text="新增" PostBackUrl="~/PAY/PAY3/PAY3101_02.aspx" />
            <asp:Button ID="DoneBtn" runat="server" Text="查詢" />
            <asp:Button ID="ResetBtn" runat="server" Text="清空重填" />
        </div>

        <table id="div1" runat="server" visible="false" class="tableStyle99"  width="100%" >
            <tr>
                <td>
                    <asp:GridView ID="GridViewA" runat="server"
                        AutoGenerateColumns="False" AllowPaging="True"
                        CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無資料!!">
                        <Columns>
                            <asp:BoundField DataField="FiscalYear_id" HeaderText="會計年度" />
                            <asp:BoundField DataField="PettyCash_nos" HeaderText="零用金流水號" />
                            <asp:TemplateField HeaderText="請購單號" >
                                <ItemTemplate>
                                    <asp:Label ID="lbPurchaseForm_id" runat="server" Text='<%# Bind("PurchaseForm_id")%>'></asp:Label><asp:Label ID="lbPurchaseForm_sn" runat="server" Text='<%# Bind("PurchaseForm_sn")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Invoice_date" HeaderText="發票日期" />
                            <asp:BoundField DataField="Beneficiary_name" HeaderText="受款人" />
                            <asp:BoundField DataField="Middleman_name" HeaderText="經手人" />
                            <asp:BoundField DataField="Use_type" HeaderText="用途別" />
                            <asp:BoundField DataField="Receipt_cnt" HeaderText="單據張數" />
                            <asp:BoundField DataField="PurchaseTotal_amt" HeaderText="請購金額" />
                            <asp:BoundField DataField="PaymentVoucher_id" HeaderText="付款憑單編號" />
                            <asp:BoundField DataField="PurchaseAbstract_desc" HeaderText="摘要" />
                            <asp:TemplateField HeaderText="維護">
                                <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                                <ItemStyle CssClass="col_1" />
                                <ItemTemplate>
                                    <asp:HiddenField ID="hfWriteOff_date" runat="server" Value='<%# Eval("WriteOff_date")%>' />
                                    <asp:HiddenField ID="hfSerialNumber_id" runat="server" Value='<%# Eval("SerialNumber_id")%>' />
                                    <asp:Button ID="btn1" runat="server" Text="維護" CommandName="Maintain" CommandArgument='<%# Eval("SerialNumber_id")%>' />
                                    <asp:Button ID="btn2" CommandName="GoDelete" CommandArgument='<%# Eval("SerialNumber_id")%>'
                                        runat="server" Text="刪除" OnClientClick="return confirm('是否確定要刪除?');" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                              <EmptyDataTemplate>
                               查無資料!!
                         </EmptyDataTemplate>
                        <RowStyle CssClass="Row" />
                        <HeaderStyle CssClass="Grid" />
                        <AlternatingRowStyle CssClass="AlternatingRow" />
                        <PagerSettings Position="TopAndBottom" />
                        <EmptyDataRowStyle CssClass="EmptyRow" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="GridViewA"
                                    PNow="1" PSize="10" Visible="true" />
                </td>
            </tr>            
        </table>
    </div>
</asp:Content>

