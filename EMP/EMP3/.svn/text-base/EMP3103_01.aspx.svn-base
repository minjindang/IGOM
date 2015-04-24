<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="EMP3103_01.aspx.cs" Inherits="EMP_EMP3_EMP3103_01" %>
<%@ Register Src="../../UControl/SAL/UcSelectOrg.ascx" TagName="UcSelectOrg" TagPrefix="uc2" %>
<%@ Register Src="../../UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc3" %>
<%@ Register src="../../UControl/UcDDLDepart.ascx" tagname="UcDDLDepart" tagprefix="uc4" %>
<%@ Register Src="../../UControl/UcDDLMember.ascx" TagPrefix="uc2" TagName="UcDDLMember" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <!--   <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:PostBackTrigger ControlID="btnQuery"></asp:PostBackTrigger>
        <asp:PostBackTrigger ControlID="btnExport"></asp:PostBackTrigger>
        <asp:PostBackTrigger ControlID="add_submit"></asp:PostBackTrigger>
        <asp:PostBackTrigger ControlID="edit_submit"></asp:PostBackTrigger>
        <asp:PostBackTrigger ControlID="btnDelete"></asp:PostBackTrigger>
    </Triggers>
    <ContentTemplate>-->
    
     
    <script language="javascript">
        function btnDelete_Click(SerialNO) {

            if (confirm("確定刪除?")) {
                document.getElementById("<%=lblSN.ClientID%>").value = SerialNO;
                document.getElementById("<%=btnDelete.ClientID%>").click();
            }
        }
        function btnedit_Click() {
            if (confirm("確定儲存?")) {
                document.getElementById("<%=edit_submit.ClientID%>").click();
            }
        }
        function btnadd_Click() {
            if (confirm("確定新增?")) {
                document.getElementById("<%=add_submit.ClientID%>").click();
            }
        }

        function getUserName() {
            document.getElementById("<%=btnGetUserName.ClientID%>").click();
        }
        function getUserName2() {
            document.getElementById("<%=btnGetUserName2.ClientID%>").click();
        }



    </script>
    <asp:Panel ID="pnlConditions" runat="server">
   <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">
                共用系統權限設定-依員工編號
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" width="15%">
                機關名稱
            </td>
            <td class="htmltable_Right" width="35%">
                <asp:DropDownList ID="cmb1stDept" runat="server" 
                    onselectedindexchanged="cmb1stDept_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td class="htmltable_Left" width="15%">
                單位名稱
            </td>
            <td class="htmltable_Right" width="35%">
                <uc4:UcDDLDepart ID="cmb_uc_org" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left">
                人員類別
            </td>
            <td class="htmltable_Right" style="width: 326px" colspan="3">
                <uc3:ucSaCode ID="cmb_uc_idtype" runat="server" Code_Kind="P" Code_sys="023" Code_type="022"
                    ControlType="2" Mode="query" />
            </td>
      <!--      <td class="htmltable_Left">
                員工編號
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="txtIDCard" runat="server" MaxLength="6"  onBlur="return getUserName();"></asp:TextBox>
                <asp:Label ID="lblUserName" runat="server"></asp:Label>
            </td>  -->

        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                <asp:Button ID="btnQuery" runat="server" Text="查詢" OnClick="btnQuery_Click"  />
                <asp:Button ID="btnNew" runat="server" Text="新增" OnClick="btnNew_Click" />
                <asp:Button ID="btnExport" runat="server" Text="匯出" onclick="btnExport_Click" />
            </td>
        </tr>
    </table>
    </asp:Panel>

     <asp:Panel ID="pnlModify" runat="server">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title" colspan="4">
                    共用系統權限設定-依員工編號-<asp:Label ID="lblMode" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Left" width="15%">
                    機關名稱
                </td>
                <td class="htmltable_Right" width="35%">
                    <asp:DropDownList ID="cmb1stDept4Edit" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="cmb1stDept4Edit_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="htmltable_Left" width="15%">
                    單位名稱
                </td>
                <td class="htmltable_Right" width="35%">
                    <uc4:UcDDLDepart ID="cmb_uc_org4Edit" runat="server" />
                </td>
            </tr>
            <tr>
            <td class="htmltable_Left">
            員工姓名
            </td>
            <td class="htmltable_Right" colspan="3">
               <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
              <uc2:UcDDLMember runat="server" ID="UcDDLMember" />
              </ContentTemplate></asp:UpdatePanel>
            </td>
            </tr>
       <!--     <tr>
                <td class="htmltable_Left">
                    人員類別
                </td>
                <td class="htmltable_Right" style="width: 326px">
                    <uc3:ucSaCode ID="cmb_uc_idtype4Edit" runat="server" Code_Kind="P" Code_sys="002"
                        Code_type="017" ControlType="2" />
                </td>
            <td class="htmltable_Left">
                員工編號
            </td>
            <td class="htmltable_Right">
                <asp:TextBox ID="txtIDCard4Edit" runat="server" MaxLength="6" onBlur="return getUserName2();"></asp:TextBox>
                <asp:Label ID="lblUserName2" runat="server"></asp:Label>
            </td>
            </tr>  -->
            <tr>
                <td class="htmltable_Left">
                    可使用的應用系統
                </td>
                <td class="htmltable_Right" style="width: 326px" colspan="3">
                    <table width="100%">
                        <tr>
                            <td width="45%">
                                應用系統選單<br />
                                     <asp:UpdatePanel ID="UpdatePane3" runat="server">
                                <ContentTemplate>
                                <asp:ListBox ID="lstUnSelect" runat="server" Width="100%" Rows="6" SelectionMode="Multiple">
                                </asp:ListBox>
                                </ContentTemplate></asp:UpdatePanel>
                            </td>
                            <td valign="middle" align="center">
                                <asp:Button ID="btnSelectFun" runat="server" Text="選擇 >" OnClick="btnSelectFun_Click" /><br />
                                <asp:Button ID="btnRemoveFun" runat="server" Text="< 移除" OnClick="btnRemoveFun_Click" />
                            </td>
                            <td width="45%">
                                可使用的應用系統<br />
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                       
                                <asp:ListBox ID="lstSelect" runat="server" Width="100%" Rows="6" SelectionMode="Multiple">
                                </asp:ListBox>
                                         
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                    <input id="btnAddOK" type="button" value="確定" runat="server" onclick="btnadd_Click()" />
                    <input id="btnEditOK" type="button" value="確定" runat="server" onclick="btnedit_Click()" />
                    <asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" Text="取消" />
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlresult" runat="server" Width="100%">
        <table class="tableStyle99" width="100%">
            <tr>
                <td class="htmltable_Title2" colspan="4">
                    查詢結果
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="gvResult" runat="server" Width="100%" AutoGenerateColumns="False"
                        EnableModelValidation="True" OnRowCommand="gvResult_RowCommand" 
                        CssClass="Grid" AllowPaging="True" ondatabinding="gvResult_DataBinding" 
                        ondatabound="gvResult_DataBound" onrowcreated="gvResult_RowCreated">
                        <Columns>
                            <asp:BoundField DataField="Depart_id" HeaderText="Depart_id" />
                            <asp:BoundField DataField="Share_id" HeaderText="Share_id" />
                            <asp:BoundField DataField="ID_CARD" HeaderText="ID_CARD" />
                            <asp:BoundField DataField="ID" HeaderText="項次" />
                            <asp:BoundField DataField="OrgName" HeaderText="機關名稱" />
                            <asp:BoundField DataField="DepartName" HeaderText="單位名稱" />
                            <asp:BoundField DataField="ShareName" HeaderText="人員類別" />
                            <asp:BoundField DataField="USER_NAME" HeaderText="人員姓名" />
                            <asp:BoundField DataField="SystemNames" HeaderText="可使用的應用系統" />
                            <asp:TemplateField HeaderText="維護">
                                <ItemTemplate>
                                    <asp:Button ID="update" runat="server" Text="維護" CommandName="doupdate" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                    <input id="delete" type="button" value="刪除" onclick="btnDelete_Click('<%#((GridViewRow)Container).RowIndex%>')" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="Row" />
                        <AlternatingRowStyle CssClass="AlternatingRow" />
                        <PagerSettings Position="TopAndBottom" Visible="False" />
                        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                查無資料!!
                            </EmptyDataTemplate>            
                    </asp:GridView>
                
                  </td>
               </tr>  
               <tr><td align="right">
                      <uc1:Ucpager ID="Ucpager1" runat="server" GridName="gvResult" PNow="1" 
                        PSize="10" />
               </td>
               </tr>
        </table>
    </asp:Panel>

    <div style="visibility: hidden">
        <asp:Button ID="add_submit" runat="server" Text="確定新增" OnClick="add_submit_Click" />
        <asp:Button ID="edit_submit" runat="server" Text="確定修改" OnClick="edit_submit_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="刪除" OnClick="btnDelete_Click" />
        <asp:TextBox ID="lblSN" runat="server"></asp:TextBox>
        <asp:Button ID="btnGetUserName" 
            runat="server" Text="取得人名" onclick="btnGetUserName_Click" />
            <asp:Button ID="btnGetUserName2" 
            runat="server" Text="取得人名" onclick="btnGetUserName2_Click" />
            <asp:TextBox runat="server" ID="mode"></asp:TextBox>
    </div>
<!--  </ContentTemplate>
    </asp:UpdatePanel>-->
</asp:Content>

