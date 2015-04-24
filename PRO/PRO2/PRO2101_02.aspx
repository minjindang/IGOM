<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PRO2101_02.aspx.cs" Inherits="PRO_PRO2_PRO2101_02" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">財產移轉歷程
                </td>
            </tr>
        </table>
        <asp:GridView ID="GridViewA" runat="server"
            AutoGenerateColumns="False"
            AllowPaging="True" PagerSettings-Visible="false" OnPageIndexChanging="GridViewA_PageIndexChanging"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%">
            <PagerSettings Visible="false" />
            <Columns>
                <asp:BoundField DataField="Index" HeaderText="項次" />
                <asp:BoundField DataField="Property_id_class" HeaderText="總號/分類編號" />
                <asp:BoundField DataField="Property_name" HeaderText="財產名稱" />
                <asp:BoundField DataField="OldUnit_name" HeaderText="原保管單位" />
                <asp:BoundField DataField="OldKeeper_name" HeaderText="原保管人" />
                <asp:BoundField DataField="NewUnit_name" HeaderText="新保管單位" />
                <asp:BoundField DataField="NewKeeper_name" HeaderText="新保管人" />
                <asp:BoundField DataField="Buy_date" HeaderText="購置日期" />
                <asp:BoundField DataField="PropertyTran_date" HeaderText="財產移轉日期" />
                <asp:BoundField DataField="Scrap_date" HeaderText="報廢日期" />
            </Columns>
            <RowStyle CssClass="Row" />
            <HeaderStyle CssClass="Grid" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle CssClass="EmptyRow" />
        </asp:GridView>
        <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="GridViewA"
            PNow="1" PSize="10" Visible="true" />
        <div align="center">
            <asp:Button ID="BackBtn" runat="server" Text="回上頁" PostBackUrl="~/PRO/PRO2/PRO2101_01.aspx" />
        </div>
    </div>

</asp:Content>

