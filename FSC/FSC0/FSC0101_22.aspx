<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="FSC0101_22.aspx.cs" Inherits="FSC_FSC0_FSC0101_22" %>
<%@ Register Src="~/UControl/SYS/UcFlowDetail.ascx" TagPrefix="uc2" TagName="UcFlowDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">表單明細</td>
        </tr>
    </table>
    <div id="div1" runat="server">
        <asp:GridView ID="GridViewA" runat="server"
            AutoGenerateColumns="False" OnRowDataBound="GridViewA_RowDataBound"
            AllowPaging="True" PagerSettings-Visible="false"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%">
            <PagerSettings Visible="False" />
            <Columns>
                <asp:BoundField DataField="BASE_IDNO" HeaderText="身份證號/護照" />
                <asp:BoundField DataField="BASE_NAME" HeaderText="姓名" />
                <asp:BoundField DataField="BASE_SERVICE_PLACE_DESC" HeaderText="服務單位" />
                <asp:BoundField DataField="BASE_DCODE_NAME" HeaderText="職稱" />
                <asp:BoundField DataField="Meeting_date" HeaderText="會議日期" />
                <asp:BoundField DataField="Apply_amt" HeaderText="金額" />
                <asp:BoundField DataField="BASE_ADDR" HeaderText="地址" />
                <asp:BoundField DataField="Pay_type" HeaderText="機關審查是否匯款" />
                <asp:BoundField DataField="BASE_BANK_NO" HeaderText="帳號" />
                <asp:BoundField DataField="Budget_code" HeaderText="預算來源" />
                <asp:BoundField DataField="Item_code" HeaderText="薪資項目" />
            </Columns>
            <RowStyle CssClass="Row" />
            <HeaderStyle CssClass="Grid" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle CssClass="EmptyRow" />
        </asp:GridView>
    </div>
    <div align="center">
        <input id="cbPrint" type="button" value="列印" onclick="javascript: window.print();" class="nonPrinted" />  
        <asp:Button ID="btnBack" runat="server" Text="回上頁" OnClick="btnBack_Click" />
    </div>
    <uc2:UcFlowDetail runat="server" ID="UcFlowDetail" />
</asp:Content>

