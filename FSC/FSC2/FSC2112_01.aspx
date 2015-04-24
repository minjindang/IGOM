<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC2112_01.aspx.vb" Inherits="FSC2112_01" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
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
                        <td class="htmltable_Title" colspan="4">���N�ХX�Ԭ����d��
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">���O
                        </td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                            <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px">���u�m�W</td>
                        <td class="htmltable_Right" style="width: 250px">
                            <uc6:UcDDLMember runat="server" ID="UcDDLMember" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px">���u�s��</td>
                        <td class="htmltable_Right">
                            <uc1:UcAuthorityMember runat="server" ID="UcAuthorityMember" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px"><span style="color: Red">*</span>�X�Ԥ��</td>
                        <td class="TdHeightLight">
                            <uc2:UcDate ID="UcDate1" runat="server" />
                            ~
                            <uc2:UcDate ID="UcDate2" runat="server" />
                            <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="����g�d��:101/01/01"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 120px; height: 26px;">�b¾���A</td>
                        <td class="htmltable_Right" style="height: 26px">
                            <asp:DropDownList ID="ddlQuit_Job" runat="server" AppendDataBoundItems="True">
                                <asp:ListItem Value="N" Text="�{¾���u"></asp:ListItem>
                                <asp:ListItem Value="Y" Text="��¾���u"></asp:ListItem>
                                <asp:ListItem Value="1" Text="�d¾���~"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px">�ʧO
                        </td>
                        <td class="htmltable_Right" style="height: 26px">
                            <asp:DropDownList ID="ddlsextype" runat="server" AppendDataBoundItems="True">
                                <asp:ListItem Value="">�п��</asp:ListItem>
                                <asp:ListItem Value="1" Text="�k"></asp:ListItem>
                                <asp:ListItem Value="0" Text="�k"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px">�H�����O
                        </td>
                        <td class="htmltable_Right" style="height: 26px">
                            <asp:DropDownList ID="ddlEmployeetype" runat="server" AppendDataBoundItems="True">
                                <asp:ListItem Value="14" Text="���N��"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px">�������O</td>
                        <td class="htmltable_Right" style="height: 26px">
                            <asp:RadioButtonList ID="rblReporttype" runat="server" Width="265px" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                <asp:ListItem Value="0" Text="�X�Ԭ���" Selected="True" ></asp:ListItem>
                                <asp:ListItem Value="1" Text="�X�Բ��`����"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" class="TdHeightLight">
                            <asp:Button ID="btnQuery" runat="server" Text="�d��" UseSubmitBehavior="false" />
                            <input id="Reset" type="button" value="����" style="display:none" />
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
                                        <ItemStyle HorizontalAlign="Center" Width="15px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lb_pyvtype" runat="server" Text='<%# (container.dataitemindex+1).tostring() %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="���W��">
                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbDepart_name" runat="server" Text='<%# Eval("Depart_name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="���u�s��">
                                        <ItemStyle HorizontalAlign="Center" Width="65px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbPKCARD" runat="server" Text='<%# Eval("PKCARD")%>'></asp:Label><br />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="���u�m�W">
                                        <ItemStyle HorizontalAlign="Center" Width="65px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbPKNAME" runat="server" Text='<%# Eval("PKNAME")%>'></asp:Label><br />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�W�Z���">
                                        <ItemStyle HorizontalAlign="Center" Width="145px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="45px" />
                                        <ItemTemplate>
                                            <uc3:UcShowDate ID="UcShowDate" runat="server" Text='<%# Eval("PKWDATE")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�W�Z�ɶ�">
                                        <ItemStyle HorizontalAlign="Center" Width="145px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="45px" />
                                        <ItemTemplate>
                                            <uc4:UcShowTime ID="UcShowTimestart" runat="server" Text='<%# Eval("PKSTIME")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�U�Z�ɶ�">
                                        <ItemStyle HorizontalAlign="Center" Width="145px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="45px" />
                                        <ItemTemplate>
                                            <uc4:UcShowTime ID="UcShowTimeend" runat="server" Text='<%# Eval("PKETIME")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="��d�ɼ�">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbPKWORKH" runat="server" Text='<%# Eval("PKWORKH")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�X�Ԫ��p">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbPKWKTPE" runat="server" Text='<%# Eval("PKWKTPE")%>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�t���O">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbLeave_type" runat="server" Text='<%# Eval("Leavetype")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�t���ɼ�">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbleave_hours" runat="server" Text='<%# Eval("Leavehours")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�m¾�ɼ�">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbabsenthours" runat="server" Text='<%# Eval("Absenthours")%>'></asp:Label>
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
