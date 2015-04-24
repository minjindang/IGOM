<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="CAR1102_02.aspx.vb" Inherits="CAR1_CAR1102" %>

<%@ Register Src="~/UControl/UcPager.ascx" TagName="UcPager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">車輛基本資料維護-維護
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">車牌
            </td>
            <td class="TdHeightLight" colspan="3">
                <asp:TextBox ID="tbCarID" runat="server" AutoPostBack="false" Enabled="false" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">出廠年月
            </td>
            <td class="TdHeightLight" colspan="3">&nbsp; 民國
                  <asp:DropDownList ID="MA_Year" runat="server">
                  </asp:DropDownList>年
                  <asp:DropDownList ID="MA_Month" runat="server">
                  </asp:DropDownList>月
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">購置年月
            </td>
            <td class="TdHeightLight" colspan="3">&nbsp; 民國
                  <asp:DropDownList ID="BUY_Year" runat="server">
                  </asp:DropDownList>年
                  <asp:DropDownList ID="BUY_Month" runat="server">
                  </asp:DropDownList>月
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">汽缸容量
            </td>
            <td class="TdHeightLight" colspan="3">
                <asp:TextBox ID="tbCCcnt" runat="server" AutoPostBack="false" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">廠牌
            </td>
            <td class="TdHeightLight" colspan="3">
                <asp:TextBox ID="tbbrandname" runat="server" AutoPostBack="false" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">強制險日期(每年)
            </td>
            <td class="TdHeightLight" colspan="3">
                <asp:TextBox ID="tbComInsurance" runat="server" AutoPostBack="false" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">全險日期
            </td>
            <td class="TdHeightLight" colspan="3">
                <asp:TextBox ID="tbInsurance" runat="server" AutoPostBack="false" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">報廢日期
            </td>
            <td class="TdHeightLight" colspan="3">
                <asp:TextBox ID="tbScrapDate" runat="server" AutoPostBack="false" />
            </td>
        </tr>
        <tr id="tr1" runat="server" visible="false">
            <td class="htmltable_Left" style="width: 150px">更新人員資料
            </td>
            <td class="TdHeightLight" colspan="3">
                <asp:TextBox ID="tbModuserid" runat="server" AutoPostBack="false" />
                <asp:TextBox ID="tbModdate" runat="server" AutoPostBack="false" />
                <asp:TextBox ID="tbOrgCode" runat="server" AutoPostBack="false" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" style="height: 17px" class="TdHeightLight">
                <asp:Button ID="btnConfirm" runat="server" Text="確認" />
                <asp:Button ID="btnReset" runat="server" Text="清空重填" />
            </td>
        </tr>
    </table>

    <div id="div1" runat="server" visible="false">
        <asp:GridView ID="GridViewA" runat="server"
            AutoGenerateColumns="False"
            AllowPaging="True" PagerSettings-Visible="false"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" PageSize="25" EmptyDataText="查無資料!">
            <PagerSettings Visible="False" />
            <Columns>
                <asp:TemplateField HeaderText="車牌">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="lblcarid" runat="server" Text='<%# Eval("Car_id")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="購置年月">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="lblbuydate" runat="server" Text='<%# Eval("Buy_date")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="汽缸容量">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="lblCCcnt" runat="server" Text='<%# Eval("CylinderCapacity_cnt")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="廠牌">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="lblbrandname" runat="server" Text='<%# Eval("Brand_name")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="出廠年月">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="lblmadate" runat="server" Text='<%# Eval("Manufacture_date")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="強制險日期(每年)">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="lblcominsurancedate" runat="server" Text='<%# Eval("ComInsurance_date")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="全險日期">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="lblinsurancedate" runat="server" Text='<%# Eval("Insurance_date")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="報廢日期">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="lblscrapdate" runat="server" Text='<%# Eval("Scrap_date")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="Row" />
            <HeaderStyle CssClass="Grid" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle CssClass="EmptyRow" />
        </asp:GridView>
    </div>

</asp:Content>

