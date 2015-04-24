<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC2109_01.aspx.vb" Inherits="FSC2109_01"  %>

<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register Src="../../UControl/UcShowDate.ascx" TagName="UcShowDate" TagPrefix="uc3" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc2" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc2" TagName="UcDDLAuthorityMember" %>
<%@ Register Src="~/UControl/FSC/UcAuthorityMember.ascx" TagPrefix="uc2" TagName="UcAuthorityMember" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">署內值日表
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
            <td class="htmltable_Left" style="width: 100px">員工姓名
            </td>
            <td class="TdHeightLight">
                <uc2:UcDDLAuthorityMember runat="server" ID="UcDDLAuthorityMember" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 100px">員工編號
            </td>
            <td class="TdHeightLight">
                <uc2:UcAuthorityMember runat="server" ID="UcAuthorityMember" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 100px">在職狀態
            </td>
            <td class="TdHeightLight">
                <asp:DropDownList ID="ddlQuit" runat="server">
                    <asp:ListItem Value="N">現職人員</asp:ListItem>
                    <asp:ListItem Value="Y">離職人員</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 100px">性別
            </td>
            <td class="TdHeightLight">
                <asp:DropDownList ID="ddlSex" runat="server">
                    <asp:ListItem Value="">請選擇</asp:ListItem>
                    <asp:ListItem Value="1">男</asp:ListItem>
                    <asp:ListItem Value="0">女</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 100px">值班日期
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
            <td class="htmltable_Title2" style="width: 100%" align="center">查詢結果
            </td>
        </tr>
        <tr>
            <td style="width: 100%" class="TdHeightLight" valign="top">
                <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30"
                    BorderWidth="0px" CssClass="Grid" PagerStyle-HorizontalAlign="Right" Width="100%"
                    EmptyDataText="查無資料!!">
                    <Columns>
                        <asp:BoundField DataField="Id_card" HeaderText="員工編號"></asp:BoundField>
                        <asp:BoundField DataField="User_name" HeaderText="員工姓名"></asp:BoundField>
                        <asp:BoundField DataField="Depart_Name" HeaderText="單位"></asp:BoundField>
                        <asp:BoundField DataField="Title_Name" HeaderText="職稱"></asp:BoundField>
                        <asp:BoundField DataField="Sche_date" HeaderText="值班日期"></asp:BoundField>
                        <asp:BoundField DataField="Sche_Name" HeaderText="值班類別"></asp:BoundField>
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
            <td align="center" class="htmltable_Title2" colspan="2">查詢結果
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" style="height: 21px" class="EmptyRow">查無資料!!
            </td>
        </tr>
    </table>
</asp:Content>
