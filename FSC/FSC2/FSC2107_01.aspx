<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC2107_01.aspx.vb" Inherits="FSC2107_01" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagName="UcDDLDepart" TagPrefix="uc1" %>

<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register src="~/UControl/UcShowDate.ascx" tagname="UcShowDate" tagprefix="uc3" %>
<%@ Register src="~/UControl/UcShowTime.ascx" tagname="UcShowTime" tagprefix="uc4" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc6" TagName="UcDDLMember" %>
<%@ Register Src="~/UControl/FSC/UcAuthorityMember.ascx" TagPrefix="uc1" TagName="UcAuthorityMember" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="TABLE1" runat="server" width="100%">
        <tr>
            <td align="left" style="height: 1px" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title" colspan="4">刷卡補登查詢
                        </td>
                    </tr>
                    <tr id="tr0" runat="server">
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">單位別
                        </td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                            <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px">員工姓名</td>
                        <td class="htmltable_Right" style="width: 250px">
                            <uc6:UcDDLMember runat="server" ID="UcDDLMember" />
                        </td>
                    </tr>
                    <tr id="tr1" runat="server">
                        <td class="htmltable_Left" style="width: 100px">員工編號</td>
                        <td class="htmltable_Right">
                            <uc1:UcAuthorityMember runat="server" ID="UcAuthorityMember" />
                        </td>
                    </tr>
                    <tr id="tr2" runat="server">
                        <td class="htmltable_Left" style="width: 120px; height: 26px;">在職狀態</td>
                        <td class="htmltable_Right" style="height: 26px">
                            <asp:DropDownList ID="ddlQuit_Job" runat="server" AppendDataBoundItems="True">
                                <asp:ListItem Value="N" Text="現職員工"></asp:ListItem>
                                <asp:ListItem Value="Y" Text="離職員工"></asp:ListItem>
                                <asp:ListItem Value="1" Text="留職停薪"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px"><span style="color: Red">*</span>
                            刷卡日期
                        </td>
                        <td class="TdHeightLight" style="width: 850px" colspan="3">
                            <uc2:UcDate ID="UcDate1" runat="server"></uc2:UcDate>
                            <uc2:UcDate ID="UcDate2" runat="server"></uc2:UcDate>
                            <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※填寫範例:101/01/01"></asp:Label>
                        </td>
                    </tr>
                    <tr id="tr3" runat="server">
                        <td class="htmltable_Left" style="width: 100px">人員類別
                        </td>
                        <td class="htmltable_Right" style="height: 26px">
                            <asp:DropDownList ID="ddlEmployeetype" runat="server" AppendDataBoundItems="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="tr4" runat="server">
                        <td class="htmltable_Left" style="width: 100px">狀態</td>
                        <td class="htmltable_Right">
                            <asp:CheckBoxList ID="cblStatus" runat="server" DataTextField="code_desc1" DataValueField="code_no" RepeatColumns="5" />
                        </td>

                    </tr>
                    <tr>
                        <td align="center" colspan="4" class="TdHeightLight">
                            <asp:Button ID="btnQuery" runat="server" Text="查詢" UseSubmitBehavior="false" />
                            <input id="Reset" type="button" value="重填" runat="server"  Visible="false"/>
                            <asp:Button ID="btnPrint" runat="server" Enabled="false" Text="匯出EXCEL" />
                        </td>
                    </tr>

                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 358px" valign="top">
                <table id="tbq" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%"
                    visible="false" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title2" style="width: 100%" align="center">查詢結果
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%" class="TdHeightLight" valign="top">
                            <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="false" BorderWidth="0px" PageSize="30"
                                AllowPaging="true" CssClass="Grid" PagerStyle-HorizontalAlign="right" Width="100%"
                                EmptyDataText="查無資料!!">
                                <Columns>
                                    <asp:TemplateField HeaderText="編號">
                                        <ItemStyle HorizontalAlign="Center"  />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lb_pyvtype" runat="server" Text='<%# (container.dataitemindex+1).tostring() %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="狀態">
                                        <ItemStyle HorizontalAlign="Center"  />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbCase_status" runat="server" Text='<%# Eval("Case_status")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="單位名稱">
                                        <ItemStyle HorizontalAlign="Center"  />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbDepart_name" runat="server" Text='<%# Eval("Depart_name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="員工編號">
                                        <ItemStyle HorizontalAlign="Center"  />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbApply_idcard" runat="server" Text='<%# Eval("Apply_idcard")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="員工姓名">
                                        <ItemStyle HorizontalAlign="Center" Width="85px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbApply_name" runat="server" Text='<%# Eval("Apply_name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="刷卡補登日期">
                                        <ItemStyle HorizontalAlign="Center"  />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <uc3:UcShowDate ID="UcShowDate2" runat="server" Text='<%# Eval("Forgot_date")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="刷卡補登時間">
                                        <ItemStyle HorizontalAlign="Center"  />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <uc4:UcShowTime ID="UcShowTime1" runat="server" Text='<%# Eval("Forgot_time")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="直屬主管">
                                        <ItemStyle HorizontalAlign="Center"  />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbBossname" runat="server" Text='<%# Eval("Bossname")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="簽核流程">
                                        <ItemStyle HorizontalAlign="Center" Width="145px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbLast_name" runat="server" Text='<%# Bind("Process")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="卡別">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbCard_type" runat="server" Text='<%# Eval("Card_type")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="補登事由">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbReason" runat="server" Text='<%# Eval("Reason")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="核准日期">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbChange_date" runat="server" Text='<%# Eval("Change_date")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle HorizontalAlign="Right" />
                                <EmptyDataTemplate>
                                    查無資料!!
                                </EmptyDataTemplate>
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
                            <uc1:Ucpager ID="Ucpager" runat="server" EnableViewState="true" GridName="gvlist"
                                PNow="1" PSize="30" Visible="true" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
