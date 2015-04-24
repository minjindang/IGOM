<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC2104_01.aspx.vb" Inherits="FSC2104_01" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register src="~/UControl/UcShowDate.ascx" tagname="UcShowDate" tagprefix="uc3" %>
<%@ Register src="~/UControl/UcShowTime.ascx" tagname="UcShowTime" tagprefix="uc4" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc6" TagName="UcDDLMember" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="TABLE1" runat="server" width="100%">
        <tr>
            <td align="left" style="height: 1px" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title" colspan="4">公差紀錄查詢
                        </td>
                    </tr>
                    <tr id="tr0" runat="server">
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">單位別
                        </td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                            <uc1:ucddldepart runat="server" id="UcDDLDepart" />
                        </td>

                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px">員工姓名</td>
                        <td class="htmltable_Right" style="width: 250px">
                            <uc6:ucddlmember runat="server" id="UcDDLMember" />
                        </td>
                    </tr>
                    <tr id="tr1" runat="server">
                        <td class="htmltable_Left" style="width: 100px">員工編號</td>
                        <td class="htmltable_Right">
                            <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr id="tr2" runat="server">
                        <td class="htmltable_Left" style="width: 120px; height: 26px;">在職狀態</td>
                        <td class="htmltable_Right" style="height: 26px">
                            <asp:DropDownList ID="ddQuit_Job" runat="server" AppendDataBoundItems="True">
                                <asp:ListItem Value="N" Text="現職員工"></asp:ListItem>
                                <asp:ListItem Value="Y" Text="離職員工"></asp:ListItem>
                                <asp:ListItem Value="1" Text="留職停薪"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="tr3" runat="server">
                        <td class="htmltable_Left" style="width: 100px">性別
                        </td>
                        <td class="htmltable_Right" style="height: 26px">
                            <asp:DropDownList ID="ddlsextype" runat="server" AppendDataBoundItems="True">
                                <asp:ListItem Value="" Text="請選擇"></asp:ListItem>
                                <asp:ListItem Value="1" Text="男"></asp:ListItem>
                                <asp:ListItem Value="0" Text="女"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px"><span style="color: Red">*</span>
                            公差日期
                        </td>
                        <td class="TdHeightLight" style="width: 850px" colspan="3">
                            <uc2:ucdate id="UcDate1" runat="server"></uc2:ucdate>
                            <uc2:ucdate id="UcDate2" runat="server"></uc2:ucdate>
                            <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※填寫範例:101/01/01"></asp:Label>
                        </td>
                    </tr>
                    <tr id="tr4" runat="server">
                        <td class="htmltable_Left" style="width: 120px">公差類別
                        </td>
                        <td class="htmltable_Right" style="width: 230px">
                            <asp:DropDownList ID="ddlLocationFlag" runat="server" AutoPostBack="True">
                                <asp:ListItem Value="" Text="--請選擇--"></asp:ListItem>
                                <asp:ListItem Value="0" Text="國內"></asp:ListItem>
                                <asp:ListItem Value="1" Text="國外"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="tr5" runat="server">
                        <td class="htmltable_Left" style="width: 100px">狀態</td>
                        <td class="htmltable_Right">
                            <asp:CheckBoxList ID="cblStatus" runat="server" DataTextField="code_desc1" DataValueField="code_no" RepeatColumns="5" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" class="TdHeightLight">
                            <asp:Button ID="btnQuery" runat="server" Text="查詢" UseSubmitBehavior="false" />
                            <input id="Reset" type="button" value="重填" runat="server"  Visible="false"/>
                            <asp:Button ID="btnPrint" runat="server" Enabled="false" Text="匯出" />
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
                                        <ItemStyle HorizontalAlign="Center" Width="15px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lb_pyvtype" runat="server" Text='<%# (container.dataitemindex+1).tostring() %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="狀態">
                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbdepart_id" runat="server" Text='<%# Eval("Case_status")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="員工編號<br/>員工姓名<br/>公差日期">--%>
                                    <asp:TemplateField HeaderText="員工編號<br/>員工姓名">
                                        <ItemStyle HorizontalAlign="Center" Width="65px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbApply_idcard" runat="server" Text='<%# Eval("Id_card")%>'></asp:Label><br />
                                            <asp:Label ID="lbApply_name" runat="server" Text='<%# Eval("User_name")%>'></asp:Label><br />
                                            <%--<uc3:ucshowdate id="UcShowDate1" runat="server" text='<%# Eval("Start_date")%>' />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="類別<br/>日時<br/>公差地點">--%>
                                    <asp:TemplateField HeaderText="類別<br/>日時">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbLeave_name" runat="server" Text='<%# Eval("Leave_name")%>'></asp:Label><br />
                                            <asp:Label ID="lbDayHours" runat="server" Text='<%# Eval("DayHours")%>'></asp:Label><br />
                                            <%--<asp:Label ID="lbPlace" runat="server" Text='<%# Eval("Place")%>'></asp:Label>--%>
                                       </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="公差開始日期<br/>公差結束日期">
                                        <ItemStyle HorizontalAlign="Center" Width="145px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="45px" />
                                        <ItemTemplate>
                                            <uc3:ucshowdate id="UcShowDate2" runat="server" text='<%# Eval("Start_date")%>' />
                                            <uc4:ucshowtime id="UcShowTime1" runat="server" text='<%# Eval("Start_time")%>' />
                                            <uc3:ucshowdate id="UcShowDate3" runat="server" text='<%# Eval("End_date")%>' />
                                            <uc4:ucshowtime id="UcShowTime2" runat="server" text='<%# Eval("End_time")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="官等<br/>職等<br/>工作內容">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbDegree_code" runat="server" Text='<%# Eval("Degree_code")%>'></asp:Label><br />
                                            <asp:Label ID="lbLevel" runat="server" Text='<%# Eval("Level")%>'></asp:Label><br />
                                            <asp:Label ID="lbReason" runat="server" Text='<%# Eval("Reason")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="代理人">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbDeputy_idcard" runat="server" Text='<%# Eval("Deputy")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="簽核流程">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbLast_name" runat="server" Text='<%# Eval("Last_name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="公差事由<br/>搭機理由<br/>補修紀錄">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbReason2" runat="server" Text='<%# Eval("Reason")%>'></asp:Label><br />
                                            <asp:Label ID="lbFlightReason" runat="server" Text='<%# Eval("Leave_name")%>'></asp:Label><br />
                                            <asp:Label ID="lbRecord" runat="server" Text='<%# Eval("Leave_name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="往返">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Leave_name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="公差明細地點">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbDetailPlace" runat="server" Text='<%# Eval("DetailPlaces")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="搭乘高鐵或飛機<br/>之理由說明">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbTransport_desc" runat="server" Text='<%# Eval("Transport_desc")%>'></asp:Label>
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
                            <uc1:ucpager id="Ucpager" runat="server" enableviewstate="true" gridname="gvlist"
                                pnow="1" psize="30" visible="true" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
