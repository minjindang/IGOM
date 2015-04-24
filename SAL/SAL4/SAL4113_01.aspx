<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL4113_01.aspx.cs" Inherits="SAL_SAL4_SAL4113" %>
<%@ Register src="../../UControl/UcPager.ascx" tagname="UcPager" tagprefix="uc4" %>
<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc1" %>
<%@ Register Src="~/UControl/SAL/uc_SaParameter_List.ascx" TagName="uc_SaParameter_List" TagPrefix="uc1" %>
<%@ Register Src="~/UControl/SAL/ucDateTextBox.ascx" TagName="ucDateTextBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>-->
    <script language="javascript"> 
        function btnDelete_Click(SerialNO) { 

            if (confirm("確定刪除?")) {
                document.getElementById('ctl00_ContentPlaceHolder1_txtFuncParam').value = SerialNO;
                document.getElementById('ctl00_ContentPlaceHolder1_btnSubmit').click();
            }
        }
        function btnedit_Click() {
            if (confirm("確定儲存?")) {
                document.getElementById('ctl00_ContentPlaceHolder1_edit_submit').click();
            }
        }
        function btnadd_Click() {
            if (confirm("確定新增?")) {
                document.getElementById('ctl00_ContentPlaceHolder1_add_submit').click(); 
            }

        }

        function IsFloatText() {
            var charkc = window.event.keyCode
            if (charkc == 46 || (charkc >= 48 && charkc <= 57)) {
                return true;
            }
            return false;
        }       	
function add_onclick() {

}

