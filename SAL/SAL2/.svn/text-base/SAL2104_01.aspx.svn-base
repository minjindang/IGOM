<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SAL2104_01.aspx.vb" Inherits="SAL2104_01" %>


<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <div runat="server" id="div1">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">薪資鎖定記錄查詢</td>
            </tr>
            <%--<tr>
                <td class="htmltable_Left">預算來源
                </td>
                <td class="htmltable_Right" style="width: 326px" colspan="3">
                    <uc1:ucSaCode ID="ddlcode_no" runat="server"  Code_sys="002" Code_Kind ="P" Code_type ="018"  ControlType ="DropDownList" />
                </td>
            </tr>--%>
            <tr>
                <td class="htmltable_Left">薪資鎖定年月</td>
                <td class="htmltable_Right" style="width: 326px">民國
                        <asp:DropDownList ID="DropDownList_year" runat="server" ></asp:DropDownList>年
                        <asp:DropDownList ID="DropDownList_month" runat="server">
                            <asp:ListItem Text="01" Value="01"></asp:ListItem>
                            <asp:ListItem Text="02" Value="02"></asp:ListItem>
                            <asp:ListItem Text="03" Value="03"></asp:ListItem>
                            <asp:ListItem Text="04" Value="04"></asp:ListItem>
                            <asp:ListItem Text="05" Value="05"></asp:ListItem>
                            <asp:ListItem Text="06" Value="06"></asp:ListItem>
                            <asp:ListItem Text="07" Value="07"></asp:ListItem>
                            <asp:ListItem Text="08" Value="08"></asp:ListItem>
                            <asp:ListItem Text="09" Value="09"></asp:ListItem>
                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                            <asp:ListItem Text="11" Value="11"></asp:ListItem>
                            <asp:ListItem Text="12" Value="12"></asp:ListItem>
                        </asp:DropDownList>月
                </td>
            </tr>
            <%--<tr>
                <td class="htmltable_Left">薪資項目</td>
                <td>
                    <uc1:ucSaCode ID="UcSaCode1" runat="server" Code_sys="003" Code_type="005" ControlType="DropDownList" ReturnEvent="true" />
                </td>
            </tr>--%>
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <asp:Button ID="btn_search" runat="server" Text="查詢" />
                    <%--<asp:Button ID="Button1" runat="server" Text="取消" />--%>
                </td>
            </tr>
        </table>
    </div>
                    <table id="tbq" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%"
                      visible="false" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title2" style="width: 100%" align="center">查詢結果
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%" class="TdHeightLight" valign="top">
                            <div runat="server" id="Div2">
                                <asp:GridView ID="GridView1" runat="server"
                                    AutoGenerateColumns="False" DataKeyNames="FREEZ_ORGID,FREEZ_YM,FREEZ_MUSER,FREEZ_MDATE"
                                    AllowPaging="True" PagerSettings-Visible="false"
                                    CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%">
                                    <PagerSettings Visible="False" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="鎖定年(月)">
                                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                                            <ItemStyle CssClass="col_1" />
                                            <ItemTemplate>
                                                <asp:Label ID="f_ym" runat="server" Text='<%# Eval("FREEZ_YM")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="預算來源">
                                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                                            <ItemStyle CssClass="col_1" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label_tabname3" runat="server" Text=''></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="計算項目">
                                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                                            <ItemStyle CssClass="col_1" />
                                            <ItemTemplate>
                                                <asp:Label ID="f_item_w" runat="server" Text=''></asp:Label>
                                                <asp:Label ID="f_item" runat="server" Text='<%# Eval("FREEZ_CODE_NO")%>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="鎖定時間">
                                            <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                                            <ItemStyle CssClass="col_1" />
                                            <ItemTemplate>
                                                <asp:Label ID="f_date" runat="server" Text='<%# Eval("FREEZ_MDATE") %>'></asp:Label>
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
                            </td>
                    </tr>
                    <tr>
                        <td align="right" class="TdHeightLight" style="width: 100%">
                            <uc1:Ucpager ID="Ucpager" runat="server" EnableViewState="true" GridName="GridView1"
                                PNow="1" PSize="30" Visible="true" />
                        </td>
                    </tr>
                </table>
</asp:Content>
