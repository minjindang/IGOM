<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC4102_02.aspx.vb" Inherits="FSC4102_02" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table id="TABLE2" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%"
        class="tableStyle99">
        <tr>
            <td class="htmltable_Title2" style="width: 100%" align="center">
                表單通知人員設定
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnToFSC4102_01" runat="server" CausesValidation="False" Text="E-mail管理員設定" />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderWidth="0px" 
                    CssClass="Grid" PagerStyle-HorizontalAlign="Right" Width="100%"
                    EmptyDataText="查無資料">
                    <Columns>
                        <asp:BoundField DataField="num" HeaderText="項次" ItemStyle-Width="100px" HeaderStyle-Width="100px" />
                        <asp:BoundField DataField="Leave_name" HeaderText="差假別" />
                        <asp:BoundField DataField="User_names" HeaderText="收件人" />
                        <asp:TemplateField HeaderText="維護">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" CommandArgument='<%# Eval("Leave_type") & ","  &  Eval("Leave_name") %>'
                                    CommandName="Modify" Text="修改" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                    <EmptyDataTemplate>
                        查無資料!!
                    </EmptyDataTemplate>
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                </asp:GridView>
            </td>
        </tr>
    </table>
            
</asp:Content>
