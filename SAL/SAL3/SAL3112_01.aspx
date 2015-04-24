<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" 
    CodeFile="SAL3112_01.aspx.cs" Inherits="SAL_SAL3_SAL3112_01" MaintainScrollPositionOnPostback="false" %>
  
<%@ Register src="../../UControl/UcPager.ascx" tagname="UcPager" tagprefix="uc4" %>
<%@ Register Src="../../UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc2" %>
<%@ Register Src="../../UControl/UcROCYearMonth.ascx" TagName="UcROCYearMonth" TagPrefix="uc3" %>
<%@ Register Src="../../UControl/SAL/UcSelectOrg.ascx" TagName="UcSelectOrg" TagPrefix="uc4" %>
<%@ Register Src="../../UControl/SAL/ucDateDropDownList.ascx" TagName="ucDateDropDownList"
    TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

  
   <script language="javascript">
     function btnDelete_Click(SerialNO) {
         if (confirm("確定刪除?")) {
             document.getElementById('ctl00_ContentPlaceHolder1_txtFuncParam').value = SerialNO;
             document.getElementById('ctl00_ContentPlaceHolder1_btnSubmit').click();
         }
     } 
   </script>

       <asp:UpdatePanel ID="UpdatePanel6" runat="server">
       <ContentTemplate>  
    <table class="tableStyle99" width="100%" runat="server" id = "searchview">
        <tr>
            <td class="htmltable_Title" colspan="4">
                薪資計算結果查詢與維護
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" width="15%">
                請選擇發放種類
            </td>
            <td class="htmltable_Right" colspan="3">
              <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>  
                <uc2:ucSaCode ID="cmb_uc_PayType" runat="server" Code_Kind="P" Code_sys="003" Code_type="005"
                    ControlType="2" ShowMulti="False" />
           </ContentTemplate></asp:UpdatePanel>  
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" width="15%">
                薪資年月
            </td>
            <td class="htmltable_Right" width="35%">
              <asp:UpdatePanel ID="UpdatePanel4" runat="server" >
                            <ContentTemplate>  
                 <uc4:ucDateDropDownList ID="ucDateDropDownList" runat="server" Kind="YM" />
                 </ContentTemplate></asp:UpdatePanel>  
            </td>
            <td class="htmltable_Left" width="15%">
                發放日期
            </td>
            <td class="htmltable_Right" width="35%">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>     
                <asp:DropDownList ID="cmbDatePay" runat="server" AutoPostBack="True">
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>        
            </td>
        </tr>
        <tr>
            <td colspan="4">        
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>                             
                <asp:Panel ID="pnlOthers" runat="server" Visible="False">
                    <table class="tableStyle99" width="100%">
                        <tr>
                            <td class="htmltable_Left" width="15%">
                                項目類別
                            </td>
                            <td class="htmltable_Right" width="35%">
                                <asp:DropDownList ID="cmbItemTyp1" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="cmbItemTyp1_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:DropDownList ID="cmbItemTyp2" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="cmbItemTyp2_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td class="htmltable_Left" width="15%">
                                項目名稱
                            </td>
                            <td class="htmltable_Right" width="35%">
                                <asp:DropDownList ID="cmbItemTypeName" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="cmbItemTypeName_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
              </ContentTemplate>
              </asp:UpdatePanel>  
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                單位別
            </td>
            <td class="htmltable_Right">
                <uc4:UcSelectOrg ID="cmb_uc_org" runat="server" ShowMulti="True" />
            </td>
            <td class="htmltable_Left">
                員工類別
            </td>
            <td class="htmltable_Right">
                <uc2:ucSaCode ID="cmb_uc_EmpType" runat="server" Code_Kind="P" Code_sys="002" Code_type="017"
                    ControlType="2" Mode="query" ShowMulti="True" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" style="height: 23px">
                員工編號
            </td>
            <td class="htmltable_Right" style="height: 23px">
                <asp:TextBox ID="edtEmpID" runat="server"></asp:TextBox>
            </td>
            <td class="htmltable_Left" style="height: 23px">
                員工姓名
            </td>
            <td class="htmltable_Right" style="height: 23px">
                <asp:TextBox ID="edtEmpName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%">
                <asp:Button ID="btnQuery" runat="server" Text="查詢" OnClick="btnQuery_Click" />
                <asp:Button ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" 
                    Visible="False" /> 
                <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
            </td>
        </tr>
    </table>
    </ContentTemplate></asp:UpdatePanel>  

         <asp:UpdatePanel ID="UpdatePanel5" runat="server">
         <ContentTemplate>               
      <table width="100%" runat="server" id ="view" visible="false" class="tableStyle99">
      <tr>
      <td class="htmltable_Title2" style="width: 100%" align="center">
      查詢結果
      </td>
      </tr>
      <tr>
      <td>
       <asp:GridView ID="gvResult" runat="server" Width="100%" AutoGenerateColumns="False"
        EnableModelValidation="True" CssClass="Grid" OnRowCommand="GridView1_RowCommand1"
        Visible="False" AllowPaging="True" ondatabinding="gvResult_DataBinding" 
              ondatabound="gvResult_DataBound" PagerSettings-Position="TopAndBottom" 
              PageSize="30" PagerStyle-HorizontalAlign="Right" 
              onpageindexchanging="gvResult_PageIndexChanging">
        <PagerSettings />
