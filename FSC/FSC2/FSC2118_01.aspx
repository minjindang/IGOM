<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="FSC2118_01.aspx.vb" Inherits="FSC2_FSC2118_01" EnableEventValidation="false"%>

<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx"  TagName="UcDDLDepart" TagPrefix="uc3" %>
<%@ Register Src="~/UControl/UcDDLDepart02.ascx"  TagName="UcDDLDepart02" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">
                敘獎紀錄查詢
            </td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="4">
                查詢條件
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"  style="width:100px ">
                提報單位
            </td>
            <td class="TdHeightLight">
                <uc1:UcDDLDepart02 ID="ddlDept" runat="server" />
            </td>
            <td class="TdHeightLight">
                考績會日期
            </td>
            <td class="TdHeightLight">
                <uc2:UcDate ID="UcCouncilDateStart" runat="server" />&nbsp;~<uc2:UcDate ID="UcCouncilDateEnd" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"  style="width:100px ">
                提報日期
            </td>
            <td class="TdHeightLight" colspan="3">
                <uc2:UcDate ID="UcApplyDateStart" runat="server" />&nbsp;~<uc2:UcDate ID="UcApplyDateEnd" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"  style="width:100px ">
                獎勵令日期
            </td>
            <td class="TdHeightLight">
                <uc2:UcDate ID="UcRewordDateStart" runat="server" />&nbsp;~<uc2:UcDate ID="UcRewordDateEnd" runat="server" />
            </td>
            <td class="TdHeightLight">
                 獎勵令文號
            </td>
            <td class="TdHeightLight">
                 <asp:TextBox ID="tbRewordDoc" runat="server" MaxLength="30"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left"  style="width:100px ">
                獎懲人員單位
            </td>
            <td class="TdHeightLight">
                <uc3:UcDDLDepart ID="ddlRewordDepartID" runat="server" />
            </td>
            <td class="TdHeightLight">
                 官職等
            </td>
            <td class="TdHeightLight">
                <asp:DropDownList ID="ddlRewordLevel" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <%--<tr>
            <td class="htmltable_Left"  style="width:100px ">
                選擇匯出之欄位
            </td>
            <td class="TdHeightLight" colspan="3">
                <asp:CheckBox ID="cbExport01" runat="server" Text="提報單位" Checked="True" />&nbsp;
                <asp:CheckBox ID="cbExport02" runat="server" Text="人員類別" />&nbsp;
                <asp:CheckBox ID="cbExport03" runat="server" Text="獎懲令文號" />&nbsp;
                <asp:CheckBox ID="cbExport04" runat="server" Text="適用事由類別" />&nbsp;
                <asp:CheckBox ID="cbExport05" runat="server" Text="創新性" />
                <br />
                <asp:CheckBox ID="cbExport06" runat="server" Text="敘獎人員單位" />&nbsp;
                <asp:CheckBox ID="cbExport07" runat="server" Text="官職等" />&nbsp;
                <asp:CheckBox ID="cbExport08" runat="server" Text="提報日期" />&nbsp;
                <asp:CheckBox ID="cbExport09" runat="server" Text="自評點數" />&nbsp;
                <asp:CheckBox ID="cbExport10" runat="server" Text="困難度" />
                <br />
                <asp:CheckBox ID="cbExport11" runat="server" Text="敘獎人姓名" />&nbsp;
                <asp:CheckBox ID="cbExport12" runat="server" Text="獎懲種類" />&nbsp;
                <asp:CheckBox ID="cbExport13" runat="server" Text="敘獎事由" />&nbsp;
                <asp:CheckBox ID="cbExport14" runat="server" Text="最近一次相關案例敘獎點數" />&nbsp;
                <asp:CheckBox ID="cbExport15" runat="server" Text="貢獻度(成效)" />
                <br />
                <asp:CheckBox ID="cbExport16" runat="server" Text="職稱" />&nbsp;
                <asp:CheckBox ID="cbExport17" runat="server" Text="獎懲令日期" />
            </td>
        </tr>--%>
        <tr>
            <td align="center" colspan="4" style="height: 17px" class="TdHeightLight">
                <asp:Button ID="btnQuery" runat="server" Text="查詢" />&nbsp;
                <%--<asp:Button ID="btnPrint" runat="server" Text="匯出" />--%>
            </td>
        </tr>
    </table>
    <br />
    <table id="dataList" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title2" style="width: 100%" align="center">
                敘獎查詢明細
            </td>
        </tr>
        <tr>
            <td style="width: 100%" class="TdHeightLight" valign="top">
                <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30"
                    BorderWidth="0px" CssClass="Grid" PagerStyle-HorizontalAlign="Right" Width="100%" EmptyDataText="查無資料!!">
                    <Columns>
                        <asp:BoundField DataField="Num" HeaderText="項次" ></asp:BoundField>
                        <asp:BoundField DataField="DepartName" HeaderText="提報單位" ></asp:BoundField>
                        <asp:BoundField DataField="ApplyDate" HeaderText="提報日期" ></asp:BoundField>
                        <asp:BoundField DataField="RewordDate" HeaderText="獎勵令日期" ></asp:BoundField>
                        <asp:BoundField DataField="RewordDoc" HeaderText="獎勵令文號" ></asp:BoundField>
                        <asp:BoundField DataField="RewordDepartName" HeaderText="獎懲人員單位" ></asp:BoundField>
                        <asp:BoundField DataField="RewordUserName" HeaderText="獎懲人員姓名" ></asp:BoundField>
                        <asp:BoundField DataField="RewordLevel" HeaderText="獎懲人員官職等" ></asp:BoundField>
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
               <uc1:Ucpager ID="Ucpager" runat="server" EnableViewState="true" GridName="gvlist" PNow="1" PSize="30" Visible="true" />
            </td>
       </tr>
    </table>
    <asp:GridView ID="grdExcel" runat="server" Visible="False"></asp:GridView>
</asp:Content>
