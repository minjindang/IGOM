<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucFormSaItem.ascx.vb"
    Inherits="uc_ucFormSaItem" %>
<%@ Register Src="ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc1" %>
<div>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">自訂薪資項目維護
            </td>
        </tr>
        <tr>
            <td class="htmltable_Title2" colspan="2">
                <asp:Label ID="lbTitle" runat="server" />
            </td>
        </tr>
                                <tr>
                                    <td class="htmltable_Left" width="144">薪資科目&nbsp;</td>
                                    <td  class="TdHeightLight">
                                        <asp:DropDownList ID="edit_Item_Code_Type" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource_dl_operation"
                                            DataTextField="CODE_DESC1" DataValueField="CODE_NO">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjectDataSource_dl_operation" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetDataByOperation" TypeName="dt_SaCode_TableAdapters.ucFormSaItem_TableAdapter"></asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="htmltable_Left" width="234">
                                        <asp:Label ID="Label_Type_Name" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td  class="TdHeightLight">
                                        <asp:DropDownList ID="edit_Item_Code_No" runat="server" DataSourceID="ObjectDataSource_code_no"
                                            DataTextField="CODE_DESC1" DataValueField="CODE_NO">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ObjectDataSource_code_no" runat="server" OldValuesParameterFormatString="original_{0}"
                                            SelectMethod="GetDataCode" TypeName="dt_SaCode_TableAdapters.dl_SACODE_TableAdapter">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="005" Name="code_sys" Type="String" />
                                                <asp:ControlParameter ControlID="edit_Item_Code_Type" DefaultValue="-1" Name="code_type"
                                                    PropertyName="SelectedValue" Type="String" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="htmltable_Left" width="144">補發代扣項目名稱
                                    </td>
                                    <td class="TdHeightLight" width="234">
                                        <asp:TextBox ID="edit_Item_Name" runat="server" MaxLength="20" Width="160"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="tr_belong" runat="server">
                                    <td class="htmltable_Left" width="144">所屬應扣款(公共)種類
                                    </td>
                                    <td class="TdHeightLight" width="234">
                                        <uc1:ucSaCode ID="edit_Item_Belong" runat="server" Code_sys="003" Code_type="002"
                                            Mode="" ControlType="DropDownList" />
                                    </td>
                                </tr>
                                <tr id="tr_icode" runat="server">
                                    <td class="htmltable_Left" width="144">所得種類
                                    </td>
                                    <td class="TdHeightLight" width="234">
                                        <uc1:ucSaCode ID="edit_Item_Icode" runat="server" Code_sys="003" Code_type="004"
                                            Mode="" ReturnEvent="true" ControlType="DropDownList" />
                                        <%--<asp:DropDownList ID="edit_Item_Icode" runat="server" DataValueField="CODE_NO" DataTextField="CODE_DESC1" />--%>
                                    </td>
                                </tr>
                                <tr id="tr_doc_type" runat="server" visible="false">
                                    <td class="htmltable_Left" width="144">
                                        <asp:Label ID="Label_doc_type" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="TdHeightLight" width="234">
                                        <asp:DropDownList ID="edit_Item_Doc_Type" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr id="tr_tax" runat="server">
                                    <td class="htmltable_Left" width="144">
                                        是否扣繳稅額
                                    </td>
                                    <td class="TdHeightLight" width="144">
                                        <asp:CheckBox ID="edit_Item_Tax" runat="server" AutoPostBack="true" Text="是" /> 
                                        <asp:DropDownList ID="edit_Item_Tax_Type" runat="server" Visible="false">
                                            <asp:ListItem Value="A" Text="全額扣繳"></asp:ListItem>
                                            <%--  <asp:ListItem Value="B" Text="比例扣繳(完全中學)"></asp:ListItem>                                    --%>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="htmltable_Left" width="144" >
                                        是否隨薪發放
                                    </td>
                                    <td class="TdHeightLight">
                                        <asp:CheckBox ID="edit_item_type" runat="server" AutoPostBack="true" Text="是" />
                                    </td>
                                </tr>
                                <tr id="tr_SAinco" runat="server">
                                    <td class="htmltable_Left" width="144" >
                                       是否納入薪資所得稅額 
                                    </td>
                                    <td class="TdHeightLight">
                                        <asp:CheckBox ID="edit_item_Add_SAinco" runat="server" Text="是" />
                                    </td>
                                </tr>
                                <tr id="tr_HealthPlus" runat="server">
                                    <td class="htmltable_Left" width="144" >
                                        納入補充保費扣繳計算
                                    </td>
                                    <td class="TdHeightLight">
                                        <asp:CheckBox ID="edit_ITEM_ADD_HealthPlus" runat="server" AutoPostBack="true" Text="是" />
                                    </td>
                                </tr>
                                <tr id="tr_HealthPlusbonus" runat="server">
                                    <td class="htmltable_Left" width="144" >
                                        納入補充保費之獎金計算
                                    </td>
                                    <td class="TdHeightLight">
                                        <asp:CheckBox ID="edit_ITEM_ADD_HealthPlusbonus" runat="server" AutoPostBack="true" Text="是" />
                                    </td>
                                </tr>
                                <tr id="tr_year" runat="server">
                                    <td class="htmltable_Left" width="200" >
                                        是否列入年終獎金扣款
                                    </td>
                                    <td class="TdHeightLight">
                                        <asp:CheckBox ID="edit_Item_Year" runat="server" Text="是" />
                                    </td>
                                </tr>
                                <tr id="tr_merit_before" runat="server">
                                    <td class="htmltable_Left" width="200" >
                                        是否列入預借考績扣款
                                    </td>
                                    <td class="TdHeightLight">
                                        <asp:CheckBox ID="edit_Item_Merit_Before" runat="server" Text="是" />
                                    </td>
                                </tr>
                                <tr id="tr_merit_after" runat="server">
                                    <td class="htmltable_Left" width="200" >
                                        是否列入核定考績扣款
                                    </td>
                                    <td class="TdHeightLight">
                                        <asp:CheckBox ID="edit_Item_Merit_After" runat="server" Text="是" />
                                    </td>
                                </tr>
                                <tr id="tr_promo" runat="server">
                                    <td class="htmltable_Left" width="200" >
                                        是否列入晉級補發扣款
                                    </td>
                                    <td class="TdHeightLight">
                                        <asp:CheckBox ID="edit_Item_Promo" runat="server" Text="是" />
                                    </td>
                                </tr>
                                <tr id="tr1" runat="server">
                                    <td class="htmltable_Left" width="200" >
                                        隱藏註記
                                    </td>
                                    <td class="TdHeightLight">
                                        <asp:CheckBox ID="edit_Item_Suspend" runat="server" Text="隱藏" />
                                    </td>
                                </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <span id="FunctionEdit" runat="server" visible="false">
                                <asp:Button ID="UpdateButton" runat="server" Text="確定" />
                            </span><span id="FunctionInsert" runat="server" visible="false">
                                <asp:Button ID="InsertButton" runat="server" Text="確定" />
                            </span>
                            <asp:Button ID="ButtonClose" runat="server" CausesValidation="False" Text="取消" />
                        </td>
                    </tr>
                </table>
</div>
<div id="info" runat="server" style="display: none;">
    Orgid=<asp:TextBox ID="edt_Item_Orgid" runat="server"></asp:TextBox><br />
    Code=<asp:TextBox ID="edit_Item_Code" runat="server"></asp:TextBox><br />
    muser=<asp:TextBox ID="edit_Item_Muser" runat="server"></asp:TextBox><br />
    mdate=<asp:TextBox ID="edit_Item_Mdate" runat="server"></asp:TextBox><br />
    Fmode=<asp:TextBox ID="TextBox_Fmode" runat="server"></asp:TextBox><br />
</div>
