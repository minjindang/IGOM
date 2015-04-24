<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SAL3103_02.aspx.vb" Inherits="SAL3103_02" %>

<%@ Register Src="~/UControl/SAL/ucFormSaItem.ascx" TagName="ucFormSaItem" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

                <asp:FormView ID="FormView_item" runat="server" DataKeyNames="ITEM_ORGID,ITEM_CODE"
                    DataSourceID="ObjectDataSource_fv" Width="100%">
                    <EditItemTemplate>
                        <uc1:ucFormSaItem ID="UcFormSaItem1" runat="server" Fmode="Edit" v_ADD_HealthPlus='<%# Bind("ITEM_ADD_HealthPlus") %>'
                            v_ADD_HealthPlusbonus='<%# Bind("ITEM_ADD_HealthPlusbonus") %>' v_orgid='<%# Eval("ITEM_ORGID") %>'
                            v_code_sys='<%# Bind("ITEM_CODE_SYS") %>' v_code_kind='<%# Bind("ITEM_CODE_KIND") %>'
                            v_code_type='<%# Bind("ITEM_CODE_TYPE") %>' v_code_no='<%# Bind("ITEM_CODE_NO") %>'
                            v_code='<%# Eval("ITEM_CODE") %>' v_name='<%# Bind("ITEM_NAME") %>' v_operation='<%# Bind("ITEM_OPERATION") %>'
                            v_bmon='<%# Bind("ITEM_BMON") %>' v_emon='<%# Bind("ITEM_EMON") %>' v_permanent='<%# Bind("ITEM_PERMANENT") %>'
                            v_icode='<%# Bind("ITEM_ICODE") %>' v_tax='<%# Bind("ITEM_TAX") %>' v_type='<%# Bind("ITEM_TYPE") %>'
                            v_row='<%# Bind("ITEM_ROW") %>' v_form='<%# Bind("ITEM_FORM") %>' v_suspend='<%# Bind("ITEM_SUSPEND") %>'
                            v_muser='<%# Bind("ITEM_MUSER") %>' v_mdate='<%# Bind("ITEM_MDATE") %>' v_year='<%# Bind("ITEM_YEAR") %>'
                            v_merit_before='<%# Bind("ITEM_MERIT_BEFORE") %>' v_merit_after='<%# Bind("ITEM_MERIT_AFTER") %>'
                            v_promo='<%# Bind("ITEM_PROMO") %>' v_belong='<%# Bind("ITEM_BELONG") %>' v_doc_type='<%# Bind("ITEM_DOC_TYPE") %>'
                            v_tax_type='<%# Bind("ITEM_TAX_TYPE") %>' v_memo='<%# Bind("ITEM_MEMO") %>' v_add_inco='<%# Bind("ITEM_AddINCO") %>'
                            OnFormUpdate="FormUpdate" OnWindowClose="FormClose"></uc1:ucFormSaItem>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <uc1:ucFormSaItem ID="UcFormSaItem1" runat="server" Fmode="Insert" v_ADD_HealthPlus='<%# Bind("ITEM_ADD_HealthPlus") %>'
                            v_ADD_HealthPlusbonus='<%# Bind("ITEM_ADD_HealthPlusbonus") %>' v_orgid='<%# Bind("ITEM_ORGID") %>'
                            v_code_sys='<%# Bind("ITEM_CODE_SYS") %>' v_code_kind='<%# Bind("ITEM_CODE_KIND") %>'
                            v_code_type='<%# Bind("ITEM_CODE_TYPE") %>' v_code_no='<%# Bind("ITEM_CODE_NO") %>'
                            v_code='<%# Bind("ITEM_CODE") %>' v_name='<%# Bind("ITEM_NAME") %>' v_operation='<%# Bind("ITEM_OPERATION") %>'
                            v_bmon='<%# Bind("ITEM_BMON") %>' v_emon='<%# Bind("ITEM_EMON") %>' v_permanent='<%# Bind("ITEM_PERMANENT") %>'
                            v_icode='<%# Bind("ITEM_ICODE") %>' v_tax='<%# Bind("ITEM_TAX") %>' v_type='<%# Bind("ITEM_TYPE") %>'
                            v_row='<%# Bind("ITEM_ROW") %>' v_form='<%# Bind("ITEM_FORM") %>' v_suspend='<%# Bind("ITEM_SUSPEND") %>'
                            v_muser='<%# Bind("ITEM_MUSER") %>' v_mdate='<%# Bind("ITEM_MDATE") %>' v_year='<%# Bind("ITEM_YEAR") %>'
                            v_merit_before='<%# Bind("ITEM_MERIT_BEFORE") %>' v_merit_after='<%# Bind("ITEM_MERIT_AFTER") %>'
                            v_promo='<%# Bind("ITEM_PROMO") %>' v_belong='<%# Bind("ITEM_BELONG") %>' v_doc_type='<%# Bind("ITEM_DOC_TYPE") %>'
                            v_tax_type='<%# Bind("ITEM_TAX_TYPE") %>' v_memo='<%# Bind("ITEM_MEMO") %>' v_add_inco='<%# Bind("ITEM_AddINCO") %>'
                            OnFormInsert="FormInsert" OnWindowClose="FormClose"></uc1:ucFormSaItem>
                    </InsertItemTemplate>
                    <ItemTemplate>
                    </ItemTemplate>
                </asp:FormView>

        <asp:ObjectDataSource ID="ObjectDataSource_fv" runat="server" DeleteMethod="Delete"
            InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCode"
            TypeName="dt_SaItem_TableAdapters.SAITEM_TableAdapter" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_ITEM_ORGID" Type="String" />
                <asp:Parameter Name="Original_ITEM_CODE" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="ITEM_ADD_HealthPlus" Type="String" />
                <asp:Parameter Name="ITEM_ADD_HealthPlusbonus" Type="String" />
                <asp:Parameter Name="ITEM_CODE_SYS" Type="String" />
                <asp:Parameter Name="ITEM_CODE_KIND" Type="String" />
                <asp:Parameter Name="ITEM_CODE_TYPE" Type="String" />
                <asp:Parameter Name="ITEM_CODE_NO" Type="String" />
                <asp:Parameter Name="ITEM_NAME" Type="String" />
                <asp:Parameter Name="ITEM_OPERATION" Type="String" />
                <asp:Parameter Name="ITEM_BMON" Type="String" />
                <asp:Parameter Name="ITEM_EMON" Type="String" />
                <asp:Parameter Name="ITEM_PERMANENT" Type="String" />
                <asp:Parameter Name="ITEM_ICODE" Type="String" />
                <asp:Parameter Name="ITEM_TAX" Type="String" />
                <asp:Parameter Name="ITEM_TYPE" Type="String" />
                <asp:Parameter Name="ITEM_ROW" Type="String" />
                <asp:Parameter Name="ITEM_FORM" Type="String" />
                <asp:Parameter Name="ITEM_SUSPEND" Type="String" />
                <asp:Parameter Name="ITEM_MUSER" Type="String" />
                <asp:Parameter Name="ITEM_MDATE" Type="String" />
                <asp:Parameter Name="ITEM_YEAR" Type="String" />
                <asp:Parameter Name="ITEM_MERIT_BEFORE" Type="String" />
                <asp:Parameter Name="ITEM_MERIT_AFTER" Type="String" />
                <asp:Parameter Name="ITEM_PROMO" Type="String" />
                <asp:Parameter Name="ITEM_BELONG" Type="String" />
                <asp:Parameter Name="ITEM_DOC_TYPE" Type="String" />
                <asp:Parameter Name="ITEM_TAX_TYPE" Type="String" />
                <asp:Parameter Name="ITEM_MEMO" Type="String" />
                <asp:Parameter Name="Original_ITEM_ORGID" Type="String" />
                <asp:Parameter Name="Original_ITEM_CODE" Type="String" />
                <asp:Parameter Name="ITEM_AddINCO" Type="String" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox_orgid" DefaultValue="-1" Name="orgid" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBox_code" DefaultValue="-1" Name="code" PropertyName="Text"
                    Type="String" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="ITEM_ADD_HealthPlus" Type="String" />
                <asp:Parameter Name="ITEM_ADD_HealthPlusbonus" Type="String" />
                <asp:Parameter Name="ITEM_ORGID" Type="String" />
                <asp:Parameter Name="ITEM_CODE_SYS" Type="String" />
                <asp:Parameter Name="ITEM_CODE_KIND" Type="String" />
                <asp:Parameter Name="ITEM_CODE_TYPE" Type="String" />
                <asp:Parameter Name="ITEM_CODE_NO" Type="String" />
                <asp:Parameter Name="ITEM_CODE" Type="String" />
                <asp:Parameter Name="ITEM_NAME" Type="String" />
                <asp:Parameter Name="ITEM_OPERATION" Type="String" />
                <asp:Parameter Name="ITEM_BMON" Type="String" />
                <asp:Parameter Name="ITEM_EMON" Type="String" />
                <asp:Parameter Name="ITEM_PERMANENT" Type="String" />
                <asp:Parameter Name="ITEM_ICODE" Type="String" />
                <asp:Parameter Name="ITEM_TAX" Type="String" />
                <asp:Parameter Name="ITEM_TYPE" Type="String" />
                <asp:Parameter Name="ITEM_ROW" Type="String" />
                <asp:Parameter Name="ITEM_FORM" Type="String" />
                <asp:Parameter Name="ITEM_SUSPEND" Type="String" />
                <asp:Parameter Name="ITEM_MUSER" Type="String" />
                <asp:Parameter Name="ITEM_MDATE" Type="String" />
                <asp:Parameter Name="ITEM_YEAR" Type="String" />
                <asp:Parameter Name="ITEM_MERIT_BEFORE" Type="String" />
                <asp:Parameter Name="ITEM_MERIT_AFTER" Type="String" />
                <asp:Parameter Name="ITEM_PROMO" Type="String" />
                <asp:Parameter Name="ITEM_BELONG" Type="String" />
                <asp:Parameter Name="ITEM_DOC_TYPE" Type="String" />
                <asp:Parameter Name="ITEM_TAX_TYPE" Type="String" />
                <asp:Parameter Name="ITEM_MEMO" Type="String" />
                <asp:Parameter Name="ITEM_AddINCO" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
    <div id="info" runat="server" style="display: none">
        orgid=<asp:TextBox ID="TextBox_orgid" runat="server"></asp:TextBox><br />
        mid=<asp:TextBox ID="TextBox_mid" runat="server"></asp:TextBox><br />
        act=<asp:TextBox ID="TextBox_act" runat="server"></asp:TextBox><br />
        code=<asp:TextBox ID="TextBox_code" runat="server"></asp:TextBox><br />
        tbn=<asp:TextBox ID="TextBox_btn" runat="server"></asp:TextBox><br />
    </div>
</asp:Content>
