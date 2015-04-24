<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="SAL3104_01.aspx.cs" Inherits="SAL_SAL3_SAL3104" EnableEventValidation="false"%>

<%@ Register Src="../../UControl/SAL/ucSaProj.ascx" TagName="ucSaProj" TagPrefix="uc2" %>
<%@ Register Src="../../UControl/SAL/ucSaCode.ascx" TagName="ucSaCode" TagPrefix="uc3" %>
<%@ Register Src="../../UControl/UcDDLDepart.ascx" TagName="UcDDLDepart" TagPrefix="uc8" %>
<%@ Register Src="~/UControl/UcDDLMember.ascx" TagPrefix="uc2" TagName="UcDDLMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        function IsFloatText() {
            var charkc = window.event.keyCode
            if (charkc == 46 || (charkc >= 48 && charkc <= 57)) {
                return true;
            }
            return false;
        }
    </script>
    <asp:Panel ID="pnlInput" runat="server">
    <table class="tableStyle99" width="100%">
        <tr>
            <td class="htmltable_Title" colspan="4">
                各類補發代扣資料維護
            </td>
        </tr>
        <!--<tr>
                    <td colspan="4">每頁顯示<asp:DropDownList ID="cmbPageItems" runat="server">
                    </asp:DropDownList>
                    </td>
                </tr>-->
        <tr>
            <td class="htmltable_Left" width="15%">
                員工類別
            </td>
            <td class="htmltable_Right" width="35%">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <uc3:ucSaCode ID="cmb_uc_EmployeeType" runat="server" Code_Kind="P" Code_sys="002"
                            Code_type="017" ControlType="2" Mode="query" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="htmltable_Left" width="15%">
                依批號查詢
            </td>
            <td class="htmltable_Right" width="35%">
                <asp:TextBox ID="edtBatchNo" runat="server" MaxLength="11"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" width="15%">
                是否隨薪發放
            </td>
            <td class="htmltable_Right" width="35%">
                <asp:DropDownList ID="cmbPaywithSalary" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbPaywithSalary_SelectedIndexChanged">
                <asp:ListItem Value="N">不隨薪</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="htmltable_Left" width="15%">
                發放方式
            </td>
            <td class="htmltable_Right" width="35%">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbPayMethod" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbPayMethod_SelectedIndexChanged">
                            <asp:ListItem Value="001">應發款</asp:ListItem>
                            <asp:ListItem Value="002">應扣款</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="htmltable_Left" width="15%">
                項目類別
            </td>
            <td class="htmltable_Right" width="35%">
                <asp:UpdatePanel ID="uPnlItemType" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <uc3:ucSaCode ID="cmb_uc_SalItemType" runat="server" Code_Kind="D" Code_sys="005"
                            ControlType="2" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="htmltable_Left" width="15%">
                項目名稱
            </td>
            <td class="htmltable_Right" width="35%">
                <asp:UpdatePanel ID="uPnlItemNeme" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbSalItemName" runat="server">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
        <td class="htmltable_Left" >
            在職狀態
        </td>
        <td class="htmltable_Right">
                <asp:DropDownList ID="DropDownList_base_edate" runat="server">
                    <asp:ListItem Value="0" Text="全部"></asp:ListItem>
                    <asp:ListItem Value="1" Text="在職" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="2" Text="已離職"></asp:ListItem>
                    <asp:ListItem Value="3" Text="已退休"></asp:ListItem>
                </asp:DropDownList>
        </td>
        <td class="htmltable_Left" >
        單位名稱
        </td>
        <td class="htmltable_Right" >
            <uc8:UcDDLDepart ID="cmbDepartID" runat="server" />     
            <uc2:UcDDLMember runat="server" ID="ddlName" />          
        </td>

        </tr>
        <tr>
            <td class="htmltable_Bottom" colspan="4" style="border-top: none;" width="50%">
                <asp:Button ID="btnQuery" runat="server" Text="查詢" OnClick="btnQuery_Click" />
                <asp:Button ID="btnNew" runat="server" Text="新增查詢" OnClick="btnNew_Click" />
                <asp:Button ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" Visible="False" 
                 />
            </td>
        </tr>
        <tr>
            <td colspan="4">
            </td>
        </tr>
    </table>
    </asp:Panel>

    <!--Data-->
    <asp:Panel ID="pnlQuery" runat="server" Visible="false">
        <table class="tableStyle99" width="100%">
            <tr runat="server" id="tr_query_result">
                <td class="htmltable_Title2" colspan="4">
                    查詢結果
                </td>
            </tr>
            <tr runat="server" id="tr_newadd" visible="false">
                <td class="htmltable_Title" colspan="4">
                    各類補發代扣維護－新增
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="uPnlGrids" runat="server" UpdateMode="Conditional">
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnNewFinish"></asp:PostBackTrigger>
                             <asp:PostBackTrigger ControlID="btnOK"></asp:PostBackTrigger>
                             <asp:PostBackTrigger ControlID="btnShowDetailFinish"></asp:PostBackTrigger>
                             <asp:PostBackTrigger ControlID="btnBack"></asp:PostBackTrigger>
                        </Triggers>
                        <ContentTemplate>
                            <asp:Panel ID="pnlResult" runat="server">
                                <table width="100%"><tr><td>
                                <asp:Button ID="btnOK" runat="server" Text="確定" onclick="Button1_Click" 
                                        Visible="False"/>                                
                                </td></tr>
                                <tr><td>
                                <asp:GridView ID="gvResult" runat="server" Width="100%" AutoGenerateColumns="False"
                                    EnableModelValidation="True" OnRowCommand="gvResult_RowCommand" 
                                        CssClass="Grid" AllowPaging="True" 
                                        onpageindexchanging="gvResult_PageIndexChanging" PageSize="30">
                                    <Columns>
                                        <asp:BoundField DataField="PAYITEM_Merge_flow_id" HeaderText="批號" />
                                        <asp:BoundField HeaderText="項目" DataField="ItemName" />
                                        <asp:BoundField HeaderText="預算來源" DataField="BudgeSource" />
                                        <asp:BoundField DataField="sum_PAYITEM_Pay_amt" HeaderText="金額" />
                                        <asp:TemplateField HeaderText="明細">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="AddButton" runat="server" CommandName="ShowDetail" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    Text="明細資料" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
                                </td></tr>
                                <tr><td align="right">
                                 <uc1:Ucpager ID="Ucpager2" runat="server" GridName="gvResult" PNow="1" 
                                        PSize="30" />
                                </td></tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnlDetail" runat="server" Visible="False">
                                <table class="tableStyle99" width="100%">
                                    <tr>
                                        <td colspan="4" style="border-top: none;" width="50%">
                                            <asp:Button ID="btnShowDetailFinish" runat="server" Text="確定" OnClick="btnShowDetailFinish_Click"
                                                Visible="False" />
                                            <asp:Button ID="btnNewFinish" runat="server" Text="確定" OnClick="btnNewFinish_Click"
                                                Visible="False" />
                                            <asp:Button ID="btnBack" runat="server" Text="回上頁" onclick="btnBack_Click" />
                                            <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                                                EnableModelValidation="True" Width="100%" OnRowCommand="gvDetail_RowCommand"
                                                AllowPaging="True" OnPageIndexChanged="gvDetail_PageIndexChanged" OnPageIndexChanging="gvDetail_PageIndexChanging"
                                                OnRowDataBound="gvDetail_RowDataBound" PageSize="30">
                                                <Columns>
                                                    <asp:BoundField DataField="PAYITEM_Merge_flow_id" HeaderText="批號" />
                                                    <asp:BoundField DataField="DeptName" HeaderText="科室" />
                                                    <asp:BoundField DataField="base_name" HeaderText="姓名" />
                                                    <asp:BoundField DataField="ItemName" HeaderText="項目" />
                                                    <asp:TemplateField HeaderText="預算來源">
                                                        <ItemTemplate>
                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>
                                                                    <uc3:ucSaCode ID="cmb_uc_BudgeSource" runat="server" Code_Kind="P" Code_sys="002"
                                                                        Code_type="018" ControlType="2" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="金額">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="edtAmount" Text='<%# DataBinder.Eval(Container.DataItem, "PAYITEM_Pay_amt") %>'
                                                                onkeypress="return IsFloatText();"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="base_orgid" />
                                                    <asp:BoundField DataField="base_seqno" />
                                                    <asp:BoundField DataField="code_sys" />
                                                    <asp:BoundField DataField="code_kind" />
                                                    <asp:BoundField DataField="code_type" />
                                                    <asp:BoundField DataField="code_no" />
                                                    <asp:BoundField DataField="code" />
                                                    <asp:BoundField DataField="PAYITEM_Flow_id" />
                 
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
                                    <tr>
                                        <td align="right" colspan="4">
                                            <uc1:Ucpager ID="Ucpager1" runat="server" GridName="gvDetail" PNow="0" 
                                                PSize="30" />
                                        </td>
                                    </tr>
                                </table>
                            
                            </asp:Panel>
                            
 <asp:TextBox ID="Detilindex" runat="server" Visible="False"></asp:TextBox>
 <asp:TextBox ID="TxtDetailNew" runat="server" Visible="False"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>
