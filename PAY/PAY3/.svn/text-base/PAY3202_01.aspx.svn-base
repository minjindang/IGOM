<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="PAY3202_01.aspx.vb" Inherits="PAY_PAY3_PAY3202_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">審查收入付款人維護作業
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">付款人編號
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtPayer_id" runat="server"></asp:TextBox>
<%--                 <asp:RegularExpressionValidator runat="server" ID="REV1" ControlToValidate="txtPayer_id"
                    ValidationExpression="^\d+?$" ErrorMessage="只能輸入數字!!" />--%>
            </td>
            <td class="htmltable_Left">付款人名稱
            </td>
            <td style="width: 326px">
                <asp:TextBox ID="txtPayer_name" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div align="center">
        <asp:Button ID="AddBtn" runat="server" Text="新增" />
        <asp:Button ID="QryBtn" runat="server" Text="查詢" />
        <asp:Button ID="ResetBtn" runat="server" Text="清空重填" />
    </div>
    <div id="div1" runat="server" visible="false">
        <asp:GridView ID="GridViewA" runat="server"
            AutoGenerateColumns="False"
            AllowPaging="True" PagerSettings-Visible="false"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%">
            <PagerSettings Visible="false" />
            <Columns>
                <asp:BoundField DataField="Payer_id" HeaderText="付款人代號" />
                <asp:BoundField DataField="Payer_name" HeaderText="付款人名稱" />
                <asp:BoundField DataField="Mod_date" HeaderText="異動日期" />
                <asp:TemplateField HeaderText="維護">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Button ID="btn1" runat="server" Text="維護"
                            CommandArgument='<%# Eval("Payer_id") %>'
                            CommandName="Maintain" />
                        <asp:Button ID="btn2" CommandName="GoDelete"
                            runat="server" Text="刪除" OnClientClick="return confirm('是否確定要刪除?');"
                            CommandArgument='<%# Eval("Payer_id")%>' />
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
        <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="GridViewA"
            PNow="1" PSize="10" Visible="true" />
    </div>
</asp:Content>

