<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC0101_07.aspx.vb" Inherits="FSC0101_07" %>
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
                 <asp:TemplateField HeaderText="財產編號">
                    <HeaderStyle CssClass="item_col0" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate> 
                        
                        <asp:label ID="lblProperty_id" Text='<%# Eval("Property_id") %>' runat="server" /> -
                        <asp:label ID="lblProperty_clsno" Text='<%# Eval("Property_clsno")%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:BoundField DataField="Property_type_New" HeaderText="財產別" />
                <asp:BoundField DataField="Property_name" HeaderText="財產名稱" />
                <asp:BoundField DataField="Buy_Date" HeaderText="購置日期" />
                <asp:BoundField DataField="LifeTime" HeaderText="年限" />
                <asp:BoundField DataField="AllowScrap_date" HeaderText="可報廢日期" />
                <asp:BoundField DataField="Location" HeaderText="放置地點" />
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
        <asp:Button ID="btnBack" runat="server" Text="回上頁" />
    </div>
<uc2:UcFlowDetail runat="server" ID="UcFlowDetail" />
</asp:Content>