<PagerStyle HorizontalAlign="Right"></PagerStyle>
        <RowStyle CssClass="Row" />
        <AlternatingRowStyle CssClass="AlternatingRow" />
           <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                        <EmptyDataTemplate>
                            查無資料!!
                        </EmptyDataTemplate>
        <Columns>
        <asp:BoundField DataField="data_no" HeaderText="項次" />
            <asp:TemplateField HeaderText="員工編號">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkUserID" runat="server" CommandName="ShowDetail" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                        Text='<%# DataBinder.Eval(Container.DataItem, "payo_seqno") %>' />
                </ItemTemplate>
             </asp:TemplateField>
            <asp:BoundField HeaderText="單位" DataField="payo_dep" />
            <asp:BoundField HeaderText="員工姓名" DataField="payo_name" />
            <asp:BoundField HeaderText="應發合計" DataField="payod_amt_001" />
            <asp:BoundField HeaderText="應扣合計" DataField="payod_amt_002" />
            <asp:BoundField HeaderText="實發金額" DataField="payod_amt_003" />
            <asp:TemplateField HeaderText="刪除">
                <ItemTemplate>       
                    <asp:Panel ID="Panel2" runat="server">
                    <input id="btnDelte" type="button" value="刪除" onclick="btnDelete_Click('<%#((GridViewRow)Container).RowIndex%>')" />
                    </asp:Panel>
                <!--    <asp:Button ID="btn_delete" runat="server" Text="刪除" OnClientClick="btnDelete_Click('<%# Eval(((GridViewRow)Container).RowIndex) %>')" />  -->
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="payo_orgid" DataField="payo_orgid"  />
            <asp:BoundField HeaderText="payo_seqno" DataField="payo_seqno" />
            <asp:BoundField HeaderText="payo_kind" DataField="payo_kind"  />
            <asp:BoundField HeaderText="payo_yymm" DataField="payo_yymm"  />
            <asp:BoundField HeaderText="payo_date" DataField="payo_date"  />
            <asp:BoundField HeaderText="payo_kind_code_type" DataField="payo_kind_code_type"  />
            <asp:BoundField HeaderText="payo_kind_code_no" DataField="payo_kind_code_no"  />
            <asp:BoundField HeaderText="payo_kind_code" DataField="payo_kind_code"  />
            <asp:BoundField HeaderText="payo_fins_kind" DataField="payo_fins_kind"  />
            <asp:BoundField HeaderText="payo_quit_date" DataField="payo_quit_date" />
            <asp:BoundField HeaderText="payo_quit_rezn" DataField="payo_quit_rezn"  />
            <asp:BoundField HeaderText="PAYO_LABOR_DAYS" DataField="PAYO_LABOR_DAYS"  />
            <asp:BoundField HeaderText="PAYO_PEN_DAYS" DataField="PAYO_PEN_DAYS"  />
            <asp:BoundField HeaderText="PAYO_PEN_SUP_DAYS" DataField="PAYO_PEN_SUP_DAYS"  />
            <asp:BoundField HeaderText="PAYO_LABOR_SERIES" DataField="PAYO_LABOR_SERIES"  />
            <asp:BoundField HeaderText="PAYO_FINS_SELF" DataField="PAYO_FINS_SELF"  />
            <asp:BoundField HeaderText="PAYO_LAB_JIF" DataField="PAYO_LAB_JIF"  />
            <asp:BoundField HeaderText="PAYO_LAB1" DataField="PAYO_LAB1"  />
            <asp:BoundField HeaderText="PAYO_LAB2" DataField="PAYO_LAB2"  />
            <asp:BoundField HeaderText="PAYO_LAB3" DataField="PAYO_LAB3"  />
            <asp:BoundField HeaderText="PAYO_PEN_TYPE" DataField="PAYO_PEN_TYPE"  />
            <asp:BoundField HeaderText="PAYO_PEN_SERIES" DataField="PAYO_PEN_SERIES"  />
            <asp:BoundField HeaderText="PAYO_PEN_RATE" DataField="PAYO_PEN_RATE"  />
            <asp:BoundField HeaderText="payo_tax" DataField="payo_tax"  />
            <asp:BoundField HeaderText="payo_numerator" DataField="payo_numerator"  />
            <asp:BoundField HeaderText="payo_denominator" DataField="payo_denominator"  />
            <asp:BoundField HeaderText="payo_freeze" DataField="payo_freeze"  />
            <asp:BoundField HeaderText="Payo_prono" DataField="Payo_prono"  />
        </Columns>
    </asp:GridView>    
      </td>
      </tr>
      <tr><td align="right">
        <uc4:UcPager ID="UcPager" runat="server" GridName="gvResult" 
        Visible="False" PSize="30" PNow="1" />
      </td></tr>
      </table> 
    <div style="visibility: hidden">               
             <asp:button id="btnSubmit" runat="server" Text="刪除" onclick="btnSubmit_Click" ></asp:button> 
             <input id="txtFuncParam"  name="txtFuncParam" runat="server" />
             <asp:TextBox ID="indexno" runat="server"></asp:TextBox>
    </div> 
       </ContentTemplate></asp:UpdatePanel>  

     <asp:UpdatePanel ID="UpdatePanel7" runat="server">
         <ContentTemplate>             
      <asp:Panel ID="pnlDetail" runat="server" Visible="false">     
        <table class="tableStyle99" width="100%">
        <tr>
        <td class="htmltable_Left"> 
          員工姓名
        </td>
        <td class="htmltable_Right">
        <asp:Label ID="Label4" runat="server" Text="" ></asp:Label>
        </td>
        <td class="htmltable_Left">
          員工編號
        </td>
        <td class="htmltable_Right">
        <asp:Label ID="Label5" runat="server" Text="" ></asp:Label>
        </td>
        </tr>
        <tr>
        <td class="htmltable_Left">
          發放種類
        </td>
        <td class="htmltable_Right">
        <asp:Label ID="Label6" runat="server" Text="" ></asp:Label>
        </td>
        <td class="htmltable_Left">
          薪資年月
        </td>
        <td>
        <asp:Label ID="Label7" runat="server" Text="" ></asp:Label>
        </td>
        </tr>
            <tr>
                <td colspan="2" class="htmltable_Title">
                    應發項目
                </td>
                <td colspan="2" class="htmltable_Title">
                    應扣項目
                </td>
            </tr>
            <tr>
                <td colspan="2" style="vertical-align: top">
                    <asp:GridView ID="GridView_payod_001" runat="server" AutoGenerateColumns="False"
                        ShowHeader="False" Width="100%">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 50%" align="left">
                                                <asp:Label ID="Label_item" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "item_name") %>'></asp:Label>
                                            </td>
                                            <td style="width: 50%" align="left">
                                                <asp:TextBox ID="TextBox_amt" runat="server" Style="text-align:right" Text='<%# DataBinder.Eval(Container.DataItem, "payod_amt") %>'>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="payod_code_sys" DataField="payod_code_sys"  />
                            <asp:BoundField HeaderText="payod_code_type" DataField="payod_code_type"  />
                            <asp:BoundField HeaderText="payod_code_no" DataField="payod_code_no"  />
                            <asp:BoundField HeaderText="payod_code" DataField="payod_code"  />
                            <asp:BoundField HeaderText="payod_income" DataField="payod_income" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td colspan="2" style="vertical-align: top">
                    <asp:GridView ID="GridView_payod_002" runat="server" AutoGenerateColumns="False"
                        ShowHeader="False" Width="100%">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 50%" align="left">
                                                <asp:Label ID="Label_item" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "item_name") %>'></asp:Label>
                                            </td>
                                            <td style="width: 50%" align="left">
                                                <asp:TextBox ID="TextBox_amt" runat="server"  Style="text-align:right" Text='<%# DataBinder.Eval(Container.DataItem, "payod_amt") %>'>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="payod_code_sys" DataField="payod_code_sys"  />
                            <asp:BoundField HeaderText="payod_code_type" DataField="payod_code_type"  />
                            <asp:BoundField HeaderText="payod_code_no" DataField="payod_code_no"  />
                            <asp:BoundField HeaderText="payod_code" DataField="payod_code"  />
                            <asp:BoundField HeaderText="payod_income" DataField="payod_income"  />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" width="25%" style="height: 23px">
                    應發合計
                </td>
                <td class="htmltable_Right" width="25%" style="height: 23px">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </td>
                <td class="htmltable_Left" width="25%" style="height: 23px">
                    應扣合計
                </td>
                <td class="htmltable_Right" width="25%" style="height: 23px">
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="htmltable_Title">
                    實發數
                </td>
                <td colspan="2" class="htmltable_Title">
                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" class="htmltable_Title">
                    機關負擔項目
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GridView_payod_007" runat="server" AutoGenerateColumns="False"
                        ShowHeader="False" Width="100%">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 50%" align="left">
                                                <asp:Label ID="Label_item" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "item_name") %>'></asp:Label>
                                            </td>
                                            <td style="width: 50%" align="left">
                                                <asp:TextBox ID="TextBox_amt" runat="server" Style="text-align:right" Text='<%# DataBinder.Eval(Container.DataItem, "payod_amt") %>'>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="payod_code_sys" DataField="payod_code_sys"  />
                            <asp:BoundField HeaderText="payod_code_type" DataField="payod_code_type"  />
                            <asp:BoundField HeaderText="payod_code_no" DataField="payod_code_no"  />
                            <asp:BoundField HeaderText="payod_code" DataField="payod_code"  />
                            <asp:BoundField HeaderText="payod_income" DataField="payod_income"  />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="4" class="htmltable_Title">
                    備註:
                    <asp:TextBox ID="txtMemo" runat="server" Width="80%" MaxLength="120"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="htmltable_Title">
                    <asp:Button ID="Button1" runat="server" Text="儲存修改" OnClick="Button1_Click" 
                       />
                </td>
                <td colspan="2" class="htmltable_Title">
                    <asp:Button ID="Button2" runat="server" Text="關閉視窗" OnClick="Button2_Click" />&nbsp;&nbsp;&nbsp;<asp:Button
                        ID="Button3" runat="server" Text="試算勞保" OnClick="Button3_Click" Visible="False" />
                </td>
            </tr>
        </table>


        <asp:Panel ID="Panel1" runat="server" Visible="False">
            <asp:TextBox ID="txtpayo_orgid" runat="server" Visible="False"></asp:TextBox>
            <asp:TextBox ID="txtpayo_seqno" runat="server" Visible="False"></asp:TextBox>
            <asp:TextBox ID="txtpayo_kind" runat="server" Visible="False"></asp:TextBox>
            <asp:TextBox ID="txtpayo_yymm" runat="server" Visible="False"></asp:TextBox>
            <asp:TextBox ID="txtpayo_date" runat="server" Visible="False"></asp:TextBox>
            <asp:TextBox ID="txtpayo_kind_code_type" runat="server" Visible="False"></asp:TextBox>
            <asp:TextBox ID="txtpayo_kind_code_no" runat="server" Visible="False"></asp:TextBox>
            <asp:TextBox ID="txtpayo_kind_code" runat="server" Visible="False"></asp:TextBox>
            <asp:TextBox ID="TextBox_unit_pen_rate" runat="server" Visible="False"></asp:TextBox>
            <asp:TextBox ID="TextBox_labor_ptb_rate3" runat="server" Visible="False"></asp:TextBox>
            <table width="100%">
                <tr>
                    <td>
                        勞保投保天數<asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                    <td>
                        勞退自提天數<asp:TextBox ID="TextBox10" runat="server"></asp:TextBox><br>
                        勞退機關天數<asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="Button4" runat="server" Text="試算" OnClick="Button4_Click" />
                        <asp:Label ID="Label_payo_labor_days" runat="server" Text="" Visible="False"></asp:Label>
                        <asp:Label ID="Label_payo_pen_days" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="Label_payo_pen_sup_days" runat="server" Text="" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" class="htmltable_Title" style="height: 20px">
                        個人負擔
                    </td>
                </tr>
                <tr>
                    <td>
                        勞保費 - 普通事故保費率
                    </td>
                    <td>
                        <asp:Label ID="Label_lab_amt1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        勞工退休金
                    </td>
                    <td>
                        <asp:Label ID="Label_pen_amt" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        勞保費 - 就業保險費
                    </td>
                    <td>
                        <asp:Label ID="Label_lab_amt2" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td>
                        勞保費 - 合計
                    </td>
                    <td>
                        <asp:Label ID="Label_lab_amt" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" class="htmltable_Title" style="height: 20px">
                        機關負擔
                    </td>
                </tr>
                <tr>
                    <td>
                        勞保費 - 普通事故保費率
                    </td>
                    <td>
                        <asp:Label ID="Label_lab_sup1" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        勞工退休金
                    </td>
                    <td>
                        <asp:Label ID="Label_pen_sup" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        勞保費 - 就業保險費
                    </td>
                    <td>
                        <asp:Label ID="Label_lab_sup2" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td>
                        勞保費 - 職業災害保險費
                    </td>
                    <td>
                        <asp:Label ID="Label_lab_sup3" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td>
                        勞保費 - 合計
                    </td>
                    <td>
                        <asp:Label ID="Label_lab_sup" runat="server" Text=""></asp:Label>
                    </td>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" class="htmltable_Title" style="height: 20px">
                        <asp:Button ID="Button5" runat="server" Text="帶入薪資維護作業" OnClick="Button5_Click" />&nbsp;&nbsp;&nbsp;<asp:Button
                            ID="Button6" runat="server" Text="關閉此畫面" OnClick="Button6_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>     
    </asp:Panel>     
 </ContentTemplate></asp:UpdatePanel>

</asp:Content>
