<%@ Page Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="FSC0101_02.aspx.vb" Inherits="FSC0101_02" %>

<%@ Register Src="~/UControl/SYS/UcAttach.ascx" TagPrefix="uc9" TagName="UcAttach" %>
<%@ Register Src="~/UControl/UcReason.ascx" TagPrefix="uc2" TagName="UcReason" %>
<%@ Register Src="~/UControl/SYS/UcFormKind.ascx" TagPrefix="uc3" TagName="UcFormKind" %>
<%@ Register Src="~/UControl/SYS/UcFormType.ascx" TagPrefix="uc4" TagName="UcFormType" %>
<%@ Register Src="~/UControl/UcDDLDepart.ascx" TagPrefix="uc5" TagName="UcDDLDepart" %>
<%@ Register Src="~/UControl/SYS/UcDDLForm.ascx" TagPrefix="uc6" TagName="UcDDLForm" %>
<%@ Register Src="~/UControl/UcDate.ascx" TagPrefix="uc7" TagName="UcDate" %>
<%@ Register Src="~/UControl/SYS/UcCustomNext.ascx" TagPrefix="uc8" TagName="UcCustomNext" %>
<%@ Register Src="~/UControl/SYS/UcComment.ascx" TagPrefix="uc10" TagName="UcComment" %>
<%@ Register Src="~/UControl/SYS/UcReword.ascx" TagPrefix="uc11" TagName="UcReword" %>
<%@ Register Src="~/UControl/SYS/UcFormReason.ascx" TagPrefix="uc10" TagName="UcFormReason" %>
<%@ Register Src="~/UControl/SYS/UcBudget.ascx" TagPrefix="uc12" TagName="UcBudget" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function Check(parentChk, ChildId) {
            var oElements = document.getElementsByTagName("INPUT");

            for (i = 0; i < oElements.length; i++) {
                if (IsCheckBox(oElements[i]) && IsMatch(oElements[i].id, ChildId)) {
                    oElements[i].checked = parentChk;
                }
            }
        }
        function IsMatch(id, ChildId) {
            var sPattern = '^ctl00_ContentPlaceHolder1_gv.*' + ChildId + '$';
            var oRegExp = new RegExp(sPattern);
            if (oRegExp.exec(id))
                return true;
            else
                return false;
        }
        function IsCheckBox(chk) {
            if (chk.type == 'checkbox') return true;
            else return false;
        }
        function IsCheckList() {
            var oElements = document.getElementsByTagName("INPUT");
            var b = false;
            for (i = 0; i < oElements.length; i++) {
                if (IsCheckBox(oElements[i]) && IsMatch(oElements[i].id, 'gvcbx')) {
                    if (oElements[i].checked)
                        b = true;
                }
            }

            if (!b) {
                alert('至少勾選一筆清單');
                return false;
            }
            return true;
        }
        function checkBack() {
            if (IsCheckList()) {

                if (!confirm('是否確定退件？')) {
                    return false;
                } else {
                    blockUI();
                    return true
                }
            }
            return false;
        }
    </script>
    <table width="100%" class="tableStyle99">
        <tr>
            <td class="htmltable_Title" colspan="2">收件匣-待辦/待核清單</td>
        </tr>
        <tr id="tr1" runat="server">
            <td class="htmltable_Left">申請項目</td>
            <td class="htmltable_Right">         
                <uc6:UcDDLForm runat="server" ID="UcDDLForm" />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlLeave_type" runat="server" AutoPostBack="true"  DataTextField="Leave_name" DataValueField="Leave_type" Visible="false" />
                        <asp:CheckBox ID="cbInterTravelFlag" runat="server" Text="使用國民旅遊卡" Visible="false" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr id="tr2" runat="server">
            <td class="htmltable_Left">案件編號</td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbFlowId" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr id="tr3" runat="server">
            <td class="htmltable_Left">派車使用日期</td>
            <td class="htmltable_Right">
                <uc7:UcDate runat="server" ID="UcDate" />
            </td>
        </tr>
        <tr>
            <td class="TdHeightLight" colspan="2">
                <div style="float: left">
                    <asp:button runat="server" id="cbQuery" Text="篩選" OnClick="cbQuery_Click"></asp:button>
                    <input id="Button1" type="button" value="全選" onclick="Check(true, 'gvcbx')" />
                    <input id="Button2" type="button" value="全不選" onclick="Check(false, 'gvcbx')" />
                    <asp:Button ID="cbAgree" runat="server" Text="確認" OnClientClick="blockUI()" OnClick="cbAgree_Click" />
                    <asp:Button ID="cbNotAgree" runat="server" Text="退件" OnClientClick="return checkBack()" OnClick="cbNotAgree_Click" />
                    <asp:Button ID="cbMerge" runat="server" Text="成批造冊" OnClick="cbMerge_Click" OnClientClick="blockUI()" Visible="false" />
                    <uc8:UcCustomNext runat="server" ID="UcCustomNext" OnClick="UcCustomNext_Click" Visible="false" />
                    <uc11:UcReword runat="server" id="UcReword" OnClick="UcReword_Click" Visible="false" />
                    <asp:Button ID="cbPrintRPT" runat="server" Text="印領清冊" OnClick="cbPrintRPT_Click" Visible="false" />
                    <uc12:UcBudget runat="server" id="UcBudget" OnClick="UcBudget_Click" Visible="false"/>
                </div>
                <div style="float: right">
                    <asp:Button ID="cbBack" runat="server" Text="返回收件匣" OnClick="cbBack_Click" />
                </div>
                <br />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Width="100%" PageSize="30" AllowPaging="true" OnSorting="gv_Sorting"
                    CssClass="Grid" BorderWidth="0px" PagerStyle-HorizontalAlign="Right" AllowSorting="true" OnRowDataBound="gv_RowDataBound" >
                    <Columns>
                        <asp:TemplateField HeaderText="項次">
                            <ItemStyle Width="20px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="20px" />
                            <ItemTemplate>
                                <asp:Label ID="gvlbNo" runat="server" Text='<%# Container.DataItemIndex+1 %>' ></asp:Label>
                                <asp:Label ID="gvlbOrgcode" runat="server" Text='<%# Bind("Orgcode") %>' Visible="false"></asp:Label>
                                <asp:Label ID="gvlbFormId" runat="server" Text='<%# Bind("Form_id") %>' Visible="false" ></asp:Label>
                                <asp:hiddenfield ID="gvhfGroupId" runat="server" Value='<%# Bind("Group_id") %>' ></asp:hiddenfield>
                                <asp:hiddenfield ID="gvhfNextStep" runat="server" Value='<%# Bind("Next_step")%>' ></asp:hiddenfield>
                                <asp:hiddenfield ID="gvhfBudgetCode" runat="server" Value='<%# Bind("Budget_code")%>' ></asp:hiddenfield>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="選取">
                            <ItemStyle Width="20px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="20px" />
                            <ItemTemplate>
                                <asp:CheckBox ID="gvcbx" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="表單編號" SortExpression="Flow_id" >
                              <ItemStyle Width="20px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="20px" />
                            <ItemTemplate>
                                <asp:Label ID="gvlbFlowId" runat="server"  Text='<%# Bind("Flow_id") %>' ></asp:Label>
                                <asp:Label ID="gvlbMergeFlag" runat="server" Text='<%# IIf(Eval("Merge_flag").ToString() = "1", "*", "")%>' ForeColor="red"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="單位" SortExpression="depart_id" >
                            <ItemStyle Width="40px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="40px" />
                            <ItemTemplate>
                                <asp:Label ID="gvlbDepartName" runat="server" Text='<%# Bind("Depart_name")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="申請人" SortExpression="Apply_idcard" >
                            <ItemStyle Width="40px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="40px" />
                            <ItemTemplate>
                                <asp:Label ID="gvlbApply_name" runat="server" Text='<%# Bind("Apply_name") %>'></asp:Label>
                                <asp:HiddenField ID="gvhfApply_id" Value='<%# Bind("Apply_idcard") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="填單日期" SortExpression="write_time" >
                            <ItemStyle Width="35px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="35px" />
                            <ItemTemplate>
                                <asp:Label ID="gvlbwrite_time" runat="server" Text='<%# Bind("write_time") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="申請種類">
                            <ItemStyle Width="60px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="60px" />
                            <ItemTemplate>
                                <uc3:UcFormKind runat="server" ID="UcFormKind" FormId='<%# Bind("Form_id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="表單名稱" SortExpression="Form_id" >
                            <ItemStyle Width="60px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="60px" />
                            <ItemTemplate>                                
                                <uc4:UcFormType runat="server" ID="UcFormType" Orgcode='<%# Bind("Orgcode") %>' FlowId='<%# Bind("Flow_id") %>' FormId='<%# Bind("Form_id") %>' NextStep='<%# Bind("Next_step") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="申請說明" >
                            <ItemStyle Width="320px" HorizontalAlign="left"/>
                            <ItemTemplate>
                                <uc10:UcFormReason runat="server" id="UcFormReason" Orgcode='<%# Bind("Orgcode") %>' FlowId='<%# Bind("Flow_id") %>' FormId='<%# Bind("Form_id") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="批核意見">
                            <ItemTemplate>                     
                                <uc10:UcComment runat="server" ID="gvUcComment" FormId='<%# Bind("Form_id") %>' />
                            </ItemTemplate>
                            <ItemStyle Width="110px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="110px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="附件">
                            <ItemStyle Width="30px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="30px" />
                            <ItemTemplate>
                                <uc9:UcAttach runat="server" ID="UcAttach" Flow_id='<%# Bind("Flow_id")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="預算來源" SortExpression="Budget_code" >
                            <ItemStyle Width="60px" HorizontalAlign="Center"/>
                            <HeaderStyle Width="60px" />
                            <ItemTemplate>
                                <asp:Label ID="gvlbBudgetCode" Text='<%# Bind("Budget_code_name")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        無待批資料
                    </EmptyDataTemplate>
                    <PagerStyle HorizontalAlign="Right" />
                    <RowStyle CssClass="Row" />
                    <AlternatingRowStyle CssClass="AlternatingRow" />
                    <EmptyDataRowStyle CssClass="EmptyRow" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc1:ucpager id="Ucpager" runat="server" enableviewstate="true" gridname="gv"
                                pnow="1" psize="30" />
           </td>
        </tr>
    </table>
</asp:Content>
