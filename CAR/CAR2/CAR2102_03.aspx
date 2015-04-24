<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="CAR2102_03.aspx.cs" Inherits="CAR_CAR2_CAR2102_03" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="2">明細表
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 96px">車牌
            </td>
            <td>
                <asp:Label ID="lbCar_id" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 96px">派車日期起迄
            </td>
            <td>
                <asp:Label ID="lbStart_date" runat="server" />~<asp:Label ID="lbEnd_date" runat="server" />
            </td>
        </tr>
    </table>
    <asp:Button ID="cbBack" runat="server" Text="回上頁" OnClick="cbBack_Click" />
        <asp:GridView ID="GridViewA" runat="server"
            AutoGenerateColumns="False"
            AllowPaging="True" PagerSettings-Visible="false"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" PageSize="25" EmptyDataText="查無資料!">
            <PagerSettings Visible="False" />
            <Columns>
                <asp:TemplateField HeaderText="日期">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname2" runat="server" Text='<%# Eval("DATES")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="時間">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname3" runat="server" Text='<%# Eval("TIMES")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="預約者">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname4" runat="server" Text='<%# Eval("u1")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="用車人代表">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname5" runat="server" Text='<%# Eval("car_delegate")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="駕駛">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname6" runat="server" Text='<%# Eval("u2")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="標題">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname7" runat="server" Text='<%# Eval("Reason_desc")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="到達地點">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname8" runat="server" Text='<%# Eval("Destination_desc")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="Row" />
            <HeaderStyle CssClass="Grid" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle CssClass="EmptyRow" />
        </asp:GridView>
        <uc1:Ucpager ID="Ucpager2" runat="server"  EnableViewState="true" GridName="GridViewA"
            PNow="1" PSize="25" Visible="true"/>
    
</asp:Content>
