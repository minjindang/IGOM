<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="FSC0101_21.aspx.cs" Inherits="FSC_FSC0_FSC0101_21" %>
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
                <asp:BoundField DataField="User_name" HeaderText="申請人姓名" />
                <asp:BoundField DataField="Flow_id" HeaderText="表單編號" />
                <asp:BoundField DataField="Child_name" HeaderText="子女姓名" />
                <asp:BoundField DataField="Apply_Period" HeaderText="申請學年/學期" />
                <asp:BoundField DataField="ChildBirth_date" HeaderText="子女生日" />
                <asp:BoundField DataField="Child_id" HeaderText="身分證字號" />
                <asp:BoundField DataField="School_type_name" HeaderText="子女學歷" />
                <asp:BoundField DataField="School_name" HeaderText="學校名稱科系" />
                <asp:BoundField DataField="StudyLimit_nos" HeaderText="修業年限" />
                <asp:BoundField DataField="Study_nos" HeaderText="就讀年級" />
                <asp:BoundField DataField="Apply_amt" HeaderText="申請金額" />
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
            <asp:Button ID="btnMergePrint" runat="server" Text="印領清冊" OnClick="btnMergePrint_Click" />
    </div>
    <uc2:UcFlowDetail runat="server" ID="UcFlowDetail" />
</asp:Content>

