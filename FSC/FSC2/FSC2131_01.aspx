<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC2131_01.aspx.vb" Inherits="FSC2131_01" %>

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
                        <td class="htmltable_Title" colspan="4">�s��8�ѽа��d��
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">���</td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                            <uc3:UcDDLAuthorityDepart runat="server" ID="UcDDLAuthorityDepart" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">�H���m�W</td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                            <uc3:UcDDLAuthorityMember runat="server" ID="UcDDLAuthorityMember" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">�а����</td>
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
                                            <asp:Label ID="lbId_card" runat="server" Text='<%# Eval("POIDNO")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="���u�m�W">
                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbUser_name" runat="server" Text='<%# Eval("PONAME")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�ԲӮt���϶�">
                                        <ItemStyle HorizontalAlign="left" Width="45px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbdate_detail" runat="server" Text='<%# Eval("date_detail")%>'></asp:Label><br/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="�W�L�Ѽ�">
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lboverdays" runat="server" Text='<%# Eval("overdays")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="�s��Ѽ�">
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbTotaldays" runat="server" Text='<%# Eval("Totaldays")%>'></asp:Label>
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
