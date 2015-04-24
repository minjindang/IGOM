<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL4102_01.aspx.cs" Inherits="SAL_SAL4_SAL4102" %>
<%@ Register src="../../UControl/UcPager.ascx" tagname="UcPager" tagprefix="uc4" %>
<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>   -->
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
function add_onclick() {

}
function IsFloatText() {
    var charkc = window.event.keyCode
    if (charkc == 46 || (charkc >= 48 && charkc <= 57)) {
        return true;
    }
    return false;
}
    </script>  
    
        <asp:Panel ID="pSearch" runat="server">
        <table class="tableStyle99" width="100%">
          <tr>
            <td class="htmltable_Title" colspan="4">
                銀行轉帳格式檔設定
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" colspan="2">
                選擇銀行:
            </td>
            <td class="htmltable_Right" colspan="2">
                <uc1:ucSaCode ID="ucSaCode" runat="server" Code_Kind="P" Code_sys="004" Code_type="002"
                    Mode="empty" ReturnEvent="True" ControlType="2" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                <asp:Button ID="Button_add" runat="server" Text="新增" OnClick="Button_add_Click" />
            </td>
        </tr>
    </table>
        </asp:Panel>
   
                <asp:Panel ID="addPanel" runat="server" Visible="False">
                  <table class="tableStyle99" width=100%>
                  <tr>
                  <td class="htmltable_Title" colspan="4">
                       銀行轉帳格式檔設定-新增
                  </td>
                  </tr>
                        <tr>
                            <td class="htmltable_Left">
                                銀行別
                            </td>
                            <td class="htmltable_Right">
                                <asp:Label ID="lbbankno" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td  class="htmltable_Left">
                                欄位順序
                            </td>
                            <td class="htmltable_Right">
                                <asp:Label ID="lbseq" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                資料形式
                            </td>
                            <td class="htmltable_Right">
                                <asp:DropDownList ID="datatype" runat="server">
                                    <asp:ListItem Value="001">資料庫欄位</asp:ListItem>
                                    <asp:ListItem Value="002">日期</asp:ListItem>
                                    <asp:ListItem Value="003">序號</asp:ListItem>
                                    <asp:ListItem Value="004">空白</asp:ListItem>
                                    <asp:ListItem Value="005">使用者自訂</asp:ListItem>
                                    <asp:ListItem Value="006">檢查碼</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                資料表名稱
                            </td>
                            <td class="htmltable_Right">
                                <asp:TextBox ID="txtdatetable" runat="server" MaxLength="25"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                欄位名稱
                            </td>
                            <td class="htmltable_Right">
                                <asp:TextBox ID="txtfleld" runat="server" MaxLength="25"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                起始位置
                            </td>
                            <td class="htmltable_Right">
                                <asp:DropDownList ID="ALIGN" runat="server">
                                    <asp:ListItem Value="R">右</asp:ListItem>
                                    <asp:ListItem Value="L">左</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                長度
                            </td>
                            <td class="htmltable_Right">
                                <asp:TextBox ID="txtLENGTH" runat="server" MaxLength="3"  
                                    onkeypress="return IsFloatText();" Width="30px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                使用者自訂值/補值
                            </td>
                            <td class="htmltable_Right">
                                <asp:TextBox ID="txtREPLACE" runat="server" MaxLength="3"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                擷取字串
                            </td>
                            <td class="htmltable_Right">
                                字串起始位址&nbsp;
                                <asp:TextBox ID="txtSUBSTART" runat="server" Width="30" MaxLength="2" 
                                    onkeypress="return IsFloatText();"></asp:TextBox>&nbsp; 字串位數&nbsp;
                                <asp:TextBox ID="txtSUBEND" runat="server" Width="30" MaxLength="2" 
                                    onkeypress="return IsFloatText();"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <input id="add" type="button" value="確定" onclick="btnadd_Click()"  />
                                <asp:Button ID="add_cancel" runat="server" Text="取消" OnClick="add_cancel_Click" 
                                    />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="editPanel" runat="server" Visible="False">
                  <table class="tableStyle99" width=100%>
                  <tr>
                  <td class="htmltable_Title" colspan="4">
                       銀行轉帳格式檔設定-修改
                  </td>
                  </tr>
                        <tr>
                            <td class="htmltable_Left">
                                銀行別
                            </td>
                            <td class="htmltable_Right">
                                <asp:Label ID="edit_bankno" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                欄位順序
                            </td>
                            <td class="htmltable_Right">
                                <asp:Label ID="edit_seq" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                資料形式
                            </td>
                            <td class="htmltable_Right">
                                <asp:DropDownList ID="edit_TYPE" runat="server">
                                    <asp:ListItem Value="001">資料庫欄位</asp:ListItem>
                                    <asp:ListItem Value="002">日期</asp:ListItem>
                                    <asp:ListItem Value="003">序號</asp:ListItem>
                                    <asp:ListItem Value="004">空白</asp:ListItem>
                                    <asp:ListItem Value="005">使用者自訂</asp:ListItem>
                                    <asp:ListItem Value="006">檢查碼</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                資料表名稱
                            </td>
                            <td class="htmltable_Right">
                                <asp:TextBox ID="edit_TABLE" runat="server" MaxLength="25"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                欄位名稱
                            </td>
                            <td class="htmltable_Right">
                                <asp:TextBox ID="edit_FIELD" runat="server" MaxLength="25"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                起始位置
                            </td>
                            <td class="htmltable_Right">
                                <asp:DropDownList ID="edit_ALIGN" runat="server">
                                    <asp:ListItem Value="R">右</asp:ListItem>
                                    <asp:ListItem Value="L">左</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                長度
                            </td>
                            <td class="htmltable_Right">
                                <asp:TextBox ID="edit_LENGTH" runat="server" MaxLength="3"  
                                    onkeypress="return IsFloatText();" Width="30"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                使用者自訂值/補值
                            </td>
                            <td class="htmltable_Right">
                                <asp:TextBox ID="edit_REPLACE" runat="server" MaxLength="3"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                擷取字串
                            </td>
                            <td class="htmltable_Right">
                                字串起始位址&nbsp;
                                <asp:TextBox ID="edit_SUBSTART" runat="server" Width="30" MaxLength="2"  
                                    onkeypress="return IsFloatText();"></asp:TextBox>&nbsp; 字串位數&nbsp;
                                <asp:TextBox ID="edit_SUBEND" runat="server" Width="30" MaxLength="2"  
                                    onkeypress="return IsFloatText();"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <input id="edit" type="button" value="確定" onclick="btnedit_Click()" />
                                <asp:Button ID="Button2" runat="server" Text="取消" OnClick="edit_cancel_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <table width="100%" id="view" runat="server" visible="false" class="tableStyle99">
                <tr>
                <td class="htmltable_Title2" style="width: 100%" align="center">
                查詢結果
                </td>
                </tr>
                <tr>
                <td>          
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                    OnRowCommand="GridView1_RowCommand1" Width="100%" CssClass="Grid" 
                        PagerSettings-Position="TopAndBottom" PageSize="30" AllowPaging="True" 
                        onpageindexchanging="GridView1_PageIndexChanging" PagerStyle-HorizontalAlign="Right">
                    <Columns>
                        <asp:BoundField DataField="trnfmt_seq" HeaderText="欄位順序" />
                        <asp:BoundField DataField="資料表名稱" HeaderText="資料表名稱" />
                        <asp:BoundField DataField="欄位名稱" HeaderText="欄位名稱" />
                        <asp:BoundField DataField="起始位置" HeaderText="起始位置" />
                        <asp:BoundField DataField="trnfmt_length" HeaderText="長度" />
                        <asp:BoundField DataField="trnfmt_replace" HeaderText="補值" />
                        <asp:TemplateField HeaderText="維護">
                            <ItemTemplate>
                                <asp:Button ID="update" runat="server" Text="維護" CommandName="doupdate" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                <input id="delete" type="button" value="刪除" onclick="btnDelete_Click('<%#((GridViewRow)Container).RowIndex%>')" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="trnfmt_source_type" HeaderText="資料形式" />
                        <asp:BoundField DataField="trnfmt_align" HeaderText="起始位置" />
                        <asp:BoundField DataField="TRNFMT_SUBSTART" HeaderText="位址" HtmlEncode="False" />
                        <asp:BoundField DataField="TRNFMT_SUBEND" HeaderText="位數" HtmlEncode="False" />
                    </Columns>
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                    <EmptyDataTemplate>查無資料!!</EmptyDataTemplate>
                </asp:GridView>                 
          </td></tr>
          <tr><td align="right">
             <uc4:UcPager ID="UcPager" runat="server" GridName="GridView1" 
                  Visible="False" PSize="30" PNow="1" />
          </td></tr>
          </table>

    <div style="visibility: hidden">
        <asp:Button ID="add_submit" runat="server" Text="新增儲存" OnClick="add_submit_Click" />
        <asp:Button ID="edit_submit" runat="server" Text="修改儲存" OnClick="edit_submit_Click" />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click">
        </asp:Button>
        <input id="txtFuncParam" type="hidden" name="txtFuncParam" runat="server"/>
    </div>
    <!--     </ContentTemplate>
    </asp:UpdatePanel>   -->
</asp:Content>
