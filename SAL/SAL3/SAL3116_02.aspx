<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SAL3116_02.aspx.vb" Inherits="SAL_SAL3_SAL3116_02"  %>

<%@ Register Src="~/UControl/SAL/uc_Media_f040_tdpfTB.ascx" TagName="uc_Media_f040_tdpfTB"
    TagPrefix="uc2" %>

<%@ Register Src="~/UControl/SAL/uc_Media_f040_tdpfDD.ascx" TagName="uc_Media_f040_tdpfDD"
    TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<table class="table_form" style="text-align:left; ">
	<tr>
		<td>
			<table id="unit" class="table_width2">
				<tr>
					<td style="width:15%" class="form_item" colspan="4" align="center">
					    各單位銀行帳號與轉帳項目對照檔維護
					</td>
				</tr>
				<tr>
					<td style="width:15%" class="form_item" align="center">
                        機關名稱
					</td>
	                <td style="width:35%" class="form_col" >
                        <asp:Label ID="Label_orgname" runat="server" Text=""></asp:Label>
					</td>
					<td style="width:15%" class="form_item" align="center">
                        機關代號
					</td>
	                <td style="width:35%" class="form_col">
                        <asp:Label ID="Label_orgid" runat="server" Text=""></asp:Label>
					</td>
				</tr>
				<tr>
					<td style="width:15%" class="form_item" colspan="4" align="center">
					    對照檔
					</td>
				</tr>
				<tr>
				    <td class="form_item" align="center" >
				        項目類別
				    </td>
				    <td colspan="3">
                        <asp:DropDownList ID="DropDownList_kind" runat="server" AutoPostBack="true">
                            <asp:ListItem Value="1" Text="一般類別" Selected="true" ></asp:ListItem>
                            <asp:ListItem Value="2" Text="其他薪津(應發)" ></asp:ListItem>
                            <asp:ListItem Value="3" Text="其他薪津(應扣)" ></asp:ListItem>
                        </asp:DropDownList>
				    </td>
				</tr>
			</table>	
		</td>
	</tr>
	<tr>
	    <td>
            <asp:GridView ID="GridView_SaTdpm" runat="server" 
            AutoGenerateColumns="False"
            CssClass="table_width2"
            CellPadding="1" CellSpacing="1" BorderWidth="0px" >
                <Columns>
                    <asp:TemplateField HeaderText="科目">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="Label_type_name" runat="server" Text='<%# Eval("code_type_name") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="form_col" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="發薪種類">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="Label_kind_name" runat="server" Text='<%# Eval("kind_name") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="form_col" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="名稱">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="Label_sys_name" runat="server" Text='<%# Eval("code_sys_name") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="form_col" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="銀行名稱">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox_tdpf_orgid" runat="server" 
                            Text='<%# Eval("payod_orgid") %>' Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBox_tdpf_kind" runat="server" 
                            Text='<%# Eval("payod_kind") %>' Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBox_tdpf_code_sys" runat="server" 
                            Text='<%# Eval("payod_code_sys") %>' Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBox_tdpf_code_kind" runat="server" 
                            Text='<%# Eval("payod_code_kind") %>' Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBox_tdpf_code_type" runat="server" 
                            Text='<%# Eval("payod_code_type") %>' Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBox_tdpf_code_no" runat="server" 
                            Text='<%# Eval("payod_code_no") %>' Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBox_tdpf_code" runat="server" 
                            Text='<%# Eval("payod_code") %>' Visible="false"></asp:TextBox>
                            <uc1:uc_Media_f040_tdpfDD ID="Uc_Media_f040_tdpfDD1" 
                            runat="server" OnSeqnoChanged="SeqnoChanged"
                            v_orgid='<%# Eval("payod_orgid") %>' v_selected='<%# Eval("tdpm_tdpf_seqno") %>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="form_col" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="銀行帳號">
                        <HeaderStyle CssClass="item_col" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <uc2:uc_Media_f040_tdpfTB ID="Uc_Media_f040_tdpfTB1" 
                            runat="server" v_seqno='<%# Eval("tdpm_tdpf_seqno") %>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="form_col" />
                    </asp:TemplateField>
                </Columns>
                  <RowStyle CssClass="list_tr" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource_gv" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="spExeSQLGetDataTable" TypeName="DB_TableAdapters.DB_TableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBox_Sqls1" DefaultValue="select top 1 * from sal_sabase where 1=0"
                        Name="SQLs" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
	    </td>
	</tr>
	<tr>
	    <td class="item_col" align="center">
            <asp:Button ID="Button_Update" runat="server" Text="儲存變更" CssClass="formcss" />
	    </td>
	</tr>
</table>

<div id="div_info" runat="server" style="display:none;">
    orgid=<asp:TextBox ID="TextBox_orgid" runat="server"></asp:TextBox><br />
    mid=<asp:TextBox ID="TextBox_mid" runat="server"></asp:TextBox><br />
    SQL1=<asp:TextBox ID="TextBox_Sqls1" runat="server" Visible="false"></asp:TextBox><br />

</div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

