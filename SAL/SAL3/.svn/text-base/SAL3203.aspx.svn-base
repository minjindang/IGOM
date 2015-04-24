<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    EnableEventValidation="false"
    CodeFile="SAL3203.aspx.vb" Inherits="SAL_SAL3203" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%@ Register Src="~/UControl/UcPager.ascx" TagName="UcPager" TagPrefix="uc1" %>
<%@ Register src="~/UControl/SAL/ucSaCode.ascx" tagname="ucSaCode" tagprefix="uc2" %>
<%@ Register src="~/UControl/SAL/UcReset.ascx" tagname="UcReset" tagprefix="uc3" %>
<%@ Register src="~/UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc4" %>
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">短程車費申請</td>
        </tr>
        <tr>
            <td class="htmltable_Left">事由</td>
            <td style="width: 326px" colspan="3">
              <asp:TextBox ID="Apply_desc" runat="server" Text="" Width="1000px" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">乘車日期</td>
            <td style="width: 326px">
                <uc4:UcDate ID="Cost_date" runat="server" />
            </td>
            
            <td class="htmltable_Left">申請車資</td>
            <td style="width: 326px">
                <asp:TextBox ID="Apply_amt" runat="server" Width="70" Text=""></asp:TextBox></td>
        </tr>
        <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%">
                    <asp:Button ID="SelectBtn" runat="server" Text="查詢(依乘車日期)"/>
                    <asp:Button ID="InsertBtn" runat="server" Text="新增"/>
                    <asp:Button ID="SubmitBtn" runat="server" Text="送出申請" />
                    <asp:Button ID="PrintBtn" runat="server" Text="列印" />
                    <asp:Button ID="ResetBtn" runat="server" Text="清空重填"/>
                </td>
            </tr>        
    </table>
    <div id="div1" runat="server" visible="false">
            <asp:GridView ID="GridViewA" runat="server"
                AutoGenerateColumns="False"
                AllowPaging="True" PagerSettings-Visible="false"
                CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無資料!" 
                >
                <PagerSettings Visible="False" />
                <Columns>
                    <asp:TemplateField HeaderText="案件編號">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Label ID="Flow_id" runat="server" Text='<%# Eval("Flow_id")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="單位別">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Label ID="Depart_name" runat="server" Enabled="false" Text='<%# Eval("Depart_name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="人員類別">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Label ID="PEMEMCOD" runat="server" Enabled="false" Text='<%# Eval("PEMEMCOD")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="姓名">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Label ID="User_name" runat="server" Enabled="false" Text='<%# Eval("User_name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="事由">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Label ID="Apply_desc" runat="server" Enabled="false" Text='<%# Eval("Apply_desc")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="乘車日期">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:textbox ID="Cost_date" runat="server" Enabled="false" MaxLength="7" Text='<%# Eval("Cost_date")%>'></asp:textbox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="申請車資">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:textbox ID="Apply_amt" runat="server" Enabled="false" Text='<%# Eval("Apply_amt")%>'></asp:textbox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="維護">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Button ID="StoreButton" runat="server" Text="儲存" CommandName="StoreButton" Visible="false" CommandArgument="StoreButton"/>
                            <asp:Button ID="EditorButton" runat="server" Text="維護" CommandName="EditorButton" CommandArgument="EditorButton"/>
                            <asp:Button ID="DeleteButton" runat="server" Text="刪除" CommandName="DeleteButton" CommandArgument="DeleteButton" Visible="True" OnClientClick="return confirm('確認要刪除嗎？');"/>
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
    <div id="div2" runat="server" visible="false">
            <asp:GridView ID="GridViewB" runat="server"
                AutoGenerateColumns="False"
                AllowPaging="True" PagerSettings-Visible="false"
                CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無資料!">
                <PagerSettings Visible="False" />
                <Columns>
                    <asp:TemplateField HeaderText="案件編號">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:CheckBox ID="Flow_idCheckBox" runat="server" CommandName="Flow_idCheckBox" OnCheckedChanged="Flow_idCheckBox_CheckedChanged"/>
                            <asp:Label ID="Flow_id" runat="server" Text='<%# Eval("Flow_id")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="單位別">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Label ID="Depart_name" runat="server" Enabled="false" Text='<%# Eval("Depart_name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="人員類別">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Label ID="PEMEMCOD" runat="server" Enabled="false" Text='<%# Eval("PEMEMCOD")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="姓名">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Label ID="User_name" runat="server" Enabled="false" Text='<%# Eval("User_name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="事由">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Label ID="Apply_desc" runat="server" Enabled="false" Text='<%# Eval("Apply_desc")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="乘車日期">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Label ID="Cost_date" runat="server" Enabled="false" Text='<%# Eval("Cost_date")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="申請車資">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Label ID="Apply_amt" runat="server" Enabled="false" Text='<%# Eval("Apply_amt")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle CssClass="Row" />
                <HeaderStyle CssClass="Grid" />
                <AlternatingRowStyle CssClass="AlternatingRow" />
                <PagerSettings Position="TopAndBottom" />
                <EmptyDataRowStyle CssClass="EmptyRow" />
            </asp:GridView>
        <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="GridViewB"
                    PNow="1" PSize="25" Visible="true" />
        </div>
</asp:Content>
