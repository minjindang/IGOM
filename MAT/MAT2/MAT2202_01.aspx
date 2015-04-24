<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MAT2202_01.aspx.vb" Inherits="MAT2202_01" %>
<%@ Register Src="~/UControl/MAT/UcMaterialId.ascx" TagPrefix="uc1" TagName="UcMaterialClass" %>
<%@ Register src="../../UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">物品盤點後調整報表
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">物料編號(起~迄)
            </td>
            <td >
                <asp:TextBox ID="tbMaterial_id1" runat="server" AutoPostBack="true" MaxLength="9" ></asp:TextBox>
                <uc1:UcMaterialClass runat="server" ID="UcMaterialClassB" OnChecked="UcMaterialClassB_Checked" />
                &nbsp;&nbsp;~&nbsp;&nbsp;
                <asp:TextBox ID="tbMaterial_id2" runat="server" AutoPostBack="true" MaxLength="9" ></asp:TextBox>
                <uc1:UcMaterialClass runat="server" ID="UcMaterialClassE" OnChecked="UcMaterialClassE_Checked" />
            </td>
          </tr>
        <tr>
            <td class="htmltable_Left">盤點日期(起~迄)
            </td>
            <td >
              
                <uc2:UcDate ID="UcDate1" runat="server"  />　
                ～　
                <uc2:UcDate ID="UcDate2" runat="server" />                             
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                <asp:Button ID="QueryBtn" runat="server" Text="查詢" />
                <asp:Button ID="PrintBtn" runat="server" Text="列印" OnClick="PrintBtn_Click"/>
                <asp:Button ID="ResetBtn" runat="server" Text="清空重填" />
            </td>
        </tr>
        <tr>
            <td style="height: 358px" valign="top" colspan="4">
                <table id="tbq" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%"
                    visible="false" class="tableStyle99">
                    <tr>
                        <td class="htmltable_Title2" style="width: 100%" align="center">查詢結果
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%" class="TdHeightLight" valign="top">
                            <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="false" BorderWidth="0px" PageSize="30"
                                AllowPaging="true" CssClass="Grid" PagerStyle-HorizontalAlign="right" Width="100%"
                                EmptyDataText="查無資料!!">
                                <Columns>
                                    <asp:TemplateField HeaderText="物料編號">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbMaterial_id" runat="server" Text='<%# Eval("Material_id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="物料名稱">
                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbMaterial_name" runat="server" Text='<%# Eval("Material_name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="盤點前數量">
                                        <ItemStyle HorizontalAlign="Center" Width="45px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="65px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbInvBefore_cnt" runat="server" Text='<%# Eval("InvBefore_cnt")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="盤點後數量">
                                        <ItemStyle HorizontalAlign="Center" Width="45px"/>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbInvAfter_cnt" runat="server" Text='<%# Eval("InvAfter_cnt")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="調整數量">
                                        <ItemStyle HorizontalAlign="Center" Width="45px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbInvModify_cnt" runat="server" Text='<%# Bind("InvModify_cnt")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="差異解釋說明">
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbDiff_desc" runat="server" Text='<%# Eval("Diff_desc")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle HorizontalAlign="Right" />
                                <EmptyDataTemplate>
                                    查無資料!!
                                </EmptyDataTemplate>
                                <RowStyle CssClass="Row" />
                                <HeaderStyle CssClass="Grid" />
                                <AlternatingRowStyle CssClass="AlternatingRow" />
                                <PagerSettings Position="TopAndBottom" />
                                <EmptyDataRowStyle CssClass="EmptyRow" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="TdHeightLight" style="width: 100%">
                            <uc1:Ucpager ID="Ucpager" runat="server" EnableViewState="true" GridName="gvlist"
                                PNow="1" PSize="30" Visible="true" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

                <%--<uc1:Ucpager ID="Ucpager1" runat="server" />--%>

</asp:Content>

