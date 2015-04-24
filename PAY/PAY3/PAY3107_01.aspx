<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PAY3107_01.aspx.cs" Inherits="PAY_PAY3_PAY3107_01" %>

<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">零用金撥入</td>
            </tr>
            <tr>
                <td class="htmltable_Left">年度初始撥入</td>
                <td>
                    <asp:TextBox ID="txtYearInitial_amt" runat="server" Width="70px" Text=""></asp:TextBox>
                </td>
                <td class="htmltable_Left">入帳日期</td>
                <td>
                    <uc1:UcDate runat="server" ID="ucReceive_date" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">上期結轉金額</td>
                <td colspan="3">
                    <asp:Label ID="lblBroughtForward_amt" runat="server" Width="70px" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" colspan="4"  align="center">本次收入金額</td>
            </tr>
            <tr>
                <td colspan="4">
                    <div id="div1" runat="server" visible="true">
                        <asp:GridView ID="GridViewA" runat="server"
                            AutoGenerateColumns="False" AllowPaging="False"
                            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <HeaderStyle CssClass="item_col0" HorizontalAlign="Center" />
                                    <ItemStyle CssClass="col_1" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" Text="" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="序號">
                                    <ItemTemplate>
                                        <asp:Label ID="lb" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PettyCashInventory_id" HeaderText="零用金清單" />
                                <asp:BoundField DataField="PaymentVoucher_id" HeaderText="付款憑單編號" /> 
                                <asp:TemplateField HeaderText="收入金額">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle CssClass="col_1" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtIncome_amt" runat="server" ></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="備註">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle CssClass="col_1" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtMemo" runat="server" ></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="Row" />
                            <HeaderStyle CssClass="Grid" />
                            <AlternatingRowStyle CssClass="AlternatingRow" />
                            <PagerSettings Position="TopAndBottom" />
                            <EmptyDataRowStyle CssClass="EmptyRow" />
                            <EmptyDataTemplate>
                                目前尚無需撥入之零用金清單資料
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <asp:Button ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click" />
                    <asp:Button ID="btnClr" runat="server" Text="清空重填" OnClick="btnClr_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

