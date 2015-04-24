<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL4103_01.aspx.cs" Inherits="SAL_SAL4_SAL4103" %>
    <%@ Register src="../../UControl/UcPager.ascx" tagname="UcPager" tagprefix="uc4" %>
<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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

        function IsFloatText() {
            var charkc = window.event.keyCode
            if (charkc == 46 || (charkc >= 48 && charkc <= 57)) {
                return true;
            }
            return false;
        }  
function add_onclick() {

}
    </script>     
   
    <asp:Panel ID="pnlNew" runat="server">
        <table class="tableStyle99" width="100%">
          <tr>
            <td class="htmltable_Title" colspan="4">
                所得申報格式檔設定
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
                <table class="tableStyle99" width="100%">
                  <tr>
                  <td class="htmltable_Title" colspan="4">
                       所得申報格式檔設定-新增
                  </td>
                  </tr>
                    <tr>
                        <td class="htmltable_Left">
                            序號
                        </td>
                        <td>
                            <asp:Label ID="lbseq" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            欄位種類
                        </td>
                        <td >
                            <asp:DropDownList ID="addtype" runat="server">
                                <asp:ListItem Value="001">資料庫欄位</asp:ListItem>
                                <asp:ListItem Value="002">日期</asp:ListItem>
                                <asp:ListItem Value="003">序號</asp:ListItem>
                                <asp:ListItem Value="004">空白</asp:ListItem>
                                <asp:ListItem Value="005">自訂</asp:ListItem>
                                <asp:ListItem Value="006">內參數</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            資料表名稱
                        </td>
                        <td>
                            <asp:TextBox ID="addtable" runat="server" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            欄位名稱
                        </td>
                        <td>
                            <asp:TextBox ID="addfleld" runat="server" MaxLength="50" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            起始位置
                        </td>
                        <td style="height: 23px">
                            <asp:DropDownList ID="addALIGN" runat="server">
                                <asp:ListItem Value="R">右</asp:ListItem>
                                <asp:ListItem Value="L">左</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            使用者自訂值/補值
                        </td>
                        <td>
                            <asp:TextBox ID="addREPLACE" runat="server" MaxLength="2" Width="25px" onkeypress="return IsFloatText();"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            擷取字串
                        </td>
                        <td>
                            字串起始位址&nbsp;
                            <asp:TextBox ID="addSUBSTART" runat="server" Width="30" MaxLength="2" onkeypress="return IsFloatText();"></asp:TextBox>&nbsp;
                            字串位數&nbsp;
                            <asp:TextBox ID="addSUBEND" runat="server" Width="30" MaxLength="2" onkeypress="return IsFloatText();"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            長度
                        </td>
                        <td>
                            <asp:TextBox ID="addLENGTH" runat="server" MaxLength="3" 
                                onkeypress="return IsFloatText();" Width="30px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            欄位規則
                        </td>
                        <td>
                            <asp:TextBox ID="addrule" runat="server" TextMode="MultiLine" Height="50px" 
                                Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <input id="add" type="button" value="確定" onclick="btnadd_Click()"  />
                            <asp:Button ID="add_cancel" runat="server" Text="取消" OnClick="add_cancel_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>

            <asp:Panel ID="editPanel" runat="server" Visible="False">
                 <table class="tableStyle99" width=100%>
                  <tr>
                  <td class="htmltable_Title" colspan="4">
                       所得申報格式檔設定-修改
                  </td>
                  </tr>
                    <tr>
                        <td class="htmltable_Left">
                            序號
                        </td>
                        <td>
                            <asp:Label ID="edit_seq" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            欄位種類
                        </td>
                        <td >
                            <asp:DropDownList ID="edit_TYPE" runat="server">
                                <asp:ListItem Value="001">資料庫欄位</asp:ListItem>
                                <asp:ListItem Value="002">日期</asp:ListItem>
                                <asp:ListItem Value="003">序號</asp:ListItem>
                                <asp:ListItem Value="004">空白</asp:ListItem>
                                <asp:ListItem Value="005">自訂</asp:ListItem>
                                <asp:ListItem Value="006">內參數</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            資料表名稱
                        </td>
                        <td>
                            <asp:TextBox ID="edit_TABLE" runat="server" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            欄位名稱
                        </td>
                        <td>
                            <asp:TextBox ID="edit_FIELD" runat="server" MaxLength="50" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            起始位置
                        </td>
                        <td>
                            <asp:DropDownList ID="edit_ALIGN" runat="server">
                                <asp:ListItem Value="R">右</asp:ListItem>
                                <asp:ListItem Value="L">左</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            使用者自訂值/補值
                        </td>
                        <td>
                            <asp:TextBox ID="edit_REPLACE" runat="server" MaxLength="2" Width="25px" onkeypress="return IsFloatText();"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            擷取字串
                        </td>
                        <td>
                            字串起始位址&nbsp;
                            <asp:TextBox ID="edit_SUBSTART" runat="server" Width="30" MaxLength="2" onkeypress="return IsFloatText();"></asp:TextBox>&nbsp;
                            字串位數&nbsp;
                            <asp:TextBox ID="edit_SUBEND" runat="server" Width="30" MaxLength="2" onkeypress="return IsFloatText();"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            長度
                        </td>
                        <td>
                            <asp:TextBox ID="edit_LENGTH" runat="server" MaxLength="3" 
                                onkeypress="return IsFloatText();" Width="30px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            欄位規則
                        </td>
                        <td>
                            <asp:TextBox ID="edit_rule" runat="server" TextMode="MultiLine" Height="50px" 
                                Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <input id="edit" type="button" value="確定" onclick="btnedit_Click()" />
                            <asp:Button ID="edit_cancel" runat="server" Text="取消" OnClick="edit_cancel_Click" />
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
                        AllowPaging="True" onpageindexchanging="GridView1_PageIndexChanging" 
                        PageSize="30" PagerStyle-HorizontalAlign="Right">
                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                <EmptyDataTemplate>
                    查無資料!!
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField DataField="fmt_seqno" HeaderText="序號" HeaderStyle-Wrap="False">
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="type" HeaderText="欄位種類" HeaderStyle-Wrap="False">
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="align" HeaderText="對齊" HeaderStyle-Wrap="False">
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fmt_format" HeaderText="資料表名稱" HeaderStyle-Wrap="False">
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fmt_setting" HeaderText="欄位名稱" HeaderStyle-Wrap="False">
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fmt_rep" HeaderText="填值" HeaderStyle-Wrap="False">
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fmt_start" HeaderText="字串起始位址" HeaderStyle-Wrap="False">
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fmt_num" HeaderText="字串位數" HeaderStyle-Wrap="False">
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fmt_length" HeaderText="欄位長度" HeaderStyle-Wrap="False">
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fmt_rule" HeaderText="欄位規則" HeaderStyle-Wrap="False">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Width="100px" Wrap="True" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="維護" ItemStyle-Wrap="False" ItemStyle-HorizontalAlign="Center"
                        ItemStyle-VerticalAlign="NotSet">
                        <ItemTemplate>
                            <asp:Button ID="update" runat="server" Text="維護" CommandName="doupdate" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                            <input id="delete" type="button" value="刪除" onclick="btnDelete_Click('<%#((GridViewRow)Container).RowIndex%>')" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Fmt_Type" HeaderText="" />
                    <asp:BoundField DataField="fmt_align" HeaderText="" />
                </Columns>
                <RowStyle CssClass="Row" />
                <AlternatingRowStyle CssClass="AlternatingRow" />
                <PagerSettings Position="TopAndBottom" />
            </asp:GridView> 
          </td></tr>
            <tr>
            <td align="right">
               <uc4:ucpager ID="UcPager" runat="server" GridName="GridView1" 
                  Visible="False" PSize="30" PNow="1" />
            </td>
            </tr>
          </table>

    <div style="visibility: hidden">
        <asp:Button ID="edit_submit" runat="server" Text="修改儲存" OnClick="edit_submit_Click" />
        <asp:Button ID="add_submit" runat="server" Text="新增儲存" OnClick="add_submit_Click" />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click">
        </asp:Button>
        <input id="txtFuncParam" type="hidden" name="txtFuncParam" runat="server"/>
    </div>
    <!--  </ContentTemplate>
    </asp:UpdatePanel>   -->
</asp:Content>
