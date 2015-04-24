<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL3127_01.aspx.cs" Inherits="SAL_SAL3_SAL3127" %>
<%@ Register src="../../UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc4" %>
<%@ Register src="../../UControl/SAL/ucSaCode.ascx" tagname="ucSaCode" tagprefix="uc2" %>
<%@ Register src="../../UControl/SAL/UcSelectOrg.ascx" tagname="UcSelectOrg" tagprefix="uc2" %>
<%@ Register src="../../UControl/SAL/ucDateDropDownList.ascx" tagname="ucDateDropDownList" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function get_chg_kind()  
        {           
                if (confirm("正式所得檔資料與目前欲轉檔資料比較,\n發現有些資料除所得年月不同外,其餘大部分欄位相同,可能有誤,請檢查!\n若確定要轉檔,請按[確定],否則請按[取消]？")) 
                {
                    document.getElementById('<%=TextBox_chg_kind.ClientID %>').value = "Y";
                }
                else 
                {
                    document.getElementById('<%=TextBox_chg_kind.ClientID %>').value = "N";
                }
                document.getElementById('<%=Button_insert_inco.ClientID %>').click();            
        }    
    </script>

    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">
                外部資料轉入
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" colspan="1" style="height: 23px">
                第一步：選擇轉檔種類
            </td>
            <td class="htmltable_Right" style="height: 23px" colspan="3">
                <asp:DropDownList ID="ddltype" runat="server" 
                    onselectedindexchanged="ddltype_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Value="SAL_PAYITEM">各類補發代扣檔</asp:ListItem>
                    <asp:ListItem Value="SAL_SAINCO" Selected="True">所得扣繳資料檔</asp:ListItem>
                </asp:DropDownList>
            </td>        
        </tr>   
        <tr>       
           <td class="htmltable_Left"  colspan="1" style="height: 30px">
                 第二步：選擇項目類別
            </td>
            <td class="htmltable_Right" style="height: 30px" colspan="3">
                <asp:Label ID="Label1" runat="server" Text="其他薪津項目"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                <uc2:ucSaCode ID="ddlcno" runat="server"  Code_Kind="P" Code_sys="003"
                            Code_type="005" ControlType="2" Visible="False" />            
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Label ID="Label2" runat="server" Text="所得格式" Visible="False" ></asp:Label>&nbsp;
                 <asp:Label ID="codeno" runat="server" Text="001" Visible="False" ></asp:Label>                    
                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                    Visible="False">
                </asp:DropDownList>
            </td> 
        </tr>   
  
             <tr id="step21" runat="server" >
            <td colspan="1">
                是否隨薪
            </td>
            <td colspan="1">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem Value="Y">隨月薪</asp:ListItem>
                    <asp:ListItem Value="N">不隨月薪</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td colspan="1">
                發放方式
            </td>
            <td colspan="1">
                  <asp:DropDownList ID="TYPE" runat="server" AutoPostBack="True" 
                      onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                    <asp:ListItem Value="001">應發項</asp:ListItem>
                    <asp:ListItem Value="002">代扣項</asp:ListItem>
                </asp:DropDownList>
            </td>         
        </tr>
         <tr id ="step22" runat="server">
            <td colspan="1">
                項目類別
            </td>
            <td colspan="1">
              <uc2:ucSaCode ID="UcSaCode2" runat="server"  Code_Kind="D" Code_sys="005"
                          ReturnEvent="True" ControlType="2" />
            </td>
             <td colspan="1">
                項目名稱
            </td>
            <td colspan="1">
             <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownList3_SelectedIndexChanged">
                 </asp:DropDownList>
            </td>         
        </tr>
        <tr id="step23" runat="server">
           <td colspan="1">
                預算來源
            </td>        
            <td colspan="3">
                <uc2:ucSaCode ID="UcSaCode1" runat="server"  Code_Kind="P" Code_sys="002"
                            Code_type="018" ControlType="2" />
            </td>          
        </tr>
        <tr>
        <td class="htmltable_Left" colspan="1">
        第三步：投保單位
        </td>
        <td class="htmltable_Right" colspan="3">   
           <uc2:ucSaCode ID="UcSaCode3" runat="server"  Code_Kind="P" Code_sys="002"
                            Code_type="018"  ControlType="RadioButtonList" Budget_Code="Y" />
        </td>
        </tr>  
        <tr>
        <td class="htmltable_Left" colspan="1">
        第四步：上傳檔案
        </td>
        <td class="htmltable_Right" colspan="3">        
            <div>
                <table>
                    <tr>                      
                        <td width="200">
                            <asp:FileUpload ID="FileUpload1" runat="server"  
                                Width="100%" />
                            <asp:Label ID="lbFilename" runat="server"></asp:Label>
                        </td>
                        <td >
                            <asp:Button ID="Button_Upload" runat="server"  Text="確定上傳" 
                                onclick="Button_Upload_Click" />
                            <input id="Reset1"  type="reset" value="清空" />
                        </td>
                    </tr>               
                </table>
            </div>
            <div id="div_inco" runat="server" style="display:none;">
                ORGID=<asp:TextBox ID="TextBox_orgid" runat="server"></asp:TextBox>
                <br />
                BTN=<asp:TextBox ID="TextBox_btn" runat="server"></asp:TextBox>
                <br />
                FILENAME=<asp:TextBox ID="TextBox_filename" runat="server"></asp:TextBox>
                <br />
            </div>        
        </td>
        </tr>
        <tr>
        <td class="htmltable_Left" colspan="1" style="height: 25px">
        第五步：<asp:Label ID="Label3" runat="server" Text="轉檔" Font-Size="Medium"></asp:Label>
        </td>
        <td class="htmltable_Right" colspan="3" style="height: 25px">
        <asp:Button ID="SAL_PAYITEM_Btn" runat="server" Text="轉檔" 
                onclick="SAL_PAYITEM_Btn_Click" />
        <asp:Button ID="Button2" runat="server" Text="轉入暫存檔" Visible="False" 
                onclick="SAL_PAYITEM_Btn_Click" />
        </td>            
        </tr>
        <tr id="step5" runat="server" visible="false">
        <td class="htmltable_Left" colspan="1">
        第五步：轉入所得檔
        </td>
        <td class="htmltable_Right" colspan="3">
          <asp:Button ID="Button1" runat="server" Text="轉入所得檔" onclick="Button1_Click" />
        </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%">               
                <asp:Button ID="Reset" runat="server" Text="重置" onclick="Reset_Click" />
            </td>
        </tr>      
    </table>  
                   <table id="tran" runat="server" visible =false border="1">
                     <tr>
                        <td>
                            轉檔檔名:
                        </td>
                        <td >
                            <asp:Label ID="Label_fname" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr >
                        <td>
                            原始檔案筆數:
                        </td>
                        <td >
                            <asp:Label ID="lbcnt" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr >
                        <td>
                            轉檔筆數:
                        </td>
                        <td >
                            <asp:Label ID="lbincnt" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>

