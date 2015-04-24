<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="EMP3110_01.aspx.cs" Inherits="EMP_EMP3_EMP3110_01" %>
<%@ Register src="../../UControl/UcDate.ascx" tagname="UcDate" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <script language="javascript">
        function btnDelete_Click(SerialNO) {

            if (confirm("確定刪除?")) {
                document.getElementById('ctl00_ContentPlaceHolder1_txtFuncParam').value = SerialNO;
                document.getElementById('ctl00_ContentPlaceHolder1_btnSubmit').click();
            }
        }
        function btnedit_Click() {
            if (confirm("確定儲存?")) {
                document.getElementById('ctl00_ContentPlaceHolder1_edit_submit').click();
            }
        }
        function btnadd_Click() {
            if (confirm("確定新增?")) {
                document.getElementById('ctl00_ContentPlaceHolder1_add_submit').click();
            }
        } 
function btnAddOK_onclick() {

}

    </script>
    <table class="tableStyle99" width="100%" runat ="server" id="search">
        <tr>
            <td class="htmltable_Title" colspan="4">
                WEBSERVER的權限設定作業
            </td>
        </tr>  
        <tr>
            <td class="htmltable_Left" width="15%">
                應用系統主機位址
            </td>            
            <td class="htmltable_Right" width="35%">
            <asp:TextBox ID="AP_IP" runat="server" MaxLength="20" Width="220px"></asp:TextBox>
            </td>
            <td class="htmltable_Left" width="15%">
               應用系統管理單位名稱
            </td>
            <td class="htmltable_Right" width="35%">
             <asp:TextBox ID="AP_name" runat="server" MaxLength="20" Width="220px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" width="15%">
                資料查調類別
            </td>
            <td class="htmltable_Right" width="35%">
               <asp:TextBox ID="WS_type" runat="server" MaxLength="3" Width="40px"></asp:TextBox>
            </td>
            <td class="htmltable_Left" width="15%">
                應用系統代碼
            </td>
            <td class="htmltable_Right" width="35%">
                <asp:TextBox ID="AP_code" runat="server" MaxLength="3" Width="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" width="15%">
                資料查調期間(起)
            </td>
            <td class="htmltable_Right" width="35%">
                <uc4:UcDate ID="UcDate1" runat="server" />
            </td>
            <td class="htmltable_Left" width="15%">
                資料查調期間(迄)
            </td>
            <td class="htmltable_Right" width="35%">
                <uc4:UcDate ID="UcDate2" runat="server" />
            </td>
        </tr>
         <tr>
            <td class="htmltable_Left" width="15%">
                是否停用
            </td>
            <td class="htmltable_Right" width="35%" colspan="3">
              <asp:DropDownList ID="Is_disable" runat="server" AutoPostBack="True">
                  <asp:ListItem Value="0">啟用</asp:ListItem>
                  <asp:ListItem Value="1">停用</asp:ListItem>
                </asp:DropDownList>
            </td>
         
        </tr>       
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                <asp:Button ID="btnQuery" runat="server" Text="查詢" OnClick="btnQuery_Click" />
                <asp:Button ID="btnNew" runat="server" Text="新增" onclick="btnNew_Click" />  
            </td>
        </tr>
    </table>

         <asp:Panel ID="pnlQuery" runat="server" Visible="False">
         <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title2" colspan="4">
                    查詢結果
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="gvResult" runat="server" AutoGenerateColumns="False" 
                        EnableModelValidation="True" onrowcommand="gvResult_RowCommand" 
                        CssClass="Grid" Width="100%" AllowPaging="True" 
                        ondatabinding="gvResult_DataBinding" ondatabound="gvResult_DataBound" 
                        PagerSettings-Position="TopAndBottom" PagerStyle-HorizontalAlign="Right" 
                        PageSize="30" onpageindexchanging="gvResult_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="AP_IP" HeaderText="主機位址" />
                            <asp:BoundField DataField="AP_NAME" HeaderText="管理單位名稱" />
                            <asp:BoundField DataField="WS_type" HeaderText="資料查調類別" 
                                HtmlEncode="False" />
                            <asp:BoundField DataField="system_code" HeaderText="應用系統代碼" 
                                HtmlEncode="False" />
                            <asp:BoundField DataField="Use_sdate" HeaderText="資料查調期間(起)" 
                                HtmlEncode="False" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="Use_edate" HeaderText="資料查調期間(迄)" 
                                HtmlEncode="False" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="start" HeaderText="是否停用" 
                                HtmlEncode="False" />
                            <asp:BoundField DataField="Purpose" HeaderText="使用目的" 
                                HtmlEncode="False" /> 
                            <asp:BoundField DataField="Note_desc" HeaderText="備註" 
                                HtmlEncode="False" />
                            <asp:BoundField DataField="Change_userid" HeaderText="異動人員" 
                                HtmlEncode="False" />
                            <asp:BoundField DataField="Change_date" HeaderText="異動日期" 
                                HtmlEncode="False" DataFormatString="{0:d}" />
                            <asp:TemplateField HeaderText="維護">
                                <ItemTemplate>
                                    <asp:Button ID="update" runat="server" Text="維護" CommandName="doupdate" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                    <input id="delete" type="button" value="刪除" onclick="btnDelete_Click('<%#((GridViewRow)Container).RowIndex%>')" />
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:BoundField DataField="id" HeaderText="key" 
                                HtmlEncode="False" />
                        </Columns>
                        <PagerStyle HorizontalAlign="Right" />
            <RowStyle CssClass="Row" />
            <AlternatingRowStyle CssClass="AlternatingRow" />
            <PagerSettings Position="TopAndBottom" />
              <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                <EmptyDataTemplate>
                    查無資料!!
                </EmptyDataTemplate>
            </asp:GridView>                   
                </td>
            </tr>
            <tr><td align="right" >
             <uc1:Ucpager ID="Ucpager1" runat="server" GridName="gvResult" PSize="30" 
                        PNow="1" />
            </td></tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlNew" runat="server" Visible="False">
        <table class="tableStyle99" width="100%">        
          <tr>
            <td class="htmltable_Title" colspan="4">
                WEBSERVER的權限設定作業-<asp:Label ID="Label1" runat="server" Font-Size="Medium"></asp:Label>
            </td>
          </tr>  
            <tr>
            <td class="htmltable_Left" width="15%">
                應用系統主機位址
            </td>            
            <td class="htmltable_Right" width="35%">
            <asp:TextBox ID="AP_IP_1" runat="server" MaxLength="20" Width="220px"></asp:TextBox>
            </td>
            <td class="htmltable_Left" width="15%">
               應用系統管理單位名稱
            </td>
            <td class="htmltable_Right" width="35%">
             <asp:TextBox ID="AP_name_1" runat="server" MaxLength="20" Width="220px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" width="15%">
                資料查調類別
            </td>
            <td class="htmltable_Right" width="35%">
               <asp:TextBox ID="WS_type_1" runat="server" MaxLength="3" Width="40px"></asp:TextBox>
            </td>
            <td class="htmltable_Left" width="15%">
                應用系統代碼
            </td>
            <td class="htmltable_Right" width="35%">
                <asp:TextBox ID="AP_code_1" runat="server" MaxLength="3" Width="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" width="15%">
                資料查調期間(起)
            </td>
            <td class="htmltable_Right" width="35%">
                <uc4:UcDate ID="UcDate3" runat="server" />
            </td>
            <td class="htmltable_Left" width="15%">
                資料查調期間(迄)
            </td>
            <td class="htmltable_Right" width="35%">
                <uc4:UcDate ID="UcDate4" runat="server" />
            </td>
        </tr>
         <tr>
            <td class="htmltable_Left" width="15%">
                是否停用
            </td>
            <td class="htmltable_Right" width="35%">
              <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                  <asp:ListItem Value="0">啟用</asp:ListItem>
                  <asp:ListItem Value="1">停用</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="htmltable_Left" width="15%">
                使用目的
            </td>
            <td class="htmltable_Right" width="35%">
                <asp:TextBox ID="Purpose_1" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr >
            <td class="htmltable_Left" width="15%" colspan="1">
                備註
            </td>
            <td class="htmltable_Right" width="35%" colspan="3">
               <asp:TextBox ID="Note_desc_1" runat="server" Width="80%" TextMode="MultiLine" 
                    MaxLength="120"></asp:TextBox>
            </td>          
        </tr>       
        <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">                
                    <input id="btnAddOK" type="button" value="確定" runat="server" onclick="btnadd_Click()"  />
                    <input id="btnEditOK" type="button" value="確定" runat="server" onclick="btnedit_Click()" />
                    <asp:Button ID="cancel" runat="server" Text="取消" onclick="cancel_Click"/> 
                    <asp:Label ID="edit_id" runat="server" Text="" Visible="False"></asp:Label>  
                </td>
        </tr>
        </table>

    </asp:Panel>
        <div style="visibility: hidden">
        <asp:Button ID="add_submit" runat="server" Text="確定新增" 
            onclick="add_submit_Click" />
        <asp:Button ID="edit_submit" runat="server" Text="確定儲存" 
            onclick="edit_submit_Click" />
        <asp:Button ID="btnSubmit" runat="server" Text="刪除" 
            onclick="btnSubmit_Click"></asp:Button>  
        <input id="txtFuncParam" type="hidden" name="txtFuncParam" runat="server"/>

        </div>
</asp:Content>
