<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="FSC2122_01.aspx.vb" Inherits="FSC2122_01"  %>

<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register Src="../../UControl/UcShowDate.ascx" TagName="UcShowDate" TagPrefix="uc3" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc2" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/FSC/UcAuthorityMember.ascx" TagPrefix="uc2" TagName="UcMember" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc2" TagName="UcDDLAuthorityMember" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">
                線上刷卡記錄查詢
            </td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="2">
                查詢條件
            </td>
        </tr>
        <tr id="tr0" runat="server">
            <td class="htmltable_Left"  style="width:100px ">
                單位別
            </td>
            <td class="TdHeightLight">
                <uc2:UcDDLDepart runat="server" ID="UcDDLDepart" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"  style="width:100px ">
                員工姓名
            </td>
            <td class="TdHeightLight">
                <uc2:UcDDLAuthorityMember runat="server" ID="UcDDLAuthorityMember" />
            </td>
        </tr>
        <tr id="tr1" runat="server">
            <td class="htmltable_Left"  style="width:100px ">
                員工編號
            </td>
            <td class="TdHeightLight">
                <uc2:UcMember runat="server" ID="UcMember" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"  style="width:100px ">
                刷卡日期
            </td>
            <td class="TdHeightLight">
                <uc2:UcDate ID="UcDate1" runat="server" />
                &nbsp;~
                <uc2:UcDate ID="UcDate2" runat="server" />
                <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※填寫範例:101/01/01"></asp:Label>
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
            <td class="htmltable_Title2" style="width: 100%" align="center">
                查詢結果
            </td>
        </tr>
        <tr>
            <td style="width: 100%" class="TdHeightLight" valign="top">
                <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30"
                    BorderWidth="0px" CssClass="Grid" PagerStyle-HorizontalAlign="Right" Width="100%"
                    EmptyDataText="查無資料!!">
                    <Columns>
                        <asp:BoundField DataField="Num" HeaderText="項次" ></asp:BoundField>
                        <asp:BoundField DataField="Depart_Name" HeaderText="單位名稱" ></asp:BoundField>
                        <asp:BoundField DataField="FULL_Name" HeaderText="員工編號" ></asp:BoundField>
                        <asp:BoundField DataField="PHI_datetime" HeaderText="刷卡日期/時間" ></asp:BoundField>
                        <asp:BoundField DataField="PHITYPE" HeaderText="刷卡班別" ></asp:BoundField>
                        <asp:BoundField DataField="PHADDR" HeaderText="值班類別" ></asp:BoundField>
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
    <table id="EmptyTable" runat="server"  border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99" visible="false">
        <tr>
            <td align="center" class="htmltable_Title2" colspan="2">
                查詢結果
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" style="height: 21px" class="EmptyRow">
                查無資料!!
            </td>
        </tr>
    </table>
</asp:Content>
