<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL4101_01.aspx.cs" Inherits="SAL_SAL4_SAL4101" %>
<%@ Register src="../../UControl/UcPager.ascx" tagname="UcPager" tagprefix="uc4" %>
<%@ Register Src="~/UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>-->
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

function edit_onclick() {

}

    </script>
    <table class="tableStyle99" width="100%" id="title" runat="server">   
         <tr>
            <td class="htmltable_Title" colspan="4">
                勞保事故保險金額分級表
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                請選擇保險種類
            </td>
            <td class="htmltable_Right">
                <uc1:ucSaCode ID="cmbTypes" runat="server" Code_Kind="P" Code_sys="001" Code_type="005"
                    ControlType="2" />
            </td>
            <td class="htmltable_Left">
                請選擇勞保事故保險費金額分級表啟用年月
            </td>
            <td class="htmltable_Right">
                民國<asp:DropDownList ID="DropDownList_Year" runat="server" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DropDownList_Year_SelectedIndexChanged">
                </asp:DropDownList>
                實施
            </td>
        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                <asp:Button ID="Button_add" runat="server" Text="新增" OnClick="Button_add_Click" />
                <asp:Button ID="Button_report" runat="server" Text="列印" OnClick="Button_report_Click" />
                <asp:Button ID="Button_Search" runat="server" Text="查詢" OnClick="Button_Search_Click" />
            </td>
        </tr>
    </table>
 
            <asp:Panel ID="addPanel" runat="server" Visible="False">
                    <table width=100% class="tableStyle99">
                       <tr>
            <td class="htmltable_Title" colspan="4">
                勞保事故保險金額分級表-新增
                        </td>
                    </tr>
                        <tr>
                            <td class="htmltable_Left">
                                請選擇保險種類:
                            </td>
                            <td class="htmltable_Right">
                                 <uc1:ucSaCode ID="UcSaCode1" runat="server" Code_Kind="P" Code_sys="001" Code_type="005"
                                  ControlType="2" />
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                啟用年月:
                            </td>
                            <td class="htmltable_Right">
                                民國<asp:TextBox ID="txtYear" runat="server" Width="50" MaxLength="3" onkeypress="return IsFloatText();"></asp:TextBox>年<asp:TextBox
                                    ID="txtMonth" runat="server" Width="30" MaxLength="2" onkeypress="return IsFloatText();"></asp:TextBox>月
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                               <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                投保金額等級
                            </td>
                            <td class="htmltable_Right">
                                <asp:TextBox ID="stws_level" runat="server" MaxLength="3" onkeypress="return IsFloatText();" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                               <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                月薪資所得上限
                            </td>
                            <td class="htmltable_Right">
                                <asp:TextBox ID="stws_up" runat="server" onkeypress="return IsFloatText();" 
                                    MaxLength="7"></asp:TextBox>元(單位:新台幣)
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                               <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                月薪資所得下限
                            </td >
                            <td class="htmltable_Right">
                                <asp:TextBox ID="stws_low" runat="server" onkeypress="return IsFloatText();" 
                                    MaxLength="7"></asp:TextBox>元(單位:新台幣)
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                1日(投保日數)自負擔金額
                            </td>
                            <td class="htmltable_Right">
                                <asp:TextBox ID="dct1" runat="server" onkeypress="return IsFloatText();" 
                                    MaxLength="7"></asp:TextBox>元(單位:新台幣)
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                30日(投保日數)自負擔金額
                            </td>
                            <td class="htmltable_Right">
                                <asp:TextBox ID="dct30" runat="server" onkeypress="return IsFloatText();" 
                                    MaxLength="7"></asp:TextBox>元(單位:新台幣)
                            </td>
                        </tr>
                          <tr>
                            <td class="htmltable_Left">
                               <asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                保險金額
                            </td>
                            <td class="htmltable_Right">
                                <asp:TextBox ID="stws_stand" runat="server" onkeypress="return IsFloatText();" 
                                    MaxLength="7"></asp:TextBox>元(單位:新台幣)
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                自負擔
                            </td>
                            <td class="htmltable_Right">
                                <asp:TextBox ID="STWS_DCT" runat="server" onkeypress="return IsFloatText();" 
                                    MaxLength="7"></asp:TextBox>元(單位:新台幣)
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                機關負擔
                            </td>
                            <td class="htmltable_Right">
                                <asp:TextBox ID="STWS_SUP" runat="server" onkeypress="return IsFloatText();" MaxLength="7"></asp:TextBox>元(單位:新台幣)
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <input id="add" type="button" value="確定" onclick="btnadd_Click()" />
                                <asp:Button ID="add_cancel" runat="server" Text="取消" OnClick="add_cancel_Click" />
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
            <asp:Panel ID="editPanel" runat="server" Visible="False">
            <table width=100% class="tableStyle99">
            <tr>
            <td class="htmltable_Title" colspan="4">
                勞保事故保險金額分級表-修改
            </td>
            </tr>
                       <tr>
                            <td class="htmltable_Left">
                                保險種類:
                            </td>
                            <td class="htmltable_Right">
                                 <uc1:ucSaCode ID="UcSaCode2" runat="server" Code_Kind="P" Code_sys="001" Code_type="005"
                                  ControlType="2" />
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                               <asp:Label ID="Label10" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                啟用年月:
                            </td>
                            <td class="htmltable_Right">
                                民國<asp:Label ID="YearMonth" runat="server" Text=""></asp:Label>
                                <asp:Label ID="edtYM4Edit" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                               <asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                投保金額等級
                            </td>
                            <td class="htmltable_Right">
                                <asp:Label ID="level" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                               <asp:Label ID="Label6" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                月薪資所得上限
                            </td>
                            <td class="htmltable_Right">
                                <asp:TextBox ID="txt_up" runat="server" MaxLength="7" onkeypress="return IsFloatText();" ></asp:TextBox >元(單位:新台幣)
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                               <asp:Label ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                月薪資所得下限
                            </td>
                            <td class="htmltable_Right">
                                <asp:TextBox ID="txt_low" runat="server" MaxLength="7" onkeypress="return IsFloatText();" ></asp:TextBox>元(單位:新台幣)
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                1日(投保日數)自負擔金額
                            </td>
                            <td class="htmltable_Right">
                                <asp:TextBox ID="txt_dct1" runat="server" MaxLength="7" onkeypress="return IsFloatText();" ></asp:TextBox>元(單位:新台幣)
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                30日(投保日數)自負擔金額
                            </td>
                            <td class="htmltable_Right">
                                <asp:TextBox ID="txt_dct30" runat="server" MaxLength="7" onkeypress="return IsFloatText();" ></asp:TextBox>元(單位:新台幣)
                            </td>
                        </tr>
                         <tr>
                            <td class="htmltable_Left">
                               <asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                保險金額
                            </td>
                            <td class="htmltable_Right">
                                <asp:TextBox ID="TextBox1" runat="server" onkeypress="return IsFloatText();" 
                                    MaxLength="7"></asp:TextBox>元(單位:新台幣)
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                自負擔
                            </td>
                            <td class="htmltable_Right">
                                <asp:TextBox ID="TextBox2" runat="server" onkeypress="return IsFloatText();" 
                                    MaxLength="7"></asp:TextBox>元(單位:新台幣)
                            </td>
                        </tr>
                        <tr>
                            <td class="htmltable_Left">
                                機關負擔
                            </td>
                            <td class="htmltable_Right">
                                <asp:TextBox ID="TextBox3" runat="server" onkeypress="return IsFloatText();" 
                                    MaxLength="7"></asp:TextBox>元(單位:新台幣)
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <input id="edit" type="button" value="確定" onclick="btnedit_Click()"  />
                                <asp:Button ID="edit_cancel" runat="server" Text="取消" OnClick="edit_cancel_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <table width=100% id="view" runat="server" visible="false" class="tableStyle99">
                <tr>
                <td class="htmltable_Title2" style="width: 100%" align="center">
                查詢結果
                </td>
                </tr>
                <tr>
                <td>                
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                    OnRowCommand="GridView1_RowCommand1" Width="100%" CssClass="Grid" 
                        AllowPaging="True" PageSize="30" 
                        onpageindexchanged="GridView1_PageIndexChanged" 
                        onpageindexchanging="GridView1_PageIndexChanging">
                            <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                查無資料!!
                            </EmptyDataTemplate>
                    <Columns>
                        <asp:BoundField DataField="data_no" HeaderText="項次" />
                        <asp:BoundField DataField="stws_level" HeaderText="投保金額等級" />
                        <asp:BoundField DataField="stws_up" HeaderText="月薪資所得上限" />
                        <asp:BoundField DataField="stws_low" HeaderText="月薪資所得下限" />
                        <asp:BoundField DataField="stws_stand" HeaderText="保險金額" />
                        <asp:BoundField DataField="stws_dct1" HeaderText="1日" />
                        <asp:BoundField DataField="stws_dct2" HeaderText="30日" />                     
                        <asp:BoundField DataField="STWS_DCT" HeaderText="自負擔" />
                        <asp:BoundField DataField="STWS_SUP" HeaderText="機關負擔" />
                        <asp:BoundField DataField="stws_ym" ReadOnly="True" HeaderText="年月" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="update" runat="server" Text="修改" CommandName="doupdate" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                <input id="delete" type="button" value="刪除" onclick="btnDelete_Click('<%#((GridViewRow)Container).RowIndex%>')" />
                            </ItemTemplate>
                        </asp:TemplateField>  
                        <asp:BoundField DataField="stws_no" ReadOnly="True" HeaderText="保險種類" />              
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" />
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <PagerSettings Position="TopAndBottom" />                 
                </asp:GridView>             
                </td></tr>
                <tr><td align="right">
                     <uc4:UcPager ID="UcPager" runat="server" GridName="GridView1" 
                  Visible="False" PSize="30" PNow="1" />
                </td></tr>
                </table>            

       
    <div style="visibility: hidden">
        <asp:Button ID="add_submit" runat="server" Text="確定新增" OnClick="add_submit_Click" />
        <asp:Button ID="edit_submit" runat="server" Text="確定儲存" OnClick="edit_submit_Click" />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click">
        </asp:Button>
        <input id="txtFuncParam" type="hidden" name="txtFuncParam" runat="server"/>
    </div>
    <!--</ContentTemplate>
    </asp:UpdatePanel>-->
</asp:Content>