<asp:Label ID="Label_ErrMsg" runat="server" Text=""></asp:Label>

 <table width="100%">
        <tr>
            <td >             
                    <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" 
                    BorderWidth="1" cellspacing="0" cellpadding="0" Width="100%"
                    ShowFooter="true" ondatabinding="GridView1_DataBinding" 
                    ondatabound="GridView1_DataBound" onrowcreated="GridView1_RowCreated" CssClass="Grid">
                       <RowStyle CssClass="Row" />
                       <AlternatingRowStyle CssClass="AlternatingRow" />
                       <Columns>
                            <asp:TemplateField HeaderText="[&amp;nbsp;]">
                                <ItemTemplate>
                                    <asp:Label ID="Label_flag" runat="server" ForeColor="red" 
                                    Text='<%# DataBinder.Eval(Container.DataItem, "exists_flag") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="身分證號">
                                <ItemTemplate>
                                    <asp:Label ID="Label_idno" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Base_Idno") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="姓名">
                                <ItemTemplate>
                                    <asp:Label ID="Label_name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Base_Name") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="所得項目">
                            <ItemTemplate>
                                    <asp:Label ID="Label_code" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Inco_Code") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="所得格式">
                                <ItemTemplate>
                                    <asp:Label ID="Label_icode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Inco_Icode") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="所得年月">
                                <ItemTemplate>
                                    <asp:Label ID="Label_ym" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Inco_Ym") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="給付日期">
                                <ItemTemplate>
                                    <asp:Label ID="Label_date" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Inco_Date") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="給付總額">
                                <ItemTemplate>
                                    <asp:Label ID="Label_amt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Inco_amt") %>'></asp:Label>
                                    <asp:TextBox ID="TextBox_amt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Inco_amt") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="扣繳稅率">
                                <ItemTemplate>
                                    <asp:Label ID="Label_txra" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Inco_txra") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="扣繳稅額">
                                <ItemTemplate>
                                    <asp:Label ID="Label_txam" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Inco_txam") %>'></asp:Label>
                                    <asp:TextBox ID="TextBox_txam" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Inco_txam") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="公勞保費">
                                <ItemTemplate>
                                    <asp:Label ID="Label_fee" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Inco_fee") %>'></asp:Label>
                                    <asp:TextBox ID="TextBox_fee" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Inco_fee") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="健保費">
                                <ItemTemplate>
                                    <asp:Label ID="Label_fees" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Inco_fees") %>'></asp:Label>
                                    <asp:TextBox ID="TextBox_fees" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Inco_fees") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="自付退職金">
                                <ItemTemplate>
                                    <asp:Label ID="Label_leave_self" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Inco_leave_self") %>'></asp:Label>
                                    <asp:TextBox ID="TextBox_leave_self" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Inco_leave_self") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="機關負擔退職金">
                                <ItemTemplate>
                                    <asp:Label ID="Label_leave_sup" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Inco_leave_sup") %>'></asp:Label>
                                    <asp:TextBox ID="TextBox_leave_sup" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Inco_leave_sup") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="right" />
                            </asp:TemplateField>
                        </Columns> 
                       </asp:GridView>
           </td>
        </tr>
        <tr><td>
           <asp:Label ID="Label_dup" runat="server" Visible="false" ForeColor="red"
                            Text="有[＊]註記之資料, 表示該筆資料在正式所得檔已存在, 不應再轉檔。<br />">
                            </asp:Label>
                            <asp:Label ID="Label_dup1" runat="server" Visible="false" ForeColor="red"
                            Text="有[！]註記之資料, 表示該筆資料在正式所得檔除所得年月不同外, 其餘欄位已存在, 可能有誤,請檢查。<br />">
                            </asp:Label>       
        </td></tr>
        <tr><td>      
               
         <asp:Button ID="Button_insert" runat="server" Text="轉入正式所得檔" 
                onclick="Button_insert_Click" Visible="False"  />    
                
        </td></tr>
</table>   
<div style="display: none">
<asp:TextBox ID="TextBox_dup" runat="server" >0</asp:TextBox>
<asp:TextBox ID="TextBox_dup1" runat="server">0</asp:TextBox> 
<asp:TextBox ID="TextBox_chg_kind" runat="server"></asp:TextBox>
<asp:TextBox ID="TextBox_kind" runat="server"></asp:TextBox>
<asp:Button ID="Button_insert_inco" runat="server" Text="Button" 
        onclick="Button_insert_inco_Click" />
</div>
</asp:Content>
