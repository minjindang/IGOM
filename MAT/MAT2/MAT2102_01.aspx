<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    EnableEventValidation="true"
    CodeFile="MAT2102_01.aspx.vb" Inherits="MAT2102_01" %>

<%@ Register Src="~/UControl/UcPager.ascx" TagName="UcPager" TagPrefix="uc1" %>
<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc2" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc4" %>
<%--<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc1" TagName="UcDDLDepart" %>--%>
<%@ Register Src="~/UControl/MAT/UcMaterialId.ascx" TagPrefix="uc1" TagName="UcMaterialClass" %>
<%@ Register Src="~/UControl/MAT/UcDDLMatDepart.ascx" TagPrefix="uc1" TagName="UcDDLMatDepart" %>
<%@ Register Src="~/UControl/MAT/ucDDLMatMember.ascx" TagPrefix="uc1" TagName="ucDDLMatMember" %>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">領用量查詢</td>
            </tr>
            <tr>
                <td class="htmltable_Left">使用類別</td>
                <td style="width: 326px" colspan="3" runat="server" id="tdType">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <uc2:ucSaCode ID="ucType" runat="server" Code_sys='014' Code_type='001' ControlType="RadioButtonList" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">物料編號(起~迄)</td>
                <td style="width: 326px">
                    <asp:TextBox ID="Material_idS" runat="server" Width="120px" Text="" MaxLength="9"></asp:TextBox>
                    <uc1:UcMaterialClass runat="server" ID="UcMaterialClassB" OnChecked="UcMaterialClassB_Checked" />
                    &nbsp;&nbsp;~&nbsp;&nbsp;
			        <asp:TextBox ID="Material_idE" runat="server" Width="120px" Text="" MaxLength="9"></asp:TextBox>
                    <uc1:UcMaterialClass runat="server" ID="UcMaterialClassE" OnChecked="UcMaterialClassE_Checked" />
                </td>
                <td class="htmltable_Left">領用日期(起~迄)</td>
                <td style="width: 326px">
                    <uc4:UcDate runat="server" ID="ReceiveS" />
                    &nbsp;&nbsp;~&nbsp;&nbsp;
                    <uc4:UcDate runat="server" ID="ReceiveE" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">單位別</td>
                <td style="width: 326px">
                    <%--<uc1:UcDDLDepart runat="server" ID="UcDDLDepart" />--%>
                    <uc1:UcDDLMatDepart runat="server" ID="ddlDepart_id" />
                </td>
                <td class="htmltable_Left">人員姓名</td>
                <td style="width: 326px">
                    <%--<asp:TextBox ID="User_name" runat="server" Width="100px" Text=""></asp:TextBox>--%>
                    <uc1:ucDDLMatMember runat="server" ID="ddlUser_name" />
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">排序方式</td>
                <td style="width: 326px" colspan="3">
                    <asp:RadioButtonList ID="SortRadioButtonList" runat="server" RepeatColumns="9" RepeatLayout="Flow">
                        <asp:ListItem Value="0" Text="依領用數量" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="1" Text="依員工姓名"></asp:ListItem>
                        <asp:ListItem Value="2" Text="依物料編號"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">分頁方式</td>
                <td style="width: 326px" colspan="3">
                    <asp:RadioButtonList ID="PagingRadioButtonList" runat="server" RepeatColumns="9" RepeatLayout="Flow">
                        <asp:ListItem Value="0" Text="依單位" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="1" Text="依員工"></asp:ListItem>
                        <asp:ListItem Value="2" Text="依物料編號"></asp:ListItem>
                    </asp:RadioButtonList>

                </td>
            </tr>
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <asp:Button ID="SelectBtn" runat="server" Text="查詢" />
                    <asp:Button ID="ResetBtn" runat="server" Text="清空重填" OnClick="ResetBtn_Click" />
                    <asp:Button ID="PrintBtn" runat="server" Text="列印" />
                </td>
            </tr>
        </table>
        <div id="div1" runat="server" visible="false">
            <table class="tableStyle99" width="100%">
                <tr>
                    <td>
                        <asp:GridView ID="GridViewA" runat="server"
                            AutoGenerateColumns="false" CssClass="Grid"
                            AllowPaging="true" PagerSettings-Visible="true"
                            CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無資料!">
                            <PagerSettings Visible="False" />
                            <Columns>

                                <asp:TemplateField HeaderText="領用類別">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <asp:Label ID="Form_typeForm_type_name" runat="server" Text='<%# Eval("Form_type_name")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="單位別">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <asp:Label ID="Unit_name" runat="server" Text='<%# Eval("Unit_name")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="姓名">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <asp:Label ID="User_name" runat="server" Text='<%# Eval("User_name")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="申請日期">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <asp:Label ID="Apply_date" runat="server" Text='<%# Eval("Apply_date")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="領用日期">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <asp:Label ID="Out_date" runat="server" Text='<%# Eval("Out_date")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="物料編號">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <asp:Label ID="Material_id" runat="server" Text='<%# Eval("Material_id")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="物料名稱">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <asp:Label ID="Material_name" runat="server" Text='<%# Eval("Material_name")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="單位">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <asp:Label ID="Unit" runat="server" Text='<%# Eval("Unit")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="申請數量">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <asp:Label ID="Apply_cnt" runat="server" Text='<%# Eval("Apply_cnt")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="領用數量">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <asp:Label ID="Out_cnt" runat="server" Text='<%# Eval("Out_cnt")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="Row" />
                            <HeaderStyle CssClass="Grid" />
                            <AlternatingRowStyle CssClass="AlternatingRow" />
                            <PagerSettings Position="TopAndBottom" />
                            <EmptyDataRowStyle CssClass="EmptyRow" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:UcPager ID="Ucpager1" runat="server" EnableViewState="true" GridName="GridViewA"
                            PNow="1" PSize="25" Visible="true" />
                    </td>
                </tr>
            </table>
        </div>
    </div>

</asp:Content>
