<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SAL3103_01.aspx.vb" Inherits="SAL3103_01"  %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">自訂薪資項目維護
            </td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="2">查詢條件
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">加/減項
            </td>
            <td class="TdHeightLight">
                 <asp:DropDownList ID="DropDownList_Operation" runat="server" AutoPostBack="true">
                     <asp:ListItem Value="" Text="---全部---"></asp:ListItem>
                     <asp:ListItem Value="+" Text="應發項"></asp:ListItem>
                     <asp:ListItem Value="-" Text="應扣項"></asp:ListItem>
                 </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">項目類別
            </td>
            <td class="TdHeightLight">
                <asp:DropDownList ID="DropDownList_Code" runat="server" DataTextField="CODE_DESC1" DataValueField="CODE_NO">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 120px">查詢隱藏項目
            </td>
            <td class="TdHeightLight">
                  <%--<asp:DropDownList ID="DropDownList_Suspend" runat="server">
                      <asp:ListItem Value="N" Text="隱藏註記" Selected="true"></asp:ListItem>
                      <asp:ListItem Value="Y" Text="顯示全部"></asp:ListItem>
                  </asp:DropDownList>--%>
                <asp:CheckBox ID="cbSuspend" runat="server" />查詢隱藏項目
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 17px" class="TdHeightLight">
                <asp:Button ID="btnQuery" runat="server" Text="查詢" /><input id="Reset2" type="button"
                    value="重填" /><asp:Button ID="btnNew" runat="server" Text="新增" />
            </td>
        </tr>
    </table>
<br />
    <table id="dataList" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" visible="false" >
        <tr>
            <td class="htmltable_Title2" style="width: 100%" align="center">
                查詢結果
            </td>
        </tr>
        <tr>
            <td style="width: 100%" class="TdHeightLight" valign="top">
                <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30"
                    BorderWidth="0px" CssClass="Grid" PagerStyle-HorizontalAlign="Right" Width="100%"
                    EmptyDataText="查無資料!!">
                    <Columns>
                        <asp:TemplateField HeaderText="項目種類">
                            <ItemTemplate>
                                <asp:Label ID="Label_item_desc" runat="server" Text='<%# Eval("item_desc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="明細名稱">
                            <ItemTemplate>
                                (<asp:Label ID="Label_item_code" runat="server" Text='<%# Eval("Item_Code") %>'></asp:Label>)<br />
                                <asp:Label ID="Label_item_name" runat="server" Text='<%# Eval("Item_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="加/減項">
                            <ItemTemplate>
                                <asp:Label ID="Label_operate_name" runat="server" Text='<%# Eval("Operation_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="所得種類">
                            <ItemTemplate>
                                <asp:Label ID="Label_icode_name" runat="server" Text='<%# Eval("Icode_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="扣繳稅額">
                            <ItemTemplate>
                                <asp:Label ID="Label_tax_name" runat="server" Text='<%# Eval("Tax_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="隨薪發放">
                            <ItemTemplate>
                                <asp:Label ID="Label_type_name" runat="server" Text='<%# Eval("Type_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="納入薪資所得稅額">
                            <ItemTemplate>
                                <asp:Label ID="Label_add_inco" runat="server" Text='<%# Eval("add_inco") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="維護">
                            <ItemTemplate>
                                <asp:Button ID="btnUpdate" runat="server" Text="修改" OnClick="btnUpdate_Click" />
                                <%--<asp:Button ID="btnDel" runat="server" Text="刪除註記" OnClick="btnDel_Click" OnClientClick="return confirm('確定刪除註記??')" Visible='<%# Eval("Show_Del") %>' />
                                <asp:Button ID="btnDeleteBatch" runat="server" Text="刪除金額" OnClick="btnDeleteBatch_Click" />--%>
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
        <tr>
            <td align="right" class="TdHeightLight" style="width: 100%">
                <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="gvList"
                    PNow="1" PSize="30" Visible="false" />
            </td>
        </tr>
    </table>
</asp:Content>

