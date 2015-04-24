<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL3118_01.aspx.cs" Inherits="SAL_SAL3_SAL3118" %>
<%@ Register src="../../UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc4" %>
<%@ Register src="../../UControl/SAL/ucSaCode.ascx" tagname="ucSaCode" tagprefix="uc2" %>
<%@ Register src="../../UControl/SAL/UcSelectOrg.ascx" tagname="UcSelectOrg" tagprefix="uc2" %>
<%@ Register src="../../UControl/SAL/ucDateDropDownList.ascx" tagname="ucDateDropDownList" tagprefix="uc2" %>
<%@ Register src="../../UControl/UcPager.ascx" tagname="UcPager" tagprefix="uc4" %>
<%@ Register Src="../../UControl/UcDDLDepart.ascx" TagName="UcDDLDepart" TagPrefix="uc8" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc2" TagName="UcDDLMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <script language="javascript">
       function btnDelete_Click(SerialNO)
           {
              if (confirm("確定刪除?"))  
              {
                  document.getElementById('ctl00_ContentPlaceHolder1_txtFuncParam').value = SerialNO;
                  document.getElementById('ctl00_ContentPlaceHolder1_btnSubmit').click();			
			  }
          }

          function IsFloatText() {
              var charkc = window.event.keyCode
              if (charkc == 46 || (charkc >= 48 && charkc <= 57)) {
                  return true;
              }
              return false;
          }       	


   </script>
  
    <table class="tableStyle99" width="100%" runat="server" id="searchtitle">
        <tr>
            <td class="htmltable_Title" colspan="4">
                所得扣繳資料檔維護
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                單位
            </td>
            <td class="htmltable_Right">
                       <uc8:UcDDLDepart ID="cmbDepartID" runat="server" />          
            </td>
           <td class="htmltable_Left">
                人員類別
            </td>
            <td class="htmltable_Right">
                <uc2:ucSaCode ID="ddlcno" runat="server"  Code_Kind="P" Code_sys="002"
                            Code_type="017" ControlType="2" Mode="query" />
            </td>
        </tr>      
        <tr>
            <td class="htmltable_Left">
                員工編號
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="txtno" runat="server"></asp:TextBox>
            </td>
               <td class="htmltable_Left">
                人員姓名
            </td>
            <td class="htmltable_Right">
                     <uc2:UcDDLMember runat="server" ID="ddlName" />
            </td>         
        </tr>
         <tr>
            <td class="htmltable_Left">
                在職狀態
            </td>
            <td class="htmltable_Right">
                <asp:DropDownList ID="ddlAct" runat="server">
                    <asp:ListItem Value="0">全部</asp:ListItem>
                    <asp:ListItem Value="1">在職員工</asp:ListItem>
                    <asp:ListItem Value="2">離職員工</asp:ListItem>
                </asp:DropDownList>
            </td>
               <td class="htmltable_Left">
                所得申報
            </td>
            <td class="htmltable_Right">
               <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem Value="Y">是</asp:ListItem>
                    <asp:ListItem Value="N">否</asp:ListItem>
                    <asp:ListItem Value="A">全部</asp:ListItem>
                </asp:DropDownList>
            </td>         
        </tr>
        <tr>
           <td class="htmltable_Left">
                給付日期起迄
            </td>
            <td class="htmltable_Right" colspan="3">
                <uc4:UcDate ID="UcDate1" runat="server" /> ~ 
                <uc4:UcDate ID="UcDate2" runat="server" /> 請輸入日期 (例如:103/01/01)
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                預算來源
            </td>
            <td class="htmltable_Right" >
                <uc2:ucSaCode ID="UcSaCode1" runat="server"  Code_Kind="P" Code_sys="002"
                            Code_type="018" ControlType="2" Mode="query" />
            </td>          
            <td  class="htmltable_Left"> 
            薪資種類
            </td>
            <td class="htmltable_Right">
              <uc2:ucSaCode ID="UcSaCode5" runat="server"  Code_Kind="P" Code_sys="003"
                            Code_type="005" ControlType="2" Mode="query" /> 
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%">
                <asp:Button ID="Button_report" runat="server" Text="代扣稅額總計" OnClick="Button_report_Click" />
                <asp:Button ID="Search" runat="server" Text="查詢" onclick="Search_Click"  />
                <asp:Button ID="Reset" runat="server" Text="重置" onclick="Reset_Click" 
                    Visible="False" />

            </td> 
        </tr>      
    </table>

    <table width="100%" runat="server" id="view" visible="False" class="tableStyle99">
      <tr>
      <td class="htmltable_Title2" style="width: 100%" align="center">
      查詢結果
      </td>
      </tr>
    <tr><td>
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                          Width="100%" CssClass="Grid" 
            OnRowCommand="GridView1_RowCommand1" AllowPaging="True" 
            ondatabinding="GridView1_DataBinding" 
            ondatabound="GridView1_DataBound" PageSize="30" 
            PagerSettings-Position="TopAndBottom" 
            onpageindexchanged="GridView1_PageIndexChanged" 
            onpageindexchanging="GridView1_PageIndexChanging">
           <PagerSettings Position="TopAndBottom"></PagerSettings>
           <PagerStyle HorizontalAlign="Right" />
           <RowStyle CssClass="Row" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                <EmptyDataTemplate>
                    查無資料!!
                </EmptyDataTemplate>
            <Columns>
             <asp:BoundField DataField ="status_name" HeaderText="資料類別"/>
             <asp:BoundField DataField ="base_idno" HeaderText="身分證號(統一編號)"/>
              <asp:BoundField DataField ="Depart_name" HeaderText="單位"/>
             <asp:BoundField DataField ="base_name" HeaderText="姓名"/>
             <asp:BoundField DataField ="alldate" HeaderText="所得給付區間"/>
             <asp:BoundField DataField ="incorec" HeaderText="給付總筆數"/>              
             <asp:BoundField  DataField="base_seqno" />   
             <asp:BoundField  DataField="base_idno" />            
             <asp:BoundField  DataField="base_name" />    
                <asp:TemplateField HeaderText="維護">
                <ItemTemplate>     
                    <asp:Button ID="Button1" runat="server" Text="維護" CommandName="ShowDetail" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>
             </ItemTemplate>
             </asp:TemplateField>  
             </Columns>
        </asp:GridView> 
    </td></tr>  
    <tr><td align="right">
      <uc4:UcPager ID="UcPager" runat="server" GridName="GridView1" 
                 PSize="30" PNow="1" />    
    </td></tr>
    </table>
  

     <asp:Panel ID="Panel1" runat="server" Visible="False">
     <table class="tableStyle99" width="100%">
     <tr>
     <td>
     姓名:<asp:Label ID="name" runat="server" Text="Label"></asp:Label>
     </td>
     <td>
     身分證號:<asp:Label ID="idno" runat="server" Text="Label"></asp:Label>
     </td>
     <td>
         <asp:Button ID="add_btn" runat="server" Text="新增" onclick="add_btn_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Label ID="Label2" runat="server" Text="檢視所得項目"></asp:Label>&nbsp;&nbsp;  
            <uc2:ucSaCode ID="UcSaCode4" runat="server"  Code_Kind="P" Code_sys="003"
                            Code_type="005" ControlType="2" Mode="query" /> 
     </td>
     </tr>     
     </table>
     <asp:Panel ID="edit" runat="server">
     <table>   
            <tr><td colspan="4">
                <asp:Label ID="Label1" runat="server" ForeColor="Red" >
       不可直接變更所得項目、年月、發放日期、科目，有變更發放日期需求且經由系統計算產生之資料請至 [轉帳作業]--[基本薪資發放轉帳]執行
       [發放日期修正]，若直接在此頁面新增之資料請刪除後重新新增一本資料</asp:Label>
       </td></tr>  
     <tr><td colspan="4">
         <asp:GridView ID="GridView_Inco" runat="server" AutoGenerateColumns="False"                    
                    Width="100%" onrowcommand="GridView_Inco_RowCommand"   >
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <table  id="div_header1" style="border: 1px solid #FFFFFF; width:100%;" runat="server" >
                                        <tr>
                                            <td class="htmltable_Title" width="20%">所得項目</td>
                                            <td class="htmltable_Title" width="20%">所得年月</td>
                                            <td class="htmltable_Title" width="20%">給付日期</td>
                                            <td class="htmltable_Title" width="20%">所得格式</td>
                                            <td class="htmltable_Title" rowspan="2" width="20%">維護</td>
                                        </tr>
                                        <tr>
                                            <td class="htmltable_Title">申報金額</td>
                                            <td class="htmltable_Title">扣繳稅率</td>
                                            <td class="htmltable_Title">扣繳稅額</td>
                                            <td class="htmltable_Title">預算來源</td>
                                        </tr>
                                    </table>                                   
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="20%">   
                                                <asp:DropDownList ID="inco_code" runat="server"> 
                                                </asp:DropDownList>  
                                                <asp:DropDownList ID="inco_kind_code" runat="server" > 
                                                </asp:DropDownList>  
                                            </td>             
                                            <td width="20%"><asp:Label ID="inco_ym" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "inco_ym") %>'></asp:Label>
                                            </td>
                                            <td width="20%"><asp:Label ID="inco_date" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "inco_date") %>'></asp:Label>
                                            </td> 
                                            <td width="20%"><asp:DropDownList ID="inco_icode" runat="server"> 
                                                </asp:DropDownList>        
                                            </td>
                                            <td rowspan="2" width="20%" align="center">
                                            <input id="delete" type="button" value="刪除" onclick="btnDelete_Click('<%#((GridViewRow)Container).RowIndex%>')"/> 
                                            </td>
                                         </tr>
                                         <tr>
                                         <td><asp:TextBox ID="inco_amt" runat="server" Style="text-align:right" Text='<%# DataBinder.Eval(Container.DataItem, "inco_amt") %>' MaxLength="8" onkeypress="return IsFloatText();"></asp:TextBox></td>
                                         <td><asp:Label ID="inco_txra" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "inco_txra") %>'></asp:Label></td>
                                         <td><asp:TextBox ID="inco_txam" runat="server" Style="text-align:right" 
                                                 Text='<%# DataBinder.Eval(Container.DataItem, "inco_txam") %>' MaxLength="8" 
                                                 onkeypress="return IsFloatText();" Enabled="False"></asp:TextBox></td>
                                         <td><asp:DropDownList ID="inco_budget_code" runat="server"> 
                                                </asp:DropDownList></td>
                                         </tr> 
                                    </table>                                 
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField  DataField ="inco_prikey"  HeaderText="KEY" />
                        </Columns>                          
                    </asp:GridView>
                    </td></tr>
                    <tr><td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%">
                        <asp:Button ID="btn_ok" runat="server" Text="確認" onclick="btn_ok_Click" />
                        <asp:Button ID="btn_cancel" runat="server" Text="回上頁" 
                            onclick="btn_cancel_Click" />
                    </td></tr>
         </table>
         </asp:Panel>
     </asp:Panel>

           <asp:Panel ID="add" runat="server" Visible="False">
            <table  id="div_header2" style="border: 1px solid #FFFFFF; width:100%;" 
                   runat="server"  >
            <tr>
                <td class="htmltable_Title" style="height: 20px" width="25%">所得項目</td>
                <td class="htmltable_Title" style="height: 20px" width="25%">所得年月</td>
                <td class="htmltable_Title" style="height: 20px" width="25%">給付日期</td>
                <td class="htmltable_Title" style="height: 20px" width="25%">所得格式</td>                                          
            </tr>
            <tr >
                <td  class="htmltable_Title">申報金額</td>
                <td  class="htmltable_Title">扣繳稅率</td>
                <td  class="htmltable_Title">扣繳稅額</td>
                <td  class="htmltable_Title">預算來源</td>
            </tr>
            <tr>
            <td>   
                 <uc2:ucSaCode ID="code_no" runat="server"  Code_Kind="P" Code_sys="003"
                            Code_type="005" ControlType="2" /> 
                <asp:DropDownList ID="DropDownList1" runat="server" 
                    AutoPostBack="True" 
                     onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td> 
               <uc2:ucDateDropDownList ID="ucDateDropDownList" runat="server"/>
            </td>
            <td><uc4:UcDate ID="UcDate3" runat="server" /> </td>
            <td><uc2:ucSaCode ID="UcSaCode2" runat="server"  Code_Kind="P" Code_sys="003"
                            Code_type="004" ControlType="2" /> </td>
            </tr>
            <tr>
            <td> <asp:TextBox ID="TextBox1" runat="server" Style="text-align:right" MaxLength="8" onkeypress="return IsFloatText();"></asp:TextBox> </td>
            <td> <asp:TextBox ID="TextBox2" runat="server" Style="text-align:right" MaxLength="8" onkeypress="return IsFloatText();"></asp:TextBox> </td>
            <td> <asp:TextBox ID="TextBox3" runat="server" Style="text-align:right" MaxLength="8" onkeypress="return IsFloatText();"></asp:TextBox> </td>
            <td> <uc2:ucSaCode ID="UcSaCode3" runat="server"  Code_Kind="P" Code_sys="002"
                            Code_type="018" ControlType="2" EnableTheming="True" 
                    Visible="True" /> </td>    
            </tr>
            <tr><td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%">
              <asp:Button ID="add_ok" runat="server" Text="確認" onclick="add_ok_Click"  />
                        <asp:Button ID="add_cancel" runat="server" Text="回上頁" onclick="add_cancel_Click" 
                           />
            </td></tr>
            </table> 
           </asp:Panel>          

      <div style="visibility: hidden">                             
            	<asp:button id="btnSubmit" runat="server" Text="刪除" onclick="btnSubmit_Click" ></asp:button>
             <input id="txtFuncParam" type="hidden" name="txtFuncParam" runat="server"/>
          <asp:TextBox ID="indexno" runat="server"></asp:TextBox>
             </div>

</asp:Content>
