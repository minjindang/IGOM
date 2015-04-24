<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC2128_01.aspx.vb" Inherits="FSC2128_01" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc6" TagName="UcDDLMember" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title" colspan="2">
                            員工基本資料及差假統計查詢
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">年度
                        </td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                            <asp:DropDownList ID="ddlYear" runat="server" />
                        </td>

                    </tr>
                    <tr id="tr0" runat="server">
                        <td class="htmltable_Left" style="width: 100px; height: 19px;">單位別
                        </td>
                        <td class="TdHeightLight" style="width: 250px; height: 19px;">
                            <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
                        </td>

                    </tr>
                      <tr>
                         <td class="htmltable_Left" style="width: 100px">員工姓名</td>
                         <td class="htmltable_Right" style="width:250px">
                         <uc6:UcDDLMember runat="server" ID="UcDDLMember" /></td>
                    </tr>
                    <tr id="tr1" runat="server">
                        <td class="htmltable_Left" style="width: 120px; height: 26px;">職稱</td>
                        <td class="htmltable_Right" style="height: 26px">
                            <asp:DropDownList ID="ddlJobtype" runat="server" AppendDataBoundItems="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="tr2" runat="server">
                        <td class="htmltable_Left" style="width: 120px; height: 26px;">在職狀態</td>
                        <td class="htmltable_Right" style="height: 26px">
                            <asp:DropDownList ID="ddlQuit_Job" runat="server" AppendDataBoundItems="True">
                                <asp:ListItem Value="" Text="請選擇"></asp:ListItem>
                                <asp:ListItem Value="N" Text="現職員工"></asp:ListItem>
                                <asp:ListItem Value="Y" Text="離職員工"></asp:ListItem>
                                <asp:ListItem Value="1" Text="留職停薪"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" class="TdHeightLight">
                            <asp:Button ID="btnQuery" runat="server" Text="查詢" />
                        </td>
                    </tr>
                </table>
                <br />
            <table id="tbq" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" visible="false" class="tableStyle99">
               <tr>
                   <td class="htmltable_Title2" style="width: 100%" align="center" colspan="10" >員工基本資料及差假統計</td>
               </tr>
               <%--<tr>
                   <td class="htmltable_Left">員工編號</td>
                   <td class="htmltable_Right"><asp:Label ID="lbId_card" runat="server" /></td>
                   <td class="htmltable_Left">員工姓名</td>
                   <td class="htmltable_Right"><asp:Label ID="lbUser_name" runat="server" /></td>
                   <td class="htmltable_Left">單位</td>
                   <td class="htmltable_Right" colspan="2" ><asp:Label ID="lbDepart_name" runat="server" /></td>
                   <td class="htmltable_Left" colspan="3" ><asp:Label ID="lbEmployee_type" runat="server" /></td>
               </tr>
               <tr>
                   <td class="htmltable_Title2" style="width: 100%" align="center" colspan="10" ><asp:Label ID="lbYear" runat="server" />年度可請假天數</td>
               </tr>
               <tr>
                   <td class="htmltable_Left"><asp:Label ID="lbYear2" runat="server" />年休假天數</td>
                   <td class="htmltable_Right" style="width:5%" ><asp:Label ID="lbPEHDAY" runat="server" /></td>
                   <td class="htmltable_Left">保留<asp:Label ID="lbYear4" runat="server" />年未休假天數</td>
                   <td class="htmltable_Right" style="width:5%" ><asp:Label ID="lbPERDAY1" runat="server" /></td>
                   <td class="htmltable_Left">保留<asp:Label ID="lbYear5" runat="server" />年未休假天數</td>
                   <td class="htmltable_Right" style="width:5%" ><asp:Label ID="lbPERDAY2" runat="server" /></td>
                   <td class="htmltable_Left" style="width:10%" >事假天數</td>
                   <td class="htmltable_Right" style="width:5%" ><asp:Label ID="lbPEHDAY2" runat="server" /></td>
                   <td class="htmltable_Left" style="width:10%" >病假天數</td>
                   <td class="htmltable_Right" style="width:5%" ><asp:Label ID="lbdays2" runat="server" /></td>
               </tr>
               <tr>
                   <td class="htmltable_Title2" style="width: 100%" align="center" colspan="10" ><asp:Label ID="lbYear3" runat="server" />年度已請假天數</td>
               </tr>--%>
               <tr>
                   <td style="width: 100%" class="TdHeightLight" valign="top" colspan="10" >
                            <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="false" BorderWidth="0px" PageSize="30"
                                AllowPaging="true" CssClass="Grid" PagerStyle-HorizontalAlign="right" Width="100%"
                                EmptyDataText="查無資料!!">
                                <Columns>
                                    <asp:BoundField DataField="id_card" HeaderText="員工編號" />
                                    <asp:BoundField DataField="User_name" HeaderText="員工姓名" />
                                    <asp:BoundField DataField="Depart_name" HeaderText="單位" />
                                    <asp:BoundField DataField="employee_type_name" HeaderText="人員類別" />
                                    <asp:BoundField DataField="Pehday" HeaderText="休假上限天數" />
                                    <asp:BoundField DataField="Perday1" HeaderText="前一年保留休假天數" />
                                    <asp:BoundField DataField="Perday2" HeaderText="前二年保留休假天數" />
                                    <asp:BoundField DataField="Pehday2" HeaderText="事假上限天數" />
                                    <asp:BoundField DataField="limit" HeaderText="病假上限天數" />
                                    <asp:BoundField DataField="07" HeaderText="公出" />
                                    <asp:BoundField DataField="01" HeaderText="事假" />
                                    <asp:BoundField DataField="25" HeaderText="家庭照顧假" />
                                    <asp:BoundField DataField="02" HeaderText="病假" />
                                    <asp:BoundField DataField="24" HeaderText="生理假" />
                                    <asp:BoundField DataField="08" HeaderText="婚假" />
                                    <asp:BoundField DataField="21" HeaderText="產前假" />
                                    <asp:BoundField DataField="09" HeaderText="娩假" />
                                    <asp:BoundField DataField="13" HeaderText="流產假" />
                                    <asp:BoundField DataField="22" HeaderText="陪產假" />
                                    <asp:BoundField DataField="03" HeaderText="休假" />
                                    <asp:BoundField DataField="10" HeaderText="喪假" />
                                    <asp:BoundField DataField="04" HeaderText="加班補休" />
                                    <asp:BoundField DataField="20" HeaderText="公差補休" />
                                    <asp:BoundField DataField="06" HeaderText="公假" />
                                </Columns>
                                <PagerStyle HorizontalAlign="Right" />
                                <EmptyDataTemplate>
                                    查無資料!!
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
</asp:Content>
