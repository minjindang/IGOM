<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/MasterPage/Mobile.master" AutoEventWireup="true" CodeFile="MOB0204_01.aspx.cs" Inherits="Mobile_MOB0_MOB0204_01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function Check(parentChk, ChildId) {

            var oElements = document.getElementsByTagName("INPUT");
            //     alert(oElements.length);  17

            for (i = 0; i < oElements.length; i++) {
       //         alert(oElements[i]);
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
function Button1_onclick() {

}

function Button1_onclick() {

}

    </script>
    <table width="100%">
        <tr>
            <td class="htmltable_Right">案件編號</td>
            <td class="htmltable_Right">
                <asp:TextBox ID="tbFlowId" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <table width="100%">
                    <tr>
                        <td width="33%">
                            <asp:Button runat="server" ID="cbQuery" Text="篩選" OnClick="cbQuery_Click"></asp:Button></td>
                        <td width="33%">
                         <!--   <input id="Button1" type="button" value="全選"
                                onclick="Check(true, 'gvcbx')"  />  -->
                            <asp:Button ID="check_all" runat="server" Text="全選" onclick="check_all_Click" />
                                </td>
                        <td>
                        <!--    <input id="Button2" type="button" value="全不選"
                                onclick="Check(false, 'gvcbx')" />  -->
                            <asp:Button ID="clean_all" runat="server" Text="全不選" 
                                onclick="clean_all_Click" />
                                </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="cbAgree" runat="server" Text="同意/確認"
                                 OnClick="cbAgree_Click" UseSubmitBehavior="false"/></td>
                        <td>
                            <asp:Button ID="cbNotAgree" runat="server" Text="退件"
                                OnClientClick="if(!confirm('是否確定退件？'))return false; blockUI()" /></td>
                        <td>
                            <asp:Button ID="cbBack" runat="server" Text="回上頁" OnClick="cbBack_Click" UseSubmitBehavior="false"/></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" Width="100%" PageSize="30" AllowPaging="True"
                    BorderWidth="0px" PagerStyle-HorizontalAlign="Right" AllowSorting="True" EnableModelValidation="True" ShowHeader="False" CellPadding="5" BorderStyle="None" GridLines="None">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="gvlbOrgcode" runat="server" Text='<%# Bind("Orgcode") %>' Visible="false"></asp:Label>
                                <asp:Label ID="gvlbFormId" runat="server" Text='<%# Bind("Form_id") %>' Visible="false"></asp:Label>
                                <asp:HiddenField ID="gvhfGroupId" runat="server" Value='<%# Bind("Group_id") %>'></asp:HiddenField>
                                <table width="100%" bgcolor="White" frame="box">

                                    <tr>
                                        <td align="center"  rowspan="13" valign="top">
                                            <asp:CheckBox ID="gvcbx" runat="server" Text="<%# Container.DataItemIndex+1 %>" />
                                            <asp:Label ID="gvlbNo" runat="server" Text='<%# Container.DataItemIndex+1 %>' Visible="false"></asp:Label>
                                        </td>
                                        <td width="60%">
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        表單編號：<asp:Label ID="gvlbFlowId" runat="server" Text='<%# Bind("Flow_id") %>' ForeColor="#0000CC"></asp:Label></td>
                                                    <td></td>

                                                </tr>
                                            </table>
                                            <!--表單編號-->
                                        </td>
                                        <td width="35%">
                                            <asp:Label ID="gvlbMergeFlag" runat="server" Text='<%# (Eval("Merge_flag").ToString() == "1" ? "*" : "") %>' ForeColor="#0000CC"></asp:Label>

                                        </td>
                                    </tr>
                                    <tr>
                                        
                                        <td colspan="2">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                    </tr>
                                    <tr>
                                       
                                        
                                        <td>
                                            <!-- 單位-->
                                            <asp:Label ID="gvlbDepartName" runat="server" Text='<%# Bind("Depart_name")%>' ForeColor="#0000CC"></asp:Label>
                                        </td>
                                        <td>
                                            <!-- 送件人 -->
                                            <asp:Label ID="gvlbApply_name" runat="server" Text='<%# Bind("Apply_name") %>' ForeColor="#0000CC"></asp:Label>
                                            <asp:HiddenField ID="gvhfApply_id" Value='<%# Bind("Apply_idcard") %>' runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        
                                        <td colspan="2">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <!--填單日期-->
                                        <td colspan="2">
                                            填單日期：<asp:Label ID="gvlbwrite_time" runat="server" Text='<%# Bind("write_time") %>' ForeColor="#0000CC"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        
                                        <td colspan="2">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <!-- 申請種類-->
                                        <td>
                                            申請種類：<asp:Label runat="server" ID="UcFormKind" Text='<%# Bind("type_name") %>'  ForeColor="#0000CC"/></td>
                                        <td>
                                            <asp:Label runat="server" ID="UcFormType" Text='<%# Bind("type_name_2") %>'  ForeColor="#0000CC"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        
                                        <td colspan="2">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <!--申請說明-->
                                        <td colspan="2" >
                                            申請說明：<asp:Label ID="gvlbReason" Text='<%# Bind("Reason")%>' runat="server" ForeColor="#0000CC"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        
                                        <td colspan="2">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <!--批核意見-->
                                        <td colspan="2" align="left">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        
                                        <td colspan="2">
                                            <div style="background: black; width: 100%; height: 1px"></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <!--預算來源-->
                                        <td colspan="2" align="left"">
                                            預算來源：<asp:Label ID="gvlbBudgetCode" Text='<%# Bind("Budget_code")%>' runat="server" ForeColor="#0000CC"></asp:Label>&nbsp;</td>
                                    </tr>
                                </table>


                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        無待批資料
                    </EmptyDataTemplate>
                    <PagerStyle HorizontalAlign="Right" />
                    <EmptyDataRowStyle CssClass="EmptyRow" />
                </asp:GridView>
            </td>
        </tr>
    </table>

</asp:Content>

