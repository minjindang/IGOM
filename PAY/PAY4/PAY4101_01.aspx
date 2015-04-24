<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PAY4101_01.aspx.cs" Inherits="PAY_PAY4_PAY4101_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">審查收入類別設定-查詢
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">收入類別
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtExamineIncome_type" runat="server" Width="20px"></asp:TextBox>
                    <asp:DropDownList ID="ddlExamineIncome_type" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlExamineIncome_type_SelectedIndexChanged" > 
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <div align="center">
            <asp:Button ID="AddBtn" runat="server" Text="新增" OnClick="AddBtn_Click" />
            <asp:Button ID="QryBtn" runat="server" Text="查詢" OnClick="QryBtn_Click" />
            <asp:Button ID="ClrBtn" runat="server" Text="清空重填" OnClick="ClrBtn_Click" />
        </div>
        <div id="div1" runat="server" visible="false">
            <asp:GridView ID="GridViewA" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                PagerSettings-Visible="false" CellPadding="1" CellSpacing="1" BorderWidth="0px"
                Width="100%" OnRowCommand="GridViewA_RowCommand" OnPageIndexChanging="GridViewA_PageIndexChanging" OnPageIndexChanged="GridViewA_PageIndexChanged">
                <PagerSettings Visible="False" />
                <Columns>
                    <asp:BoundField DataField="ExamineIncome_type" HeaderText="審查收入代號" />
                    <asp:BoundField DataField="ExamineIncome_name" HeaderText="審查收入名稱" />
                    <asp:BoundField DataField="Unit" HeaderText="計費單位" />
                    <asp:BoundField DataField="UnitPrice_amt" HeaderText="計費單價" />
                    <asp:BoundField DataField="PaymentCode" HeaderText="收據字號" />
                    <asp:TemplateField HeaderText="維護">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Button ID="btn1" runat="server" Text="維護"
                                CommandArgument='<%# Eval("ExamineIncome_type")%>'
                                CommandName="Maintain" />
                            <asp:Button ID="btn2" CommandName="GoDelete"
                                runat="server" Text="刪除" OnClientClick="return confirm('是否確定要刪除?');"
                                CommandArgument='<%# Eval("ExamineIncome_type")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle CssClass="Row" />
                <HeaderStyle CssClass="Grid" />
                <AlternatingRowStyle CssClass="AlternatingRow" />
                <PagerSettings Position="TopAndBottom" />
                <EmptyDataRowStyle CssClass="EmptyRow" />
            </asp:GridView>
            <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="GridViewA"
                PNow="1" PSize="10" Visible="true" />
        </div>
    </div>

</asp:Content>

