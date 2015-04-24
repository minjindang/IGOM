<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL4114_01.aspx.cs" Inherits="SAL_SAL4_SAL4114" %>
<%@ Register src="../../UControl/UcPager.ascx" tagname="UcPager" tagprefix="uc4" %>
<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc1" %>
<%@ Register Src="~/UControl/SAL/uc_SaParameter_List.ascx" TagName="uc_SaParameter_List" TagPrefix="uc1" %>
<%@ Register Src="~/UControl/SAL/ucDateTextBox.ascx" TagName="ucDateTextBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
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

function edit_onclick() {

}

    </script>

     <table width="100%" class="tableStyle99" id="view" runat="server" >
       <tr>
           <td class="htmltable_Title" colspan="4" >
                   機關基本資料維護    
           </td>
       </tr>
       <tr>
            <td width="20%" align="center" class="htmltable_Left">
              機關類別
            </td>
            <td  colspan="3" class="htmltable_Right">
                <uc1:ucSaCode ID="UcSaCode_kind" runat="server" Code_sys="004" Code_type="001" ControlType="2"   ReturnEvent="True" />
             </td>
       </tr>
          <tr>
            <td width="20%" align="center" class="htmltable_Left">
              機關名稱
            </td>
            <td width="30%" class="htmltable_Right">
                <asp:TextBox ID="UNIT_DEPTextBox" runat="server" ></asp:TextBox>  
            </td>
            <td width="20%"  align="center" class="htmltable_Left">
              機關代號
            </td>
            <td width="30%" class="htmltable_Right">
                <asp:Label ID="UNIT_NOLabel1" runat="server" ></asp:Label>  
            </td>
          </tr>
            <tr>
            <td width="20%" align="center" class="htmltable_Left">
              統一編號
            </td>
            <td width="30%" class="htmltable_Right">
                <asp:TextBox ID="UNIT_TAXTextBox" runat="server"  MaxLength="8"></asp:TextBox>  
            </td>
            <td width="20%" align="center" class="htmltable_Left">
              負責人
            </td>
            <td width="30%" class="htmltable_Right">
                <asp:TextBox ID="UNIT_HNAMETextBox" runat="server"  MaxLength="20"></asp:TextBox>  
            </td>
          </tr>
          <tr>
            <td width="20%" align="center" class="htmltable_Left">
              聯絡人
            </td>
            <td width="30%" class="htmltable_Right">
                <asp:TextBox ID="UNIT_CNAMETextBox" runat="server"  MaxLength="20"></asp:TextBox>  
            </td>
            <td width="20%" align="center" class="htmltable_Left">
              聯絡電話
            </td>
            <td width="30%" class="htmltable_Right">  
                <asp:TextBox ID="UNIT_TELTextBox" runat="server"   onkeypress="return IsFloatText();" ></asp:TextBox>              
            </td>
          </tr>
          <tr>
            <td width="20%" align="center" class="htmltable_Left">
              媒體編號
            </td>
            <td width="30%" class="htmltable_Right">
                <asp:TextBox ID="UNIT_MEDIATextBox" runat="server"  Width="84px" MaxLength="4"></asp:TextBox>
            </td>
            <td width="20%" align="center" class="htmltable_Left">
              稽徵機關代號
            </td>
            <td width="30%" class="htmltable_Right">
                <asp:TextBox ID="UNIT_AREATextBox" runat="server"  Width="56px" MaxLength="3"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td width="20%" align="center" class="htmltable_Left">
              機關地址
            </td>
            <td colspan="3" class="htmltable_Right">
                <asp:TextBox ID="UNIT_ADDRTextBox" runat="server"  Width="406px" MaxLength="58"></asp:TextBox>
            </td>
          </tr>
          <tr id="vis_tr" runat="server" visible="false">
            <td width="20%" align="center" class="htmltable_Left">
              計算工資墊償基金
            </td>
            <td width="30%" class="htmltable_Right">
                <asp:CheckBox ID="CheckBox_recompense_fund" runat="server"  />
                <asp:TextBox ID="TextBox_recompense_fund" runat="server"  Visible="false"></asp:TextBox>
            </td>
            <td width="20%" align="center" class="htmltable_Left">
              計算多筆月薪
            </td>
            <td width="30%" class="htmltable_Right">
                <asp:CheckBox ID="CheckBox_multi_monthpay" runat="server" />
                <asp:TextBox ID="TextBox_multi_monthpay" runat="server" Visible="false"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td width="20%" align="center" class="htmltable_Left">
              勞保職業災害費率
            </td>
            <td colspan="3" class="htmltable_Right">
                <asp:TextBox ID="TextBox_labor_calm_rate" runat="server"  
                Width="56px" MaxLength="5" onkeypress="return IsFloatText();" ></asp:TextBox>%
            </td>
          </tr>
          <tr>
            <td width="20%" align="center" class="htmltable_Left">
              薪資實施年月
            </td>
            <td colspan="3" class="htmltable_Right">  
                <asp:Label ID="Label_unit_ym" runat="server"></asp:Label>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate> 
                        <uc1:ucDateTextBox ID="UcDateTextBox_ym" runat="server" Kind="YM" Visible="false" />
                    </ContentTemplate>   
                </asp:UpdatePanel>
                <asp:TextBox ID="TextBox_Unit_YM" runat="server" Visible="false" ></asp:TextBox>
            </td>
          </tr>  
     </table>
 
  <table id="Table3"  style="text-align:left" width="100%">
          <tr>
            <td colspan="4" align="center">                     
                銀行設定   
                <table width="100%">
                    <tr>
                        <td align="left" style="width:42%">
                            <asp:Button ID="Button_newbank" runat="server" Text="新增銀行資料" 
                                onclick="Button_newbank_Click" />
                        </td>
                        <td align="left" style="width:58%">
                              *銀行帳號設定說明*
                        </td>
                    </tr>
                </table>
            </td>
          </tr>
          <tr>
            <td colspan="4" align="center">   
                <asp:GridView ID="GridView_tdpf" runat="server" AutoGenerateColumns="False"  
                    ShowHeader="False" Width="100%" 
                    CellPadding="1" CellSpacing="1" BorderWidth="0px" CssClass="Grid" 
                    ondatabinding="GridView_tdpf_DataBinding" ondatabound="GridView_tdpf_DataBound">
                    <Columns>
                        <asp:TemplateField>                         
                            <ItemTemplate>
                                <asp:Panel ID="Panel1" runat="server" Visible='<%# Convert.ToBoolean(Eval("de1")) %>' >                              
                                <input id="delete" type="button" value="刪除" onclick="btnDelete_Click('<%#((GridViewRow)Container).RowIndex%>')" />
                                </asp:Panel>
                                <asp:Panel ID="Panel2" runat="server" Visible='<%# Convert.ToBoolean(Eval("de2")) %>' >    
                                   已有員工帳號存在, 不可刪除
                                </asp:Panel>
                            </ItemTemplate>
                            <ItemStyle Width="15%"  />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TDPF_BANK" SortExpression="TDPF_BANK">                          
                            <ItemTemplate>                                   
                                    <table id="up" runat="server" width="100%"
                                    border="0" cellpadding="0" cellspacing="0" >
                                        <tr>
                                            <td style="width:40%">
                                                銀行名稱                              
                                                <uc1:ucSaCode ID="UcSaCode_bank" runat="server" 
                                                Code_sys="004" Code_type="002" ReturnEvent="true" Code_no='<%# Eval("TDPF_BANK") %>' 
                                                Orgid='<%# Eval("TDPF_ORGID") %>' ControlType="2" OnCodeChanged="BankChanged" CommandArgument ='<%#((GridViewRow)Container).RowIndex%>'  />
                                            </td>
                                            <td style="width:35%">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" id="ta2" runat="server" >
                                                    <tr>
                                                        <td>
                                                            帳號
                                                            <asp:TextBox ID="TextBox_tdpf_bank_no" runat="server" Text='<%# Eval("TDPF_BANK_NO") %>' 
                                                            MaxLength="20"></asp:TextBox>
                                                        </td>
                                                    </tr>  
                                                    <tr id="tr_medi" runat="server" visible='<%# Convert.ToBoolean(Eval("dp_medi")) %>' >
                                                        <td>                             
                                                            <asp:Label ID="Label_tdpf_medi" runat="server" Text="郵局入帳管制碼" ></asp:Label>
                                                            <asp:TextBox ID="TextBox_tdpf_medi" runat="server" Text='<%# Eval("TDPF_MEDI") %>' 
                                                            Width="42PX" MaxLength="6"></asp:TextBox>                                                                  
                                                        </td>
                                                    </tr>                                
                                                    <tr id="tr_no" runat="server" visible='<%# Convert.ToBoolean(Eval("dp_no")) %>' >
                                                        <td>
                                                            <asp:Label ID="Label_tdpf_no" runat="server" Text="統一編號" ></asp:Label>
                                                            <asp:TextBox ID="TextBox_tdpf_no" runat="server" Text='<%# Eval("TDPF_NO") %>' 
                                                            Width="70px" MaxLength="8"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    <td>
                                                    備註
                                                       <asp:TextBox ID="TextBox_tdpf_memo" runat="server" Text='<%# Eval("TDPF_MEMO") %>' ></asp:TextBox>
                                                    </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width:25%">
                                                <table border="0" cellpadding="0" cellspacing="0" style="width:100%; ">                                                 
                                                    <tr id="tr_title" runat="server" visible='<%# Convert.ToBoolean(Eval("dp_title")) %>' >
                                                        <td>
                                                            <asp:Label ID="Label_tdpf_title" runat="server" Text="轉帳清冊顯示抬頭"  ></asp:Label>
                                                            <asp:TextBox ID="TextBox_tdpf_title" runat="server" Text='<%# Eval("TDPF_TITLE") %>' 
                                                            Width="112px" MaxLength="50"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr_entno" runat="server" visible='<%# Convert.ToBoolean(Eval("dp_entno")) %>' >
                                                        <td>
                                                            <asp:Label ID="Label_tdpf_entno" runat="server" Text='<%# Eval("dp_entno_name")%>' ></asp:Label>
                                                            <asp:TextBox ID="TextBox_tdpf_entno" runat="server" Text='<%# Eval("TDPF_ENTNO") %>' 
                                                            Width="70px" MaxLength="11"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr_unit" runat="server" visible='<%# Convert.ToBoolean(Eval("dp_unit")) %>'>
                                                        <td>
                                                            <asp:Label ID="Label_tdpf_unit" runat="server" Text="代理單位"></asp:Label>
                                                            <asp:TextBox ID="TextBox_tdpf_unit" runat="server" Text='<%# Eval("TDPF_UNIT") %>' 
                                                            Width="70px" MaxLength="4"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr_branch" runat="server" visible='<%# Convert.ToBoolean(Eval("dp_branch")) %>'>
                                                        <td>
                                                            <asp:Label ID="Label_tdpf_branch" runat="server" Text="分行代號"  ></asp:Label>
                                                            <asp:TextBox ID="TextBox_tdpf_branch" runat="server" Text='<%# Eval("TDPF_BRANCH") %>' 
                                                            Width="70px" MaxLength="8"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr_custom" runat="server" visible='<%# Convert.ToBoolean(Eval("dp_custom")) %>'>
                                                        <td>
                                                            <asp:Label ID="Label_tdpf_custom" runat="server" Text='<%# Eval("dp_custom_name")%>' ></asp:Label>
                                                            <asp:TextBox ID="TextBox_tdpf_custom" runat="server" Text='<%# Eval("TDPF_CUSTOM") %>' 
                                                            Width="70px" MaxLength="8"></asp:TextBox> 
                                                        </td>
                                                    </tr>
                                                    <tr id="tr_param" runat="server" visible='<%# Convert.ToBoolean(Eval("dp_param")) %>'>
                                                        <td>
                                                            <asp:Label ID="Label_tdpf_param" runat="server" Text="權數"  ></asp:Label>
                                                            <asp:TextBox ID="TextBox_tdpf_param" runat="server" Text='<%# Eval("TDPF_PARAM") %>' 
                                                            Width="70px" MaxLength="2"></asp:TextBox>  
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>   
                            </ItemTemplate>
                            <ItemStyle Width="85%" HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:BoundField DataField ="TDPF_BANK" HeaderText="TDPF_BANK" />
                        <asp:BoundField DataField ="TDPF_ORGID" HeaderText="TDPF_ORGID" />
                        <asp:BoundField DataField ="TDPF_SEQNO" HeaderText="TDPF_SEQNO" />
                    </Columns>  
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                </asp:GridView>             
            </td>
          </tr>
        </table>  
          <table id="Table4"  style="text-align:center ">
          <tr>
                <td colspan="3" >                 
                    <input id="edit" type="button" value="儲存修改" onclick="btnedit_Click()"  />
                    <asp:Button ID="Button_reset" runat="server" Text="回復重寫" 
                        onclick="Button_reset_Click" />
                </td>
          </tr>
          </table>  
       
    <div style="visibility: hidden">
        <asp:Button ID="add_submit" runat="server" Text="確定新增" OnClick="add_submit_Click" />
        <asp:Button ID="edit_submit" runat="server" Text="確定儲存" OnClick="edit_submit_Click" />
        <asp:Button ID="btnSubmit" runat="server" Text="刪除" OnClick="btnSubmit_Click">
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
