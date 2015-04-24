<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="SAL3122_06.aspx.cs" Inherits="SAL3122_06" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <script language="javascript">   

      function show_search() {
          if (MySearch.style.display == "none") {
              MySearch.style.display = "block";
              document.all("TheSeach").value = "關閉搜尋器";
          }
          else {
              MySearch.style.display = "none";
              document.all("TheSeach").value = "開啟搜尋器";
          }
      }
 </script>
   <br>
         <table >
            <tr >
                <td>
                    <asp:Label ID="Label_tabname" runat="server" Text=""></asp:Label>
                </td>
                <td >
                   <asp:Button ID="btn_open" runat="server" Text="開啟搜尋器" 
                        onclick="btn_open_Click" />
             <!--      <input type="button" name="TheSeach"  value="開啟搜尋器" onclick="javascript:show_search();" id="TheSeach" />-->
                </td>
            </tr>
        </table>

        <table  id="MySearch" runat="server" visible ="false">
	        <tr>
		        <td>
		            身分證字號
		        </td>
		        <td>
                    <asp:TextBox ID="TextBox_src_idno" runat="server"></asp:TextBox>
		        </td>
		        <td>
		            姓名
		        </td>
		        <td>
                    <asp:TextBox ID="TextBox_src_name" runat="server"></asp:TextBox>		            
		        </td>
		        <td>
                    <asp:Button ID="Button_search" runat="server" Text="查 詢" 
                        onclick="Button_search_Click"  />
		        </td>
	        </tr>
        </table>

    <table id="div_gv_search" runat="server" visible="false" 
    border="0" cellpadding="0" cellspacing="0" style="width:100%">
      <tr>
      <td class="htmltable_Title2" style="width: 100%" align="center">
      查詢結果
      </td>
      </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView_Search" runat="server" AutoGenerateColumns="False"              
                BorderWidth="0" CellPadding="3" CellSpacing="3"  CssClass="Grid" Width="100%">
                  <RowStyle CssClass="Row" />
                   <AlternatingRowStyle CssClass="AlternatingRow" />
                    <Columns>
                        <asp:TemplateField HeaderText="序號">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="選取">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox_chk" runat="server" Checked="true" />
                                <asp:TextBox ID="TextBox_seqno" runat="server" Text='<%# Eval("SEQNO") %>' Visible="false"></asp:TextBox>
                                <asp:TextBox ID="TextBox_orgid" runat="server" Text='<%# Eval("ORGID") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="身分證字號">
                            <ItemTemplate>
                                <asp:Label ID="Label_idno" runat="server" Text='<%# Eval("IDNO") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="姓名">
                            <ItemTemplate>
                                <asp:Label ID="Label_name" runat="server" Text='<%# Eval("NAME") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="教育類別">
                            <ItemTemplate>
                                <asp:DropDownList ID="DropDownList_KIND1" runat="server" SelectedValue='<%# Eval("KIND1") %>'>
                                    <asp:ListItem Text="大學暨獨立學院" Value="1" ></asp:ListItem>
                                    <asp:ListItem Text="五專後二年，二、三專" Value="2" ></asp:ListItem>
                                    <asp:ListItem Text="五專前三年" Value="3" ></asp:ListItem>
                                    <asp:ListItem Text="高中" Value="4" ></asp:ListItem>
                                    <asp:ListItem Text="高職" Value="5" ></asp:ListItem>
                                    <asp:ListItem Text="國中" Value="6" ></asp:ListItem>
                                    <asp:ListItem Text="國小" Value="7" ></asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="人數">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox_Qty" runat="server" Width="40px" Text='<%# Eval("QTY") %>'></asp:TextBox>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="班別">
                            <ItemTemplate>
                                <asp:DropDownList ID="DropDownList_Class" runat="server" SelectedValue='<%# Eval("CLASS") %>'>
                                    <asp:ListItem Text="公立" Value="1" ></asp:ListItem>
                                    <asp:ListItem Text="私立" Value="2" ></asp:ListItem>
                                    <asp:ListItem Text="夜間部" Value="3" ></asp:ListItem>
                                    <asp:ListItem Text="自給自足班" Value="4" ></asp:ListItem>
                                    <asp:ListItem Text="實用技能班" Value="5" ></asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="親屬">
                            <ItemTemplate>
                                <asp:DropDownList ID="DropDownList_Kind2" runat="server" SelectedValue='<%# Eval("KIND2") %>'>
                                    <asp:ListItem Text="父母" Value="1" ></asp:ListItem>
                                    <asp:ListItem Text="配偶" Value="2" ></asp:ListItem>
                                    <asp:ListItem Text="子女" Value="3" ></asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:TemplateField>   
                        <asp:TemplateField HeaderText="支領數額">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox_amt" runat="server" Width="60px" Text='<%# DataBinder.Eval(Container.DataItem, "AMT") %>'></asp:TextBox>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:TemplateField>                     
                    </Columns> 
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="text-align:center;">
                <asp:Button ID="Button_insert" runat="server" Text="加入清單" 
                    onclick="Button_insert_Click" />
            </td>
        </tr>    
    </table>
    
      <table id="div_gv_upemp" runat="server" visible="true" 
    border="0" cellpadding="0" cellspacing="0" style="width:100%"> 
      
          <tr>
      <td class="htmltable_Title2" style="width: 100%" align="center">
      查詢結果
      </td>
      </tr>
        <tr>
            <td>
                   <asp:Button ID="ImageButton_select" runat="server" Text="全選" 
                       onclick="ImageButton_select_Click" />
                   <asp:Button ID="ImageButton_clean" runat="server" Text="清除" 
                       onclick="ImageButton_clean_Click" />               
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView_SaUpemp" runat="server" AutoGenerateColumns="False"               
                BorderWidth="0" CellPadding="3" CellSpacing="3"  Width="100%" CssClass="Grid">
                  <RowStyle CssClass="Row" />
                   <AlternatingRowStyle CssClass="AlternatingRow" />
                    <Columns>
                        <asp:TemplateField HeaderText="序號">
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="選取">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox_chk" runat="server" Checked="true" />
                                <asp:TextBox ID="TextBox_seqno" runat="server" Text='<%# Eval("SEQNO") %>' Visible="false"></asp:TextBox>
                                <asp:TextBox ID="TextBox_orgid" runat="server" Text='<%# Eval("ORGID") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="身分證字號">
                            <ItemTemplate>
                                <asp:Label ID="Label_idno" runat="server" Text='<%# Eval("IDNO") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="姓名">
                            <ItemTemplate>
                                <asp:Label ID="Label_name" runat="server" Text='<%# Eval("NAME") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="教育類別">
                            <ItemTemplate>
                                <asp:DropDownList ID="DropDownList_KIND1" runat="server" SelectedValue='<%# Eval("KIND1") %>'>
                                    <asp:ListItem Text="大學暨獨立學院" Value="1" ></asp:ListItem>
                                    <asp:ListItem Text="五專後二年，二、三專" Value="2" ></asp:ListItem>
                                    <asp:ListItem Text="五專前三年" Value="3" ></asp:ListItem>
                                    <asp:ListItem Text="高中" Value="4" ></asp:ListItem>
                                    <asp:ListItem Text="高職" Value="5" ></asp:ListItem>
                                    <asp:ListItem Text="國中" Value="6" ></asp:ListItem>
                                    <asp:ListItem Text="國小" Value="7" ></asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="人數">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox_Qty" runat="server" Width="40px" Text='<%# Eval("QTY") %>'></asp:TextBox>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="班別">
                            <ItemTemplate>
                                <asp:DropDownList ID="DropDownList_Class" runat="server" SelectedValue='<%# Eval("CLASS") %>'>
                                    <asp:ListItem Text="公立" Value="1" ></asp:ListItem>
                                    <asp:ListItem Text="私立" Value="2" ></asp:ListItem>
                                    <asp:ListItem Text="夜間部" Value="3" ></asp:ListItem>
                                    <asp:ListItem Text="自給自足班" Value="4" ></asp:ListItem>
                                    <asp:ListItem Text="實用技能班" Value="5" ></asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="親屬">
                            <ItemTemplate>
                                <asp:DropDownList ID="DropDownList_Kind2" runat="server" SelectedValue='<%# Eval("KIND2") %>'>
                                    <asp:ListItem Text="父母" Value="1" ></asp:ListItem>
                                    <asp:ListItem Text="配偶" Value="2" ></asp:ListItem>
                                    <asp:ListItem Text="子女" Value="3" ></asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:TemplateField>   
                        <asp:TemplateField HeaderText="支領數額">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox_amt" runat="server" Width="60px" Text='<%# Eval("AMT") %>'></asp:TextBox>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:TemplateField>                        
                    </Columns>                  
                </asp:GridView>  
            </td>
        </tr>
        <tr>
            <td style="text-align:center;">
                <asp:Button ID="Button_update" runat="server" Text=" 存  檔 " 
                    onclick="Button_update_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button_close" runat="server" Text=" 關  閉 " onclick="Button_close_Click" 
                   />          
            </td>
        </tr>
    </table> 
      <asp:Label ID="msg" runat="server" Text="" Visible="False"></asp:Label>

    <div id="div_info" runat="server" style="display:none;">
    <asp:TextBox ID="TextBox_btn" runat="server"></asp:TextBox>
    <asp:TextBox ID="TextBox_ym" runat="server"></asp:TextBox>
    <asp:TextBox ID="TextBox_tabid" runat="server"></asp:TextBox>
    <asp:TextBox ID="TextBox_baseStr" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="TextBox_payodStr" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="TextBox_upempStr" runat="server" Visible="false"></asp:TextBox>
    </div>
</asp:Content>
