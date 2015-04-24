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
                            每月加班費請領統計
                        </td>
                    </tr>
                    <tr>                    
                        <td class="htmltable_Left" style="width:100px; height: 19px;">
                            單位名稱
                        </td>
                        <td class="TdHeightLight" style="width:250px; height: 19px;">
                            <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
                        </td>
                        
                    </tr>
                    <tr>
                         <td class="htmltable_Left" style="width: 100px">人員姓名</td>
                         <td class="htmltable_Right" style="width:250px">
                         <uc6:UcDDLMember runat="server" ID="UcDDLMember" /></td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width:100px">
                            請領年月
                        </td>
                        <td class="htmltable_Right" style="height: 26px" >
                            <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" >
                            </asp:DropDownList>年
                            <asp:DropDownList ID="ddlMonth" runat="server"></asp:DropDownList>月
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" class="TdHeightLight">
                            <asp:Button ID="btnQuery" runat="server" Text="查詢"/>
                             <input id="Reset" type="button" value="重填" runat="server"  Visible="false"/>
                            <asp:Button ID="btnExcel" runat="server" Text="匯出" Enabled="false" />
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
                            查詢結果
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%" class="TdHeightLight" valign="top">
                            <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="false" BorderWidth="0px" PageSize="30"
                                AllowPaging="true" CssClass="Grid" PagerStyle-HorizontalAlign="right" Width="100%"
                                EmptyDataText="查無資料!!" ShowFooter="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="項次">
                                        <ItemStyle HorizontalAlign="Center" Width="15px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lb_pyvtype" runat="server" Text='<%# (container.dataitemindex+1).tostring() %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="請領年月">
                                              <itemstyle horizontalalign="Center" width="75px" />
                                              <headerstyle horizontalalign="Center" verticalalign="Middle" width="60px" />
                                              <itemtemplate>
                                          <asp:Label ID="lbPRYYYMM" runat="server"  Text='<%# Eval("PRYYYMM")%>'></asp:Label><br/>                    
                                              </itemtemplate>
                                     </asp:TemplateField>
                                    <asp:TemplateField HeaderText="單位名稱">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbDepart_name" runat="server" Text='<%# Eval("Depart_name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="員工編號">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <Itemtemplate>
                                            <asp:Label ID="lbPRCARD" runat="server" Text='<%# Eval("PRCARD")%>'></asp:Label><br />
                                            </Itemtemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="員工姓名">
                                              <itemstyle horizontalalign="Center" width="75px" />
                                              <headerstyle horizontalalign="Center" verticalalign="Middle" width="60px" />
                                              <itemtemplate>
                                          <asp:Label ID="lbPRNAME" runat="server"  Text='<%# Eval("PRNAME")%>'></asp:Label><br/>                    
                                              </itemtemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="申請時數">
                                                <itemstyle horizontalalign="Center" width="145px" />
                                                <headerstyle horizontalalign="Center" verticalalign="Middle" width="45px" />
                                                <itemtemplate>
                                            <asp:Label ID="lbLeave_hours" runat="server"  Text='<%# Eval("Leave_hours")%>'></asp:Label>
                                        </itemtemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="核可時數">
                                                <itemstyle horizontalalign="Center" />
                                                <headerstyle horizontalalign="Center" verticalalign="Middle" />
                                                <itemtemplate>
                                            <asp:Label ID="lbPRADDH" runat="server"  Text='<%# Eval("PRADDH")%>' ></asp:Label>
                                        </itemtemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="已補休時數">
                                                <itemstyle horizontalalign="Center" />
                                                <headerstyle horizontalalign="Center" verticalalign="Middle" />
                                                <itemtemplate>
                                            <asp:Label ID="lbPRPAYH" runat="server"  Text='<%# Eval("PRPAYH")%>' ></asp:Label>
                                        </itemtemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="已請款時數">
                                                <itemstyle horizontalalign="Center" />
                                                <headerstyle horizontalalign="Center" verticalalign="Middle" />
                                                <itemtemplate>
                                            <asp:Label ID="lbPRMNYH" runat="server"  Text='<%# Eval("PRMNYH")%>' ></asp:Label>
                                        </itemtemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="加班費金額">
                                                <itemstyle horizontalalign="Center" />
                                                <headerstyle horizontalalign="Center" verticalalign="Middle" />
                                                <itemtemplate>
                                            <asp:Label ID="lbPRPAYFEE" runat="server"  Text='<%# Eval("PRPAYFEE")%>' ></asp:Label>
                                        </itemtemplate>
                                     </asp:TemplateField>
                                            </Columns>
                                <pagerstyle horizontalalign="Right" />
                                            <emptydatatemplate>
                                    查無資料!!
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
