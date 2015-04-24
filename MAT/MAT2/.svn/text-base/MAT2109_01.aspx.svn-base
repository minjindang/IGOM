<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    EnableEventValidation="true"
    CodeFile="MAT2109_01.aspx.vb" Inherits="MAT2_MAT2109_01" %>
<%@ Register Src="~/UControl/UcPager.ascx" TagName="UcPager" TagPrefix="uc1" %>
<%@ Register src="~/UControl/SAL/ucSaCode.ascx" tagname="ucSaCode" tagprefix="uc2" %>
<%@ Register src="~/UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc4" %>
    <%@ Register src="~/UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc3" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">領物核准清單列印</td>
            </tr>
            <tr>
                <td class="htmltable_Left" style="width:200px">單位主管領用日期(起~迄)</td>
                <td  colspan="3">
                    <uc3:UcDate ID="ReceiveDayS" runat="server" Text=""/>
					     ~ 
                    <uc3:UcDate ID="ReceiveDayE" runat="server" Text=""/>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">核准編號(起~迄)</td>
                <td  colspan="3">
                    <asp:TextBox ID="Approved_idS" runat="server" Width="120px" Text="" MaxLength="11"></asp:TextBox>
				        &nbsp;&nbsp;~&nbsp;&nbsp;
			        <asp:TextBox ID="Approved_idE" runat="server" Width="120px" Text="" MaxLength="11"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <%--<asp:Button ID="SelectBtn" runat="server" Text="查詢"/>--%>
                    <asp:Button ID="PrintBtn" runat="server" Text="列印"/>
                    <asp:Button ID="ResetBtn" runat="server" Text="清空重填" OnClick="ResetBtn_Click"/>
                </td>
            </tr>
        </table>
        <div id="div1" runat="server" visible="false">
            <asp:GridView ID="GridViewA" runat="server"
                AutoGenerateColumns="false"
                AllowPaging="true" PagerSettings-Visible="true"
                CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" EmptyDataText="查無資料!">
                <PagerSettings Visible="False"/>
                <Columns>
                    
                    <asp:TemplateField HeaderText="領用類別">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center"/>
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Label ID="Form_type" runat="server" Text='<%# Eval("Form_type")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="單位別">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Label ID="Unit_Code" runat="server" Text='<%# Eval("Unit_Code")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="姓名">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Label ID="User_name" runat="server" Text='<%# Eval("User_name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="申請日期">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Label ID="Apply_date" runat="server" Text='<%# Eval("Apply_date")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>     
                    <asp:TemplateField HeaderText="領用日期">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Label ID="Out_date" runat="server" Text='<%# Eval("Out_date")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="物料編號">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Label ID="Material_id" runat="server" Text='<%# Eval("Material_id")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="物料名稱">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Label ID="Material_name" runat="server" Text='<%# Eval("Material_name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>     
                    <asp:TemplateField HeaderText="單位">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Label ID="Unit" runat="server" Text='<%# Eval("Unit")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>   
                    <asp:TemplateField HeaderText="申請數量">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
                        <ItemTemplate>
                            <asp:Label ID="Apply_cnt" runat="server" Text='<%# Eval("Apply_cnt")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>   
                    <asp:TemplateField HeaderText="領用數量">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemStyle CssClass="col_1" />
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
            <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="GridViewA"
                    PNow="1" PSize="25" Visible="true" />
        </div>
    </div>

</asp:Content>
