<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    EnableEventValidation="false"
    CodeFile="SAL1105_02.aspx.vb" Inherits="SAL1105_02" %>

<%@ Register Src="~/UControl/UcROCYear.ascx" TagName="UcROCYear" TagPrefix="uc2" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc3" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">健檢補助費申請</td>
            </tr>
            <tr>
                <td class="htmltable_Left">申請年度</td>
                <td class="htmltable_Right" style="width: 326px">
                    <uc2:UcROCYear ID="UcDate1" runat="server" />
                </td>
                <td class="htmltable_Left">申請金額</td>
                <td class="htmltable_Right" style="width: 326px">
                    <asp:DropDownList ID="ddlamt" runat="server"
                        AutoPostBack="true" Enabled="false">
                        <asp:ListItem Text="3500" Value="3500"></asp:ListItem>
                        <asp:ListItem Text="14000" Value="14000"></asp:ListItem>
                    </asp:DropDownList>元
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">健檢日期</td>
                <td colspan="3">
                    <uc3:UcDate ID="UcDate2" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <asp:Button ID="btn_search" runat="server" Text="查詢" Visible="false" />
                    <asp:Button ID="btn_submit" runat="server" Text="送出申請" />
                    <asp:Button ID="btn_print" runat="server" Text="列印"   />
                </td>
            </tr>
        </table>
    </div>
    <div id="div1" runat="server" >
        <asp:GridView ID="gvList" runat="server"
            AutoGenerateColumns="False" DataKeyNames=""
            AllowPaging="True" PagerSettings-Visible="false"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%">
            <PagerSettings Visible="False" />
            <Columns>
                <asp:TemplateField HeaderText="姓名">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname1" runat="server" Text='<%# Eval("BASE_NAME")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="單位名稱">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabid" runat="server" Text='<%# Eval("UPORG_TABID") %>'></asp:Label>
                        <asp:Label ID="Label_tabtype" runat="server" Text='<%# Eval("UPTCL_TYPE") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="人員類別">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname2" runat="server" Text='<%# Eval("UPTCL_TABNAME2") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="申請年度">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname3" runat="server" Text='<%# Eval("Apply_yy")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
<%--                <asp:TemplateField HeaderText="申請日期">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname4" runat="server" Text='<%# Eval("UPTCL_TABNAME4")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="健檢日期">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname5" runat="server" Text='<%# Eval("Check_date")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="申請金額">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname6" runat="server" Text='<%# Eval("Apply_amt")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
<%--                <asp:TemplateField HeaderText="上次申請年度">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname7" runat="server" Text='<%# Eval("UPTCL_TABNAME7")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="查詢結果" Visible="false">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" Width="25%" HorizontalAlign="Center" />
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
