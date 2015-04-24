<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC4103_01.aspx.vb" Inherits="FSC4103_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
            <tr>
                <td class="htmltable_Title" colspan="6">
                    刷卡補登次數設定
                </td>
            </tr>
            <tr>
            <td class="TdHeightLight"  colspan="6">
                    <asp:Button ID="btnAdd" runat="server" Text="新增" />
                    <asp:HiddenField ID="hfOrgcode" runat="server" />
                    <asp:HiddenField ID="hfLoginCardId" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvnotClockInOutTimesSettingForm" runat="server" AutoGenerateColumns="False"
                        CssClass="Grid" Width="100%" BorderWidth="0px" PagerStyle-HorizontalAlign="right">
                        <Columns>
                            <asp:TemplateField HeaderText="不限次數">
                                <ItemTemplate>
                                    <asp:Label ID="lblTimes" runat="server" Text='<%# Bind("Times") %>'></asp:Label>
                                    <asp:HiddenField ID="hfTimes" runat="server" Value='<%# Bind("Times") %>'></asp:HiddenField>
                                </ItemTemplate>
                                <HeaderStyle />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="每年幾次">
                                <ItemTemplate>
                                    <asp:Label ID="lblYearTimes" runat="server" Text='<%# Bind("YearTimes") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="每月次數">
                                <ItemTemplate>
                                    <asp:Label ID="lblMonthTimes" runat="server" Text='<%# Bind("MonthTimes") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="維護">
                                <ItemTemplate>
                                    <asp:Button ID="btnUpdate" runat="server" Text="修改刷卡補登次數" CommandArgument='<%# "&Orgcode=" + Eval("Orgcode") %>'
                                        CommandName="Mod" />
                                </ItemTemplate>
                                <HeaderStyle />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            查無資料!!
                        </EmptyDataTemplate>
                        <PagerStyle HorizontalAlign="Right" />
                        <RowStyle CssClass="Row" />
                        <AlternatingRowStyle CssClass="AlternatingRow" />
                        <PagerSettings Position="TopAndBottom" />
                        <EmptyDataRowStyle CssClass="EmptyRow"/>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    <asp:Label ID="Label1" runat="server"></asp:Label>
</asp:Content>
