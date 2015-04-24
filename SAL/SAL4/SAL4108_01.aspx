<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SAL4108_01.aspx.vb" Inherits="SAL4108_01" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="~/UControl/FSC/UcAttachment.ascx" TagPrefix="uc6" TagName="UcAttachment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="TABLE1" runat="server" width="100%">
        <tr>
            <td align="left" style="height: 1px" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title" colspan="4">�~�Ĺ�Ӫ�
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 110px; height: 19px;">�п�ܺ���</td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                             <asp:DropDownList ID="ddlApply_type" runat="server" AppendDataBoundItems="True"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px">��I���</td>
                        <td class="TdHeightLight">
                           <asp:DropDownList ID="ddlYM" runat="server" AppendDataBoundItems="True"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" class="TdHeightLight">
                            <asp:Button ID="btnNew" runat="server" Text="�s�W" />
                            <asp:Button ID="btnQuery" runat="server" Text="�d��" />
                            
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
                                            <asp:Label ID="STAN_YM" runat="server" Text='<%# Eval("STAN_YM")%>' Visible="false"></asp:Label>
                                               <asp:Label ID="STAN_TYPE" runat="server" Text='<%# Eval("STAN_TYPE")%>' Visible="false"></asp:Label>
                                                  <asp:Label ID="STAN_NO" runat="server" Text='<%# Eval("STAN_NO")%>' Visible="false"></asp:Label>
                                                     <asp:Label ID="Stan_Sal_Point" runat="server" Text='<%# Eval("Stan_Sal_Point")%>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="���I�B�~�I">
                                        <ItemStyle HorizontalAlign="Center" Width="160px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbApply_typeName" runat="server" Text='<%# Eval("Stan_Sal_Point")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="���B">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbAcademicYear" runat="server" Text='<%# Eval("Stan_Sal")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="���@">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Button ID="btnModify" runat="server" Text="�ק�" OnClick="btnModify_Click" />
                                            <asp:Button ID="btnDelete" runat="server" Text="�R��" OnClick="btnDelete_Click" OnClientClick="javascript:return confirm('�T�w�n�R��������? �нT�{�������A�ϥΡA�_�h�R����|�򥢸�ơI')" />
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
