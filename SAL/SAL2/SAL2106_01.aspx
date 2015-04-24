<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SAL2106_01.aspx.cs" Inherits="SAL_SAL2_SAL2106" %>

<%@ Register src="../../UControl/SAL/ucSaCode.ascx" tagname="ucSaCode" tagprefix="uc3" %>
<%@ Register src="../../UControl/SAL/UcSelectOrg.ascx" tagname="UcSelectOrg" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <!-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>  -->
            <table class="tableStyle99" width="100%">
                <tr>
                    <td class="htmltable_Title" colspan="4">加值匯出員工薪資資料
                    </td>
                </tr>
                <tr><td colspan="4">列印資料選項</td></tr>
                <tr>
                    <td class="htmltable_Left">單位別</td>
                    <td class="htmltable_Right">
                       
                        <uc2:UcSelectOrg ID="ddltype" runat="server" ShowMulti="True" />
                    </td>
                    <td class="htmltable_Left">員工姓名</td>
                    <td class="htmltable_Right">
                        <asp:TextBox ID="txtname" runat="server" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="htmltable_Left">在職狀態
                    </td>
                    <td class="htmltable_Right" >
                        <asp:DropDownList ID="ddlstatus" runat="server">
                            <asp:ListItem Value="0">現職員工</asp:ListItem>
                            <asp:ListItem Value="1">離職員工</asp:ListItem>
                        </asp:DropDownList>

                
                    </td>
                     <td class="htmltable_Left">人員類別
                     </td>
                    <td class="htmltable_Right">
                              <uc3:ucSaCode ID="ucSaCode" runat="server"  ControlType="2" Code_Kind="P" 
                                  Code_sys="002" Code_type="017" Mode="query" />
                    </td>
                </tr>
                <tr><td class="htmltable_Left">員工編號</td>
                <td class="htmltable_Right">
                  <asp:TextBox ID="txtno" runat="server" MaxLength="6"></asp:TextBox>
                </td>
                </tr>
                <tr><td colspan="4">使用本程式時，請遵守個人資料保護法及其餘法律規範</td></tr>
                <tr>
                    <td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%">
                        <asp:Button ID="Button_report" runat="server" Text="匯出" 
                            onclick="Button_report_Click" />                     
                            <asp:Button ID="allbutton" runat="server" Text="全選" 
                            onclick="allbutton_Click" />
                            <asp:Button ID="cleanbutton" runat="server" Text="清除" 
                            onclick="cleanbutton_Click" />
                      
                    </td>
                </tr>
            </table> 
    
            <table width=100%>
            <tr><td>
          <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal" 
                    Enabled="False">
              <asp:ListItem Value="0" Selected="True">身分證字號</asp:ListItem>
                <asp:ListItem Value="1" Selected="True">姓名</asp:ListItem>
                </asp:CheckBoxList>
            </td></tr> 
            <tr><td>  
             <asp:CheckBoxList ID="CheckBoxList2" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="0">人員類別</asp:ListItem>
                <asp:ListItem Value="1">性別</asp:ListItem>
                 <asp:ListItem Value="2">科室</asp:ListItem>
                  <asp:ListItem Value="3">是否府內員工</asp:ListItem>
                </asp:CheckBoxList>
                </td> </tr>  
               <tr><td>
                <asp:CheckBoxList ID="CheckBoxList3" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="0">職業類別</asp:ListItem>
                <asp:ListItem Value="1">職稱</asp:ListItem>
                 <asp:ListItem Value="2">職等代碼</asp:ListItem>
                  <asp:ListItem Value="3">年功俸</asp:ListItem>
                   <asp:ListItem Value="4">官等</asp:ListItem>
                </asp:CheckBoxList>
                </td></tr> 
                  <tr><td> 
                  <asp:CheckBoxList ID="CheckBoxList4" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="0">是否代理</asp:ListItem>
                <asp:ListItem Value="1">權理職等</asp:ListItem>
                 <asp:ListItem Value="2">權理官等</asp:ListItem>
                  <asp:ListItem Value="3">扶養人數</asp:ListItem>  </asp:CheckBoxList>
                  </td></tr> 
                     <tr><td>
                      <asp:CheckBoxList ID="CheckBoxList5" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="0">戶籍地址</asp:ListItem>
                <asp:ListItem Value="1">EMAIL</asp:ListItem>
                 <asp:ListItem Value="2">年終獎金</asp:ListItem>
                 </asp:CheckBoxList>
               </td></tr>       
                 <tr><td>
                      <asp:CheckBoxList ID="CheckBoxList6" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="0">到職日期</asp:ListItem>
                <asp:ListItem Value="1">離職日期</asp:ListItem>
                 <asp:ListItem Value="2">停職日期</asp:ListItem>
                </asp:CheckBoxList>
               </td></tr>        
                  <tr><td>
                      <asp:CheckBoxList ID="CheckBoxList7" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="0">本俸種類</asp:ListItem>
                <asp:ListItem Value="1">本俸俸點</asp:ListItem>
                 <asp:ListItem Value="2">本俸金額</asp:ListItem>
                </asp:CheckBoxList>
               </td></tr>  
                  <tr><td>
                      <asp:CheckBoxList ID="CheckBoxList8" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="0">主管加給種類</asp:ListItem>
                <asp:ListItem Value="1">主管加給級數</asp:ListItem>
                 <asp:ListItem Value="2">主管加給金額</asp:ListItem>
                </asp:CheckBoxList>
               </td></tr>             
                <tr><td>
                      <asp:CheckBoxList ID="CheckBoxList9" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="0">專業加給種類</asp:ListItem>
                <asp:ListItem Value="1">專業加給級數</asp:ListItem>
                 <asp:ListItem Value="2">專業加給金額</asp:ListItem>
                </asp:CheckBoxList>
               </td></tr>               
                <tr><td>
                      <asp:CheckBoxList ID="CheckBoxList10" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="0">所得稅扣繳方式</asp:ListItem>             
                </asp:CheckBoxList>
               </td></tr>           
                <tr><td>
                      <asp:CheckBoxList ID="CheckBoxList11" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="0">日薪</asp:ListItem>
                <asp:ListItem Value="1">時薪</asp:ListItem>
                 <asp:ListItem Value="2">個人健保標準金額</asp:ListItem>
                 <asp:ListItem Value="3">機關負擔健保金額</asp:ListItem>
               </asp:CheckBoxList>
               </td></tr> 
                <tr><td>
                      <asp:CheckBoxList ID="CheckBoxList12" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="0">房屋津貼</asp:ListItem>             
                </asp:CheckBoxList>
               </td></tr>   
                <tr><td>
                      <asp:CheckBoxList ID="CheckBoxList13" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="0">實物代金眷口數(大口)</asp:ListItem>
                <asp:ListItem Value="1">實物代金眷口數(中口)</asp:ListItem>
                 <asp:ListItem Value="2">實物代金眷口數(小口)</asp:ListItem>
                  </asp:CheckBoxList>
               </td></tr>           
                 <tr><td>
                      <asp:CheckBoxList ID="CheckBoxList14" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="0">個人實物代金註記</asp:ListItem>
              </asp:CheckBoxList>
               </td></tr>   
                  <tr><td>
                      <asp:CheckBoxList ID="CheckBoxList15" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="0">健保眷口總人數</asp:ListItem>
              </asp:CheckBoxList>
               </td></tr>  
                  <tr><td>
                      <asp:CheckBoxList ID="CheckBoxList16" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="0">健保免繳口數(重殘及低收入戶)</asp:ListItem>
                <asp:ListItem Value="1">健保地方補助口數(65歲以上長者)</asp:ListItem>
            </asp:CheckBoxList>  
            </td></tr>  
             <tr><td>
               <asp:CheckBoxList ID="CheckBoxList17" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="0">健保自付3/4口數(輕殘)</asp:ListItem>
                <asp:ListItem Value="1">健保自付1/2口數(中殘)</asp:ListItem>
            </asp:CheckBoxList>
               </td></tr>  
                      <tr><td>
                      <asp:CheckBoxList ID="CheckBoxList18" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="0">健保自付3/4且是地方補助雙重身份口數(輕殘+65歲以上長者)</asp:ListItem>
              </asp:CheckBoxList>
               </td></tr>   
                  <tr><td>
                      <asp:CheckBoxList ID="CheckBoxList19" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="0">健保自付1/2且是地方補助雙重身份口數(中殘+65歲以上長者)</asp:ListItem>
              </asp:CheckBoxList>
               </td></tr>  
                 <tr><td>
                      <asp:CheckBoxList ID="CheckBoxList20" runat="server" RepeatDirection="Horizontal">
              <asp:ListItem Value="0">備註一</asp:ListItem>
                <asp:ListItem Value="1">備註二</asp:ListItem>
                    <asp:ListItem Value="2">備註三</asp:ListItem>
                        <asp:ListItem Value="3">目前選定之備註</asp:ListItem>
              <asp:ListItem Value="4">是否兼職</asp:ListItem>
               <asp:ListItem Value="5">保險自付註記</asp:ListItem>
                <asp:ListItem Value="6">保險種類</asp:ListItem>
            </asp:CheckBoxList>       
            銀行帳號<br>
                     <asp:CheckBoxList ID="CheckBoxList21" runat="server" 
                          RepeatDirection="Horizontal">
                     </asp:CheckBoxList>
                 
               </td></tr>              
            </table>
     <!--          </ContentTemplate>
    </asp:UpdatePanel>  -->
</asp:Content>

