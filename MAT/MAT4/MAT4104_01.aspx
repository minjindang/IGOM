<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    CodeFile="MAT4104_01.aspx.vb" Inherits="MAT4104_01" %>
<%@ Register Src="~/UControl/MAT/UcMaterialId.ascx" TagPrefix="uc2" TagName="UcMaterialClass" %>
<%@ Register Src="~/UControl/UcPager.ascx" TagName="UcPager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">物品代碼、名稱對照表列印
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">物料編號(起~迄)
            </td>
            <td class="TdHeightLight">&nbsp;
                <asp:TextBox ID="material_id1" runat="server" AutoPostBack="false" MaxLength="9" />
                <uc2:UcMaterialClass runat="server" ID="UcMaterialClassB" OnChecked="UcMaterialClassB_Checked" />
				        &nbsp;&nbsp;~&nbsp;&nbsp;
                <asp:TextBox ID="material_id2" runat="server" AutoPostBack="false"  MaxLength="9" />
                <uc2:UcMaterialClass runat="server" ID="UcMaterialClassE" OnChecked="UcMaterialClassE_Checked" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 17px" class="TdHeightLight">
                <asp:Button ID="btnSelect" runat="server" Text="查詢" />
                <asp:Button ID="btnPrint" runat="server" Text="列印" />
                <asp:Button ID="btnReset" runat="server" Text="清空重填" />
            </td>
        </tr>
    </table>


    <div id="div1" runat="server" visible="false">
        <asp:GridView ID="GridView_Uporg" runat="server"
            AutoGenerateColumns="False"
            AllowPaging="true" PagerSettings-Visible="false"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" PageSize="25 ">
            <PagerSettings Visible="false" />
            <Columns>
                <asp:TemplateField HeaderText="物品代碼">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="MAT_id" runat="server" Text='<%# Eval("Material_id")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="物品名稱">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="MAT_name" runat="server" Text='<%# Eval("Material_name")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="單位">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="MAT_unit" runat="server" Text='<%# Eval("Unit")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="個人領用限量(單位/月)">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="MAT_PLimit" runat="server" Text='<%# Eval("PersonLimit_cnt")%>'></asp:Label>/
                        <asp:Label ID="MAT_PLimitMM" runat="server" Text='<%#Eval("PersonLimitMM_cnt")%> '></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="單位領用限量(單位/月)">
                    <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                    <ItemStyle CssClass="col_1" />
                    <ItemTemplate>
                        <asp:Label ID="MAT_ULimit" runat="server" Text='<%# Eval("UnitLimit_cnt")%>'></asp:Label>/
                        <asp:Label ID="MAT_ULimitMM" runat="server" Text='<%# Eval("UnitLimitMM_cnt")%>'></asp:Label>
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

