<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="CAR3101_01.aspx.vb" Inherits="CAR3101_01" %>
<%@ Register Src="~/UControl/UcPager.ascx" TagName="UcPager" TagPrefix="uc1" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register src="~/UControl/UcROCYear.ascx" tagname="UcROCYear" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">車輛基本資料維護
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">購置年份(起~迄)</td>
            <td class="htmltable_Right" style="width: 100px">
                <table>
                    <tr>                        
                        <td><uc4:ucrocyear id="ddl_yy1" runat="server" /></td>
                        <td>~</td>
                        <td><uc4:ucrocyear id="ddl_yy2" runat="server" /></td>
                    </tr>
                </table>
            </td>
<%--            </td>
            <td class="TdHeightLight" colspan="3">&nbsp; 民國                                                                              
                
                <asp:DropDownList ID="ddl_yy1" runat="server" AutoPostBack="false" />年
                ~ 民國
                 <asp:DropDownList ID="ddl_yy2" runat="server" AutoPostBack="false" />年
            </td>--%>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">廠牌
            </td>
            <td class="TdHeightLight" colspan="3">
                <asp:TextBox ID="tbBrandName" runat="server" AutoPostBack="false" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">車牌
            </td>
            <td class="TdHeightLight" colspan="3">
                <asp:TextBox ID="tbCarID" runat="server" AutoPostBack="false" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">報廢日期</td>
            <td class="TdHeightLight">
            <uc2:UcDate ID="tbScrapDate" runat="server" />
            <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※填寫範例:101/01/01"></asp:Label>
            </td>
        <%--    <td class="TdHeightLight" colspan="3">
                <asp:TextBox ID="tbScrapDate" runat="server" AutoPostBack="false" />
            </td>--%>
        </tr>
        <tr>
            <td align="center" colspan="4" style="height: 17px" class="TdHeightLight">
                <asp:Button ID="btnSelect" runat="server" Text="查詢" UseSubmitBehavior="false" />
                <asp:Button ID="btnInsert" runat="server" Text="新增" />
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
                        <asp:Label ID="Label_tabname1" runat="server" Text='<%# Eval("Car_id")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="購置年月">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname2" runat="server" Text='<%# Eval("Buy_date")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="汽缸容量">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname3" runat="server" Text='<%# Eval("CylinderCapacity_cnt")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="廠牌">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname4" runat="server" Text='<%# Eval("Brand_name")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="出廠年月">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname5" runat="server" Text='<%# Eval("Manufacture_date")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="強制險日期(每年)">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname6" runat="server" Text='<%# Eval("ComInsurance_date")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="全險日期">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname7" runat="server" Text='<%# Eval("Insurance_date")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="報廢日期">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname8" runat="server" Text='<%# Eval("Scrap_date")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="維護">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Button ID="btnMaintain" runat="server" Text="維護" CommandName="editor" CommandArgument='<%#Eval("Car_id")%>' />
                        <asp:Button ID="btnDelete" runat="server" Text="刪除" CommandName="remove" CommandArgument='<%#Eval("Car_id")%>' OnClientClick="if(!confirm('是否確定刪除？'))return false; blockUI()"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="Row" />
            <HeaderStyle CssClass="Grid" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle CssClass="EmptyRow" />
        </asp:GridView>
        <uc1:UcPager ID="Ucpager1" runat="server" PNow="1" PSize="25" EnableViewState="true" GridName="GridViewA" Visible="true" />
    </div>

</asp:Content>

