<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL4112_01.aspx.cs" Inherits="SAL_SAL4_SAL4112" %>
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

    </script>
    <table class="tableStyle99" width="100%" id="title" runat="server">   
        <tr>
            <td class="htmltable_Title" colspan="3">
                薪資所得扣繳對照表
            </td>
        </tr>      
        <tr>  
            <td class="htmltable_Right">
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
                          <td class="htmltable_Title" colspan="2" >
                          薪資所得扣繳對照表-新增
                          </td>
                        </tr>                      
                        <tr>                     
                        <td colspan="2" align="center">
                             <uc1:ucDateTextBox ID="ucDateTextBox" runat="server"   Kind ="YM" />
                        </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left" width="50%">                            
                                月薪資所得下限
                            </td>
                            <td class="htmltable_Right" width="50%">
                                <asp:TextBox ID="TextBox_low" runat="server" 
                                    Text=""  onkeypress="return IsFloatText();" MaxLength="7" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                                月薪資所得上限
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="TextBox_up" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                               0人(扶養人數)應扣稅額
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="tax_p0TextBox" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                              1人(扶養人數)應扣稅額
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="tax_p1TextBox" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                             2人(扶養人數)應扣稅額
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="tax_p2TextBox" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                           3人(扶養人數)應扣稅額
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="tax_p3TextBox" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                           4人(扶養人數)應扣稅額
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="tax_p4TextBox" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                           5人(扶養人數)應扣稅額
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="tax_p5TextBox" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                           6人(扶養人數)應扣稅額
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="tax_p6TextBox" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                           7人(扶養人數)應扣稅額
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="tax_p7TextBox" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                           8人(扶養人數)應扣稅額
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="tax_p8TextBox" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                           9人(扶養人數)應扣稅額
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="tax_p9TextBox" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                           10人(扶養人數)應扣稅額
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="tax_p10TextBox" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                           11人(扶養人數)應扣稅額
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="tax_p11TextBox" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
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
                            薪資所得扣繳對照表-修改
                        </td>
                        </tr>                      
                        <tr>                      
                        <td colspan="2" align="center">
                             <asp:Label ID="EditYM" runat="server" Text=""></asp:Label>       
                        </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left" width="50%">                            
                                月薪資所得下限
                            </td>
                            <td class="htmltable_Right" width="50%">
                                 <asp:Label ID="Editlow" runat="server" Text=""></asp:Label>     
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                                月薪資所得上限
                            </td>
                            <td class="htmltable_Right">
                                  <asp:Label ID="Editup" runat="server" Text=""></asp:Label>     
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                               0人(扶養人數)應扣稅額
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="Edit_p0" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                              1人(扶養人數)應扣稅額
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="Edit_p1" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                             2人(扶養人數)應扣稅額
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="Edit_p2" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                           3人(扶養人數)應扣稅額
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="Edit_p3" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                           4人(扶養人數)應扣稅額
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="Edit_p4" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                           5人(扶養人數)應扣稅額
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="Edit_p5" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                           6人(扶養人數)應扣稅額
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="Edit_p6" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                           7人(扶養人數)應扣稅額
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="Edit_p7" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                           8人(扶養人數)應扣稅額
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="Edit_p8" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                           9人(扶養人數)應扣稅額
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="Edit_p9" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                           10人(扶養人數)應扣稅額
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="Edit_p10" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">                          
                           11人(扶養人數)應扣稅額
                            </td>
                            <td class="htmltable_Right">
                                 <asp:TextBox ID="Edit_p11" runat="server" Text="" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>
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
                    onpageindexchanging="GridView1_PageIndexChanging" 
                    ondatabinding="GridView1_DataBinding" ondatabound="GridView1_DataBound">
                    <Columns>
                    <asp:TemplateField HeaderText="薪資級距">
                    <ItemTemplate>
                    <asp:Label ID="Label_lev" runat="server" Text='<%# Eval("Tax_Sallow") + "~" + Eval("Tax_Salup") %>'></asp:Label>
                    </ItemTemplate>             
                    </asp:TemplateField>
                    <asp:TemplateField>
                    <HeaderTemplate>
                    <table border="0" cellpadding="0" cellspacing="0" width="100%;" >
                        <tr>
                            <td align="center" colspan="6">
                                (扶養人數)應扣稅額
                            </td>
                        </tr>
                        <tr>
                            <td  style="width:18%" >0人</td>
                            <td  style="width:18%" >1人</td>
                            <td  style="width:16%" >2人</td>
                            <td  style="width:16%" >3人</td>
                            <td  style="width:16%" >4人</td>
                            <td  style="width:16%" >5人</td>
                        </tr>
                        <tr>
                            <td>6人</td>
                            <td>7人</td>
                            <td>8人</td>
                            <td>9人</td>
                            <td>10人</td>
                            <td>11人</td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate>
                    <table border="0" cellpadding="0" cellspacing="0" width="100%;">
                        <tr>
                            <td  style="width:18%" ><%#Eval("Tax_P0")%></td>
                            <td  style="width:18%" ><%#Eval("Tax_P1")%></td>
                            <td  style="width:16%" ><%#Eval("Tax_P2")%></td>
                            <td  style="width:16%" ><%#Eval("Tax_P3")%></td>
                            <td  style="width:16%" ><%#Eval("Tax_P4")%></td>
                            <td  style="width:16%" ><%#Eval("Tax_P5")%></td>
                        </tr>
                        <tr>
                            <td ><%#Eval("Tax_P6")%></td>
                            <td ><%#Eval("Tax_P7")%></td>
                            <td ><%#Eval("Tax_P8")%></td>
                            <td ><%#Eval("Tax_P9")%></td>
                            <td ><%#Eval("Tax_P10")%></td>
                            <td ><%#Eval("Tax_P11")%></td>
                        </tr>                        
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField HeaderText="維護">
                            <ItemTemplate>
                                <asp:Button ID="update" runat="server" Text="修改" CommandName="doupdate" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                <input id="delete" type="button" value="刪除" onclick="btnDelete_Click('<%#((GridViewRow)Container).RowIndex%>')" />
                           </ItemTemplate>                            
                        </asp:TemplateField>   
                                <asp:BoundField DataField="Tax_P0" />
                                <asp:BoundField DataField="Tax_P1" />    
                                <asp:BoundField DataField="Tax_P2" />
                                <asp:BoundField DataField="Tax_P3" />
                                <asp:BoundField DataField="Tax_P4" />
                                <asp:BoundField DataField="Tax_P5" />
                                <asp:BoundField DataField="Tax_P6" />
                                <asp:BoundField DataField="Tax_P7" />
                                <asp:BoundField DataField="Tax_P8" />
                                <asp:BoundField DataField="Tax_P9" />
                                <asp:BoundField DataField="Tax_P10" />
                                <asp:BoundField DataField="Tax_P11" />
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
