<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="FSC0101_19.aspx.cs" Inherits="FSC_FSC0_FSC0101_19" %>
<%@ Register Src="~/UControl/SYS/UcFlowDetail.ascx" TagPrefix="uc2" TagName="UcFlowDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">表單明細</td>
        </tr>
    </table>
    <div id="div1" runat="server">
        <asp:GridView ID="GridViewA" runat="server"
            AutoGenerateColumns="False"
            AllowPaging="True" PagerSettings-Visible="false"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%">
            <PagerSettings Visible="False" />
            <Columns>
                <asp:BoundField DataField="depart_name" HeaderText="單位別" />
                <asp:BoundField DataField="user_name" HeaderText="申請人員" />
                <asp:BoundField DataField="Apply_ymd" HeaderText="申請日期" />
                <asp:BoundField DataField="Flow_id" HeaderText="表單編號" />
                <asp:BoundField DataField="Cost_date" HeaderText="乘車日期" />
                <asp:BoundField DataField="Apply_desc" HeaderText="事由" />
                <asp:BoundField DataField="Apply_amt" HeaderText="申請車資" />
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
        <asp:Button ID="btnMergePrint" runat="server" Text="印領清冊" OnClick="btnMergePrint_Click" />
        <asp:Button ID="btnBack" runat="server" Text="回上頁" OnClick="btnBack_Click" />
    </div>
    <uc2:UcFlowDetail runat="server" ID="UcFlowDetail" />
</asp:Content>

