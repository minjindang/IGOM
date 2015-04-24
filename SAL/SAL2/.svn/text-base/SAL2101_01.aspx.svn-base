<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL2101_01.aspx.cs" Inherits="SAL_SAL2_SAL2101_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">
                薪餉單查詢
            </td>
        </tr>
        <tr>
            <td>
                    <asp:GridView ID="gvResult" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                        AllowPaging="True" PageSize="30" CssClass="Grid" PagerStyle-HorizontalAlign="Right"
                        Width="100%" EmptyDataText="查無資料!" EmptyDataRowStyle-ForeColor="Red" EnableModelValidation="True"
                       >
                        <PagerStyle HorizontalAlign="Right" />
                        <EmptyDataTemplate>
                            查無資料!!
                        </EmptyDataTemplate>
                        <RowStyle CssClass="Row" />
                        <AlternatingRowStyle CssClass="AlternatingRow" />
                        <PagerSettings Position="TopAndBottom" />
                        <Columns>
                            <asp:BoundField DataField="Kind_name" HeaderText="項目名稱" />
                            <asp:BoundField DataField="ROC_Payo_yymm" HeaderText="發放年月" />
                            <asp:BoundField DataField="ROC_Payo_date" HeaderText="發放日期" />
                            <asp:BoundField DataField="payod_amt_001" HeaderText="應發合計" />
                            <asp:BoundField DataField="payod_amt_002" HeaderText="應扣合計" />
                            <asp:BoundField DataField="payod_amt_003" HeaderText="實發數" />
                        </Columns>
                        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                    </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
