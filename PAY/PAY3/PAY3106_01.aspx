<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="PAY3106_01.aspx.vb" Inherits="PAY_PAY3_PAY3106_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">銀行基本資料維護
            </td>
        </tr>
         <tr>
            <td class="htmltable_Left">銀行代碼
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtBank_id" runat="server"></asp:TextBox>
            </td>
            <td class="htmltable_Left">銀行簡稱
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtBankAbbreviation_name" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">銀行名稱
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtBank_name" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div align="center">
        <asp:Button ID="AddBtn" runat="server" Text="新增" />
        <asp:Button ID="QryBtn" runat="server" Text="查詢" />
        <asp:Button ID="ResetBtn" runat="server" Text="清空重填" />
    </div>
    <table id="div1" runat="server" visible="false" width="100%" class="tableStyle99">
        <tr>
            <td>
            <asp:GridView ID="GridViewA" runat="server"
                AutoGenerateColumns="False"
                AllowPaging="True" CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無資料!!">
                <Columns>
                    <asp:BoundField DataField="Bank_id" HeaderText="銀行代碼" />
                    <asp:BoundField DataField="BankAbbreviation_name" HeaderText="銀行簡稱" />
                    <asp:BoundField DataField="Bank_name" HeaderText="銀行名稱" />
                    <asp:TemplateField HeaderText="維護">
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:Button ID="btn1" runat="server" Text="維護"
                                CommandArgument='<%# Eval("Bank_id")%>'
                                CommandName="Maintain" />
                            <asp:Button ID="btn2" CommandName="GoDelete"
                                runat="server" Text="刪除" OnClientClick="return confirm('是否確定要刪除?');"
                                CommandArgument='<%# Eval("Bank_id")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                              <EmptyDataTemplate>
                           查無資料!!
                     </EmptyDataTemplate>
                <RowStyle CssClass="Row" />
                <HeaderStyle CssClass="Grid" />
                <AlternatingRowStyle CssClass="AlternatingRow" />
                <PagerSettings Position="TopAndBottom" />
                <EmptyDataRowStyle CssClass="EmptyRow" />
            </asp:GridView>
            </td>
        </tr>
    </table>        
    <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="GridViewA"
        PNow="1" PSize="10" Visible="true" />
</asp:Content>

