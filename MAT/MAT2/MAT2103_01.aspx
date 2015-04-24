<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master"
    AutoEventWireup="false" CodeFile="MAT2103_01.aspx.vb" Inherits="MAT2103_01" %>

<%@ Register Src="~/UControl/UcPager.ascx" TagName="UcPager" TagPrefix="uc1" %>
<%@ Register Src="~/UControl/MAT/UcMaterialId.ascx" TagPrefix="uc2" TagName="UcMaterialClass" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">物品庫存量查詢
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">物料編號(起~迄)
            </td>
            <td class="TdHeightLight">&nbsp;
               
                <asp:TextBox ID="material_id1" runat="server" AutoPostBack="true" MaxLength="9" />
                <uc2:UcMaterialClass runat="server" ID="UcMaterialClassB" OnChecked="UcMaterialClassB_Checked" />
                &nbsp;&nbsp;~&nbsp;&nbsp;
                 <asp:TextBox ID="material_id2" runat="server" AutoPostBack="true" MaxLength="9" />
                <uc2:UcMaterialClass runat="server" ID="UcMaterialClassE" OnChecked="UcMaterialClassE_Checked" />
            </td>
                         
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 17px" class="TdHeightLight">
                <asp:Button ID="btnSelect" runat="server" Text="查詢" />
                <asp:Button ID="btnReset" runat="server" Text="清空重填" />
                <asp:Button ID="btnPrint" runat="server" Text="列印" />
            </td>
        </tr>
    </table>



    <div id="div1" runat="server" visible="false">
        <asp:GridView ID="GridView_Uporg" runat="server"
            AutoGenerateColumns="False"
            AllowPaging="true" PagerSettings-Visible="false"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無資料!" PageSize="25">
            <PagerSettings Visible="false" />
            <Columns>
                <asp:TemplateField HeaderText="編號">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="MAT_id" runat="server" Text='<%# Eval("Material_id")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="物料名稱">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:Label ID="MAT_name" runat="server" Text='<%# Eval("Material_name")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="單位">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:Label ID="MAT_unit" runat="server" Text='<%# Eval("Unit")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="安全庫存">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:Label ID="MAT_safe" runat="server" Text='<%# Eval("Safe_cnt")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="目前庫存">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:Label ID="MAT_reserve" runat="server" Text='<%# Eval("Reserve_cnt")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="Row" />
            <HeaderStyle CssClass="Grid" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
            <EmptyDataRowStyle CssClass="EmptyRow" />
        </asp:GridView>
        <uc1:UcPager ID="Ucpager1" runat="server" EnableViewState="true" GridName="GridView_Uporg"
            PNow="1" PSize="25" Visible="true" />
    </div>

</asp:Content>

