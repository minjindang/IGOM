<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" EnableEventValidation="false"
    CodeFile="SAL1102_02.aspx.vb" Inherits="SAL1102_02" %>

<%@ Register Src="~/UControl/UcROCYearMonth.ascx" TagName="UcROCYearMonth" TagPrefix="uc2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">值班費申請</td>
            </tr>
            <tr>
                <td class="htmltable_Left">申請年月</td>
                <td>
                    <uc2:UcROCYearMonth ID="UcDate1" runat="server" />
                </td>
            </tr>

            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <asp:Button ID="btn_search" runat="server" Text="查詢" />
                    <asp:Button ID="btn_submit" runat="server" Text="送出申請" />
                </td>
            </tr>
        </table>
    </div>
    <div id="div1" runat="server">
        <asp:GridView ID="gvList" runat="server"
            AutoGenerateColumns="False" DataKeyNames=""
            AllowPaging="True" PagerSettings-Visible="false"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%">
            <PagerSettings Visible="False" />
            <Columns>
                <asp:TemplateField HeaderText="單位">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="lbDepart_name" runat="server" Text='<%# Eval("depart_name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="姓名">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="lbUser_name" runat="server" Text='<%# Eval("User_name")%>'></asp:Label>
                        <asp:HiddenField ID="hfId_card" runat="server" Value='<%# Eval("Id_card")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="值班日期">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="lbSche_date" runat="server" Text='<%# Eval("Sche_date")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="值班起時">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="lbStart_time" runat="server" Text='<%# Eval("Start_time")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="值班迄時">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="lbEnd_time" runat="server" Text='<%# Eval("End_time")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="值班時數">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="lbhours" runat="server" Text='<%# Eval("hours")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="已領/已休時數">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="lbhours" runat="server" Text='<%# Eval("Pay_hours")%>'></asp:Label> / <asp:Label ID="Label1" runat="server" Text='<%# Eval("Rest_hours")%>'></asp:Label>
                        <asp:HiddenField ID="hfusedhours" runat ="server" value='<%# Eval("Used_hours")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="請領值班費時數">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Textbox ID="lbhours2" runat="server" AutoPostBack ="true" OnTextChanged ="lbhours2_TextChanged" Text="0"></asp:Textbox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="值班費金額">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="lbamt" Width="77px" runat="server" Text='<%# Eval("amt")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="備註" Visible="true">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:TextBox runat="server" AutoPostBack="true" Width="150px" ID="txtmemo" MaxLength="50" Text='<%# Eval("memo")%>'></asp:TextBox>
                        <%--<asp:Label ID="Label_tabname9" runat="server" Text='<%# Eval("UPTCL_TABNAME9")%>'></asp:Label>--%>
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
</asp:Content>
