<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL3119_01.aspx.cs" Inherits="SAL_SAL3_SAL3119" %>
<%@ Register src="../../UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc4" %>
<%@ Register src="../../UControl/SAL/ucSaCode.ascx" tagname="ucSaCode" tagprefix="uc2" %>
<%@ Register src="../../UControl/SAL/UcSelectOrg.ascx" tagname="UcSelectOrg" tagprefix="uc2" %>
<%@ Register src="../../UControl/SAL/ucDateDropDownList.ascx" tagname="ucDateDropDownList" tagprefix="uc2" %>
<%@ Register src="../../UControl/UcPager.ascx" tagname="UcPager" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">
                產生所得稅申報檔 
            </td>
        </tr>
        <tr> 
            <td class="htmltable_Left" colspan="1">
                請輸入所得年月
            </td>
            <td class="htmltable_Right" colspan="3">  
          民國<asp:DropDownList ID="ddlyy" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlyy_SelectedIndexChanged">
                </asp:DropDownList>年<asp:DropDownList ID="ddlmm" runat="server" 
                    AutoPostBack="True" onselectedindexchanged="ddlmm_SelectedIndexChanged">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="01"></asp:ListItem>
                    <asp:ListItem Value="02"></asp:ListItem>
                    <asp:ListItem Value="03"></asp:ListItem>
                    <asp:ListItem Value="04"></asp:ListItem>
                    <asp:ListItem Value="05"></asp:ListItem>
                    <asp:ListItem Value="06"></asp:ListItem>
                    <asp:ListItem Value="07"></asp:ListItem>
                    <asp:ListItem Value="08"></asp:ListItem>
                    <asp:ListItem Value="09"></asp:ListItem>
                    <asp:ListItem Value="10"></asp:ListItem>
                    <asp:ListItem Value="11"></asp:ListItem>
                    <asp:ListItem Value="12"></asp:ListItem>
                </asp:DropDownList>月
            </td>              
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%">
                <asp:Button ID="Button_detail" runat="server" Text="代扣稅款明細" 
                    onclick="Button_detail_Click"  />
                <asp:Button ID="Button_report" runat="server" Text="產生所得報稅檔" 
                    onclick="Button_report_Click"   />             
            </td>
        </tr>      
    </table>

    <table width="100%" runat = "server" id ="view" visible ="false" class="tableStyle99">
      <tr>
      <td class="htmltable_Title2" style="width: 100%" align="center">
      查詢結果
      </td>
      </tr>
    <tr><td>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                          Width="100%" CssClass="Grid" AllowPaging="True" 
            PagerSettings-Position="TopAndBottom" PageSize="30" 
            onpageindexchanging="GridView1_PageIndexChanging" >
            <PagerSettings Position="TopAndBottom"></PagerSettings>
            <PagerStyle HorizontalAlign="Right" />
            <RowStyle CssClass="Row" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                <EmptyDataTemplate>
                    查無資料!!
                </EmptyDataTemplate>
            <Columns>

             <asp:TemplateField HeaderText="署內/署外" ><ItemTemplate>
                     <asp:Label ID="lb_base_name" runat="server" 
                    Text='<%# DataBinder.Eval(Container.DataItem, "base_name") %>' ></asp:Label>
                </ItemTemplate></asp:TemplateField>
                  <asp:TemplateField HeaderText="預算來源"><ItemTemplate>
                      <asp:Label ID="lb_budget_name" runat="server" 
                    Text='<%# DataBinder.Eval(Container.DataItem, "budget_name") %>'  >
                    </asp:Label>
                </ItemTemplate></asp:TemplateField>

                <asp:TemplateField HeaderText="員工姓名" ><ItemTemplate>
                     <asp:Label ID="Label_name" runat="server" 
                    Text='<%# DataBinder.Eval(Container.DataItem, "engf_name") %>' ></asp:Label>
                </ItemTemplate></asp:TemplateField>
                  <asp:TemplateField HeaderText="身分證字號"><ItemTemplate>
                      <asp:Label ID="Label_idno" runat="server" 
                    Text='<%# DataBinder.Eval(Container.DataItem, "engf_idno") %>'  >
                    </asp:Label>
                </ItemTemplate></asp:TemplateField>
                 <asp:TemplateField HeaderText="所得項目"><ItemTemplate>
                     <asp:Label ID="Label_name" runat="server" 
                    Text='<%# DataBinder.Eval(Container.DataItem, "form_name") %>'  >
                    </asp:Label>
                </ItemTemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="給付總額&lt;br /&gt;(新台幣元)" ItemStyle-HorizontalAlign="Right"><ItemTemplate>
                      <asp:Label ID="Label_name" runat="server" 
                    Text='<%# DataBinder.Eval(Container.DataItem, "engf_amt") %>' >
                    </asp:Label>
                </ItemTemplate>
<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>
                   <asp:TemplateField HeaderText="扣繳稅額&lt;br /&gt;(新台幣元)" ItemStyle-HorizontalAlign="Right"><ItemTemplate>
                   <asp:Label ID="Label_name" runat="server" 
                    Text='<%# DataBinder.Eval(Container.DataItem, "engf_txam") %>' >
                    </asp:Label>
                </ItemTemplate>
<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>    
    </td></tr>   
      <tr><td align="right">
                    <uc4:UcPager ID="UcPager" runat="server" GridName="GridView1" 
                 Visible="False" PSize="30" PNow="1" />           
            </td></tr> 
    </table>

     <table runat="server" id = "message" visible="false">
        <tr>
            <td>
                應轉金額：[給付總額:
                <asp:Label ID="Label_inco_amt" runat="server" Text="Label" ForeColor="red"></asp:Label>
                扣繳稅額:
                <asp:Label ID="Label_inco_txam" runat="server" Text="Label" ForeColor="red"></asp:Label>
                ]
            </td>
        </tr>
        <tr>
            <td>
                已轉金額：[給付總額:
                <asp:Label ID="Label_engf_amt" runat="server" Text="Label" ForeColor="red"></asp:Label>
                扣繳稅額:
                <asp:Label ID="Label_engf_txam" runat="server" Text="Label" ForeColor="red"></asp:Label>
                ]
            </td>
        </tr>
        <tr>
            <td>            
                        <asp:Button ID="Button_error" runat="server" Text="檢視錯誤清單" 
                            onclick="Button_error_Click"  />
                 
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"  
                    CssClass="Grid" Visible="False">
            <RowStyle CssClass="Row" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
                <Columns>
                <asp:BoundField DataField="engf_name" HeaderText="員工姓名" />
               <asp:BoundField DataField="engf_idno" HeaderText="身分證字號" />
                 <asp:BoundField DataField="engf_amt" HeaderText="所得項目" />
               <asp:BoundField DataField="engf_txam" HeaderText="給付總額(新台幣元)" ItemStyle-HorizontalAlign="Right" />
                 <asp:BoundField DataField="form_name" HeaderText="扣繳稅額(新台幣元)" ItemStyle-HorizontalAlign="Right" />          
                </Columns>
             </asp:GridView>
            </td>
        </tr>       
    </table>
   <div style="visibility: hidden"> 
    <uc2:ucSaCode ID="ddlcno" runat="server"  Code_Kind="P" Code_sys="002"
                            Code_type="001" ControlType="2"  /> 
   </div>
</asp:Content>
