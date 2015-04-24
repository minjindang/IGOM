<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC3108_01.aspx.vb" Inherits="FSC3108_01"  %>

<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>
<%@ Register src="~/UControl/UcDate.ascx" tagname="UcShowDate" tagprefix="uc3" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc1" TagName="UcDDLMember" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table width="100%" class="tableStyle99">
            <tr>
                <td class="htmltable_Title" colspan="2">刷卡記錄更新維護</td>
            </tr>
            <tr>
                <td class="htmltable_Title2" colspan="2">查詢條件</td>
            </tr>
            <tr>
                <td class="htmltable_Left">人員姓名</td>
                <td>                   
                    <uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />
                    <uc1:UcDDLMember runat="server" ID="ddlName" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">刷卡日期</td>
                <td>
                   <uc3:UcShowDate ID="UcDate1" runat="server" />
                   ~
                   <uc3:UcShowDate ID="UcDate2" runat="server" />
                   <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※填寫範例:101/01/01"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="height: 24px">進出種類</td>
                <td style="height: 24px">
                    <asp:DropDownList ID="ddlPHITYPE" runat="server">
                        <asp:ListItem Value="">全部</asp:ListItem>
                        <asp:ListItem Value="A">A:上班進</asp:ListItem>
                        <asp:ListItem Value="D">D:下班出</asp:ListItem>
                        <asp:ListItem Value="E">E:加班進</asp:ListItem>
                        <asp:ListItem Value="F">F:加班出</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="htmltable_Left">刷卡時間</td>
                <td>
                    <asp:TextBox ID="tbPHITIME" runat="server" MaxLength="4" Width="56px" onchange="checkTime(this.id)"></asp:TextBox>
                    <asp:Label ID="lbtip2" runat="server" ForeColor="Blue" Text="※填寫範例:1230"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" class="TdHeightLight" colspan="2">
                    <asp:Button ID="toSelect" runat="server" Text="查詢" /><asp:Button ID="toReset" runat="server"
                        Text="重填" /><asp:Button ID="toBatch" runat="server" Text="批次維護" /></td>
            </tr>
        </table>
        <table id="table1" runat="server" visible="false" width="100%">
            <tr>
                <td class="htmltable_Title2">查詢結果</td>
            </tr>
            <tr>
                <td style="height: 390px" valign="top">
                    <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="30"
                        CssClass="Grid" Width="100%">
                        <PagerSettings Position="TopAndBottom" />
                        <RowStyle CssClass="Row" />
                        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                        <Columns>
                            <asp:BoundField DataField="PHCARD" HeaderText="刷卡代碼" />
                            <asp:BoundField DataField="PHIDATE" HeaderText="刷卡日期" />
                            <asp:BoundField DataField="PHITYPE" HeaderText="進出種類" />
                            <asp:BoundField DataField="PHITIME" HeaderText="刷卡時間" />
                            <asp:BoundField DataField="Change_userid" HeaderText="異動人員" />
                            <asp:BoundField DataField="Change_date" HeaderText="異動日期" />
                            <asp:TemplateField HeaderText="維護" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="toUpdate" runat="server" CausesValidation="false" CommandName="toUpdate"
                                        Text="修改" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle HorizontalAlign="Right" />
                        <EmptyDataTemplate>
                            查無資料
                        </EmptyDataTemplate>
                        <AlternatingRowStyle CssClass="AlternatingRow" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

