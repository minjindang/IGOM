<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    EnableEventValidation="false" CodeFile="SAL2102_01.aspx.vb" Inherits="SAL_SAL2102_01" %>

<%@ Register Src="~/UControl/UcPager.ascx" TagName="UcPager" TagPrefix="uc1" %>
<%@ Register Src="~/UControl/UcROCYear.ascx" TagName="UcROCYear" TagPrefix="uc14" %>
<%@ Register Src="~/UControl/FSC/UcMember.ascx" TagPrefix="uc1" TagName="UcMember" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc1" TagName="UcDDLMember" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="5">
                勞/健、公/健保繳納證明列印
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                申請年度
            </td>
            <td style="width: 326px" colspan="4">
                <uc14:UcROCYear ID="UcROCYear" runat="server" />
            </td>
        </tr>
        <%--新增人員 區塊--%>
        <tr runat="server" visible="false" id="InsertTr">
            <td class="htmltable_Left">
                新增人員
            </td>
            <td style="width: 326px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlDepart" runat="server" AutoPostBack="true" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlname" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlDepart" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Button ID="InsertBtn" Text="列印" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                繳納證明種類
            </td>
            <td style="width: 326px" colspan="4">
                <asp:RadioButtonList ID="rblPAYOD_CODE" runat="server" RepeatColumns="2">
                    <asp:ListItem Value="002" Selected="True">勞/健</asp:ListItem>
                    <asp:ListItem Value="001">公/健</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                員工姓名
            </td>
            <td style="width: 326px" colspan="4">
                <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
                <uc1:UcDDLMember runat="server" ID="UcDDLMember" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="5" style="border-top: none;" width="50%">
                <asp:Button ID="SelectBtn" runat="server" Text="查詢" />
                <asp:Button ID="ResetBtn" runat="server" Text="清空重填" Visible="false" />
                <asp:Button ID="InsertBtnVisible" runat="server" Text="新增人員" Visible="false" />
                <asp:Button ID="PrintBtn" runat="server" Text="列印" />
            </td>
        </tr>
    </table>
    <table id="tbq" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%"
        visible="false" class="tableStyle99">
        <tr>
            <td class="htmltable_Title2" style="width: 100%" align="center">
                查詢結果
            </td>
        </tr>
        <tr>
            <td style="width: 100%" class="TdHeightLight" valign="top">
                <asp:GridView ID="GridViewA" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                    PageSize="30" CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%"
                    EmptyDataText="查無資料!">
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle />
                            <ItemTemplate>
                                <asp:Label ID="No" runat="server" Text='<%# Eval("No")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單位別">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle />
                            <ItemTemplate>
                                <asp:Label ID="Depart_name" runat="server" Enabled="false" Text='<%# Eval("Depart_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="人員姓名">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle />
                            <ItemTemplate>
                                <asp:Label ID="User_name" runat="server" Enabled="false" Text='<%# Eval("User_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="員工編號">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle />
                            <ItemTemplate>
                                <asp:Label ID="User_id" runat="server" Enabled="false" Text='<%# Eval("id_card")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lbPAYOD_CODE" runat="server" Text='<%# IIf(rblPAYOD_CODE.SelectedValue = "001", "公保", "勞保")%>' />
                            </HeaderTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle />
                            <ItemTemplate>
                                <asp:Label ID="PAYOD_AMT" runat="server" Enabled="false" Text='<%# Eval("PAYOD_AMT")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="健保">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle />
                            <ItemTemplate>
                                <asp:Label ID="family_amt" runat="server" Enabled="false" Text='<%# Eval("family_amt")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="維護" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle />
                            <ItemTemplate>
                                <asp:Button ID="RowPrintBtn" runat="server" Text="列印" CommandName="RowPrintBtn" Visible="true"
                                    CommandArgument="RowPrintBtn" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="Row" />
                    <HeaderStyle CssClass="Grid" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle CssClass="EmptyRow" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right" class="TdHeightLight" style="width: 100%">
                <uc1:UcPager ID="Ucpager1" runat="server" EnableViewState="true" GridName="GridViewA"
                    PNow="1" PSize="30" Visible="true" />
            </td>
        </tr>
    </table>
    <%--<div id="div2" runat="server" visible="false">
            <asp:GridView ID="GridViewB" runat="server"
                AutoGenerateColumns="False"
                AllowPaging="True" PagerSettings-Visible="false"
                CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無資料!">
                <PagerSettings Visible="False" />
                <Columns>
                    <asp:TemplateField HeaderText="案件編號">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle />
                        <ItemTemplate>
                            <asp:CheckBox ID="Flow_idCheckBox" runat="server" CommandName="Flow_idCheckBox" OnCheckedChanged="Flow_idCheckBox_CheckedChanged" AutoPostBack="true"/>
                            <asp:Label ID="Flow_id" runat="server" Text='<%# Eval("Flow_id")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="單位別">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle />
                        <ItemTemplate>
                            <asp:Label ID="Depart_name" runat="server" Enabled="false" Text='<%# Eval("Depart_name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="人員類別">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle />
                        <ItemTemplate>
                            <asp:Label ID="PEMEMCOD" runat="server" Enabled="false" Text='<%# Eval("PEMEMCOD")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="姓名">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle />
                        <ItemTemplate>
                            <asp:Label ID="User_name" runat="server" Enabled="false" Text='<%# Eval("User_name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="事由">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle />
                        <ItemTemplate>
                            <asp:Label ID="Apply_desc" runat="server" Enabled="false" Text='<%# Eval("Apply_desc")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="乘車日期">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle />
                        <ItemTemplate>
                            <asp:Label ID="Cost_date" runat="server" Enabled="false" Text='<%# Eval("Cost_date")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="申請車資">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle />
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
        </div>--%>
</asp:Content>
