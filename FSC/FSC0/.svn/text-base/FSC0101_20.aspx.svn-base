<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="FSC0101_20.aspx.cs" Inherits="FSC_FSC0_FSC0101_20" %>
<%@ Register Src="~/UControl/SYS/UcFlowDetail.ascx" TagPrefix="uc2" TagName="UcFlowDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">表單明細</td>
        </tr>
        <tr>
            <td style="width: 100%" class="TdHeightLight" valign="top">
                <asp:GridView ID="GridViewA" runat="server" OnRowDataBound="GridViewA_RowDataBound"
                    AutoGenerateColumns="False" OnPageIndexChanging="GridViewA_PageIndexChanging"
                    AllowPaging="True" PagerSettings-Visible="true"
                    CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%">
                    <Columns> 
                        <asp:BoundField DataField="Duty_userUnit" HeaderText="單位" />
                        <asp:BoundField DataField="Duty_userId" HeaderText="姓名" />
                        <asp:BoundField DataField="Duty_date" HeaderText="值班日期" />
                        <asp:BoundField DataField="Duty_sTime" HeaderText="值班起時" />
                        <asp:BoundField DataField="Duty_eTime" HeaderText="值班迄時" />
                        <%--<asp:BoundField DataField="Is_rest" HeaderText="可補休" />
                        <asp:BoundField DataField="ApplyHour_cnt" HeaderText="已補休時數" />--%>
                        <asp:BoundField DataField="ApplyHour_cnt" HeaderText="值班時數" />
                        <asp:BoundField DataField="Apply_amt" HeaderText="值班費金額" />
                        <asp:BoundField DataField="MEMO" HeaderText="備註" />
                    </Columns>
                    <RowStyle CssClass="Row" />
                    <pagerstyle horizontalalign="Right" />
                    <HeaderStyle CssClass="Grid" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle CssClass="EmptyRow" />
                </asp:GridView>
            </td> 
        </tr>
        <tr>
            <td align="right" class="TdHeightLight" style="width: 100%">
                <uc1:Ucpager ID="Ucpager" runat="server" EnableViewState="true" GridName="GridViewA"
                    PNow="1" PSize="30" Visible="true" />
            </td> 
        </tr>
    </table>
    <div align="center">
        <input id="cbPrint" type="button" value="列印" onclick="javascript: window.print();" class="nonPrinted" />  
        <asp:Button ID="btnBack" runat="server" Text="回上頁" OnClick="btnBack_Click" />
    </div>
    <uc2:UcFlowDetail runat="server" ID="UcFlowDetail" />
</asp:Content>

