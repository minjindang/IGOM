<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SAL4106_01.aspx.vb" Inherits="SAL4106_01" %>
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
                        <td class="htmltable_Title" colspan="4">申請區間設定
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 110px; height: 19px;">申請類別</td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                             <asp:DropDownList ID="ddlApply_type" runat="server" AppendDataBoundItems="True"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px">申請年度</td>
                        <td class="htmltable_Right" style="width: 250px">
                             <uc4:UcROCYear ID="ddlAcademicYear" runat="server" />
                        </td>
          <%--              <td class="htmltable_Left" style="width: 100px">TEST</td>
                         <td class="htmltable_Right" style="width: 250px">
                             <uc5:UcROCYearMonth ID="test1" runat="server" />
                        </td>--%>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px">申請日期(起)~申請日期(迄)</td>
                        <td class="TdHeightLight">
                            <uc1:UcDate ID="UcDate1" runat="server" />~
                            <uc1:UcDate ID="UcDate2" runat="server" />
                            <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※填寫範例:101/01/01"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" class="TdHeightLight">
                            <asp:Button ID="btnQuery" runat="server" Text="查詢" UseSubmitBehavior="false" />
                            <asp:Button ID="btnNew" runat="server" Text="新增" />
                            <input id="cbRest" type="button" value="重填" />
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
                                            <asp:Label ID="lbid" runat="server" Text='<%# Eval("id")%>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="申請類別">
                                        <ItemStyle HorizontalAlign="Center" Width="160px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbApply_typeName" runat="server" Text='<%# Eval("Apply_typeName")%>'></asp:Label>
                                            <asp:Label ID="lbApply_type" runat="server" Text='<%# Eval("Apply_type")%>' Visible="false" ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="申請年度">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbAcademicYear" runat="server" Text='<%# Eval("AcademicYear")%>'></asp:Label><br />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="申請學期">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbSemester" runat="server" Text='<%#  IIf(Eval("Semester") = "", Eval("Semester"), "")%>'></asp:Label><br />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="申請日期(起)">
                                        <ItemStyle HorizontalAlign="Center" Width="125px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="45px" />
                                        <ItemTemplate>
                                           <uc2:UcShowDate ID="Apply_sDate" runat="server" Text='<%# Eval("Apply_sDate")%>'/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="申請時間(起)">
                                        <ItemStyle HorizontalAlign="Center" Width="125px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="45px" />
                                        <ItemTemplate>
                                           <uc3:UcShowTime ID="Apply_sTime" runat="server" Text='<%# Eval("Apply_sTime")%>'/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="申請日期(迄)">
                                        <ItemStyle HorizontalAlign="Center" Width="125px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="45px" />
                                        <ItemTemplate>
                                           <uc2:UcShowDate ID="Apply_eDate" runat="server" Text='<%# Eval("Apply_eDate")%>'/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="申請時間(迄)">
                                        <ItemStyle HorizontalAlign="Center" Width="125px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="45px" />
                                        <ItemTemplate>
                                          <uc3:UcShowTime ID="Apply_eTime" runat="server" Text='<%# Eval("Apply_eTime")%>'/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="開放狀態">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbStatus" runat="server" Text='<%# IIf(Eval("Status") = "Y", "開放", "不開放")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                       
                                    <asp:TemplateField HeaderText="維護">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Button ID="btnModify" runat="server" Text="修改" OnClick="btnModify_Click" />
                                            <asp:Button ID="btnDelete" runat="server" Text="刪除" OnClick="btnDelete_Click" />
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
