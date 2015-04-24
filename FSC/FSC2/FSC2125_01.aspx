<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC2125_01.aspx.vb" Inherits="FSC2125_01" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

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
                        <td class="htmltable_Title" colspan="2">
                            �C��[�Z�O�л�έp
                        </td>
                    </tr>
                    <tr>                    
                        <td class="htmltable_Left" style="width:100px; height: 19px;">
                            ���W��
                        </td>
                        <td class="TdHeightLight" style="width:250px; height: 19px;">
                            <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
                        </td>
                        
                    </tr>
                    <tr>
                         <td class="htmltable_Left" style="width: 100px">�H���m�W</td>
                         <td class="htmltable_Right" style="width:250px">
                         <uc6:UcDDLMember runat="server" ID="UcDDLMember" /></td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width:100px">
                            �л�~��
                        </td>
                        <td class="htmltable_Right" style="height: 26px" >
                            <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" >
                            </asp:DropDownList>�~
                            <asp:DropDownList ID="ddlMonth" runat="server"></asp:DropDownList>��
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" class="TdHeightLight">
                            <asp:Button ID="btnQuery" runat="server" Text="�d��"/>
                             <input id="Reset" type="button" value="����" runat="server"  Visible="false"/>
                            <asp:Button ID="btnExcel" runat="server" Text="�ץX" Enabled="false" />
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
                        <td class="htmltable_Title2" style="width: 100%" align="center">
                            �d�ߵ��G
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%" class="TdHeightLight" valign="top">
                            <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="false" BorderWidth="0px" PageSize="30"
                                AllowPaging="true" CssClass="Grid" PagerStyle-HorizontalAlign="right" Width="100%"
                                EmptyDataText="�d�L���!!" ShowFooter="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="����">
                                        <ItemStyle HorizontalAlign="Center" Width="15px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lb_pyvtype" runat="server" Text='<%# (container.dataitemindex+1).tostring() %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="�л�~��">
                                              <itemstyle horizontalalign="Center" width="75px" />
                                              <headerstyle horizontalalign="Center" verticalalign="Middle" width="60px" />
                                              <itemtemplate>
                                          <asp:Label ID="lbPRYYYMM" runat="server"  Text='<%# Eval("PRYYYMM")%>'></asp:Label><br/>                    
                                              </itemtemplate>
                                     </asp:TemplateField>
                                    <asp:TemplateField HeaderText="���W��">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbDepart_name" runat="server" Text='<%# Eval("Depart_name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="���u�s��">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <Itemtemplate>
                                            <asp:Label ID="lbPRCARD" runat="server" Text='<%# Eval("PRCARD")%>'></asp:Label><br />
                                            </Itemtemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="���u�m�W">
                                              <itemstyle horizontalalign="Center" width="75px" />
                                              <headerstyle horizontalalign="Center" verticalalign="Middle" width="60px" />
                                              <itemtemplate>
                                          <asp:Label ID="lbPRNAME" runat="server"  Text='<%# Eval("PRNAME")%>'></asp:Label><br/>                    
                                              </itemtemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="�ӽЮɼ�">
                                                <itemstyle horizontalalign="Center" width="145px" />
                                                <headerstyle horizontalalign="Center" verticalalign="Middle" width="45px" />
                                                <itemtemplate>
                                            <asp:Label ID="lbLeave_hours" runat="server"  Text='<%# Eval("Leave_hours")%>'></asp:Label>
                                        </itemtemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="�֥i�ɼ�">
                                                <itemstyle horizontalalign="Center" />
                                                <headerstyle horizontalalign="Center" verticalalign="Middle" />
                                                <itemtemplate>
                                            <asp:Label ID="lbPRADDH" runat="server"  Text='<%# Eval("PRADDH")%>' ></asp:Label>
                                        </itemtemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="�w�ɥ�ɼ�">
                                                <itemstyle horizontalalign="Center" />
                                                <headerstyle horizontalalign="Center" verticalalign="Middle" />
                                                <itemtemplate>
                                            <asp:Label ID="lbPRPAYH" runat="server"  Text='<%# Eval("PRPAYH")%>' ></asp:Label>
                                        </itemtemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="�w�дڮɼ�">
                                                <itemstyle horizontalalign="Center" />
                                                <headerstyle horizontalalign="Center" verticalalign="Middle" />
                                                <itemtemplate>
                                            <asp:Label ID="lbPRMNYH" runat="server"  Text='<%# Eval("PRMNYH")%>' ></asp:Label>
                                        </itemtemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="�[�Z�O���B">
                                                <itemstyle horizontalalign="Center" />
                                                <headerstyle horizontalalign="Center" verticalalign="Middle" />
                                                <itemtemplate>
                                            <asp:Label ID="lbPRPAYFEE" runat="server"  Text='<%# Eval("PRPAYFEE")%>' ></asp:Label>
                                        </itemtemplate>
                                     </asp:TemplateField>
                                            </Columns>
                                <pagerstyle horizontalalign="Right" />
                                            <emptydatatemplate>
                                    �d�L���!!
                                </emptydatatemplate>
                                            <rowstyle cssclass="Row" />
                                            <headerstyle cssclass="Grid" />
                                            <alternatingrowstyle cssclass="AlternatingRow" />
                                            <pagersettings position="TopAndBottom" />
                                            <emptydatarowstyle cssclass="EmptyRow" />
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
