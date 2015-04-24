<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="PAY3103_02.aspx.vb" Inherits="PAY_PAY3_PAY3103_02" %>

<%@ Register Src="~/UControl/UcROCYear.ascx" TagPrefix="uc1" TagName="UcROCYear" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>
<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc1" TagName="ucSaCode" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">零用金清單維護-新增
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"><span style="color: red;">*</span>會計年度
            </td>
            <td style="width: 326px">
                <uc1:UcROCYear runat="server" ID="ucFiscalYear_id" />
            </td>
            <td class="htmltable_Left">零用金類別 
            </td>
            <td style="width: 326px">
                <uc1:ucSaCode runat="server" ID="ucPettyCash_type" ControlType="RadioButtonList"  Code_sys="018" Code_type="002" />
            </td>
        </tr>
        <%-- 
        <tr>
            <td class="htmltable_Left">零用金清單編號
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtPCList_id" runat="server"></asp:TextBox>
            </td>
        </tr>--%>
        <tr>
            <td class="htmltable_Left">零用金流水號(起~迄)
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtPettyCashStart_nos" runat="server"></asp:TextBox>
                ~
                <asp:TextBox ID="txtPettyCashEnd_nos" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">墊付款編號(起~迄)
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtPrepayStart_nos" runat="server"></asp:TextBox>
                ~
                <asp:TextBox ID="txtPrepayEnd_nos" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">核銷日期
            </td>
            <td colspan="3">
                <uc1:UcDate runat="server" ID="ucWriteOff_date" />
            </td>
        </tr>
    </table>
    <div align="center">
        <asp:Button ID="QryBtn" runat="server" Text="產生清單" />
        <asp:Button ID="DoneBtn" runat="server" Text="確認" />
        <asp:Button ID="ClrBtn" runat="server" Text="清空重填" />
        <asp:Button ID="BackBtn" runat="server" Text="回上頁" OnClick="BackBtn_Click" />
    </div>

    <table id="div1" runat="server" visible="false"  width="100%"  class="tableStyle99">
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridViewA" runat="server"
                    AutoGenerateColumns="False" AllowPaging="False" 
                    CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                            <ItemStyle CssClass="col_1" />
                            <ItemTemplate>
                                <asp:HiddenField ID="hfSerialNumber_id" runat="server" Value='<%# Eval("SerialNumber_id")%>' /> 
                                <asp:HiddenField ID="hfInvoice_date" runat="server" Value='<%# Eval("Invoice_date") %>' /> 
                                <asp:HiddenField ID="hfBeneficiary_id" runat="server" Value='<%# Eval("Beneficiary_id")%>' />
                                <asp:HiddenField ID="hfBeneficiary_name" runat="server" Value='<%# Eval("Beneficiary_name")%>' />
                                <asp:HiddenField ID="hfMiddleman_id" runat="server" Value='<%# Eval("Middleman_id")%>' />
                                <asp:HiddenField ID="hfMiddleman_name" runat="server" Value='<%# Eval("Middleman_name")%>' />
                                <asp:HiddenField ID="hfUse_type" runat="server" Value='<%# Eval("Use_type")%>' />
                                <asp:HiddenField ID="hfReceipt_cnt" runat="server" Value='<%# Eval("Receipt_cnt")%>' />
                                <asp:HiddenField ID="hfPurchaseTotal_amt" runat="server" Value='<%# Eval("PurchaseTotal_amt")%>' />
                                <asp:HiddenField ID="hfPurchaseAbstract_desc" runat="server" Value='<%# Eval("PurchaseAbstract_desc")%>' />
                                <asp:HiddenField ID="hfPurchaseForm_id" runat="server" Value='<%# Eval("PurchaseForm_id")%>' />
                                <asp:HiddenField ID="hfPurchaseForm_sn" runat="server" Value='<%# Eval("PurchaseForm_sn")%>' />
                                <asp:HiddenField ID="hfPrepay_id" runat="server" Value='<%# Eval("Prepay_id")%>' />
                                <asp:HiddenField ID="hfIncome_amt" runat="server" Value='<%# Eval("Income_amt")%>' />
                                <asp:HiddenField ID="hfPettyCash_nos" runat="server" Value='<%# Eval("PettyCash_nos")%>' />

                                <asp:CheckBox ID="cbLendPetty" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FiscalYear_id" HeaderText="會計年度" /> 
                        <asp:BoundField DataField="PCList_id" HeaderText="零用金清單編號" />
                        <asp:BoundField DataField="PettyCash_nos" HeaderText="零用金流水號" />
                        <asp:BoundField DataField="Prepay_id" HeaderText="墊付款編號" />
                        <asp:BoundField DataField="TotalSIncome" HeaderText="墊付款支出" />
                        <asp:BoundField DataField="Income_amt" HeaderText="本期收入" />
                        <asp:BoundField DataField="WriteOff_date" HeaderText="核銷日期" />
                    </Columns>
                    <RowStyle CssClass="Row" />
                    <HeaderStyle CssClass="Grid" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle CssClass="EmptyRow" />
                </asp:GridView> 
            </td>
        </tr>
        
    </table>


</asp:Content>

