<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL3114_01.aspx.cs" Inherits="SAL_SAL3_SAL3114" %>
<%@ Register src="../../UControl/UcPager.ascx" tagname="UcPager" tagprefix="uc4" %>
<%@ Register Src="../../UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc2" %>
<%@ Register Src="../../UControl/UcROCYearMonth.ascx" TagName="UcROCYearMonth" TagPrefix="uc3" %>
<%@ Register Src="../../UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tableStyle99" width="100%"    >
        <tr>
            <td align="center" colspan="5" class="htmltable_Title">
                請選擇欲進行的基本薪資發放轉帳作業
            </td>
        </tr>
        <tr>
            <td align="center">
                第一步<br />
                <asp:RadioButton ID="rbStep1" runat="server" Text="產生轉帳檔" GroupName="rbSteps" AutoPostBack="True"
                    Checked="True" OnCheckedChanged="rbStep1_CheckedChanged" />
            </td>
            <td align="center">
                第二步<br />
                <asp:RadioButton ID="rbStep2" runat="server" Text="轉帳資料查詢" GroupName="rbSteps" AutoPostBack="True"
                    OnCheckedChanged="rbStep2_CheckedChanged" />
            </td>
            <td align="center">
                第三步<br />
                <asp:RadioButton ID="rbStep3" runat="server" Text="轉帳檔下載" GroupName="rbSteps" AutoPostBack="True"
                    OnCheckedChanged="rbStep3_CheckedChanged" />
            </td>
            <td align="center">
                第四步<br />
                <asp:RadioButton ID="rbStep4" runat="server" Text="轉帳清冊列印" GroupName="rbSteps" AutoPostBack="True"
                    OnCheckedChanged="rbStep4_CheckedChanged" />
            </td>
            <td align="center">
                第五步<br />
                <asp:RadioButton ID="rbStep5" runat="server" Text="EMAIL傳送作業" GroupName="rbSteps"
                    AutoPostBack="True" OnCheckedChanged="rbStep5_CheckedChanged" />
            </td>
        </tr>
    </table>
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Left" width="15%">
                請選擇發放種類
            </td>
            <td colspan="5">
                <uc2:ucSaCode ID="cmb_uc_calitem" runat="server" Code_Kind="P" Code_sys="003" Code_type="005"
                    ControlType="2" />
                <asp:DropDownList ID="cmbItemType2" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" width="15%">
                薪資年月
            </td>
            <td class="htmltable_Right" width="35%">
                <uc3:UcROCYearMonth ID="cmbYearMonth" runat="server" />            
            </td>
            <td class="htmltable_Left" width="15%">
                發放日期
            </td>                    
            <td class="htmltable_Right" width="10%" runat ="server" id="td1">             
             <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
            </td> 
            <td class="htmltable_Left" width="15%" runat="server" id="td2">
                  <asp:Label ID="Label1" runat="server" Text="修正發放日期"></asp:Label> 
             </td>         
            <td class="htmltable_Right">
                 <uc4:UcDate ID="UcDate1" runat="server" />        
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:Panel ID="pnlOthers" runat="server" Visible="False">
                    <table class="tableStyle99" width="100%">
                        <tr>
                            <td colspan="4" style="height: 20px">
                                請選擇其他發放項目
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left" width="15%">
                               是否已轉帳
                            </td>
                            <td colspan="3" class="htmltable_Right"> 
                            <asp:CheckBox ID="CheckBox1" runat="server" Text="是否已轉帳" AutoPostBack="True" 
                                    oncheckedchanged="CheckBox1_CheckedChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left" width="15%">
                                其他薪津
                            </td>
                            <td colspan="3" class="htmltable_Right"> 
                                 <asp:CheckBoxList ID="chkOtherPayItems" runat="server" RepeatColumns="5" 
                                    onselectedindexchanged="chkOtherPayItems_SelectedIndexChanged" 
                                     AutoPostBack="True">
                                </asp:CheckBoxList>
                         
                            </td>
                        </tr>                        

                    </table>
                </asp:Panel>
                  <asp:Panel ID="Panel1" runat="server" Visible="False">
                    <table class="tableStyle99" width="100%">
                        <tr>
                            <td colspan="2" class="htmltable_Left" width="15%">
                                發送副本e-mail位址
                            </td>
                            <td colspan="2" class="htmltable_Right">
                                <asp:TextBox ID="TextBox1" runat="server" Width="400px"></asp:TextBox>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1"
                   ErrorMessage="電子郵件信箱輸入格式不正確" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic">
                 </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        </table>
                  </asp:Panel>
            </td>
        </tr>
    </table>
         <asp:GridView ID="GridView2" runat="server" 
                    AutoGenerateColumns="False"  CssClass="Grid" CellPadding="1"
                    CellSpacing="1" BorderWidth="0px" Width="100%">
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <Columns>
                    <asp:BoundField DataField="PAYITEM_Merge_flow_id" HeaderText="批號" />
                    <asp:BoundField DataField="itemname" HeaderText="項目" />
                    </Columns>  
                   </asp:GridView>
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Bottom">                
                <asp:Button ID="Button_transfer" runat="server" Text="批次產生轉帳檔" 
                    onclick="Button_transfer_Click"/>
                <asp:Button ID="Button_search" runat="server" Text="轉帳資料查詢"  Visible="false" 
                    onclick="Button_search_Click"/>
                <asp:Button ID="Button_download" runat="server" Text="轉帳檔下載"
                    Visible="false" onclick="Button_download_Click" />
                <asp:Button ID="Button_print" runat="server" Text="轉帳清冊列印" Visible="false" 
                    onclick="Button_print_Click" />
                <asp:Button ID="Button_EMail" runat="server" Text="EMail傳送作業" Visible="false" 
                    onclick="Button_EMail_Click" />
                <asp:Button ID="Button_Reset" runat="server" Text="重置" />
            </td>
        </tr>
    </table>


    <table class="tableStyle99" width="100%" runat="server" visible ="false" id = "tableGV1">
      <tr>
      <td class="htmltable_Title2" style="width: 100%" align="center">
      查詢結果
      </td>
      </tr>
    <tr><td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    AllowPaging="True" CssClass="Grid" CellPadding="1"
                    CellSpacing="1" BorderWidth="0px"   
                    OnRowCommand="GridView1_RowCommand1" Width="100%" 
                    Visible="False" PageSize="30" 
                        onpageindexchanging="GridView1_PageIndexChanging" 
                        ondatabound="GridView1_DataBound" onrowdatabound="GridView1_RowDataBound" 
                        ShowFooter="True">
                        <FooterStyle HorizontalAlign="Center" />
                        <PagerSettings Position="TopAndBottom" />
                        <PagerStyle HorizontalAlign="Right" />
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                       <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                       <EmptyDataTemplate>
                       查無資料!!
                       </EmptyDataTemplate>
                    <Columns>
                    <asp:TemplateField>
                    <ItemTemplate>    
                        <asp:CheckBox id="ch1" runat="server" AutoPostBack="True" 
                            oncheckedchanged="ch1_CheckedChanged">
                        </asp:CheckBox>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PAYO_Merge_Flow_Id" HeaderText="批號" />
                    <asp:BoundField DataField="ITEM_NAME" HeaderText="項目" />
                    <asp:BoundField DataField="amt" HeaderText="金額" />
                    <asp:TemplateField HeaderText="明細">
                    <ItemTemplate>  
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="ShowDetail" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">明細資料</asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                       <asp:BoundField DataField="PAYO_KIND_CODE_TYPE" HeaderText="PAYO_KIND_CODE_TYPE" />
                          <asp:BoundField DataField="PAYO_KIND_CODE_NO" HeaderText="PAYO_KIND_CODE_NO" />
                             <asp:BoundField DataField="PAYO_KIND_CODE" HeaderText=" PAYO_KIND_CODE" />
                   
                     </Columns>
                     </asp:GridView>
                     </td></tr>
                      <tr>
                      <td align="right">
                        <uc4:ucpager ID="UcPager" runat="server" GridName="GridView1" 
                        PSize="30" PNow="1" />
                      </td>
                      </tr>
                      </table>
                    
                   <asp:GridView ID="GridView_trndata" runat="server" 
                    AutoGenerateColumns="False"  CssClass="Grid" CellPadding="1"
                    CellSpacing="1" BorderWidth="0px" Width="100%" Visible="False">
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <Columns>
                    <asp:BoundField DataField="PAYOD_Merge_flow_id" HeaderText="批號" />
                    <asp:BoundField DataField="BASE_NAME" HeaderText="姓名" />
                    <asp:BoundField DataField="ITEM_NAME" HeaderText="項目" />
                    <asp:BoundField DataField="PAYOD_AMT" HeaderText="金額" />
                    </Columns>  
                </asp:GridView>
                <br />
              
                     <table class="tableStyle99" width="100%" runat="server" visible ="false" id = "table1">
                      <tr>
                      <td class="htmltable_Title2" style="width: 100%" align="center">
                      查詢結果
                      </td>
                      </tr>
                    <tr>
                    <td>
                   <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                    AllowPaging="True"  CssClass="Grid" CellPadding="1"
                    CellSpacing="1" BorderWidth="0px" 
                     ondatabound="GridView3_DataBound" Width="100%" 
                      Visible="False" PageSize="30" onpageindexchanging="GridView3_PageIndexChanging">
                       <PagerSettings Position="TopAndBottom" />
                       <PagerStyle HorizontalAlign="Right" />
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                       <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                       <EmptyDataTemplate>
                       查無資料!!
                       </EmptyDataTemplate>
                    <Columns>
                    <asp:TemplateField HeaderText="序號">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1%>
                            </ItemTemplate>                        
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="批號">
                            <ItemTemplate>
                                <asp:Label ID="Label_idno" runat="server" Text='<%# Eval("TRNDATA_Merge_Flow_Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="身分證字號">
                            <ItemTemplate>
                                <asp:Label ID="Label_idno" runat="server" Text='<%# Eval("base_idno") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="人員姓名">
                            <ItemTemplate>
                                <asp:Label ID="Label_name" runat="server" Text='<%# Eval("BASE_NAME") %>'></asp:Label>
                            </ItemTemplate>                          
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="銀行帳號">
                            <ItemTemplate>
                                <asp:Label ID="Label_bankno" runat="server" Text='<%# Eval("BANK_BANK_NO") %>'></asp:Label>
                            </ItemTemplate>                        
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="發放金額(元)">
                            <ItemTemplate>
                                <asp:Label ID="Label_amt" runat="server" Text='<%# Eval("TRNDATA_AMT") %>'></asp:Label>
                            </ItemTemplate>                       
                        </asp:TemplateField>
                    </Columns>  
                </asp:GridView>
                </td>
                </tr>
                 <tr>
                 <td align="right">
                 <uc4:ucpager ID="UcPager1" runat="server" GridName="GridView3" 
                 PSize="30" PNow="1" />
                 </td>
                 </tr>
                 </table>

                 <table id ="amt" runat="server" visible="false">
                    <tr>
                        <td style="height: 20px">
                            &nbsp;&nbsp; &nbsp;&nbsp;應發總金額：<asp:Label ID="Label_payod_amt_1" runat="server" Text="0"
                                ForeColor="red"></asp:Label>元 &nbsp;&nbsp;轉帳總金額：<asp:Label ID="Label_trndata_amt_1"
                                    runat="server" Text="0" ForeColor="red"></asp:Label>元
                        </td>
                    </tr>
                </table>    
                

