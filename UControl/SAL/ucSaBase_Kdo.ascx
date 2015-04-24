<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucSaBase_Kdo.ascx.vb" Inherits="uc_ucSaBase_Kdo" %>
<%@ Register Src="ucSaSpesup.ascx" TagName="ucSaSpesup" TagPrefix="uc1" %>

<table class="table_width2" style="background:#dddddd" width="100%">
    <tr><td>請勾選加給項目</td></tr>
    <tr>
        <td>
            <asp:GridView ID="GridView_pitm" runat="server" DataSourceID="ObjectDataSource_gv" 
            AutoGenerateColumns="False" Width="100%" ShowHeader="False">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel_chk" runat="server" ChildrenAsTriggers="false" UpdateMode="conditional">
                                <ContentTemplate>
                                    <asp:CheckBox ID="CheckBox_chk" runat="server" 
                                    AutoPostBack="true" OnCheckedChanged ="chk_Changed" 
                                    Checked='<%#chk_Checked(Eval("Pitm_Code")) %>' />
                                    <asp:Label ID="Label_code_desc1" runat="server" Text='<%# Eval("Code_Desc1") %>'></asp:Label>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="CheckBox_chk" EventName="CheckedChanged" />
                                </Triggers> 
                            </asp:UpdatePanel>
                        </ItemTemplate>
                        <ItemStyle Width="60%" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:UpdatePanel ID="UpdatePanel_amt" runat="server" ChildrenAsTriggers="false" UpdateMode="conditional">
                                <ContentTemplate>
                                    <asp:TextBox ID="TextBox_code_sys" runat="server" Text='<%# Eval("Code_Sys") %>' Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="TextBox_code_kind" runat="server" Text='<%# Eval("Code_Kind") %>' Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="TextBox_code_type" runat="server" Text='<%# Eval("Code_Type") %>' Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="TextBox_code_no" runat="server" Text='<%# Eval("Code_No") %>' Visible="false"></asp:TextBox>
                                    <uc1:ucSaSpesup ID="UcSaSpesup_pitm_amt" runat="server" 
                                    v_Type="006" v_No='<%# Eval("Code_No") %>' 
                                    v_Series='<%# Eval("Pitm_Code") %>' Visible='<%#chk_Checked(Eval("Pitm_Code")) %>' />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="CheckBox_chk" EventName="CheckedChanged" />
                                </Triggers> 
                            </asp:UpdatePanel>
                        </ItemTemplate>
                        <ItemStyle Width="40%" />
                    </asp:TemplateField>
                </Columns>
                <RowStyle CssClass="col_5" />
                  <RowStyle CssClass="list_tr" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource_gv" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="dt_SaPitm_TableAdapters.ucSaBase_Kdo_TableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBox_orgid" DefaultValue="-1" Name="orgid" PropertyName="Text"
                        Type="String" />
                    <asp:ControlParameter ControlID="TextBox_seqno" DefaultValue="-1" Name="seqno" PropertyName="Text"
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>            
        </td>
    </tr>
</table>
<div id="info" style="display:none">
orgid=<asp:TextBox ID="TextBox_orgid" runat="server"></asp:TextBox><br />
seqno=<asp:TextBox ID="TextBox_seqno" runat="server"></asp:TextBox><br />
</div>