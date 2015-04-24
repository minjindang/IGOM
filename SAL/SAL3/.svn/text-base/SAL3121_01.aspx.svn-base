<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL3121_01.aspx.cs" Inherits="SAL_SAL3_SAL3121" %>
<%@ Register src="../../UControl/SAL/ucSaCode.ascx" tagname="ucSaCode" tagprefix="uc2" %>
<%@ Register src="../../UControl/UcPager.ascx" tagname="UcPager" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="3">
                請選擇欲進行的所得稅申報檔維護作業 
            </td>  
        </tr>
        <tr>
            <td class="htmltable_Right">
                <asp:RadioButton ID="step1" runat="server" Text="第一步<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;媒體申報轉帳資料查詢" Checked="True" 
                    oncheckedchanged="step1_CheckedChanged" AutoPostBack="True" />      
            </td>
            <td class="htmltable_Right">
                <asp:RadioButton ID="step2" runat="server" Text="第二步<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;產生媒體申報轉帳檔" 
                    oncheckedchanged="step2_CheckedChanged" AutoPostBack="True" />
            </td>
           <td class="htmltable_Right">
                <asp:RadioButton ID="step3" runat="server" Text="第三步<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;媒體申報轉帳檔下載" 
                    oncheckedchanged="step3_CheckedChanged" AutoPostBack="True" />  
            </td>       
        </tr>      
        <tr>
            <td class="htmltable_Right" colspan="3">
             請選擇所得種類&nbsp;<uc2:ucSaCode ID="UcSaCode1" 
                    runat="server"  Code_Kind="P" Code_sys="003"
                            Code_type="004" ControlType="2" Mode="query" />
            </td>        
        </tr>
         <tr>
            <td class="htmltable_Right" colspan="3" style="height: 20px">
           所得年月 民國<asp:DropDownList ID="ddlyear" runat="server" AutoPostBack="True">
                </asp:DropDownList>年<asp:DropDownList ID="ddlmonth" runat="server" 
                    AutoPostBack="True">
                    <asp:ListItem Value=""> </asp:ListItem>
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
                </asp:DropDownList>月(產生整年度的資料不需輸入月份)
            </td> 
        </tr>  
        <tr>
            <td class="htmltable_Bottom" colspan="3" style="border-top: none;" width="50%">
                <asp:Button ID="Button_submit" runat="server" Text="媒體申報轉帳資料查詢" OnClick="Button_submit_Click" />          
                <asp:Button ID="Reset" runat="server" Text="重置" onclick="Reset_Click" />
            </td>
        </tr>      
    </table>
    
    
     <table class="tableStyle99" width="100%" runat ="server" id ="view" visible="False">
     <tr>
     <td class="htmltable_Title2" style="width: 100%" align="center">
     查詢結果
     </td>
     </tr>
     <tr>
     <td>     
         <asp:GridView ID="GridView_mediafmt" runat="server"  AutoGenerateColumns="False"          
           CellPadding="1" CellSpacing="1" BorderWidth="0px"  Width =100% 
             Visible="False" CssClass="Grid" AllowPaging="True" 
             PagerSettings-Position="TopAndBottom" PageSize="30" 
             PagerStyle-HorizontalAlign="Right" 
             onpageindexchanging="GridView_mediafmt_PageIndexChanging">
               <RowStyle CssClass="Row" />
                <AlternatingRowStyle CssClass="AlternatingRow" />
                <EmptyDataTemplate>
                    <table width="100%">    
                        <tr>
                            <td align="center">
                                <p><font size="4" color="#808080">未給定查詢字串或查詢資料不存在!!</font></p>
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="序號">                      
                        <ItemStyle  HorizontalAlign="Center" />
                        <ItemTemplate>
                            <%#((GridViewRow)Container).RowIndex+1%> 
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="身分證字號">                     
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:Label ID="Label_idno" runat="server" 
                            Text='<%# DataBinder.Eval(Container.DataItem, "base_idno") %>'/>                        
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="人員姓名">                   
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:Label ID="Label_form_name" runat="server" 
                            Text='<%# DataBinder.Eval(Container.DataItem, "base_name") %>'/>                           
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="申報年月">                   
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:Label ID="Label_amt" runat="server" 
                            Text='<%# DataBinder.Eval(Container.DataItem, "mediafmt_ym") %>'/>                          
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="申報項目">                   
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:Label ID="Label_txam" runat="server" 
                            Text='<%# DataBinder.Eval(Container.DataItem, "form_name") %>'/>                       
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>               
            </asp:GridView>                
     </td>
     </tr>
     <tr>
     <td align="right">
        <uc4:UcPager ID="UcPager" runat="server" GridName="GridView_mediafmt" 
                 PSize="30" PNow="1" />  
     </td>
     </tr>
      
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
                <asp:Label ID="Label_media_amt" runat="server" Text="Label" ForeColor="red"></asp:Label>
                扣繳稅額:
                <asp:Label ID="Label_media_txam" runat="server" Text="Label" ForeColor="red"></asp:Label>
                ]
            </td>
        </tr>
        <tr>
            <td>
                未達1000元：[給付總額:
                <asp:Label ID="Label_excl_amt" runat="server" Text="Label" ForeColor="red"></asp:Label>
                扣繳稅額:
                <asp:Label ID="Label_excl_txam" runat="server" Text="Label" ForeColor="red"></asp:Label>
              
            </td>
        </tr>
    </table>

<asp:TextBox ID="mode" runat="server" Visible="False">search</asp:TextBox>
    <asp:TextBox ID="p_filename" runat="server" Visible="False"></asp:TextBox> 
       <asp:Panel ID="plExport1" runat="server" Visible="False">
    <asp:Label ID="Label_download" runat="server" Text="11"></asp:Label>
     </asp:Panel>
</asp:Content>