<div style="display: none">
<asp:TextBox ID="p_payo_str" runat="server"></asp:TextBox>
<asp:TextBox ID="p_payod_str" runat="server"></asp:TextBox>
<asp:TextBox ID="p_tdpm_str" runat="server"></asp:TextBox>

<asp:TextBox ID="p_tdpf_seqno" runat="server"></asp:TextBox>
<asp:TextBox ID="p_tdpm_code_sys" runat="server"></asp:TextBox>
<asp:TextBox ID="p_tdpm_code_type" runat="server"></asp:TextBox>
<asp:TextBox ID="p_tdpm_code_no" runat="server"></asp:TextBox>
<asp:TextBox ID="p_tdpm_code" runat="server"></asp:TextBox>

<asp:TextBox ID="unit_multi_monthpay" runat="server"></asp:TextBox>

<asp:TextBox ID="step3_p_payo_str" runat="server"></asp:TextBox>
<asp:TextBox ID="step3_p_payod_str" runat="server"></asp:TextBox>
<asp:TextBox ID="step3_p_tdpm_str" runat="server"></asp:TextBox>
<asp:TextBox ID="step3_p_nKeyStr" runat="server"></asp:TextBox>
<asp:TextBox ID="p_tdpm_tdpf_seqno" runat="server"></asp:TextBox>

