<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC3118_01.aspx.vb" Inherits="FSC3118_01" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register src="~/UControl/UcShowDate.ascx" tagname="UcShowDate" tagprefix="uc3" %>
<%@ Register src="~/UControl/UcShowTime.ascx" tagname="UcShowTime" tagprefix="uc4" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc6" TagName="UcDDLMember" %>
<%@ Register Src="~/UControl/FSC/UcMember.ascx" TagPrefix="uc1" TagName="UcMember" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="TABLE1" runat="server" width="100%">
        <tr>
            <td align="left" style="height: 1px" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title" colspan="4">
                            �X�Բ��`���P
                        </td>
                    </tr>
                    <tr>                    
                        <td class="htmltable_Left" style="width:100px; height: 19px;">
                            ���O
                        </td>
                        <td class="TdHeightLight" style="width:250px; height: 19px;">
                            <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
                        </td>
                        
                    </tr>
                    <<tr>
                         <td class="htmltable_Left" style="width: 100px">���u�m�W</td>
                         <td class="htmltable_Right" style="width:250px">
                         <uc6:UcDDLMember runat="server" ID="UcDDLMember" /></td>
                    </tr>
                        <tr>
                        <td class="htmltable_Left" style="width:100px">
                            ���u�s��</td>
                            <td class="htmltable_Right">
                                <uc1:UcMember runat="server" ID="UcMember" />
                            </td>
                        </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px"><span style="color:Red">*</span>�X�Ԥ��</td>
                        <td class="TdHeightLight">
                            <uc2:UcDate ID="UcDate1" runat="server" />~
                            <uc2:UcDate ID="UcDate2" runat="server" />
                            <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="����g�d��:101/01/01"></asp:Label>
                        </td>
                    </tr>
               
                        <tr>
                            <td class="htmltable_Left" style="width:120px; height: 26px;">
                            �b¾���A</td>            
                        <td class="htmltable_Right" style="height: 26px" >
                            <asp:DropDownList ID="ddlQuit_Job" runat="server" AppendDataBoundItems="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width:100px">
                            �H�����O
                        </td>
                        <td class="htmltable_Right" style="height: 26px" >
                            <asp:DropDownList ID="ddlEmployeetype" runat="server" AppendDataBoundItems="True" >
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" class="TdHeightLight">
                            <asp:Button ID="btnQuery" runat="server" Text="�d��"/>
                            <input id="Reset" type="button" runat="server" value="����" />
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
                                            <asp:Label ID="lbPKCARD" runat="server" Text='<%# Eval("PKCARD")%>'></asp:Label><br />
                                            </Itemtemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="���u�m�W">
                                              <itemstyle horizontalalign="Center" width="75px" />
                                              <headerstyle horizontalalign="Center" verticalalign="Middle" width="60px" />
                                              <itemtemplate>
                                          <asp:Label ID="lbPKNAME" runat="server"  Text='<%# Eval("PKNAME")%>'></asp:Label><br/>                    
                                              </itemtemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="�W�Z���">
                                                <itemstyle horizontalalign="Center" width="145px" />
                                                <headerstyle horizontalalign="Center" verticalalign="Middle" width="45px" />
                                                <itemtemplate>
                                            <uc3:UcShowDate ID="UcShowDate" runat="server" Text='<%# Eval("PKWDATE")%>'/>
                                        </itemtemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="�W�Z�ɶ�">
                                                <itemstyle horizontalalign="Center" width="145px" />
                                                <headerstyle horizontalalign="Center" verticalalign="Middle" width="45px" />
                                                <itemtemplate>
                                                    <uc4:UcShowTime runat="server" ID="UcPKSTIME" Text='<%# Eval("PKSTIME")%>'/>
                                                </itemtemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="�U�Z�ɶ�">
                                                <itemstyle horizontalalign="Center" width="145px" />
                                                <headerstyle horizontalalign="Center" verticalalign="Middle" width="45px" />
                                                <itemtemplate>
                                                <uc4:UcShowTime runat="server" ID="UcPKETIME" Text='<%# Eval("PKETIME")%>'/>
                                                </itemtemplate>
                                     </asp:TemplateField>
                                            <asp:TemplateField HeaderText="�X�Ԫ��p">
                                                <itemstyle horizontalalign="Center" />
                                                <headerstyle horizontalalign="Center" verticalalign="Middle" />
                                                <itemtemplate>
                                            <asp:Label ID="lbCHPKWKTPE" runat="server"  Text='<%# Eval("CHPKWKTPE")%>' ></asp:Label>
                                            <asp:Label ID="lbPKWKTPE" runat="server"  Text='<%# Eval("PKWKTPE")%>' Visible="false"></asp:Label>
                                        </itemtemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="���P��]">
                                                <itemstyle horizontalalign="Center" />
                                                <headerstyle horizontalalign="Center" verticalalign="Middle" />
                                                <itemtemplate>
                                            <asp:TextBox ID="tbReason" runat="server" />
                                            <asp:Button ID="btnUpdate" runat="server" Text="���P" OnClick="btnUpdate_Click" />
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
