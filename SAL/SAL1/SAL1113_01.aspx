<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="SAL1113_01.aspx.vb" Inherits="SAL1113_01"  %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="~/UControl/UcDate.ascx" TagName="UcDate" TagPrefix="uc2" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityDepart.ascx" TagPrefix="uc1" TagName="UcDDLAuthorityDepart" %>
<%@ Register Src="~/UControl/FSC/UcDDLAuthorityMember.ascx" TagPrefix="uc1" TagName="UcDDLAuthorityMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <script type="text/javascript">
      function Check(parentChk, ChildId) {
          var oElements = document.getElementsByTagName("INPUT");

          for (i = 0; i < oElements.length; i++) {
              if (IsCheckBox(oElements[i]) && IsMatch(oElements[i].id, ChildId)) {
                  oElements[i].checked = parentChk;
              }
          }
      }
      function IsMatch(id, ChildId) {
          var sPattern = '^ctl00_ContentPlaceHolder1_gvList_.*' + ChildId + '$';
          var oRegExp = new RegExp(sPattern);
          if (oRegExp.exec(id))
              return true;
          else
              return false;
      }
      function IsCheckBox(chk) {
          if (chk.type == 'checkbox') return true;
          else return false;
      }
    </script>
    <table class="tableStyle99" border="1" cellpadding="0" cellspacing="0" width="100%">
        <tr id="Tr1" runat="server">
            <td class="htmltable_Title" colspan="2" id="tdPageHeader" runat="server" >
            差旅費申請
            </td>
        </tr>
        <tr runat="server" id="tr_Remark">
            <td class="htmltable_Left" style="width:100px">
                申請年月</td>
            <td class="htmltable_Right">
                <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>
                       
                          <uc2:UcDate ID="UcDate1" runat="server" />
                &nbsp;~
                <uc2:UcDate ID="UcDate2" runat="server" /><br />
                <asp:Label ID="lbTip1" runat="server" ForeColor="Blue" Text="※填寫範例:101/01/01"></asp:Label> 
                    </contenttemplate>
                </asp:UpdatePanel>
                </td>
        </tr>
        <tr id="tr2" runat="server" visible="false" >
            <td class="htmltable_Left" style="width: 120px">單位名稱
            </td>
            <td class="htmltable_Right">
                <uc1:UcDDLAuthorityDepart runat="server" ID="UcDDLDepart" OnSelectedIndexChanged="UcDDLDepart_SelectedIndexChanged" />
            </td>
        </tr>            
        <tr id="tr3" runat="server" visible="false">
            <td class="htmltable_Left">人員姓名</td>
            <td class="htmltable_Right">
                <uc1:UcDDLAuthorityMember runat="server" ID="UcDDLMember" />
            </td>
        </tr>
        <tr >
            <td class="htmltable_Left" style="width:100px">
                差旅費類別</td>
            <td class="htmltable_Right">
                
                          <asp:DropDownList ID="officeOuttype" runat="server">
                              <asp:ListItem Value="">請選擇</asp:ListItem>
                              <asp:ListItem Value="1">國內出差</asp:ListItem>
                              <asp:ListItem Value="2">國外出差</asp:ListItem>
                          </asp:DropDownList>
               </td>

        </tr>
    </table>
    <div style="text-align:center">
        <asp:Button ID="btnSubmit" runat="server" Text="查詢"  /><asp:Button ID="btnReset" runat="server" Text="重填"  />
    </div>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" id="tbList" runat="server" class="tableStyle99">
        <tr>
            <td class="htmltable_Title2">
                查詢結果
            </td>
        </tr>
        <tr>
            <td>
                <input id="Button1" onclick="Check(true, 'gv_cbx')" type="button" value="全選" />
                <input id="Button2" onclick="Check(false, 'gv_cbx')" type="button" value="全不選" />                
                <asp:button ID="cbApply" runat="server" Text="申請" />                
            </td>
        </tr>
        <tr>
            <td class="TdHeightLight">
                <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="False" PageSize="30"
                    CssClass="Grid" Borderwidth="0px" PagerStyle-HorizontalAlign="Right" AllowPaging="True" Width="100%" EmptyDataText="查無資料!">
                    <Columns>
                        <asp:TemplateField HeaderText="選取">
                            <ItemTemplate>
                                <asp:CheckBox ID="gv_cbx" runat="server" />
                                
                                <asp:Label ID="lbPPIDNO" runat="server" Text='<%# Bind("PPIDNO") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbPPBUSTYPE" runat="server" Text='<%# Bind("PPBUSTYPE") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbPPBUSDATEB" runat="server" Text='<%# Bind("PPBUSDATEB") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lbPPTIMEB" runat="server" Text='<%# Bind("PPTIMEB") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lblocation_flag" runat="server" Text='<%# Bind("location_flag") %>' Visible="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="類別">
                            <ItemTemplate>
                                <asp:Label ID="lbType" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="公差日期">
                            <ItemTemplate>
                                <asp:Label ID="lkbDateS" runat="server"></asp:Label>-                              
                                <asp:Label ID="lbDateE" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" width="150px" />
                            <HeaderStyle width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="公差時間">
                            <ItemTemplate>
                                <asp:Label ID="lkbTimeS" runat="server"></asp:Label>-
                                <asp:Label ID="lbTimeE" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" width="150px" />
                            <HeaderStyle width="150px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="地點" DataField="PPBUSPLACE" Visible="false" />
                        <asp:BoundField HeaderText="事由" DataField="PPREASON" />
                        <asp:TemplateField HeaderText="申請狀態">
                            <ItemTemplate>
                                <asp:Label ID="lbStatus" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="已領註記">
                            <ItemTemplate>
                                <asp:Label ID="lbMark" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="表單編號" DataField="PPGUID"/>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />     
                    <EmptyDataRowStyle CssClass="EmptyRow" />                           
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Page">
                <uc1:Ucpager ID="Ucpager1" runat="server" EnableViewState="true" GridName="gvList"
                        Other1="Ucpager2" PNow="1" PSize="30" Visible="true" />
            </td>
        </tr>
    </table>
    <div style="color:Blue; width:100%; line-height:20px; margin-top:5px;">
        <ol>
           <li>
                <asp:Label runat="server" ID="Label1" ForeColor="red" Text="送出『差旅費申請』時，務必【列印】差旅費申請表、公差批示情形表！"></asp:Label>                
           </li>

            <li>
                <asp:Label runat="server" ID="lbtip" ForeColor="blue" Text="送出『差旅費申請』後，不可再修改申請內容，須請人事人員退回申請！"></asp:Label>                
           </li>
            <li>
                <asp:Label runat="server" ID="lbtip2" ForeColor="red" Text="已領的『差旅費』，會標示「已領」，不可重複申請！"></asp:Label>
            </li>
            <!--
            <li>
                國外差旅費採人工方式請領，空白表格請按這裡<a href="../../Report/FSC1/FSC1306.doc" target="_blank">國外出差旅費報告表</a>
            </li>
            -->
        </ol>
        
    </div>
    <asp:HiddenField ID="hfIsInit" runat="server" />
</asp:Content>