<asp:TextBox ID="p_tdpf_Bank" runat="server"></asp:TextBox>
<asp:TextBox ID="p_tdpf_Bank_No" runat="server"></asp:TextBox>
<asp:TextBox ID="p_tdpf_Medi" runat="server"></asp:TextBox>
<asp:TextBox ID="p_tdpf_Title" runat="server"></asp:TextBox>
<asp:TextBox ID="p_tdpf_Unit" runat="server"></asp:TextBox>
<asp:TextBox ID="p_tdpf_entno" runat="server"></asp:TextBox>
<asp:TextBox ID="p_tdpf_branch" runat="server"></asp:TextBox>
<asp:TextBox ID="p_tdpf_no" runat="server"></asp:TextBox>
<asp:TextBox ID="p_tdpf_custom" runat="server"></asp:TextBox>

<asp:TextBox ID="p_filename" runat="server"></asp:TextBox>


<asp:TextBox ID="p_AA" runat="server" Text="0"></asp:TextBox>
<asp:TextBox ID="p_BB1" runat="server" Text="0"></asp:TextBox>
<asp:TextBox ID="p_BB" runat="server" Text="0"></asp:TextBox>
<asp:TextBox ID="p_CC" runat="server" Text="0"></asp:TextBox>
<asp:TextBox ID="trndatastring" runat="server"></asp:TextBox>
    <asp:Panel ID="plExport1" runat="server" Visible="false">
        <asp:Label ID="Label_download" runat="server" Text=""></asp:Label>
</asp:Panel>
<asp:TextBox ID="p_TT" runat="server"></asp:TextBox>

<asp:TextBox ID="step3nstr" runat="server"></asp:TextBox>
</div>

</asp:Content>
