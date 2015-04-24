<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC2106_01.aspx.vb" Inherits="FSC2106_01"  %>

<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register Src="../../UControl/UcShowDate.ascx" TagName="UcShowDate" TagPrefix="uc3" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc2" TagName="UcDDLDepart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">單位差假現況
            </td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="2">查詢條件
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 100px">單位別
            </td>
            <td class="TdHeightLight">
                <uc2:UcDDLDepart runat="server" ID="UcDDLDepart" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 100px">請假日期
            </td>
            <td class="TdHeightLight">
                <uc2:UcDate ID="UcDate1" runat="server" />
                &nbsp;~
                <uc2:UcDate ID="UcDate2" runat="server" />
                <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※填寫範例:101/01/01"></asp:Label>
            </td>
        </tr>
        <tr id="tr1" runat="server">
            <td class="htmltable_Left" style="width: 100px">狀態
            </td>
            <td class="TdHeightLight">
                <asp:CheckBoxList ID="cblStatus" runat="server" DataTextField="code_desc1" DataValueField="code_no" RepeatColumns="5" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 17px" class="TdHeightLight">
                <asp:Button ID="btnQuery" runat="server" Text="查詢" />
                <input id="Reset" type="button" value="重填" runat="server"  Visible="false"/>
                <asp:Button ID="btnPrint" Enabled="false" runat="server" Text="匯出" />
            </td>
        </tr>
    </table>
    <br />
    <table id="dataList" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" visible="false">
        <tr>
            <td class="htmltable_Title2" style="width: 100%" align="center">請假資料明細
            </td>
        </tr>
        <tr>
            <td style="width: 100%" class="TdHeightLight" valign="top">
                <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30"
                    BorderWidth="0px" CssClass="Grid" PagerStyle-HorizontalAlign="Right" Width="100%"
                    EmptyDataText="查無資料!!">
                    <Columns>
                        <asp:BoundField DataField="Status" HeaderText="狀態"></asp:BoundField>
                        <asp:TemplateField HeaderText="員工編號<br />員工姓名">
                            <ItemTemplate>
                                <asp:Label ID="lbFULL_Name" runat="server" Text='<%# Bind("FULL_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DayHours" HeaderText="請假日時"></asp:BoundField>
                        <asp:TemplateField HeaderText="開始日期<br />結束日期">
                            <ItemTemplate>
                                <asp:Label ID="lbSEdate" runat="server" Text='<%# Bind("SEdate")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Deputy_name" HeaderText="代理人"></asp:BoundField>
                        <asp:TemplateField HeaderText="簽核流程">
                            <ItemTemplate>
                                <asp:Label ID="lbProcess" runat="server" Text='<%# Bind("Process")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Reason" HeaderText="理由"></asp:BoundField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                    <EmptyDataTemplate>
                        查無資料!!
                    </EmptyDataTemplate>
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
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
    <table id="EmptyTable" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" visible="false">
        <tr>
            <td align="center" class="htmltable_Title2" colspan="2">請假資料明細
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" style="height: 21px" class="EmptyRow">查無資料!!
            </td>
        </tr>
    </table>
    <br />
    <table id="dataList2" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" visible="false">
        <tr>
            <td class="htmltable_Title2" style="width: 100%" align="center">公差資料明細
            </td>
        </tr>
        <tr>
            <td style="width: 100%" class="TdHeightLight" valign="top">
                <asp:GridView ID="gvList2" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30"
                    BorderWidth="0px" CssClass="Grid" PagerStyle-HorizontalAlign="Right" Width="100%"
                    EmptyDataText="查無資料!!">
                    <Columns>
                        <asp:BoundField DataField="Status" HeaderText="狀態"></asp:BoundField>
                        <asp:TemplateField HeaderText="員工編號<br />員工姓名">
                            <ItemTemplate>
                                <asp:Label ID="lbFULL_Name2" runat="server" Text='<%# Bind("FULL_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DayHours" HeaderText="公差日時"></asp:BoundField>
                        <asp:TemplateField HeaderText="開始日期<br />結束日期">
                            <ItemTemplate>
                                <asp:Label ID="lbSEdate2" runat="server" Text='<%# Bind("SEdate")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Deputy_name" HeaderText="代理人"></asp:BoundField>
                        <asp:TemplateField HeaderText="簽核流程">
                            <ItemTemplate>
                                <asp:Label ID="lbProcess2" runat="server" Text='<%# Bind("Process")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Reason" HeaderText="理由"></asp:BoundField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                    <EmptyDataTemplate>
                        查無資料!!
                    </EmptyDataTemplate>
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right" class="TdHeightLight" style="width: 100%">
                <uc1:Ucpager ID="Ucpager2" runat="server" EnableViewState="true" GridName="gvList2"
                    PNow="1" PSize="30" Visible="true" />
            </td>
        </tr>
    </table>
    <table id="EmptyTable2" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" visible="false">
        <tr>
            <td align="center" class="htmltable_Title2" colspan="2">公差資料明細
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" style="height: 21px" class="EmptyRow">查無資料!!
            </td>
        </tr>
    </table>
</asp:Content>
