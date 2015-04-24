<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SAL3122_01.aspx.cs" Inherits="SAL_SAL3_SAL3122_01" %>
<%@ Register Src="../../UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc2" %>
<%@ Register Src="../../UControl/SAL/UcSelectOrg.ascx" TagName="UcSelectOrg" TagPrefix="uc4" %>
<%@ Register Src="../../UControl/SAL/ucDateDropDownList.ascx" TagName="ucDateDropDownList" TagPrefix="uc2" %>
<%@ Register src="../../UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc4" %>
<%@ Register src="../../UControl/UcPager.ascx" tagname="UcPager" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

  <script language="javascript"> 
      function btnDelete_Click(SerialNO) { 
          if (confirm("確定刪除?")) {
              document.getElementById('ctl00_ContentPlaceHolder1_txtFuncParam').value = SerialNO;
              document.getElementById('ctl00_ContentPlaceHolder1_btnSubmit').click();
          }
      }
   </script> 

    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4" style="height: 20px">
                人事行政局待遇資料上傳
            </td>
        </tr> 
        <tr>
            <td class="htmltable_Left" >
                聯絡人姓名
            </td>
            <td class="htmltable_Right" >
                <asp:TextBox ID="TextBox_cname" runat="server"></asp:TextBox>
            </td>
            <td class="htmltable_Left" >
                聯絡人電話
            </td>
            <td class="htmltable_Right" >
                <asp:TextBox ID="TextBox_ctel" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
       <td class="htmltable_Left" colspan="1">
                聯絡人E-mail 
            </td>
            <td class="htmltable_Right" colspan="3">
                <asp:TextBox ID="TextBox_cemail" runat="server"></asp:TextBox>
            </td>
        </tr>
          <tr>
       <td class="htmltable_Left" colspan="1">
                請輸入轉出薪資資料年月:
            </td>
            <td class="htmltable_Right" colspan="3">       
          
      <uc2:ucDateDropDownList ID="ucDateDropDownList" runat="server" title="民國" />       
  
            </td>
        </tr> 
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%">
                <asp:Button ID="btnReport" runat="server" Text="轉檔及下載" OnClick="btnReport_Click" />                     
            </td>
        </tr>
    </table>
  <!--  <asp:UpdatePanel ID="UpdatePanel1" runat="server"> 
    <ContentTemplate>    -->
  <table class="tableStyle99" width="100%" runat="server" id ="view">
  <tr>
  <td class="htmltable_Title2" style="width: 100%" align="center">
  查詢結果
  </td>
  </tr>
  <tr>
  <td>   
       <asp:GridView ID="GridView_Uporg" runat="server" 
            AutoGenerateColumns="False"  
         CellPadding="1" CellSpacing="1" BorderWidth="0px" Width="100%" 
        onrowcommand="GridView_Uporg_RowCommand" CssClass="Grid" AllowPaging="True" 
           PageSize="30" onpageindexchanging="GridView_Uporg_PageIndexChanging" 
           ondatabinding="GridView_Uporg_DataBinding" 
           ondatabound="GridView_Uporg_DataBound">  
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
                    <asp:TemplateField HeaderText="選擇">                       
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox_chk" runat="server" AutoPostBack="true" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="表別代號">                     
                        <ItemTemplate>
                            <asp:Label ID="Label_tabid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UPORG_TABID") %>'></asp:Label>
                            <asp:Label ID="Label_tabtype" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UPTCL_TYPE") %>' Visible="false"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="表別名稱">                      
                        <ItemTemplate>
                            <asp:Label ID="Label_tabname" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UPTCL_TABNAME") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="資料筆數">                     
                        <ItemTemplate>
                            <asp:Label ID="Label_TotCnt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotCnt") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="維護">                     
                        <ItemTemplate>
                            <asp:Button ID="update" runat="server" Text="維護" CommandName="doupdate" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                            <asp:Panel ID="Panel1" runat="server">                      
                                機關費用：<asp:TextBox ID="TextBox_amt" runat="server" Width="60px" MaxLength="8" 
                                Text='<%# DataBinder.Eval(Container.DataItem, "TotAmt") %>' Enabled="False" AutoPostBack="False"></asp:TextBox>元<br />
                            </asp:Panel>     
                            <input id="delete" type="button" value="刪除" onclick="btnDelete_Click('<%#((GridViewRow)Container).RowIndex%>')"/> 
                        </ItemTemplate>
                    </asp:TemplateField> 
                </Columns>                      
            </asp:GridView>             
  </td>
  </tr>
  <tr>
  <td align="right"  >
     <uc4:UcPager ID="UcPager" runat="server" GridName="GridView_Uporg" 
                  PSize="30" PNow="1" />
  </td></tr>
  </table>
                <div id="div_info" runat="server" style="display:none;">
            <asp:TextBox ID="TextBox_filename" runat="server"></asp:TextBox>      
             <asp:Panel ID="plExport1" runat="server" Visible="true">
                    <asp:Label ID="Label_download" runat="server" Text=""></asp:Label>
             </asp:Panel>  
              
                </div>   
                  <asp:TextBox ID="TextBox_ym" runat="server" Visible="False"></asp:TextBox>     
    <div style="visibility: hidden">                             
            	<asp:button id="btnSubmit" runat="server" Text="刪除" onclick="btnSubmit_Click" ></asp:button>
             <input id="txtFuncParam" type="hidden" name="txtFuncParam" runat="server"/>
    </div>
<!--</ContentTemplate></asp:UpdatePanel>  -->

</asp:Content>
