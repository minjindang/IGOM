<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SAL4104_01.aspx.vb" Inherits="SAL4104_01" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc1" %>
<%@ Register src="~/UControl/UcShowDate.ascx" tagname="UcShowDate" tagprefix="uc2" %>
<%@ Register src="~/UControl/UcShowTime.ascx" tagname="UcShowTime" tagprefix="uc3" %>
<%@ Register src="~/UControl/UcROCYear.ascx" tagname="UcROCYear" tagprefix="uc4" %>
<%@ Register src="~/UControl/UcROCYearMonth.ascx" tagname="UcROCYearMonth" tagprefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="TABLE1" runat="server" width="100%">
        <tr>
            <td align="left" style="height: 1px" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title" colspan="4">職等年功俸點對照表
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 110px; height: 19px;">官階</td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                             <asp:DropDownList ID="ddlJob_type" runat="server" AppendDataBoundItems="True"></asp:DropDownList>
                        </td>
                        <td class="htmltable_Left" style="width: 110px; height: 19px;">職等</td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                             <asp:DropDownList ID="ddlLevel_type" runat="server" AppendDataBoundItems="True"></asp:DropDownList>
                        </td>
                    </tr>
            
                    <tr>
                        <td align="center" colspan="4" class="TdHeightLight">
                            <asp:Button ID="btnQuery" runat="server" Text="查詢" UseSubmitBehavior="false" />
                            <asp:Button ID="btnNew" runat="server" Text="新增" />
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
                                    <asp:TemplateField HeaderText="項次">
                                        <ItemStyle HorizontalAlign="Center" Width="15px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lb_pyvtype" runat="server" Text='<%# (container.dataitemindex+1).tostring() %>'></asp:Label>
                                            <%--<asp:Label ID="lbid" runat="server" Text='<%# Eval("id")%>' Visible="false"></asp:Label>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="官階">
                                        <ItemStyle HorizontalAlign="Center"  />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"  />
                                        <ItemTemplate>
                                            <asp:Label ID="lbL3" runat="server" Text='<%# Eval("L3")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="職等代碼">
                                        <ItemStyle HorizontalAlign="Center"  />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"  />
                                        <ItemTemplate>
                                            <asp:Label ID="lbL1" runat="server" Text='<%# Eval("L1")%>'></asp:Label><br />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="俸點">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbPTB" runat="server" Text='<%# Eval("LEVCOM_PTB")%>'></asp:Label><br />
                                        </ItemTemplate>
                                    </asp:TemplateField>
               
                                    <asp:TemplateField HeaderText="年功俸">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                          <%--  <asp:Label ID="lbStatus" runat="server" Text='<%# IIf(Eval("Status") = "Y", "開放", "不開放")%>'></asp:Label>--%>
                                              <asp:Label ID="Label1" runat="server" Text='<%# Eval("L2")%>'></asp:Label>
                                         <asp:Label ID="lbL2" runat="server" Text='<%# Eval("LEVCOM_ORG_L2")%>' Visible="False"></asp:Label><br />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                       
                                    <asp:TemplateField HeaderText="維護">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Button ID="btnModify" runat="server" Text="修改" OnClick="btnModify_Click" />
                                            <asp:Button ID="btnDelete" runat="server" Text="刪除" OnClick="btnDelete_Click" />
                                           <%-- <asp:Label ID="lbLEVCOM_MDATE" runat="server" Text='<%# Eval("LEVCOM_MDATE")%>' Visible="false"></asp:Label>--%>
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
