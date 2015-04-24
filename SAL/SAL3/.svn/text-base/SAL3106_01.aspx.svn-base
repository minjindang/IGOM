<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SAL3106_01.aspx.cs" Inherits="SAL_SAL3_SAL3106_01" %>
<%@ Register Src="../../UControl/SAL/UcSelectOrg.ascx" TagName="UcSelectOrg" TagPrefix="uc1" %>
<%@ Register Src="../../UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc2" %>
<%@ Register src="../../UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc3" %>
<%@ Register Src="../../UControl/SAL/ucDateDropDownList.ascx" TagName="ucDateDropDownList" TagPrefix="uc4" %>
<%@ Register src="../../UControl/UcPager.ascx" tagname="UcPager" tagprefix="uc5" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <script language="javascript">
      function btnDelete_Click(SerialNO) { 
          if (confirm("確定刪除?")) {
              document.getElementById('<%=txtFuncParam.ClientID%>').value = SerialNO;
              document.getElementById('<%=btnSubmit.ClientID%>').click();
          }
      }
   </script>
    
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">
                晉級補發維護
            </td>
        </tr>          
        <tr>
            <td class="htmltable_Left" >
                單位
            </td>
            <td class="htmltable_Right" >
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>            
                        <uc1:UcSelectOrg ID="cmb_uc_org" runat="server" ShowMulti="True" />
                     </ContentTemplate>
                </asp:UpdatePanel>          
            </td>
            <td class="htmltable_Left" >
                員工類別
            </td>
             <td  class="htmltable_Right">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <uc2:ucSaCode ID="ddlcno" runat="server"  Code_Kind="P" Code_sys="002" Code_type="017" ControlType="2" Mode="query" />
                    </ContentTemplate>
                </asp:UpdatePanel>
             </td>
        </tr>       
        <tr>
            <td class="htmltable_Left" >
                員工編號
            </td>
            <td class="htmltable_Right" >
                <asp:TextBox ID="edtEmpID" runat="server" MaxLength="6"></asp:TextBox>
            </td>
            <td class="htmltable_Left" >
                人員姓名
            </td>
            <td class="htmltable_Right" >
                <asp:TextBox ID="edtEmpName" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="htmltable_Left" >
                在職狀態
            </td>
            <td class="htmltable_Right" >
                <asp:DropDownList ID="ddlstatus" runat="server">
                    <asp:ListItem Value="0">全部</asp:ListItem>
                    <asp:ListItem Value="1">在職員工</asp:ListItem>
                    <asp:ListItem Value="2">離職員工</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="htmltable_Left" >
                請選擇晉級前最後年月
            </td>
            <td class="htmltable_Right" >
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <uc4:ucDateDropDownList ID="ucDateDropDownList" runat="server" title="民國" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" >
                補發開始日期
            </td>
            <td class="htmltable_Right" >
                <uc3:UcDate ID="UcDate1" runat="server" />             
            </td>
            <td class="htmltable_Left" >
                補發結束日期
            </td>
            <td class="htmltable_Right" >
               <uc3:UcDate ID="UcDate2" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%">
                <asp:Button ID="btnQuery" runat="server" Text="查詢" OnClick="btnQuery_Click" />
                <asp:Button ID="btnReset" runat="server" Text="重置" 
                    onclick="btnReset_Click" Visible="False" />     
                &nbsp;<asp:Button ID="btnAdd" runat="server" Text="新增" 
                    onclick="btnAdd_Click"  />     
                &nbsp;<asp:Button ID="btnAdd2" runat="server" Text="整批新增" 
                    onclick="btnAdd2_Click"  />              
            </td>
        </tr>
    </table>

     <table class="tableStyle99" width="100%" runat="server" id="search" visible ="false">
        <tr>
        <td class="htmltable_Title2" style="width: 100%" align="center">
        查詢結果
        </td>
        </tr>
        <tr id ="button" runat="server">
        <td>
         <asp:Button ID="select_all" runat="server" Text="全選" onclick="select_all_Click"  />
    &nbsp;<asp:Button ID="select_clean" runat="server" Text="全不選" onclick="select_clean_Click" />
      &nbsp;<asp:Button ID="b_DeleteMulti" runat="server" Text="刪除" onclick="b_DeleteMulti_Click" />
        </td>
        </tr>
   <tr><td> 
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                AllowPaging="True" AllowSorting="true"  RowStyle-HorizontalAlign="Center" 
                PagerSettings-Visible="True" Width="100%"  CssClass="Grid" 
        OnRowCommand="GridView1_RowCommand1" PageSize="30" 
        PagerSettings-Position="TopAndBottom" 
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
                <asp:BoundField DataField="data_no" HeaderText="項次" />
               
                    <asp:TemplateField HeaderText="選取">
                        <ItemTemplate >
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </ItemTemplate> 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="員工姓名" >
                        <ItemTemplate>
                            <asp:Label ID="c_base_name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "base_name") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="員工編號" >
                        <ItemTemplate>
                            <asp:Label ID="c_base_idno" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "base_seqno") %>' />
                        </ItemTemplate>                     
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="base_seqno" Visible="False" >
                        <ItemTemplate>
                            <asp:Label ID="c_base_seqno" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "base_seqno") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="promo_ym" Visible="False" >
                        <ItemTemplate>
                            <asp:Label ID="c_promo_ym" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "promo_ym") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="promo_seqno" Visible="False" >
                        <ItemTemplate>
                            <asp:Label ID="c_promo_seqno" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "promo_seqno") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="補發開始年月(年/月/日)" >
                        <ItemTemplate>
                        <asp:Label ID="c_promo_start_payym" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "promo_start_payym1") %>'  Visible="False" />
                       <!-- <asp:TextBox ID="txtpromo_start_payym" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "promo_start_payym1") %>' ></asp:TextBox> -->
                          <uc3:UcDate ID="GridUcDate3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "promo_start_payym1") %>'/>             
                        </ItemTemplate>                     
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="補發結束年月(年/月/日)" >
                        <ItemTemplate>
                        <asp:Label ID="c_promo_stop_payym" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "promo_stop_payym1") %>'  Visible="False" />
                      <!--  <asp:TextBox ID="txtpromo_stop_payym" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "promo_stop_payym1") %>' ></asp:TextBox>  -->
                            <uc3:UcDate ID="GridUcDate4" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "promo_stop_payym1") %>'/>     
                       </ItemTemplate>                     
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="維護" >
                        <ItemTemplate>
                          <asp:Button ID="update" runat="server" Text="修改" CommandName="doupdate" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                            <input id="delete" type="button" value="刪除" onclick="btnDelete_Click('<%#((GridViewRow)Container).RowIndex%>')"/> 
                        </ItemTemplate>                    
                    </asp:TemplateField>
                </Columns>             
            </asp:GridView>           
                </td></tr>
                   <tr><td align="right">
                    <uc5:UcPager ID="UcPager" runat="server" GridName="GridView1" 
                 Visible="False" PSize="30" PNow="1" />           
            </td></tr> 
            <tr><td>
             <asp:Label ID="errorInfo" runat="server" Visible="False"  />
            </td></tr> 
                </table>    
                 
            <div style="visibility: hidden">                             
            	<asp:button id="btnSubmit" runat="server" Text="刪除" onclick="btnSubmit_Click" ></asp:button>
                <input id="txtFuncParam" type="hidden" name="txtFuncParam" runat="server"/>
            </div>

</asp:Content>
