<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL3128_01.aspx.cs" Inherits="SAL3128_01" %>
<%@ Register src="../../UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc4" %>
<%@ Register src="../../UControl/SAL/ucSaCode.ascx" tagname="ucSaCode" tagprefix="uc2" %>
<%@ Register src="../../UControl/SAL/UcSelectOrg.ascx" tagname="UcSelectOrg" tagprefix="uc2" %>
<%@ Register src="../../UControl/SAL/ucDateDropDownList.ascx" tagname="ucDateDropDownList" tagprefix="uc2" %>
<%@ Register src="../../UControl/UcPager.ascx" tagname="UcPager" tagprefix="uc4" %>
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
  
    <table class="tableStyle99" width="100%" id="title" runat="server" >
        <tr>
            <td class="htmltable_Title" colspan="4">
                非員工所得扣繳資料檔維護
            </td>
        </tr>   
        <tr>
            <td class="htmltable_Left">
              身分證號(統一編號)
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="txtno" runat="server" MaxLength="10" ></asp:TextBox>
            </td>
               <td class="htmltable_Left">
                人員姓名
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="txtname" runat="server" MaxLength="50" ></asp:TextBox>
            </td>         
        </tr>
         <tr>
            <td class="htmltable_Left">
                所得申報
            </td>
            <td class="htmltable_Right" colspan="3" >
               <asp:DropDownList ID="DropDownList2" runat="server" >
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
                <uc4:UcDate ID="UcDate2" runat="server" /> (例如:103/01/01)
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                預算來源
            </td>
            <td class="htmltable_Right" colspan="3">
                <uc2:ucSaCode ID="UcSaCode1" runat="server"  Code_Kind="P" Code_sys="002"
                            Code_type="018" ControlType="2" Mode="query" />
            </td>          
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%">
                <asp:label ID="lbIndex" runat="server" Visible="false" />
                <asp:Button ID="Search" runat="server" Text="查詢" onclick="Search_Click"  />
                <asp:Button ID="Reset" runat="server" Text="重置" onclick="Reset_Click" 
                    Visible="False" />
                <asp:Button ID="btnInsert" runat="server" Text="新增" OnClick="btnInsert_Click" />
                <asp:Button ID="Button_report" runat="server" Text="代扣稅額總計" OnClick="Button_report_Click" />
            </td>
        </tr>      
    </table>
    <table width="100%" class="tableStyle99" runat="server" id="view" visible="False">
        <tr>
      <td class="htmltable_Title2" style="width: 100%" align="center">
      查詢結果
      </td>
      </tr>
    <tr><td>
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" PagerStyle-HorizontalAlign="right"
                          Width="100%" CssClass="Grid" AllowPaging="true" PageSize="30" OnPageIndexChanging="GridView1_PageIndexChanging" >
           <PagerSettings Position="TopAndBottom" />
           <PagerStyle HorizontalAlign="Right"></PagerStyle>
           <RowStyle CssClass="Row" />
           <AlternatingRowStyle CssClass="AlternatingRow" />
            <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
            <EmptyDataTemplate>
                查無資料!!
            </EmptyDataTemplate>
            <Columns>
                <asp:TemplateField HeaderText="資料類別">
                <ItemTemplate>                   
                     <asp:Label ID="lbbase_dcode" runat="server" Text='<%# SALARY.Logic.app.GetBaseTypeText( Eval("base_type").ToString() ) %>' />
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="身分證號(統一編號)">
                <ItemTemplate>                    
                     <asp:Label ID="lbbase_idno" runat="server" Text='<%# Eval("base_idno") %>' /> 
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="姓名">
                <ItemTemplate>                  
                     <asp:Label ID="lbbase_name" runat="server" Text='<%# Eval("base_name") %>' />  
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="所得給付區間">
                <ItemTemplate>             
                     <asp:Label ID="lballdate" runat="server" Text='<%# Eval("alldate") %>' /> 
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="給付總筆數">
                <ItemTemplate>                   
                     <asp:Label ID="lbincorec" runat="server" Text='<%# Eval("incorec") %>' />  
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="維護">
                <ItemTemplate>
                    <asp:Button ID="btnUpdate" runat="server" Text="維護" OnClick="btnUpdate_Click" />
                </ItemTemplate>
                </asp:TemplateField>  
                <asp:BoundField  DataField="base_seqno" />   
                <asp:BoundField  DataField="base_idno" />            
                <asp:BoundField  DataField="base_name" />      
            </Columns>
        </asp:GridView>    
    </td></tr>
      <tr><td align="right">
      <uc4:ucpager ID="UcPager" runat="server" GridName="GridView1" 
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
         檢視所得項目&nbsp;&nbsp;&nbsp;<uc2:ucSaCode ID="UcSaCode4" runat="server"  Code_Kind="P" Code_sys="003"
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
                    Width="100%" onrowcommand="GridView_Inco_RowCommand" >
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <table  id="div_header1" style="border: 1px solid #FFFFFF; width:100%;" runat="server" >
                                        <tr>
                                            <td class="htmltable_Title"  width="20%">所得項目</td>
                                            <td class="htmltable_Title"  width="20%">所得年月</td>
                                            <td class="htmltable_Title"  width="20%">給付日期</td>
                                            <td class="htmltable_Title"  width="20%">所得格式</td>
                                            <td class="htmltable_Title" rowspan="2"  width="20%">維護</td>
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
                                            <td  width="20%">   
                                                <asp:DropDownList ID="inco_code" runat="server"> 
                                                </asp:DropDownList>  
                                                <asp:DropDownList ID="inco_kind_code" runat="server" > 
                                                </asp:DropDownList>  
                                            </td>             
                                            <td  width="20%"><asp:Label ID="inco_ym" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "inco_ym") %>'></asp:Label>
                                            </td>
                                            <td  width="20%"><asp:Label ID="inco_date" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "inco_date") %>'></asp:Label>
                                            </td> 
                                            <td  width="20%"><asp:DropDownList ID="inco_icode" runat="server"> 
                                                </asp:DropDownList>        
                                            </td>
                                            <td rowspan="2"  width="20%" align="center">
                                            <input id="delete" type="button" value="刪除" onclick="btnDelete_Click('<%#((GridViewRow)Container).RowIndex%>')"/> 
                                            </td>
                                         </tr>
                                         <tr>
                                         <td><asp:TextBox ID="inco_amt" runat="server"  Style="text-align:right" Text='<%# DataBinder.Eval(Container.DataItem, "inco_amt") %>' MaxLength="8" onkeypress="return IsFloatText();"></asp:TextBox></td>
                                         <td><asp:Label ID="inco_txra" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "inco_txra") %>'></asp:Label></td>
                                         <td><asp:TextBox ID="inco_txam" runat="server"  Style="text-align:right" Text='<%# DataBinder.Eval(Container.DataItem, "inco_txam") %>' MaxLength="8" onkeypress="return IsFloatText();"></asp:TextBox></td>
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


             <div style="visibility: hidden">                             
            	<asp:button id="btnSubmit" runat="server" Text="刪除" onclick="btnSubmit_Click" ></asp:button>
             <input id="txtFuncParam" type="hidden" name="txtFuncParam" runat="server"/>
             </div>

</asp:Content>
