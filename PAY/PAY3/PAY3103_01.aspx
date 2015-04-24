<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="PAY3103_01.aspx.vb" Inherits="PAY_PAY3_PAY3103_01" %>

<%@ Register Src="~/UControl/UcROCYear.ascx" TagPrefix="uc1" TagName="UcROCYear" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>
<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagPrefix="uc1" TagName="ucSaCode" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">零用金清單維護-查詢
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
        <tr>
            <td class="htmltable_Left">零用金清單編號
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtPCList_id" runat="server"></asp:TextBox>
            </td>
        </tr>
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
        <asp:Button ID="AddBtn" runat="server" Text="新增" />
        <asp:Button ID="QryBtn" runat="server" Text="查詢" />
        <asp:Button ID="ClrBtn" runat="server" Text="清空重填" />
    </div>

    <table id="div1" runat="server" visible="false" class="tableStyle99" width="100%">
        <tr>
            <td>
                <asp:GridView ID="GridViewA" runat="server"
                    AutoGenerateColumns="False" AllowPaging="True"
                    CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無資料!!">
                    <Columns> 
                        <asp:BoundField DataField="FiscalYear_id" HeaderText="會計年度" /> 
                        <asp:BoundField DataField="PCList_id" HeaderText="零用金清單編號" />
                        <asp:BoundField DataField="PettyCash_nos" HeaderText="零用金流水號" />
                        <asp:BoundField DataField="Prepay_id" HeaderText="墊付款編號" />
                        <asp:BoundField DataField="TotalSIncome" HeaderText="墊付款支出" />
                        <asp:BoundField DataField="Income_amt" HeaderText="本期收入" />
                        <asp:BoundField DataField="CurrentBalances_amt" HeaderText="本期結存" />
                        <asp:BoundField DataField="WriteOff_date" HeaderText="核銷日期" />
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
    </table>    
    <uc1:Ucpager runat="server" ID="UcPager" GridName="GridViewA" EnableViewState="true" PSize="10" />
    
</asp:Content>

