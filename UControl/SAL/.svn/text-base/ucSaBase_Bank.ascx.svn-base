<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucSaBase_Bank.ascx.vb" Inherits="uc_ucSaBase_Bank" %>

<div>
    <asp:GridView ID="GridView_Bank" runat="server" 
    AutoGenerateColumns="False" DataSourceID="ObjectDataSource_gv"
    ShowHeader="False"
    CssClass="table_width2" >
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="Label_bankname" runat="server" Text='<%# Eval("CODE_DESC1") %>' CssClass="form_item" ></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="form_item" Width="18.5%" BorderStyle="solid" BorderColor="white" BorderWidth="2px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    《<asp:Label ID="Label_bankno" runat="server" Text='<%# Eval("Tdpf_Bank_No") %>'></asp:Label>》
                      <asp:Label ID="Label1_MEMO" runat="server" Text='<%# Eval("Tdpf_MEMO") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="form_col" Width="15%" BorderStyle="None" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:TextBox ID="TextBox_Tdpf_Bank" runat="server" Text='<%# Eval("Tdpf_Bank") %>' Visible="false" ></asp:TextBox>
                    <asp:TextBox ID="TextBox_Tdpf_Seqno" runat="server" Text='<%# Eval("Tdpf_Seqno") %>' Visible="false" ></asp:TextBox>
                    <asp:TextBox ID="TextBox_Bank_No" runat="server" Text='<%# Eval("Bank_Bank_No") %>' MaxLength='<%# Eval("trnfmt_length") %>'></asp:TextBox>
                </ItemTemplate>
                <ItemStyle CssClass="form_col" Width="70%" BorderStyle="None" />
            </asp:TemplateField>
        </Columns>
          <RowStyle CssClass="list_tr" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource_gv" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetData" TypeName="dt_SaBank_TableAdapters.ucSaBase_Bank_TableAdapter">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBox_seqno" DefaultValue="-1" Name="seqno" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBox_orgid" DefaultValue="-1" Name="orgid" PropertyName="Text"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>
<div id="info" style="display:none">
orgid=<asp:TextBox ID="TextBox_orgid" runat="server"></asp:TextBox><br />
seqno=<asp:TextBox ID="TextBox_seqno" runat="server"></asp:TextBox><br />
</div>