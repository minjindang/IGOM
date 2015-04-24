<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC2105_01.aspx.vb" Inherits="FSC2105_01" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register src="~/UControl/UcShowDate.ascx" tagname="UcShowDate" tagprefix="uc3" %>
<%@ Register src="~/UControl/UcShowTime.ascx" tagname="UcShowTime" tagprefix="uc4" %>
<%@ Register Src="~/UControl/FSC/UcAuthorityMember.ascx" TagName="UcMember" TagPrefix="uc5" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc6" TagName="UcDDLMember" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="TABLE1" runat="server" width="100%">
        <tr>
            <td align="left" style="height: 1px" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title" colspan="4">加班紀錄查詢
                        </td>
                    </tr>
                    <tr id="tr0" runat="server">
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">單位 </td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                            <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
                        </td>
                    </tr>
                     <tr>
                        <td class="htmltable_Left" style="width: 100px">員工姓名
                        </td>

                        <td class="htmltable_Right" style="width: 250px">
                            <uc6:UcDDLMember runat="server" ID="UcDDLMember" />
                        </td>
                    </tr>
                    <tr id="tr1" runat="server">
                        <td class="htmltable_Left" style="width: 100px">員工編號
                        </td>
                        <td class="TdHeightLight">
                            <uc5:UcMember ID="UcPersonal_id" runat="server" />
                        </td>
                    </tr>
                    <tr id="tr3" runat="server">
                        <td class="htmltable_Left" style="width: 100px">性別
                        </td>
                        <td class="TdHeightLight">
                            <asp:DropDownList ID="ddlsextype" runat="server" AppendDataBoundItems="True">
                                <asp:ListItem Value="" Text="請選擇"></asp:ListItem>
                                <asp:ListItem Value="1" Text="男"></asp:ListItem>
                                <asp:ListItem Value="0" Text="女"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px">加班日期
                        </td>
                        <td class="TdHeightLight" style="width: 250px" id="OvertimeValue" runat="server">
                            <uc2:UcDate ID="UcDate1" runat="server"></uc2:UcDate>
                            <uc2:UcDate ID="UcDate2" runat="server"></uc2:UcDate>
                            <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※填寫範例:101/01/01"></asp:Label>
                        </td>
                    </tr>
                    <tr id="tr2" runat="server">
                        <td class="htmltable_Left" style="width: 100px">狀態</td>
                        <td class="htmltable_Right">
                            <asp:CheckBoxList ID="cblStatus" runat="server" DataTextField="code_desc1" DataValueField="code_no" RepeatColumns="5" />
                        </td>

                    </tr>
                    <tr>
                        <td align="center" colspan="4" class="TdHeightLight">
                            <asp:Button ID="btnQuery" runat="server" Text="查詢" UseSubmitBehavior="false" />
                            <input id="Reset" type="button" value="重填" runat="server"  Visible="false"/>
                            <asp:Button ID="btnExport" runat="server" Enabled="false" Text="匯出" />
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
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--    <asp:BoundField HeaderText ="單位" DataField="dep" />
                                    <asp:BoundField HeaderText="員工編號" DataField="idno" />
                                    <asp:BoundField HeaderText="姓名" DataField="name" />--%>
                                    <asp:TemplateField HeaderText="狀態">
                                        <ItemTemplate>
                                            <asp:Label ID="lbStatus" runat="server" Text='<%# Eval("Case_status")%>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="員工編號<br/>員工姓名">
                                        <ItemTemplate>
                                            <asp:Label ID="lbId_card" runat="server" Text='<%# Eval("Id_card")%>'></asp:Label><br />
                                            <asp:Label ID="lbUser_name" runat="server" Text='<%# Eval("User_name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="一般/專案<br/>請示時數">
                                        <ItemTemplate>
                                            <asp:Label ID="lbPRATYPE" runat="server" Text='<%# Eval("PRATYPE")%>'></asp:Label><br />
                                            <asp:Label ID="lbLeave_hours" runat="server" Text='<%# Eval("Leave_hours")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="加班開始時間<br/>加班結束時間">
                                        <ItemStyle HorizontalAlign="Center" Width="145px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <uc3:UcShowDate ID="UcShowDate1" runat="server" Text='<%# Eval("Start_date")%>' />
                                            <uc4:UcShowTime ID="UcShowTime1" runat="server" Text='<%# Eval("Start_time")%>' />
                                            <uc3:UcShowDate ID="UcShowDate2" runat="server" Text='<%# Eval("End_date")%>' />
                                            <uc4:UcShowTime ID="UcShowTime2" runat="server" Text='<%# Eval("End_time")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="簽核流程">
                                        <ItemTemplate>
                                            <asp:Label ID="lbLast_name" runat="server" Text='<%# Eval("Last_name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="加班事由<br/>實際時數">
                                        <ItemTemplate>
                                            <asp:Label ID="lbReason" runat="server" Text='<%# Eval("Reason")%>'></asp:Label><br />
                                            <asp:Label ID="lbPRADDH" runat="server" Text='<%# Eval("PRADDH")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="請領時數">
                                        <ItemTemplate>
                                            <asp:Label ID="lbPRMNYH" runat="server" Text='<%# Eval("PRMNYH") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="補休時數">
                                        <ItemTemplate>
                                            <asp:Label ID="lbPRPAYH" runat="server" Text='<%# Eval("PRPAYH")%>'></asp:Label>
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
                                PNow="1" PSize="30" Visible="true" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
