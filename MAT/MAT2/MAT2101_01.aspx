<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master"
    AutoEventWireup="false" CodeFile="MAT2101_01.aspx.vb" Inherits="MAT2101_01" %>

<%@ Register Src="~/UControl/UcPager.ascx" TagName="UcPager" TagPrefix="uc1" %>

<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc2" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc1" TagName="UcDate" %>
<%@ Register Src="~/UControl/MAT/UcDDLMatDepart.ascx" TagPrefix="uc1" TagName="UcDDLMatDepart" %>
<%@ Register Src="~/UControl/MAT/ucDDLMatMember.ascx" TagPrefix="uc1" TagName="ucDDLMatMember" %>
<%@ Register Src="~/UControl/MAT/UcMaterialId.ascx" TagPrefix="uc1" TagName="UcMaterialClass" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="4">領用物品查詢
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">領用類別
            </td>
            <td class="TdHeightLight" colspan="3"  runat="server" id="tdType">
                <%--<uc2:ucSaCode ID="ucSaCode1" runat="server" Code_sys="014" Code_type="001"  ControlType="RadioButtonList"/>--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <uc2:ucSaCode ID="ucType"  runat="server" Code_sys='014' Code_type='001' ControlType="RadioButtonList" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">物料編號(起~迄)
            </td>
            <td class="TdHeightLight">&nbsp;
                <asp:TextBox ID="material_id1" runat="server" AutoPostBack="false" MaxLength="9" />
                <uc1:UcMaterialClass runat="server" ID="UcMaterialClassB" OnChecked="UcMaterialClassB_Checked" />
                    &nbsp;&nbsp;~&nbsp;&nbsp;
                 <asp:TextBox ID="material_id2" runat="server" AutoPostBack="false" MaxLength="9"/>
                 <uc1:UcMaterialClass runat="server" ID="UcMaterialClassE" OnChecked="UcMaterialClassE_Checked" />
            </td>
            <td class="htmltable_Left" style="width: 150px">領用日期(起~迄)
            </td>
            <td class="TdHeightLight">&nbsp;
                <uc1:UcDate runat="server" ID="Out_date1" />
                ~
                <uc1:UcDate runat="server" ID="Out_date2" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="width: 150px">單位別
            </td>
            <td class="TdHeightLight">
              <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlLeave_type" runat="server" AutoPostBack="false"
                            DataTextField="full_name" DataValueField="cols">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>--%>
                <uc1:UcDDLMatDepart runat="server" ID="ddlDepart_id" />
               
            </td>
            <td class="htmltable_Left" style="width: 150px">人員姓名
            </td>
            <td class="TdHeightLight">
                <uc1:ucDDLMatMember runat="server" ID="ddlUser_name" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" style="height: 17px" class="TdHeightLight">
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
            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" PageSize="25" EmptyDataText="查無資料">
            <PagerSettings Visible="false" />
            <Columns>
                <asp:TemplateField HeaderText="領用類別">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:Label ID="MAT_id" runat="server" Text='<%# Eval("CODE_DESC1")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="單位別">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:Label ID="MAT_name" runat="server" Text='<%# Eval("Unit_Code")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="姓名">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:Label ID="MAT_unit" runat="server" Text='<%# Eval("User_id")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="申請日期">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:Label ID="MAT_safe" runat="server" Text='<%# Eval("Apply_date")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="領用日期">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:Label ID="MAT_reserve" runat="server" Text='<%# Eval("Out_date")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="物料編號">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:Label ID="MAT_reserve" runat="server" Text='<%# Eval("Material_id")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="物料名稱">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:Label ID="MAT_reserve" runat="server" Text='<%# Eval("Material_name")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="單位">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:Label ID="MAT_reserve" runat="server" Text='<%# Eval("Unit")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="申請數量">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:Label ID="MAT_reserve" runat="server" Text='<%# Eval("Apply_cnt")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="領用數量">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:Label ID="MAT_reserve" runat="server" Text='<%# Eval("Out_cnt")%>'></asp:Label>
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

