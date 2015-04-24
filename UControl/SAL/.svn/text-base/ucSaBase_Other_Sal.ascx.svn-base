<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucSaBase_Other_Sal.ascx.vb" Inherits="uc_ucSaBase_Other_Sal" %>
<table class="table_width2" style="background:#dddddd" width="100%">
    <tr>
        <td style="width:50%" align="center">其他發放項目
        </td>
        <td style="width:50%" align="center">其他代扣項目
        </td>        
    </tr>
    <tr class="col_5">
        <td style="width:50%; vertical-align:top">
            <asp:GridView ID="GridView_Other_1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource_gv1" 
            Width="100%" ShowHeader="False" BorderStyle="None">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox_chk" runat="server" Checked='<%# chk_Checked(Eval("Pitm_Amt")) %>' />
                        </ItemTemplate>
                        <ItemStyle BorderStyle="None" Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="Label_item_name" runat="server" Text='<%# Eval("Item_Name") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle BorderStyle="None" Width="50%" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox_code_sys" runat="server" Text='<%# Eval("Item_Code_Sys") %>' Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBox_code_kind" runat="server" Text='<%# Eval("Item_Code_Kind") %>' Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBox_code_type" runat="server" Text='<%# Eval("Item_Code_Type") %>' Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBox_code_no" runat="server" Text='<%# Eval("Item_Code_No") %>' Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBox_code" runat="server" Text='<%# Eval("Item_Code") %>' Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBox_pitm_amt" runat="server" Text='<%# Eval("Pitm_Amt") %>' Width="60"></asp:TextBox>   
                        </ItemTemplate>
                        <ItemStyle BorderStyle="None" Width="40%" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    機關尚未設定任何相關資料
                </EmptyDataTemplate>
                <RowStyle CssClass="col_5" />
                  <RowStyle CssClass="list_tr" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource_gv1" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetData" TypeName="dt_SaPitm_TableAdapters.ucSaBase_Other_Sal_TableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBox_seqno" DefaultValue="-1" Name="seqno" PropertyName="Text"
                        Type="String" />
                    <asp:ControlParameter ControlID="TextBox_orgid" DefaultValue="-1" Name="orgid" PropertyName="Text"
                        Type="String" />
                    <asp:Parameter DefaultValue="+" Name="operation" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
        <td style="width:50%; vertical-align:top">
            <asp:GridView ID="GridView_Other_2" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource_gv2" 
            Width="100%" ShowHeader="False" BorderStyle="None">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox_chk" runat="server" Checked='<%# chk_Checked(Eval("Pitm_Amt")) %>' />
                        </ItemTemplate>
                        <ItemStyle BorderStyle="None" Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="Label_item_name" runat="server" Text='<%# Eval("Item_Name") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle BorderStyle="None" Width="25%" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox_code_sys" runat="server" Text='<%# Eval("Item_Code_Sys") %>' Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBox_code_kind" runat="server" Text='<%# Eval("Item_Code_Kind") %>' Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBox_code_type" runat="server" Text='<%# Eval("Item_Code_Type") %>' Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBox_code_no" runat="server" Text='<%# Eval("Item_Code_No") %>' Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBox_code" runat="server" Text='<%# Eval("Item_Code") %>' Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBox_pitm_amt" runat="server" Text='<%# Eval("Pitm_Amt") %>' Width="60"></asp:TextBox>
                            <asp:TextBox ID="TextBox_acc_accno" runat="server" Text='' Visible='<%# show_acc_no(Eval("Item_Code_Sys"),Eval("Item_Code_Type"),Eval("Item_Code_No"))%>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle BorderStyle="None" Width="65%" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    機關尚未設定任何相關資料
                </EmptyDataTemplate>
                  <RowStyle CssClass="list_tr" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource_gv2" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetData" TypeName="dt_SaPitm_TableAdapters.ucSaBase_Other_Sal_TableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBox_seqno" DefaultValue="-1" Name="seqno" PropertyName="Text"
                        Type="String" />
                    <asp:ControlParameter ControlID="TextBox_orgid" DefaultValue="-1" Name="orgid" PropertyName="Text"
                        Type="String" />
                    <asp:Parameter DefaultValue="-" Name="operation" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>        
    </tr>
</table>
<div id="info" style="display:none">
orgid=<asp:TextBox ID="TextBox_orgid" runat="server"></asp:TextBox><br />
seqno=<asp:TextBox ID="TextBox_seqno" runat="server"></asp:TextBox><br />
</div>
