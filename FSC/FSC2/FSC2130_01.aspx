<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC2130_01.aspx.vb" Inherits="FSC2130_01" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UControl/UcShowDate.ascx" TagName="UcShowDate" TagPrefix="uc3" %>
<%@ Register Src="~/UControl/UcShowTime.ascx" TagName="UcShowTime" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="TABLE1" runat="server" width="100%">
        <tr>
            <td align="left" style="height: 1px" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title" colspan="4">�{�ɤu�C��ֿn�F2�ѥH�W�H���d��
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">�~��</td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                            <asp:DropDownList ID="ddlYear" runat="server" />�~
                            <asp:DropDownList ID="ddlMonth" runat="server" />��
                        </td>

                    </tr>
                    <tr>
                        <td align="center" colspan="4" class="TdHeightLight">
                            <asp:Button ID="btnQuery" runat="server" Text="�d��" UseSubmitBehavior="false" OnClick="btnQuery_Click" />
                            <input id="Reset" type="button" value="����" runat="server"  Visible="false"/>
                            <asp:Button ID="btnExport" runat="server" Enabled="false" Text="�ץX" />
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
                        <td class="htmltable_Title2" style="width: 100%" align="center">�d�ߵ��G
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%" class="TdHeightLight" valign="top">
                            <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="false" BorderWidth="0px" PageSize="30"
                                AllowPaging="true" CssClass="Grid" PagerStyle-HorizontalAlign="right" Width="100%"
                                EmptyDataText="�d�L���!!">
                                <Columns>
                                    <asp:TemplateField HeaderText="����">
                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbno" runat="server" Text='<%# (container.dataitemindex+1).tostring() %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="���u�s��">
                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbId_card" runat="server" Text='<%# Eval("Id_card")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="���u�m�W">
                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbUser_name" runat="server" Text='<%# Eval("User_name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="���O">
                                        <ItemStyle HorizontalAlign="Center" Width="45px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="65px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbLeave_type" runat="server" Text='<%# Eval("Leave_name")%>'></asp:Label><br/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�а��}�l���">
                                        <ItemStyle HorizontalAlign="Center" Width="105px"/>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <uc3:UcShowDate ID="UcShowDate1" runat="server" Text='<%# Eval("Start_date")%>' />
                                            <uc4:UcShowTime ID="UcShowTime1" runat="server" Text='<%# Eval("Start_time")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�а��������">
                                        <ItemStyle HorizontalAlign="Center" Width="105px"    />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <uc3:UcShowDate ID="UcShowDate2" runat="server" Text='<%# Eval("End_date")%>' />
                                            <uc4:UcShowTime ID="UcShowTime2" runat="server" Text='<%# Eval("End_time")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�а����">
                                        <ItemStyle HorizontalAlign="Center" Width="80px"/>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbLeave_hours" runat="server" Text='<%# Eval("DayHours")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�а��ƥ�">
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbReason" runat="server" Text='<%# Eval("Reason")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle HorizontalAlign="Right" />
                                <EmptyDataTemplate>
                                    �d�L���!!
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
