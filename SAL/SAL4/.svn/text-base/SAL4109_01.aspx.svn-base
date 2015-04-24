<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL4109_01.aspx.cs" Inherits="SAL_SAL4_SAL4109" %>
<%@ Register src="../../UControl/UcPager.ascx" tagname="UcPager" tagprefix="uc4" %>
<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc1" %>
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

function add_onclick() {

}

    </script>
    <table class="tableStyle99" width="100%" id="title" runat="server">   
        <tr>
            <td class="htmltable_Title" colspan="3">
                加給對照表
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" colspan="1">
               加給種類
            </td>
            <td class="htmltable_Right" colspan="2">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem Value="0">主管加給對照表</asp:ListItem>
                    <asp:ListItem Value="1">專業加給對照表</asp:ListItem>
                    <asp:ListItem Value="2">其他加給對照表</asp:ListItem>
                </asp:DropDownList>
            </td>        
        </tr>
        <tr>
            <td class="htmltable_Left" width="20%">
               請選擇種類
            </td>
            <td class="htmltable_Right" width="40%">
                <uc1:ucSaCode ID="cmbTypes" runat="server"  ControlType="2" />
            </td>        
            <td class="htmltable_Right" width="40%"> 
                民國
                <asp:DropDownList ID="DropDownList_Year" runat="server" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DropDownList_Year_SelectedIndexChanged">
                </asp:DropDownList>
                實施
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="3" style="border-top: none;">
                <asp:Button ID="Button_add" runat="server" Text="新增" OnClick="Button_add_Click" />            
                <asp:Button ID="Button_Search" runat="server" Text="查詢" OnClick="Button_Search_Click" />
            </td>
        </tr>
    </table>
 
            <asp:Panel ID="addPanel" runat="server" Visible="False">
                    <table width="100%" class="tableStyle99">
                        <tr>
                          <td class="htmltable_Title" colspan="2" style="height: 20px">
                          加給對照表-新增
                          </td>
                        </tr>
                        <tr>
                            <td >                             
                                加給種類         
                            </td>
                            <td >
                               <asp:Label ID="Label_kind" runat="server" Text=""></asp:Label>            
                            </td>
                        </tr>
                        <tr>
                        <td>
                            實施年月
                        </td>
                        <td>
                             <uc1:ucDateTextBox ID="ucDateTextBox" runat="server"   Kind ="YM" />
                        </td>
                        </tr>
                        <tr>
                            <td >                            
                                加給級數
                            </td>
                            <td >
                                <asp:TextBox ID="TextBox_Series" runat="server" 
                                    Text=""  onkeypress="return IsFloatText();" MaxLength="4" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td >                          
                                加給金額
                            </td>
                            <td >
                                 <asp:TextBox ID="TextBox_SAL" runat="server" Text="" 
                                     onkeypress="return IsFloatText();" MaxLength="6"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <input id="add" type="button" value="確定" onclick="btnadd_Click()" />
                                <asp:Button ID="add_cancel" runat="server" Text="取消" OnClick="add_cancel_Click" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>

            <asp:Panel ID="editPanel" runat="server" Visible="False">
            <table width="100%" class="tableStyle99">
            <tr>
            <td class="htmltable_Title" colspan="2">
                加給對照表-修改
            </td>
            </tr>
                        <tr>
                            <td >                             
                                    加給種類             
                            </td>
                            <td >
                                   <asp:Label ID="EditKind" runat="server" Text=""></asp:Label>       
                            </td>
                        </tr>
                        <tr>
                        <td>
                               實施年月
                        </td>
                        <td>
                             <asp:Label ID="EditYM" runat="server" Text=""></asp:Label>       
                        </td>
                        </tr>
                        <tr>
                            <td >                            
                                加給級數
                            </td>
                            <td >
                                <asp:Label ID="EditSer" runat="server" Text=""></asp:Label>                             
                            </td>
                        </tr>
                        <tr>
                            <td >                          
                                加給金額
                            </td>
                            <td >
                                 <asp:TextBox ID="EditSal" runat="server" Text="" 
                                     onkeypress="return IsFloatText();" MaxLength="6"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <input id="edit" type="button" value="確定" onclick="btnedit_Click()"  />
                                <asp:Button ID="edit_cancel" runat="server" Text="取消" OnClick="edit_cancel_Click" />
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
                        onpageindexchanging="GridView1_PageIndexChanging">
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        查無資料!!
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField HeaderText="加給級數">
                        <ItemTemplate>
                              <asp:Label ID="Label_series" runat="server" Text='<%# Eval("Spesup_Series") %>'></asp:Label>
                        </ItemTemplate>              
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="加給金額">
                        <ItemTemplate>
                              <asp:Label ID="Label_sal" runat="server" Text='<%# Eval("Spesup_Sal") %>'></asp:Label>
                        </ItemTemplate>          
                        </asp:TemplateField>  
                        <asp:TemplateField HeaderText="維護">
                            <ItemTemplate>
                                <asp:Button ID="update" runat="server" Text="修改" CommandName="doupdate" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                <input id="delete" type="button" value="刪除" onclick="btnDelete_Click('<%#((GridViewRow)Container).RowIndex%>')" />
                           </ItemTemplate>                            
                        </asp:TemplateField>                          
                    </Columns>
                        <PagerStyle HorizontalAlign="Right" />
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                </asp:GridView>             
                </td></tr>
                <tr><td align="right">
                     <uc4:UcPager ID="UcPager" runat="server" GridName="GridView1" 
                  Visible="False" PSize="30" PNow="1" />
                </td></tr>
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
