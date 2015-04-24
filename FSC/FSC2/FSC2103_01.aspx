<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC2103_01.aspx.vb" Inherits="FSC2103_01" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register Src="~/UControl/UcShowDate.ascx" TagName="UcShowDate" TagPrefix="uc3" %>
<%@ Register Src="~/UControl/UcShowTime.ascx" TagName="UcShowTime" TagPrefix="uc4" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc6" TagName="UcDDLMember" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="TABLE1" runat="server" width="100%">
        <tr>
            <td align="left" style="height: 1px" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title" colspan="4">�а������d��
                        </td>
                    </tr>
                    <tr id="tr8" runat="server">
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">���O
                        </td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                            <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
                        </td>

                    </tr>
                      <tr>
                         <td class="htmltable_Left" style="width: 100px">���u�m�W</td>
                         <td class="htmltable_Right" style="width:250px">
                         <uc6:UcDDLMember runat="server" ID="UcDDLMember" /></td>
                    </tr>
                    <tr id="tr1" runat="server">
                        <td class="htmltable_Left" style="width: 100px">���u�s��</td>
                        <td class="htmltable_Right">
                            <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr id="tr2" runat="server">
                        <td class="htmltable_Left" style="width: 100px">¾��<asp:CheckBox ID="cbAll" runat="server" AutoPostBack="true" />
                        </td>
                        <td class="TdHeightLight">
                            <asp:UpdatePanel id="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:CheckBoxList ID="cblTitle_no" runat="server" RepeatColumns="10" DataTextField="CODE_DESC1" DataValueField="CODE_NO" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr id="tr3" runat="server">
                        <td class="htmltable_Left" style="width: 120px; height: 26px;">�b¾���A</td>
                        <td class="htmltable_Right" style="height: 26px">
                            <asp:DropDownList ID="ddlQuit_Job" runat="server" AppendDataBoundItems="True">
                                <asp:ListItem Value="N" Text="�{¾���u"></asp:ListItem>
                                <asp:ListItem Value="Y" Text="��¾���u"></asp:ListItem>
                                <asp:ListItem Value="1" Text="�d¾���~"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="tr4" runat="server">
                        <td class="htmltable_Left" style="width: 100px">�ʧO
                        </td>
                        <td class="htmltable_Right" style="height: 26px">
                            <asp:DropDownList ID="ddlsextype" runat="server" AppendDataBoundItems="True">
                                <asp:ListItem Value="" Text="�п��"></asp:ListItem>
                                <asp:ListItem Value="1" Text="�k"></asp:ListItem>
                                <asp:ListItem Value="0" Text="�k"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td class="htmltable_Left" style="width: 100px"><span style="color:Red">*</span>�а����
                        </td>
                        <td class="TdHeightLight" style="width: 850px" colspan="3">
                            <uc2:UcDate ID="UcDate1" runat="server"></uc2:UcDate>
                            <uc2:UcDate ID="UcDate2" runat="server"></uc2:UcDate>
                            <asp:Label ID="lbTip" runat="server" ForeColor="Blue" Text="����g�d��:101/01/01"></asp:Label>
                        </td>
                    </tr>
                    <tr id="tr6" runat="server">
                        <td class="htmltable_Left" style="width: 100px">���O
                        </td>
                        <td class="htmltable_Right">
                            <asp:CheckBoxList ID="cblLeavetype" runat="server" RepeatDirection="Vertical" RepeatColumns="10" >
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr id="tr5" runat="server">
                        <td class="htmltable_Left" style="width: 100px">�H�����O
                        </td>
                        <td class="htmltable_Right" style="height: 26px">
                            <asp:DropDownList ID="ddlEmployeetype" runat="server" AppendDataBoundItems="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="tr7" runat="server">
                        <td class="htmltable_Left" style="width: 100px">���A</td>
                        <td class="htmltable_Right">
                            <asp:CheckBoxList ID="cblStatus" runat="server" DataTextField="code_desc1" DataValueField="code_no" RepeatColumns="5" />
                        </td>

                    </tr>

                        <tr>
                            <td align="center" colspan="4" class="TdHeightLight">
                                <asp:Button ID="btnQuery" runat="server" Text="�d��" UseSubmitBehavior="false" OnClick="btnQuery_Click" />
                                <input id="Reset" type="button" value="����" runat="server"  Visible="false"/>
                                <asp:Button ID="btnExport" runat="server" Enabled="false" Text="�ץXEXCEL" />
                                <asp:Button ID="btn" runat="server" Text="���u�򥻸�Ƥήt���έp�d��" OnClick="btn_Click" />
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
                                            <asp:Label ID="lb_pyvtype" runat="server" Text='<%# (container.dataitemindex+1).tostring() %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="���A">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbStatus" runat="server" Text='<%# Eval("Case_status")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="���u�s��<br>���u�m�W">
                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbId_card" runat="server" Text='<%# Eval("Id_card")%>'></asp:Label><br />
                                            <asp:Label ID="lbUser_name" runat="server" Text='<%# Eval("User_name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="���O<br>�а����">
                                        <ItemStyle HorizontalAlign="Center" Width="45px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="65px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbLeave_type" runat="server" Text='<%# Eval("Leave_name")%>'></asp:Label><br/>
                                            <asp:Label ID="lbLeave_hours" runat="server" Text='<%# Eval("DayHours")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�а��}�l���<br />�а��������">
                                        <ItemStyle HorizontalAlign="Center" Width="105px"/>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <uc3:UcShowDate ID="UcShowDate1" runat="server" Text='<%# Eval("Start_date")%>' />
                                            <uc4:UcShowTime ID="UcShowTime1" runat="server" Text='<%# Eval("Start_time")%>' />
                                            <br />
                                            <uc3:UcShowDate ID="UcShowDate2" runat="server" Text='<%# Eval("End_date")%>' />
                                            <uc4:UcShowTime ID="UcShowTime2" runat="server" Text='<%# Eval("End_time")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�N�z�H">
                                        <ItemStyle HorizontalAlign="Center" Width="80px"/>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbDeputy" runat="server" Text='<%# Eval("Deputy")%>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ñ�֬y�{">
                                        <ItemStyle HorizontalAlign="Center" Width="145px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbLast_name" runat="server" Text='<%# Bind("Process")%>'></asp:Label>
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