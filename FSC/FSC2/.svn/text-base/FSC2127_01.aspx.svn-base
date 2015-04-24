<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC2127_01.aspx.vb" Inherits="FSC2127_01" %>
    
<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc6" TagName="UcDDLMember" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="TABLE1" runat="server" width="100%">
        <tr>
            <td align="left" style="height: 1px" valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title" colspan="4">
                            刷卡資料查詢
                        </td>
                    </tr>
                    <tr id="tr0" runat="server">                    
                        <td class="htmltable_Left" style="width:100px; height: 19px;">
                            單位別
                        </td>
                        <td class="TdHeightLight" style="width:250px; height: 19px;">
                            <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" OnSelectedIndexChanged="UcDDLDepart_SelectedIndexChanged" />
                        </td>
                        
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width: 100px">員工姓名</td>
                        <td class="htmltable_Right" style="width:250px">
                            <uc6:UcDDLMember runat="server" ID="UcDDLMember" /></td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" style="width:100px">
                            刷卡日期</td>
                        <td class="TdHeightLight" style="width:250px" colspan="3">
                            <uc2:UcDate runat="server" ID="UcDateS" />
                            ~
                            <uc2:UcDate runat="server" ID="UcDateE" />
                         </td>   
                    </tr>
                    <tr>
                        <td align="center" colspan="4" class="TdHeightLight">
                            <asp:Button ID="btnQuery" runat="server" Text="查詢" UseSubmitBehavior="false" />
                            <input id="Reset" type="button" value="重填" runat="server"  Visible="false"/>
                            <asp:Button ID="btnPrint" runat="server" Enabled="false" Text="列印" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 358px" valign="top">
                <table id="dataTable" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%"
                    visible="false" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title2" style="width: 100%" align="center">
                            查詢結果
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%" class="TdHeightLight" valign="top">
                            <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30"
                                Borderwidth="0px" CssClass="Grid" PagerStyle-HorizontalAlign="Right" width="100%" EmptyDataText="查無資料">
                                <Columns>
                                    <asp:BoundField DataField="User_name" HeaderText="人員姓名" HeaderStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Center" >
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PHIDATE" HeaderText="刷卡日期" HeaderStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Center" >
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PHITIME" HeaderText="刷卡時間" HeaderStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Center">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PHITYPE" HeaderText="刷卡種類" HeaderStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="Center">
                                    </asp:BoundField>
                                </Columns>

                                <EmptyDataTemplate>
                                    查無資料!!
                                </EmptyDataTemplate>
                                <PagerStyle HorizontalAlign="Right" />                    
                                <RowStyle CssClass="Row" />
                                <AlternatingRowStyle CssClass="AlternatingRow" />
                                <PagerSettings Position="TopAndBottom" />
                                <EmptyDataRowStyle  CssClass="EmptyRow" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TdHeightLight" style="width: 100%">
                            <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="gvList"
                                PNow="1" PSize="30" Visible="true" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
