<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC2132_01.aspx.vb" Inherits="FSC2132_01" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UControl/UcShowDate.ascx" TagName="UcShowDate" TagPrefix="uc3" %>
<%@ Register Src="~/UControl/UcShowTime.ascx" TagName="UcShowTime" TagPrefix="uc4" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc3" TagName="UcDDLAuthorityDepart" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc3" TagName="UcDDLAuthorityMember" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc3" TagName="UcDate" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="TABLE1" runat="server" width="100%">
        <tr>
            <td align="left" style="height: 1px" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title" colspan="4">�X�t�浧�W�L15�Ѭd��
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">���</td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                            <uc3:UcDDLAuthorityDepart runat="server" ID="UcDDLAuthorityDepart" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">�X�t���</td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                            <uc3:UcDate runat="server" ID="UcDateS" />~
                            <uc3:UcDate runat="server" ID="UcDateE" />
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
                                    <asp:TemplateField HeaderText="�X�t�O">
                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbLocation_Flag" runat="server" Text='<%#IIf( Eval("Location_Flag") = "0","�ꤺ","��~")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�X�t�}�l���">
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        <ItemTemplate>
                                            <uc3:UcShowDate ID="UcShowDate1" runat="server" Text='<%# Eval("Start_date")%>' />
                                            <uc4:UcShowTime ID="UcShowTime1" runat="server" Text='<%# Eval("Start_time")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�X�t�������">
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        <ItemTemplate>
                                            <uc3:UcShowDate ID="UcShowDate2" runat="server" Text='<%# Eval("End_date")%>' />
                                            <uc4:UcShowTime ID="UcShowTime2" runat="server" Text='<%# Eval("End_time")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�X�t���">
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbDayHours" runat="server" Text='<%# Eval("DayHours")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�X�t�ƥ�">
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbReason" runat="server" Text='<%# Eval("Reason")%>' />
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