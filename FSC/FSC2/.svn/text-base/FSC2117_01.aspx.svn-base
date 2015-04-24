<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC2117_01.aspx.vb" Inherits="FSC2117_01" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register src="~/UControl/UcShowDate.ascx" tagname="UcShowDate" tagprefix="uc3" %>
<%@ Register src="~/UControl/UcShowTime.ascx" tagname="UcShowTime" tagprefix="uc4" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc6" TagName="UcDDLMember" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/FSC/UcAuthorityMember.ascx" TagPrefix="uc1" TagName="UcAuthorityMember" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="TABLE1" runat="server" width="100%">
        <tr>
            <td align="left" style="height: 1px" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title" colspan="4">
                            悠遊卡刷卡紀錄查詢
                        </td>
                    </tr>
                    <tr>                    
                        <td class="htmltable_Left" style="width:100px; height: 19px;">
                            單位別
                        </td>
                        <td class="TdHeightLight" style="width:250px; height: 19px;">
                            <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
                        </td>
                        
                    </tr>
                    <tr>
                         <td class="htmltable_Left" style="width: 100px">員工姓名</td>
                         <td class="htmltable_Right" style="width:250px">
                         <uc6:UcDDLMember runat="server" ID="UcDDLMember" /></td>
                    </tr>
                        <tr>
                        <td class="htmltable_Left" style="width:100px">
                            員工編號</td>
                            <td class="htmltable_Right">
                                <uc1:UcAuthorityMember runat="server" ID="UcAuthorityMember" />
                            </td>
                        </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px"><span style="color:Red">*</span>出勤日期</td>
                            <td class="TdHeightLight">
                            <uc2:UcDate ID="UcDate1" runat="server" />~
                            <uc2:UcDate ID="UcDate2" runat="server" />
                            <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※填寫範例:101/01/01"></asp:Label>
                        </td>
                    </tr>
               
                        <tr>
                            <td class="htmltable_Left" style="width:120px; height: 26px;">在職狀態</td>
                            <td class="htmltable_Right" style="height: 26px">
                                <asp:DropDownList ID="ddlQuit_Job" runat="server" AppendDataBoundItems="True">
                                    <asp:ListItem Value="N" Text="現職員工"></asp:ListItem>
                                    <asp:ListItem Value="Y" Text="離職員工"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="留職停薪"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    
                           <tr>
                        <td class="htmltable_Left" style="width:100px">
                            職稱
                        </td>
                         <td class="htmltable_Right" style="height: 26px" >
                        <asp:DropDownList ID="ddlTitle_name" runat="server" AppendDataBoundItems="True" >
                            </asp:DropDownList>
                             </td>
                           </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px">人員類別
                        </td>
                        <td class="htmltable_Right" style="height: 26px">
                            <asp:DropDownList ID="ddlEmployeetype" runat="server" AppendDataBoundItems="True">
                            </asp:DropDownList>
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
                        <td class="htmltable_Title2" style="width: 100%" align="center">
                            查詢結果
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%" class="TdHeightLight" valign="top">
                            <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="false" BorderWidth="0px" PageSize="30"
                                AllowPaging="true" CssClass="Grid" PagerStyle-HorizontalAlign="right" Width="100%"
                                EmptyDataText="查無資料!!">
                                <Columns>
                                    <asp:TemplateField HeaderText="項次">
                                        <ItemStyle HorizontalAlign="Center" Width="15px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lb_pyvtype" runat="server" Text='<%# (container.dataitemindex+1).tostring() %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="單位名稱">
                                        <ItemStyle HorizontalAlign="Center" Width="160px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbDepart_name" runat="server" Text='<%# Eval("Depart_name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="員工編號">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                        <Itemtemplate>
                                            <asp:Label ID="lbPKCARD" runat="server" Text='<%# Eval("PKCARD")%>'></asp:Label><br />
                                            </Itemtemplate>
                                            </asp:TemplateField>
                                          <asp:TemplateField HeaderText="員工姓名">
                                              <itemstyle horizontalalign="Center" width="75px" />
                                              <headerstyle horizontalalign="Center" verticalalign="Middle" width="60px" />
                                              <itemtemplate>
                                          <asp:Label ID="lbPKNAME" runat="server"  Text='<%# Eval("PKNAME")%>'></asp:Label><br/>                    
                                              </itemtemplate>
                                          </asp:TemplateField>

                                            <asp:TemplateField HeaderText="刷卡日期">
                                                <itemstyle horizontalalign="Center" width="145px" />
                                                <headerstyle horizontalalign="Center" verticalalign="Middle" width="45px" />
                                                <itemtemplate>
                                            <uc3:UcShowDate ID="UcShowDate" runat="server" Text='<%# Eval("PKWDATE")%>'/>
                                        </itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="上班刷卡時間">
                                                <itemstyle horizontalalign="Center" width="145px" />
                                                <headerstyle horizontalalign="Center" verticalalign="Middle" width="45px" />
                                                <itemtemplate>
                                            <uc4:UcShowTime ID="UcShowTimestart" runat="server" Text='<%# Eval("PKSTIME")%>'/>
                                        </itemtemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="下班刷卡時間">
                                                <itemstyle horizontalalign="Center" width="145px" />
                                                <headerstyle horizontalalign="Center" verticalalign="Middle" width="45px" />
                                                <itemtemplate>
                                            <uc4:UcShowTime ID="UcShowTimeend" runat="server" Text='<%# Eval("PKETIME")%>'/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                    <asp:TemplateField HeaderText="曠職">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbAbsense" runat="server" Text='<%# Bind("Absent")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                        <%--    <asp:TemplateField HeaderText="免刷事由">
                                                <itemstyle horizontalalign="Center" />
                                                <headerstyle horizontalalign="Center" verticalalign="Middle" />
                                                <itemtemplate>
                                            <asp:Label ID="lbleave_hours" runat="server" Text='<%# Eval("PKNAME")%>'></asp:Label>
                                        </itemtemplate>
                                            </asp:TemplateField>--%>

                                            <asp:TemplateField HeaderText="備註">
                                                <itemstyle horizontalalign="Center" />
                                                <headerstyle horizontalalign="Center" verticalalign="Middle" />
                                                <itemtemplate>
                                                    <%--<asp:Label ID="lbabsenthours" runat="server" Text='<%# Eval("PKNAME")%>'></asp:Label>--%>
                                         
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
