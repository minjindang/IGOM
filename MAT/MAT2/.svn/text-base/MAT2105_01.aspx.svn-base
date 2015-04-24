<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    EnableEventValidation="false"
    CodeFile="MAT2105_01.aspx.vb" Inherits="MAT2105_01" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%" runat="server">
            <tr>
                <td class="htmltable_Title" colspan="4">低於安全庫存量物品報表</td>
            </tr>
        </table>
        <div id="div1" runat="server" visible="false">
            <asp:GridView ID="GridViewA" runat="server"
                AutoGenerateColumns="False"
                AllowPaging="True" PagerSettings-Visible="false"
                CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無資料!" PageSize="25">
                <PagerSettings Visible="False" />
                <Columns>
                    <asp:TemplateField HeaderText="物品編號">
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:Label ID="Material_id" runat="server" Text='<%# Eval("Material_id")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="物品名稱">
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:Label ID="Material_name" runat="server" Text='<%# Eval("Material_name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="單位">
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:Label ID="Unit" runat="server" Text='<%# Eval("Unit")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="可用餘額">
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:Label ID="Available_cnt" runat="server" Text='<%# Eval("Available_cnt")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="安全庫存量">
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:Label ID="Safe_cnt" runat="server" Text='<%# Eval("Safe_cnt")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle CssClass="Row" />
                <HeaderStyle CssClass="Grid" />
                <AlternatingRowStyle CssClass="AlternatingRow" />
                <PagerSettings Position="TopAndBottom" />
                <EmptyDataRowStyle CssClass="EmptyRow" />
            </asp:GridView>
        </div>
    </div>

</asp:Content>
