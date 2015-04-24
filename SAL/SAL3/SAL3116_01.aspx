<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SAL3116_01.aspx.vb" Inherits="SAL_SAL3_SAL3116_01"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
            <table class="tableStyle99" width="100%">
                <tr>
                    <td style="width: 15%" class="htmltable_Title" colspan="4" align="center">各單位銀行帳號與轉帳項目對照檔維護
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%" class="htmltable_Left" align="center">機關名稱
                    </td>
                    <td style="width: 35%" class="form_col">
                        <asp:Label ID="Label_orgname" runat="server" Text=""></asp:Label>
                    </td>
                    <td style="width: 15%" class="htmltable_Left" align="center">機關代號
                    </td>
                    <td style="width: 35%" class="form_col">
                        <asp:Label ID="Label_orgid" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%" class="htmltable_Left" colspan="4" align="center">對照檔
                    </td>
                </tr>
         <!--       <tr>
                    <td class="form_item" align="center">項目類別
                    </td>
                    <td colspan="3">
                        <asp:DropDownList ID="ddlKind" runat="server" AutoPostBack="true">
                            <asp:ListItem Value="1" Text="一般類別" Selected="true"></asp:ListItem>
                            <asp:ListItem Value="2" Text="其他薪津(應發)"></asp:ListItem>
                            <asp:ListItem Value="3" Text="其他薪津(應扣)"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>  -->
            </table>
            <div id="div1" runat="server">
                <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" CssClass="Grid" Width="100%">
                    <Columns>
                       <asp:TemplateField HeaderText="科目">
                          <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="Label_type_name" runat="server" Text='<%# Eval("code_type_name") %>'></asp:Label>
                            </ItemTemplate>
                           <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="發薪種類">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="Label_kind_name" runat="server" Text='<%# Eval("kind_name") %>'></asp:Label>
                            </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="名稱">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="Label_sys_name" runat="server" Text='<%# Eval("code_sys_name") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="銀行名稱">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:TextBox ID="tb_payod_orgid" runat="server" Text='<%# Eval("payod_orgid") %>' Visible="false" />
                                <asp:TextBox ID="tb_payod_kind" runat="server" Text='<%# Eval("payod_kind") %>' Visible="false" />
                                <asp:TextBox ID="tb_payod_code_sys" runat="server" Text='<%# Eval("payod_code_sys") %>' Visible="false" />
                                <asp:TextBox ID="tb_payod_code_kind" runat="server" Text='<%# Eval("payod_code_kind") %>' Visible="false" />
                                <asp:TextBox ID="tb_payod_code_type" runat="server" Text='<%# Eval("payod_code_type") %>' Visible="false" />
                                <asp:TextBox ID="tb_payod_code_no" runat="server" Text='<%# Eval("payod_code_no") %>' Visible="false" />
                                <asp:TextBox ID="tb_payod_code" runat="server" Text='<%# Eval("payod_code") %>' Visible="false" />
                                <asp:TextBox ID="tbtdpm_tdpf_seqno" runat="server" Text='<%# Eval("tdpm_tdpf_seqno")%>' Visible="false" />
                                <asp:DropDownList ID="ddlBankName" runat="server" AutoPostBack="True" OnSelectedIndexChanged ="ddlBankName_SelectedIndexChanged" />
                            </ItemTemplate>
                           <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="銀行帳號">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:TextBox ID="tb_BANK_BANK_NO" runat="server" ReadOnly="True" Text='<%# Eval("BANK_BANK_NO")%>'></asp:TextBox>
                               <%-- <asp:TextBox ID="tdpf_seqno" runat="server" ReadOnly="True" Text='<%# Eval("tdpf_seqno")%>'></asp:TextBox>--%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="備註">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:TextBox ID="tb_BANK_MEMO" runat="server" ReadOnly="True" Text='<%# Eval("tdpf_memo")%>'></asp:TextBox>
                             </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="list_tr" />
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource_gv" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="spExeSQLGetDataTable" TypeName="DB_TableAdapters.DB_TableAdapter">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TextBox_Sqls1" DefaultValue="select top 1 * from sal_sabase where 1=0" Name="SQLs" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
            <table width="100%">
                <tr>
                    <td align="center">
                        <asp:Button ID="btnUpdate" runat="server" Text="儲存變更" />
                    </td>
                </tr>
            </table>

            <div id="div_info" runat="server" style="display: none;">
                orgid=<asp:TextBox ID="TextBox_orgid" runat="server"></asp:TextBox><br />
                mid=<asp:TextBox ID="TextBox_mid" runat="server"></asp:TextBox><br />
                SQL1=<asp:TextBox ID="TextBox_Sqls1" runat="server" Visible="false"></asp:TextBox><br />

            </div>
</asp:Content>

