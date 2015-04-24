<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="FSC0101_27.aspx.cs" Inherits="FSC_FSC0_FSC0101_27" %>
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
                <asp:BoundField DataField="Apply_type_name" HeaderText="申請事由" />
                <asp:BoundField DataField="Apply_desc" HeaderText="檢附文件說明" />
                <asp:BoundField DataField="Apply_amt" HeaderText="申請金額" />
                <asp:BoundField DataField="Relation_type_name" HeaderText="補助對象" />
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

