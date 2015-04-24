<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="CAR3102_02.aspx.vb" Inherits="CAR_CAR3_CAR3102_02" %>

<%@ Register Src="../../UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">派車申請-維護
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 96px">類型
            </td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <uc2:ucSaCode ID="ucCarType" runat="server" ControlType="DropDownList" Code_sys="015" Code_type="002" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr id="Tr1" runat="server" visible="false" >
            <td class="htmltable_Left" style="width: 96px">車輛代號
            </td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="tbCarName" runat="server" MaxLength="30"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 96px">車牌
            </td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="tbCarId" runat="server" Enabled="false"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 96px">是否審核
            </td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <uc2:ucSaCode ID="rdoVerify" runat="server" ControlType="RadioButtonList" Code_sys="015" Code_type="008" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 96px">狀態
            </td>
            <td colspan="3">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <uc2:ucSaCode ID="rdoStatus" runat="server" ControlType="RadioButtonList" Code_sys="015" Code_type="005" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 96px">可使用單位
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:ListBox ID="usedUnit1" runat="server" Height="120px" Width="300px"
                             SelectionMode="Multiple" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 10%" align="center">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnRight" runat="server" Text=">>" Width="80px" /><br />
                        <asp:Button ID="btnLeft" runat="server" Text="<<" Width="80px" /><br />
                    </ContentTemplate>
                </asp:UpdatePanel>
                (可複選)
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:ListBox ID="usedUnit2" runat="server" Height="120px" Width="300px" SelectionMode="Multiple" DataTextField="UsedUnitcode"
                            DataValueField="Carid" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                <asp:Button ID="btnConfirm" runat="server" Text="確認" />
                <asp:Button ID="btnGiveup" runat="server" Text="放棄修改" />
                <asp:Button ID="BackBtn" runat="server" Text="回上頁" />
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
                <asp:TemplateField HeaderText="車輛類型">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname1" runat="server" Text='<%# Eval("Car_type")%>'></asp:Label>
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
                <asp:TemplateField HeaderText="需審核">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname4" runat="server" Text='<%# Eval("NeedVerify_type")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="使用單位">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname5" runat="server" Text='<%# Eval("UsedUnit_code")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="狀態">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="Label_tabname6" runat="server" Text='<%# Eval("Status_type")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="維護">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Button ID="btnMaintain" runat="server" Text="維護" CommandName="editor" CommandArgument='<%#Eval("Car_id")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="Row" />
            <HeaderStyle CssClass="Grid" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle CssClass="EmptyRow" />
        </asp:GridView>
        <uc1:Ucpager ID="Ucpager1" runat="server" PNow="1" PSize="25" EnableViewState="true" GridName="GridViewA" Visible="true" />
    </div>
</asp:Content>
