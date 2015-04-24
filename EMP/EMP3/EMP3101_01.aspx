<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="EMP3101_01.aspx.cs" Inherits="EMP_EMP3_EMP3101_01" %>

<%@ Register Src="../../UControl/SAL/UcSelectOrg.ascx" TagName="UcSelectOrg" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnQuery"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="Button_report"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="add_submit"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="edit_submit"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="btnSubmit"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="btnOK"></asp:PostBackTrigger>
        </Triggers>
        <ContentTemplate>
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
                        document.getElementById("<%=add_submit.ClientID%>").click();
                    }
                }

                function getUserName() {
                    document.getElementById("<%=btnGetUserName.ClientID%>").click();
                }
            </script>
            <asp:Panel ID="pnlInput" runat="server">
                <table class="tableStyle99" width="100%">
                    <tr>
                        <td class="htmltable_Title" colspan="4">
                            應用系統設定
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" width="15%">
                            機關名稱
                        </td>
                        <td class="htmltable_Right" width="35%">
                            <asp:DropDownList ID="cmb1stDept" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td class="htmltable_Left" width="15%">
                            應用系統名稱
                        </td>
                        <td class="htmltable_Right" width="35%">
                            <asp:DropDownList ID="cmbSystemNames" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left">
                            是否啟用
                        </td>
                        <td class="htmltable_Right" style="width: 326px" colspan="3">
                            <asp:CheckBox ID="chkActive" runat="server" Text="是" />
                            <asp:CheckBox ID="chkDisable" runat="server" Text="否" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                            <asp:Button ID="btnQuery" runat="server" Text="查詢" OnClick="btnQuery_Click" />
                            <asp:Button ID="btnNew" runat="server" Text="新增" OnClick="btnNew_Click" />
                            <asp:Button ID="Button_report" runat="server" Text="匯出" OnClick="Button_report_Click" />
                            <asp:Label ID="mode" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlQuery" runat="server" Visible="False">
                <table class="tableStyle99" width="100%">
                    <tr>
                        <td class="htmltable_Title2" colspan="4">
                            查詢結果
                        </td>
                    </tr>
                    <!--<tr>
                        <td colspan="4">
                            <asp:Button ID="btnQueryBack" runat="server" Text="確定" 
                                onclick="Button1_Click" /></td>
                    </tr>-->
                    <tr>
                        <td colspan="4">
                            <asp:GridView ID="gvResult" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                                OnRowCommand="gvResult_RowCommand" CssClass="Grid" Width="100%" AllowPaging="True"
                                OnDataBinding="gvResult_DataBinding" OnDataBound="gvResult_DataBound" 
                                onpageindexchanging="gvResult_PageIndexChanging" 
                                onselectedindexchanged="gvResult_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="OrgCode" HeaderText="OrgCode" />
                                    <asp:BoundField DataField="AP_NAME" HeaderText="AP_NAME" />
                                    <asp:BoundField DataField="Is_active_flag" HeaderText="Is_active_flag" HtmlEncode="False" />
                                    <asp:BoundField DataField="NOTE_DESC" HeaderText="NOTE_DESC" HtmlEncode="False" />
                                    <asp:BoundField DataField="ID" HeaderText="項次" />
                                    <asp:BoundField DataField="DeptName" HeaderText="機關名稱" />
                                    <asp:BoundField DataField="System_Name" HeaderText="應用系統名稱" />
                                    <asp:BoundField DataField="System_code" HeaderText="應用系統代碼" />
                                    <asp:BoundField DataField="Server_ip" HeaderText="伺服器位址" />
                                    <asp:BoundField DataField="Web_URL" HeaderText="應用系統網址" />
                                    <asp:BoundField DataField="isActiveDisplay" HeaderText="啟用" />
                                    <asp:TemplateField HeaderText="維護">
                                        <ItemTemplate>
                                            <asp:Button ID="update" runat="server" Text="維護" CommandName="doupdate" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                            <input id="delete" type="button" value="刪除" onclick="btnDelete_Click('<%#((GridViewRow)Container).RowIndex%>')" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle CssClass="Row" />
                                <AlternatingRowStyle CssClass="AlternatingRow" />
                                <PagerSettings Position="TopAndBottom" />
                                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                                <EmptyDataTemplate>查無資料</EmptyDataTemplate>
                            </asp:GridView>
                            <uc1:Ucpager ID="Ucpager1" runat="server" GridName="gvResult" PSize="30" 
                                PNow="1" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlNew" runat="server" Visible="False">
                <table class="tableStyle99" width="100%">
                    <tr>
                        <td class="htmltable_Title" colspan="4">
                            <asp:Label ID="Label1" runat="server" Text="應用系統設定"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" width="15%">
                            機關名稱
                        </td>
                        <td class="htmltable_Right" width="35%">
                            <asp:DropDownList ID="cmb1stDept4Edit" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td class="htmltable_Left" width="15%">
                            應用系統代碼
                        </td>
                        <td class="htmltable_Right" width="35%">
                            <asp:TextBox ID="txtSystemCode" runat="server" MaxLength="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" width="15%">
                            應用系統名稱
                        </td>
                        <td class="htmltable_Right" width="35%">
                            <asp:TextBox ID="txtsystemName" runat="server" Width="90%"></asp:TextBox>
                        </td>
                        <td class="htmltable_Left" width="15%">
                            伺服器位址
                        </td>
                        <td class="htmltable_Right" width="35%">
                            <asp:TextBox ID="txtServerIP" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" width="15%">
                            應用系統網址
                        </td>
                        <td class="htmltable_Right" width="35%">
                            <asp:TextBox ID="txtWebURL" runat="server" Width="90%"></asp:TextBox>
                        </td>
                        <td class="htmltable_Left" width="15%">
                            是否啟用
                        </td>
                        <td class="htmltable_Right" width="35%">
                            <asp:CheckBox ID="chkisActive" runat="server" Text="啟用" />
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" width="15%">
                            應用系統負責人
                        </td>
                        <td class="htmltable_Right" colspan="3">
                            <asp:TextBox ID="txtAPIdCard" runat="server" MaxLength="6"></asp:TextBox>
                            <asp:Label ID="labAPName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Left" width="15%">
                            備註
                        </td>
                        <td class="htmltable_Right" colspan="3">
                            <asp:TextBox ID="txtNoteDesc" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="htmltable_Bottom" colspan="4" style="border-top: none;">
                            <asp:Button ID="btnOK" runat="server" Text="確定" OnClick="btnOK_Click1" Visible="False" />
                            <asp:Label ID="lblID" runat="server" cancel="" Visible="False"></asp:Label>
                            <input id="btnAddOK" type="button" value="確定" runat="server" onclick="btnadd_Click()" />
                            <input id="btnEditOK" type="button" value="確定" runat="server" onclick="btnedit_Click()" />
                            <asp:Button ID="cancel" runat="server" Text="取消" OnClick="cancel_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <div style="visibility: hidden">
                <asp:Button ID="add_submit" runat="server" Text="確定新增" OnClick="add_submit_Click" />
                <asp:Button ID="edit_submit" runat="server" Text="確定儲存" OnClick="edit_submit_Click" />
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click">
                </asp:Button><asp:Button ID="btnGetUserName" runat="server" Text="取得人名" OnClick="btnGetUserName_Click" />
                <input id="txtFuncParam" type="hidden" name="txtFuncParam" runat="server">
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
