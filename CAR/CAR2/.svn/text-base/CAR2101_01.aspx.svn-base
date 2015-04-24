<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="CAR2101_01.aspx.vb" Inherits="CAR_CAR2_CAR2101_01" %>

<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register Src="../../UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="2">派車使用狀況
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 96px">用車日期
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <uc2:UcDate ID="Start_date" runat="server" />
                        ~　
                        <uc2:UcDate ID="End_date" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 96px">車輛代號
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlCarName" runat="server" AutoPostBack="true"></asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 96px">車牌
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlCarId" runat="server"></asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 96px">排序方式
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <uc3:ucSaCode ID="Sort_Style1" runat="server" Code_sys="015" Code_type="007" ControlType="DropDownList" />
                        <uc3:ucSaCode ID="Sort_Style2" runat="server" Code_sys="015" Code_type="007" ControlType="DropDownList" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="2" style="border-top: none;">
                <asp:Button ID="SelectBtn" runat="server" Text="查詢" />
                <asp:Button ID="ResetBtn" runat="server" Text="清空重填" />
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
                <asp:TemplateField HeaderText="">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="lb_pyvtype" runat="server" Text='<%# (Container.DataItemIndex + 1).ToString()%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="車輛代號">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname2" runat="server" Text='<%# Eval("Car_name")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="車牌">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname3" runat="server" Text='<%# Eval("Car_id")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="用車日期">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname4" runat="server" Text='<%# Eval("Car_date")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="用車時間">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname5" runat="server" Text='<%# Eval("Car_time")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="用車人數">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname6" runat="server" Text='<%# Eval("Passenger_cnt")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="申請人">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname7" runat="server" Text='<%# Eval("User_id")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="分機">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname8" runat="server" Text='<%# Eval("Phone_nos")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="駕駛">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname9" runat="server" Text='<%# Eval("DriverUser_id")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="到車地點">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname10" runat="server" Text='<%# Eval("Destination_desc")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="用車事由">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname6" runat="server" Text='<%# Eval("Reason_desc")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="Row" />
            <HeaderStyle CssClass="Grid" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle CssClass="EmptyRow" />
        </asp:GridView>
        <uc1:Ucpager ID="Ucpager2" runat="server"  EnableViewState="true" GridName="GridViewA"
            PNow="1" PSize="25" Visible="true"/>
    </div>

</asp:Content>

