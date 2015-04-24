<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false"
    EnableEventValidation="true"
    CodeFile="PAY2102_01.aspx.vb" Inherits="PAY2_PAY2102_01" %>
<%@ Register src="~/UControl/UcROCYear.ascx" tagname="UcROCYear" tagprefix="UcROCYear" %>
<%@ Register src="~/UControl/SAL/UcReset.ascx" tagname="UcReset" tagprefix="UcReset" %>
<%@ Register Src="~/UControl/UcBeneficiary.ascx" TagPrefix="UcBeneficiary" TagName="UcBeneficiary" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="Div_Approve_Query" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">零用金列印</td>
            </tr>
            <tr>
                <td class="htmltable_Left">年度別</td>
                <td style="width:326px">
                    <UcROCYear:UcROCYear ID="UcROCYear" runat="server"/>
                </td>
                <td class="htmltable_Left" style="width:125px">零用金流水號(起~迄)</td>
                <td style="width:326px">
                    <asp:TextBox ID="PettyCash_nosS" runat="server" Width="120px" ></asp:TextBox>
				        &nbsp;&nbsp;~&nbsp;&nbsp;
			        <asp:TextBox ID="PettyCash_nosE" runat="server" Width="120px" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">受款人姓名</td>
                <td>
                    <UcBeneficiary:UcBeneficiary runat="server" ID="ucBeneficiary" />
                </td>
                <td class="htmltable_Left">類別</td>
                <td>
                    <asp:RadioButtonList runat="server" ID="Type">
                        <asp:ListItem Text="受款人支用清單(員工及台灣銀行廠商)" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="大批匯款明細表(非台灣銀行廠商)" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left">批號(製成磁片用)</td>
                <td colspan="3">
                    <asp:TextBox ID="LotNumber" runat="server" Text="" MaxLength="2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <font size="3" color="red" >*</font>可視情況輸入所需要部份的列印條件
                </td>
            </tr>
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <asp:Button ID="PrintBtn" runat="server" Text="列印"/>
                    <UcReset:UcReset ID="ResetBtn" runat="server" btnText="清空重填"/>
                    <asp:Button ID="DiskBBtn" runat="server" Text="製成磁片"/>
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
