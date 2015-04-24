<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PAY2104_01.aspx.cs" Inherits="PAY_PAY2_PAY2104_01" %>

<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">零用金墊付明細表</td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width: 170px">零用金流水號(起~迄)</td>
                <td style="width: 326px" colspan="3">
                    <asp:TextBox ID="txtPettyCash_nosS" runat="server" Width="140px"></asp:TextBox>
                    &nbsp;&nbsp;~&nbsp;&nbsp;
			        <asp:TextBox ID="txtPettyCash_nosE" runat="server" Width="140px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">借款日期(起~迄)</td>
                <td style="width: 326px">
                    <uc1:UcDate runat="server" ID="ucBorrow_dateS" />
                    &nbsp;&nbsp;~&nbsp;&nbsp;
			         <uc1:UcDate runat="server" ID="ucBorrow_dateE" />
                </td>
                <td class="htmltable_Left">收回日期(起~迄)</td>
                <td style="width: 326px">
                    <uc1:UcDate runat="server" ID="ucIncome_dateS" />
                    &nbsp;&nbsp;~&nbsp;&nbsp;
			     <uc1:UcDate runat="server" ID="ucIncome_dateE" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <asp:Button ID="btnQuery" runat="server" Text="查詢" OnClick="btnQuery_Click" />
                    <asp:Button ID="btnPrint" runat="server" Text="列印" OnClick="btnPrint_Click" />
                    <asp:Button ID="btnClear" runat="server" Text="清空重填" OnClick="btnClear_Click" />

                </td>
            </tr>
        </table>
    </div>
    <table id="div1" runat="server" visible="False" width="100%" class="tableStyle99">
        <tr>
            <td>
            <asp:GridView ID="GridViewA" runat="server" EmptyDataText="查無資料"
                AutoGenerateColumns="False" OnPageIndexChanging="GridViewA_PageIndexChanging"
                AllowPaging="True" CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%">
                <Columns>
                    <asp:BoundField DataField="Prepay_id" HeaderText="墊付款編號" />
                    <asp:BoundField DataField="PettyCash_nos" HeaderText="零用金流水號" />
                    <asp:BoundField DataField="Borrow_date" HeaderText="日期" />
                    <asp:BoundField DataField="PurchaseAbstract_desc" HeaderText="摘要" />
                    <asp:BoundField DataField="User_unit" HeaderText="單位別" />
                    <asp:BoundField DataField="Beneficiary_name" HeaderText="姓名" />
                    <asp:BoundField DataField="WriteOff_date" HeaderText="核銷日期" />
                    <asp:BoundField DataField="PurchaseTotalSIncome" HeaderText="支出" />
                    <asp:BoundField DataField="PurchaseTotalSIncome" HeaderText="核銷金額" /> 
                    <asp:BoundField DataField="Income_date" HeaderText="收回日期" />
                    <asp:BoundField DataField="Note" HeaderText="備註" />
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
    <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="GridViewA"
            PNow="1" PSize="10" Visible="true" />

</asp:Content>