function edit_onclick() {

}

    </script>
    <table class="tableStyle99" width="100%" id="title" runat="server">   
        <tr>
            <td class="htmltable_Title" colspan="3">
                薪資計算參數維護
            </td>
        </tr>      
        <tr>  
            <td class="htmltable_Right">
                請選擇種類
                <uc1:ucSaCode ID="UcSaCode_parameter_type" runat="server"  ControlType="2" />  
            </td>
        </tr>      
    </table>
 
            <asp:Panel ID="addPanel" runat="server" Visible="False">
                    <table width="100%" class="tableStyle99">
                        <tr>
                              <td class="htmltable_Title" colspan="2" style="height: 20px">
                              薪資計算參數維護-新增
                              </td>
                        </tr>
                        <tr>                           
                            <td colspan="2" class="htmltable_Right" align="center">
                                        <uc1:ucDateTextBox ID="ucDateTextBox" runat="server"   Kind ="YM" />
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left" width="50%">
                                參數名稱
                            </td>
                            <td class="htmltable_Right" width="50%">
                                 <asp:Label ID="Label_Desc1" runat="server" Text="">
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                            
                                參數值
                            </td>
                            <td class="htmltable_Right">
                                <asp:TextBox ID="PARAMETER_VALUETextBox" runat="server" 
                                    Text=""  onkeypress="return IsFloatText();" MaxLength="7" ></asp:TextBox>
                            </td>
                        </tr>                       
                        <tr>
                            <td colspan="2" align="center">
                                <input id="add" type="button" value="確定" onclick="btnadd_Click()" />
                                <asp:Button ID="add_cancel" runat="server" Text="取消" OnClick="add_cancel_Click" />
                                <asp:Label ID="v_sys" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="v_kind" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="v_type" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="v_no" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
            </asp:Panel>

            <asp:Panel ID="editPanel" runat="server" Visible="False">
                   <table width="100%" class="tableStyle99">
                        <tr>
                            <td class="htmltable_Title" colspan="2">
                                薪資計算參數維護-修改
                            </td>
                        </tr>                      
                        <tr>                     
                            <td colspan="2"  class="htmltable_Right" align ="center">
                                 <asp:Label ID="EditYM" runat="server" Text=""></asp:Label>       
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left" width="50%">                            
                                參數名稱
                            </td>
                            <td class="htmltable_Right" width="50%">
                                <asp:Label ID="EditDesc" runat="server" Text=""></asp:Label>                             
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                                參數值
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="EditValue" runat="server" Text="" 
                                     onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <input id="edit" type="button" value="確定" onclick="btnedit_Click()"  />
                                <asp:Button ID="edit_cancel" runat="server" Text="取消" OnClick="edit_cancel_Click" />
                                <asp:Label ID="Editsys" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="Editkind" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="Edittype" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="Editno" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="ym" runat="server" Text="" Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                  
                <table width="100%" id="view" runat="server" visible="false" class="tableStyle99">
                <tr>
                <td class="htmltable_Title2" style="width: 100%" align="center">
                查詢結果
                </td>
                </tr>
                <tr>
                <td>   
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                    OnRowCommand="GridView1_RowCommand1" Width="100%" CssClass="Grid" 
                        AllowPaging="True" PageSize="30" 
                        onpageindexchanged="GridView1_PageIndexChanged" 
                        onpageindexchanging="GridView1_PageIndexChanging" 
                        ondatabinding="GridView1_DataBinding" ondatabound="GridView1_DataBound">
                        <Columns>
                          <asp:TemplateField HeaderText="參數名稱">
                            <ItemTemplate>                     
                                <asp:Label ID="Label_code_desc1" runat="server"  Text='<%# Eval("Code_Desc1") %>'>
                                </asp:Label>
                            </ItemTemplate>             
                          </asp:TemplateField>
                         <asp:TemplateField HeaderText="參數值">
                            <ItemTemplate> 
                               <uc1:uc_SaParameter_List ID="ucSaParameter_1" runat="server"
                                v_code_sys='<%# Eval("Code_Sys") %>'
                                v_code_kind='<%# Eval("Code_Kind") %>'
                                v_code_type='<%# Eval("Code_Type") %>'
                                v_code_no='<%# Eval("Code_No") %>'  />                   
                            </ItemTemplate>                             
                        </asp:TemplateField>              
                        <asp:TemplateField HeaderText="維護">
                            <ItemTemplate>
                                <asp:Button ID="btn_add" runat="server" Text="新增" CommandName="doadd" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />                          
                                <asp:Button ID="update" runat="server" Text="修改" CommandName="doupdate" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                             <!--   <input id="delete" type="button" value="刪除" onclick="btnDelete_Click('<%#((GridViewRow)Container).RowIndex%>')" /> -->
                           </ItemTemplate>                            
                        </asp:TemplateField>
                        <asp:BoundField DataField="Code_Sys" HeaderText="sys" />
                        <asp:BoundField DataField="Code_Kind" HeaderText="kind" />
                        <asp:BoundField DataField="Code_Type" HeaderText="type" />
                        <asp:BoundField DataField="Code_No" HeaderText="no" />
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                       <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                       <EmptyDataTemplate>
                            查無資料!!
                       </EmptyDataTemplate>
                </asp:GridView>                                        
                </td>
                </tr>
                <tr>
                <td align="right">
                     <uc4:UcPager ID="UcPager" runat="server" GridName="GridView1" 
                  Visible="False" PSize="30" PNow="1" />
                </td>
                </tr>
                </table>            

       
    <div style="visibility: hidden">
        <asp:Button ID="add_submit" runat="server" Text="確定新增" OnClick="add_submit_Click" />
        <asp:Button ID="edit_submit" runat="server" Text="確定儲存" OnClick="edit_submit_Click" />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click">
        </asp:Button>
        <input id="txtFuncParam" type="hidden" name="txtFuncParam" runat="server"/>

        <asp:TextBox ID="TextBox_orgid" runat="server"></asp:TextBox>    
        <asp:TextBox ID="TextBox_mid" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox_role" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox_type" runat="server"></asp:TextBox>
    </div>
    <!--</ContentTemplate>
    </asp:UpdatePanel>-->
</asp:Content>
